Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.ServiceProcess
Imports System.Threading

Public Class clsData
    Private m_Server As String
    Private m_LocalServer As String
    Private cn As SqlConnection
    Private localcn As SqlConnection

    Public Property Server() As String
        Get
            Return m_Server
        End Get
        Set(ByVal value As String)
            m_Server = value
        End Set
    End Property
    Public Property LocalServer As String
        Get
            Return m_LocalServer
        End Get
        Set(value As String)
            m_LocalServer = value
        End Set
    End Property

    Public Function MakeConnection(ByRef sError As String) As Boolean
        sError = ""
        Try

            cn = New SqlConnection
            'cn.ConnectionString = "data source=" & m_Server & ";initial catalog=AssessmentManagerData;Integrated Security=SSPI;connect timeout=30"
            cn.ConnectionString = "data source=" & m_Server & ";initial catalog=AssessmentManagerData;connect timeout=30;user id=vantageapp;password=vantage2012"
            cn.Open()
            ExecuteSQL("set arithabort on")

            Return True
        Catch ex As Exception
            sError = "Error logging in:  Error = " & ex.Message
            Return False
        End Try
    End Function
    Public Function MakeLocalConnection(ByRef sError As String) As Boolean
        sError = ""
        Try
            localcn = New SqlConnection
            localcn.ConnectionString = "data source=" & m_LocalServer & ";initial catalog=AssessmentManagerLocalData;Integrated Security=SSPI;connect timeout=15"
            localcn.Open()
            Return True
        Catch ex As Exception
            sError = "Error logging in:  Error = " & ex.Message
            Return False
        End Try
    End Function

    Public Sub CloseConnection()
        Try
            cn.Close()
            localcn.Close()
            'BackupDatabase()
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetData(ByVal sSQL As String, ByRef dt As DataTable) As Long
        Dim lRows As Long = -1
        dt = New DataTable
        If cn.State = ConnectionState.Open Then
        Else
            MakeConnection("")
        End If
        Dim i As Integer = 0
        'retry once
        For i = 0 To 1
            Try
                Using adapter As New SqlDataAdapter()
                    Dim ds As New DataSet
                    adapter.SelectCommand = New SqlCommand(sSQL, cn)
                    adapter.SelectCommand.CommandTimeout = 300
                    adapter.Fill(ds)
                    dt = ds.Tables(0)
                    lRows = dt.Rows.Count
                End Using
            Catch ex As Exception
                MakeConnection("")
            End Try
            If lRows > -1 Then Exit For
        Next
        Return lRows
    End Function
    Public Function GetLocalData(ByVal sSQL As String, ByRef dt As DataTable) As Long
        Dim lRows As Long = -1
        dt = New DataTable
        If localcn.State = ConnectionState.Open Then
        Else
            MakeLocalConnection("")
        End If
        Dim i As Integer = 0
        'retry once
        For i = 0 To 1
            Try
                Using adapter As New SqlDataAdapter()
                    Dim ds As New DataSet
                    adapter.SelectCommand = New SqlCommand(sSQL, localcn)
                    adapter.SelectCommand.CommandTimeout = 300
                    adapter.Fill(ds)
                    dt = ds.Tables(0)
                    lRows = dt.Rows.Count
                End Using
            Catch ex As Exception
                MakeLocalConnection("")
            End Try
            If lRows > -1 Then Exit For
        Next
        Return lRows
    End Function

    Public Function GetDataset(ByVal sSQL As String) As DataSet
        If cn.State = ConnectionState.Open Then
        Else
            MakeConnection("")
        End If
        Using adapter As New SqlDataAdapter()
            Dim ds As New DataSet
            adapter.SelectCommand = New SqlCommand(sSQL, cn)
            adapter.Fill(ds)
            Return ds
        End Using
    End Function

    Public Function ExecuteSQL(ByVal sSQL As String) As Long
        If cn.State = ConnectionState.Open Then
        Else
            MakeConnection("")
        End If
        Dim command As SqlCommand = New SqlCommand(sSQL, cn)
        command.CommandTimeout = 300
        Return command.ExecuteNonQuery()
    End Function
    Public Function ExecuteLocalSQL(ByVal sSQL As String) As Long
        If localcn.State = ConnectionState.Open Then
        Else
            MakeLocalConnection("")
        End If
        Dim command As SqlCommand = New SqlCommand(sSQL, localcn)
        command.CommandTimeout = 300
        Return command.ExecuteNonQuery()
    End Function

    Public Function QuoStr(ByVal sIn As String, Optional ByVal lLength As Long = 0) As String
        Return Chr(39) & IIf(lLength > 0, Microsoft.VisualBasic.Left(Trim(Replace(sIn, Chr(39), Chr(39) & Chr(39))), lLength), Trim(Replace(sIn, Chr(39), Chr(39) & Chr(39)))) & Chr(39)
    End Function

    Public Function GetAssetList(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal lFactoringEntityId As Long,
            ByVal bNeedFactoredAmounts As Boolean, ByVal bNeedFactoringEntityNames As Boolean, ByVal bNeedTotalValues As Boolean, ByVal bNeedTotalOriginalCost As Boolean,
            ByVal bNeedDetail As Boolean, ByVal bAccrual As Boolean, ByVal bNeedFixedAndInv As Boolean) As DataSet
        Dim cmd As SqlCommand = New SqlCommand("spGetAssetList", cn)
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@ClientId", SqlDbType.BigInt, 8)
        cmd.Parameters("@ClientId").Value = lClientId
        cmd.Parameters.Add("@LocationId", SqlDbType.BigInt, 8)
        cmd.Parameters("@LocationId").Value = lLocationId
        cmd.Parameters.Add("@AssessmentId", SqlDbType.BigInt, 8)
        cmd.Parameters("@AssessmentId").Value = lAssessmentId
        cmd.Parameters.Add("@TaxYear", SqlDbType.BigInt, 8)
        cmd.Parameters("@TaxYear").Value = iTaxYear
        cmd.Parameters.Add("@FactorEntityId", SqlDbType.BigInt, 8)
        cmd.Parameters("@FactorEntityId").Value = lFactoringEntityId
        cmd.Parameters.Add("@NeedFactoredAmounts", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedFactoredAmounts").Value = IIf(bNeedFactoredAmounts, "1", "0")
        cmd.Parameters.Add("@NeedFactoringEntityNames", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedFactoringEntityNames").Value = IIf(bNeedFactoringEntityNames, "1", "0")
        cmd.Parameters.Add("@NeedTotalValues", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedTotalValues").Value = IIf(bNeedTotalValues, "1", "0")
        cmd.Parameters.Add("@NeedTotalOriginalCost", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedTotalOriginalCost").Value = IIf(bNeedTotalOriginalCost, "1", "0")
        cmd.Parameters.Add("@NeedDetail", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedDetail").Value = IIf(bNeedDetail, "1", "0")
        cmd.Parameters.Add("@Accrual", SqlDbType.TinyInt, 4)
        cmd.Parameters("@Accrual").Value = IIf(bAccrual, "1", "0")
        cmd.Parameters.Add("@NeedFixedAndInv", SqlDbType.TinyInt, 4)
        cmd.Parameters("@NeedFixedAndInv").Value = IIf(bNeedFixedAndInv, "1", "0")

        Dim parm As System.Data.SqlClient.SqlParameter

        Debug.WriteLine(cmd.CommandText)
        For Each parm In cmd.Parameters
            Debug.WriteLine(parm.ParameterName & "=" & parm.Value & ",")
        Next
        Debug.WriteLine("")

        Dim adapter As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        For Each dt As DataTable In ds.Tables
            dt.TableName = dt.Columns(0).ColumnName
        Next

        Return ds
    End Function


    Public Function StoreStateFormBLOB(ByVal sFile As String, ByVal lFormId As Long, ByVal iTaxYear As Integer, _
            ByVal sStateCd As String, ByVal sFormName As String, ByVal sFormDescription As String, ByVal sUserId As String) As Boolean

        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read)
        Dim bloblen As Integer = CInt(fs.Length)
        Dim BLOB(bloblen) As Byte
        Dim sSQL As String

        sSQL = "DELETE StateFormsXRef FROM StateFormsXRef x, StateForms s" & _
            " WHERE x.FormId = s.FormId AND x.TaxYear = s.TaxYear" & _
            " AND s.FormName = " & QuoStr(sFormName) & " And s.StateCd = " & QuoStr(sStateCd) & _
            " AND s.TaxYear = " & iTaxYear
        ExecuteSQL(sSQL)
        sSQL = "DELETE StateForms WHERE FormName = " & QuoStr(sFormName) & " AND StateCd = " & QuoStr(sStateCd) & _
            " AND TaxYear = " & iTaxYear
        ExecuteSQL(sSQL)

        fs.Read(BLOB, 0, bloblen)
        fs.Close()
        sSQL = "INSERT StateForms (FormId, TaxYear,StateCd,FormName,FormDescription,FormData,AddUser)" & _
            " VALUES (@formid,@taxyear,@statecd,@formname,@formdescription,@formdata,@adduser)"
        Dim cmd As SqlCommand = New SqlCommand(sSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@formid", SqlDbType.BigInt)
        cmd.Parameters("@formid").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@taxyear", SqlDbType.SmallInt)
        cmd.Parameters("@taxyear").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@statecd", SqlDbType.VarChar)
        cmd.Parameters("@statecd").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formname", SqlDbType.VarChar)
        cmd.Parameters("@formname").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formdescription", SqlDbType.VarChar)
        cmd.Parameters("@formdescription").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@addUser", SqlDbType.VarChar)
        cmd.Parameters("@addUser").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formdata", SqlDbType.Image)
        cmd.Parameters("@formdata").Direction = ParameterDirection.Input


        cmd.Parameters("@formid").Value = lFormId
        cmd.Parameters("@taxyear").Value = iTaxYear
        cmd.Parameters("@statecd").Value = sStateCd
        cmd.Parameters("@formname").Value = sFormName
        cmd.Parameters("@formdescription").Value = sFormDescription
        cmd.Parameters("@adduser").Value = sUserId
        ' Store the byte array in the image field
        cmd.Parameters("@formdata").Value = BLOB
        cmd.ExecuteNonQuery()

        Return True
    End Function

    Public Function StoreClientFormBLOB(ByVal sFile As String, ByVal lFormId As Long, ByVal lClientId As Long, _
            ByVal iTaxYear As Integer, _
            ByVal sStateCd As String, ByVal sFormName As String, ByVal sFormDescription As String, ByVal sUserId As String) As Boolean

        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read)
        Dim bloblen As Integer = CInt(fs.Length)
        Dim BLOB(bloblen) As Byte
        Dim sSQL As String

        sSQL = "DELETE ClientFormsXRef FROM ClientFormsXRef x, ClientForms s" & _
            " WHERE x.FormId = s.FormId AND x.TaxYear = s.TaxYear" & _
            " AND s.FormName = " & QuoStr(sFormName) & " And s.StateCd = " & QuoStr(sStateCd) & _
            " AND s.TaxYear = " & iTaxYear & " AND s.ClientId = " & lClientId
        ExecuteSQL(sSQL)
        sSQL = "DELETE ClientForms WHERE FormName = " & QuoStr(sFormName) & " AND StateCd = " & QuoStr(sStateCd) & _
            " AND TaxYear = " & iTaxYear & " AND ClientId = " & lClientId
        ExecuteSQL(sSQL)

        fs.Read(BLOB, 0, bloblen)
        fs.Close()
        sSQL = "INSERT ClientForms (FormId,ClientId,TaxYear,StateCd,FormName,FormDescription,FormData,AddUser)" & _
            " VALUES (@formid,@clientid,@taxyear,@statecd,@formname,@formdescription,@formdata,@adduser)"
        Dim cmd As SqlCommand = New SqlCommand(sSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@formid", SqlDbType.BigInt)
        cmd.Parameters("@formid").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@taxyear", SqlDbType.SmallInt)
        cmd.Parameters("@taxyear").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@statecd", SqlDbType.VarChar)
        cmd.Parameters("@statecd").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formname", SqlDbType.VarChar)
        cmd.Parameters("@formname").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formdescription", SqlDbType.VarChar)
        cmd.Parameters("@formdescription").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@addUser", SqlDbType.VarChar)
        cmd.Parameters("@addUser").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@formdata", SqlDbType.Image)
        cmd.Parameters("@formdata").Direction = ParameterDirection.Input


        cmd.Parameters("@formid").Value = lFormId
        cmd.Parameters("@clientid").Value = lClientId
        cmd.Parameters("@taxyear").Value = iTaxYear
        cmd.Parameters("@statecd").Value = sStateCd
        cmd.Parameters("@formname").Value = sFormName
        cmd.Parameters("@formdescription").Value = sFormDescription
        cmd.Parameters("@adduser").Value = sUserId
        ' Store the byte array in the image field
        cmd.Parameters("@formdata").Value = BLOB
        cmd.ExecuteNonQuery()

        Return True
    End Function

    Public Function StoreClientContractBLOB(ByVal lClientId As Long, ByVal sFile As String, ByVal sUserId As String) As Boolean

        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read)
        Dim bloblen As Integer = CInt(fs.Length)
        Dim BLOB(bloblen) As Byte
        Dim sSQL As String

        fs.Read(BLOB, 0, bloblen)
        fs.Close()
        sSQL = "UPDATE Clients SET ContractImage = @contractimage WHERE ClientId = @ClientId"
        Dim cmd As SqlCommand = New SqlCommand(sSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@contractimage", SqlDbType.Image)
        cmd.Parameters("@contractimage").Direction = ParameterDirection.Input
        cmd.Parameters("@clientid").Value = lClientId
        ' Store the byte array in the image field
        cmd.Parameters("@contractimage").Value = BLOB
        cmd.ExecuteNonQuery()

        Return True
    End Function

    Public Function StoreClientProposalBLOB(ByVal lClientId As Long, ByVal sFile As String, ByVal sUserId As String) As Boolean

        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read)
        Dim bloblen As Integer = CInt(fs.Length)
        Dim BLOB(bloblen) As Byte
        Dim sSQL As String

        fs.Read(BLOB, 0, bloblen)
        fs.Close()
        sSQL = "UPDATE Clients SET ProposalImage = @proposalimage WHERE ClientId = @ClientId"
        Dim cmd As SqlCommand = New SqlCommand(sSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@proposalimage", SqlDbType.Image)
        cmd.Parameters("@proposalimage").Direction = ParameterDirection.Input
        cmd.Parameters("@clientid").Value = lClientId
        ' Store the byte array in the image field
        cmd.Parameters("@proposalimage").Value = BLOB
        cmd.ExecuteNonQuery()

        Return True
    End Function


    Public Function StoreTaxBillBLOB(ByVal sTable As String, ByVal lClientId As Long, ByVal lLocationId As Long, _
            ByVal lAssessmentId As Long, ByVal lCollectorId As Long, ByVal iTaxYear As Integer, ByVal sUserName As String, _
            ByVal sFile As String) As Boolean

        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read)
        Dim bloblen As Integer = CInt(fs.Length)
        Dim BLOB(bloblen) As Byte
        Dim sql As New StringBuilder

        fs.Read(BLOB, 0, bloblen)
        fs.Close()
        sql.Length = 0
        sql.Append("UPDATE ").Append(sTable).Append(" SET FormData=@FormData,ChangeUser=@AddUser,ChangeDate=GETDATE(),ChangeType=2")
        sql.Append(" WHERE ClientId=@ClientId AND LocationId=@LocationId AND AssessmentId=@AssessmentId AND CollectorId=@CollectorId AND TaxYear=@TaxYear")
        sql.Append(" IF @@ROWCOUNT=0 BEGIN ")
        sql.Append("INSERT " & sTable)
        sql.Append(" (ClientId,LocationId,AssessmentId,CollectorId,TaxYear,FormData,AddUser) VALUES ")
        sql.Append(" (@ClientId,@LocationId,@AssessmentId,@CollectorId,@TaxYear,@FormData,@AddUser)")
        sql.Append(" END")
        Dim cmd As SqlCommand = New SqlCommand(sql.ToString, cn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@ClientId", SqlDbType.BigInt)
        cmd.Parameters("@ClientId").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@LocationId", SqlDbType.BigInt)
        cmd.Parameters("@LocationId").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@AssessmentId", SqlDbType.BigInt)
        cmd.Parameters("@AssessmentId").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@CollectorId", SqlDbType.BigInt)
        cmd.Parameters("@CollectorId").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@TaxYear", SqlDbType.SmallInt)
        cmd.Parameters("@TaxYear").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@AddUser", SqlDbType.VarChar)
        cmd.Parameters("@AddUser").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@FormData", SqlDbType.Image)
        cmd.Parameters("@FormData").Direction = ParameterDirection.Input
        cmd.Parameters("@ClientId").Value = lClientId
        cmd.Parameters("@LocationId").Value = lLocationId
        cmd.Parameters("@AssessmentId").Value = lAssessmentId
        cmd.Parameters("@CollectorId").Value = lCollectorId
        cmd.Parameters("@TaxYear").Value = iTaxYear
        cmd.Parameters("@AddUser").Value = sUserName
        ' Store the byte array in the image field
        cmd.Parameters("@FormData").Value = BLOB

        Debug.Print(sql.ToString)


        cmd.ExecuteNonQuery()

        Return True
    End Function

    Public Function RetrieveBLOB(ByVal lFormId As Long, ByVal iTaxYear As Integer, ByRef sMemoryStream As MemoryStream) As Boolean
        'Try
        Dim cmd As New SqlCommand _
           ("SELECT FormData FROM StateForms WHERE FormId = @formid AND TaxYear = @taxyear", cn)
        cmd.Parameters.Add("@formid", SqlDbType.BigInt)
        cmd.Parameters.Add("@taxyear", SqlDbType.SmallInt)
        cmd.Parameters("@formid").Direction = ParameterDirection.Input
        cmd.Parameters("@taxyear").Direction = ParameterDirection.Input
        cmd.Parameters("@formid").Value = lFormId
        cmd.Parameters("@taxyear").Value = iTaxYear

        Dim BLOB As Byte()
        BLOB = cmd.ExecuteScalar()

        'Dim fs As New FileStream("D:\empty.pdf", FileMode.OpenOrCreate, FileAccess.Write)
        'fs.Write(BLOB, 0, BLOB.Length)
        'fs.Close()
        sMemoryStream = New MemoryStream
        sMemoryStream.Write(BLOB, 0, BLOB.Length)
        'sMemoryStream.Close()

        Return True
        'Catch ex As Exception
        'sError = "Error in RetrieveBLOB:  " & ex.Message
        'Return False
        'End Try

    End Function

    Public Function RetrieveClientContractBLOB(ByVal lClientId As Long, ByVal sFile As String) As Boolean
        'Try
        Dim cmd As New SqlCommand _
           ("SELECT ContractImage FROM Clients WHERE ClientId = @clientId", cn)
        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters("@clientid").Value = lClientId

        Dim BLOB As Byte()
        BLOB = cmd.ExecuteScalar()

        Dim fs As New FileStream(sFile, FileMode.OpenOrCreate, FileAccess.Write)
        fs.Write(BLOB, 0, BLOB.Length)
        fs.Close()
        'sMemoryStream = New MemoryStream
        'sMemoryStream.Write(BLOB, 0, BLOB.Length)
        'sMemoryStream.Close()

        Return True
        'Catch ex As Exception
        'sError = "Error in RetrieveBLOB:  " & ex.Message
        'Return False
        'End Try

    End Function
    Public Function RetrieveClientProposalBLOB(ByVal lClientId As Long, ByVal sFile As String) As Boolean
        'Try
        Dim cmd As New SqlCommand _
           ("SELECT ProposalImage FROM Clients WHERE ClientId = @clientId", cn)
        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters("@clientid").Value = lClientId

        Dim BLOB As Byte()
        BLOB = cmd.ExecuteScalar()

        Dim fs As New FileStream(sFile, FileMode.OpenOrCreate, FileAccess.Write)
        fs.Write(BLOB, 0, BLOB.Length)
        fs.Close()
        'sMemoryStream = New MemoryStream
        'sMemoryStream.Write(BLOB, 0, BLOB.Length)
        'sMemoryStream.Close()

        Return True
        'Catch ex As Exception
        'sError = "Error in RetrieveBLOB:  " & ex.Message
        'Return False
        'End Try

    End Function


    Public Function RetrieveClientFormBLOB(ByVal lFormId As Long, ByVal iTaxYear As Integer, ByRef sMemoryStream As MemoryStream) As Boolean
        'Try
        Dim cmd As New SqlCommand _
           ("SELECT FormData FROM ClientForms WHERE FormId = @formid AND TaxYear = @taxyear", cn)
        cmd.Parameters.Add("@formid", SqlDbType.BigInt)
        cmd.Parameters.Add("@taxyear", SqlDbType.SmallInt)
        cmd.Parameters("@formid").Direction = ParameterDirection.Input
        cmd.Parameters("@taxyear").Direction = ParameterDirection.Input
        cmd.Parameters("@formid").Value = lFormId
        cmd.Parameters("@taxyear").Value = iTaxYear

        Dim BLOB As Byte()
        BLOB = cmd.ExecuteScalar()

        'Dim fs As New FileStream("D:\empty.pdf", FileMode.OpenOrCreate, FileAccess.Write)
        'fs.Write(BLOB, 0, BLOB.Length)
        'fs.Close()
        sMemoryStream = New MemoryStream
        sMemoryStream.Write(BLOB, 0, BLOB.Length)
        'sMemoryStream.Close()

        Return True
        'Catch ex As Exception
        'sError = "Error in RetrieveBLOB:  " & ex.Message
        'Return False
        'End Try

    End Function

    Public Function RetrieveTaxBillBLOB(ByVal sTable As String, ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
            ByVal lCollectorId As Long, ByVal iTaxYear As Integer, ByVal sFileName As String) As Boolean
        'Try
        Dim cmd As New SqlCommand _
           ("SELECT FormData FROM " & sTable & " WHERE ClientId = @clientid" & _
            " AND LocationId = @locationid" & _
            " AND AssessmentId = @assessmentid" & _
            " AND CollectorId = @collectorid" & _
            " AND TaxYear = @taxyear", cn)

        cmd.Parameters.Add("@clientid", SqlDbType.BigInt)
        cmd.Parameters.Add("@locationid", SqlDbType.BigInt)
        cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt)
        cmd.Parameters.Add("@collectorid", SqlDbType.BigInt)
        cmd.Parameters.Add("@taxyear", SqlDbType.SmallInt)
        cmd.Parameters("@clientid").Direction = ParameterDirection.Input
        cmd.Parameters("@locationid").Direction = ParameterDirection.Input
        cmd.Parameters("@assessmentid").Direction = ParameterDirection.Input
        cmd.Parameters("@collectorid").Direction = ParameterDirection.Input
        cmd.Parameters("@taxyear").Direction = ParameterDirection.Input
        cmd.Parameters("@clientid").Value = lClientId
        cmd.Parameters("@locationid").Value = lLocationId
        cmd.Parameters("@assessmentid").Value = lAssessmentId
        cmd.Parameters("@collectorid").Value = lCollectorId
        cmd.Parameters("@taxyear").Value = iTaxYear

        Dim BLOB As Byte()
        BLOB = cmd.ExecuteScalar()

        If BLOB Is Nothing Then
        Else
            Dim fs As New FileStream(sFileName, FileMode.OpenOrCreate, FileAccess.Write)
            fs.Write(BLOB, 0, BLOB.Length)
            fs.Close()
        End If
        Return True
        'Catch ex As Exception
        'sError = "Error in RetrieveBLOB:  " & ex.Message
        'Return False
        'End Try

    End Function
    Public Function BackupDatabase() As Boolean
        Dim sSQLService As String = "SQL Server (SQLEXPRESS)", sStatus As String = "", svcctlSQL As New ServiceController

        Try




            'CloseConnection()
            svcctlSQL = New ServiceController(sSQLService)
            sStatus = svcctlSQL.Status.ToString
            svcctlSQL.Stop()
            Thread.Sleep(10000)
            FileCopy("D:\My Files\VantageOne\Assessment Manager\Data\AssessmentManagerData.MDF", "D:\My Files\VantageOne\Assessment Manager\Data\Backup\AssessmentManagerData.MDF")
            Thread.Sleep(10000)
            FileCopy("D:\My Files\VantageOne\Assessment Manager\Data\AssessmentManagerData_log.LDF", "D:\My Files\VantageOne\Assessment Manager\Data\Backup\AssessmentManagerData_log.LDF")
            Thread.Sleep(10000)
            svcctlSQL.Start()
            Thread.Sleep(10000)
            svcctlSQL.Close()
            svcctlSQL = Nothing
            'MakeConnection("")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function

End Class
