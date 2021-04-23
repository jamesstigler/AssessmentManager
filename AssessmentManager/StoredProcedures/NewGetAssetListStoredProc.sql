--Open asset list without factored amounts
exec spGetAssetList 
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=0,
@NeedFactoringEntityNames=1,
@NeedTotalValues=0,
@NeedTotalOriginalCost=1,
@NeedDetail=1,
@Accrual=0


--open asset list with factored amounts
exec spGetAssetList
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=1,
@NeedTotalValues=0,
@NeedTotalOriginalCost=1,
@NeedDetail=1,
@Accrual=0

--open bpp assessment screen (total amounts only)
exec spGetAssetList
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=0,
@NeedTotalValues=1,
@NeedTotalOriginalCost=0,
@NeedDetail=0,
@Accrual=0

--Value comparison report (same as assessment screen totals only)
exec spGetAssetList
@ClientId=1506588172,
@LocationId=1704672745,
@AssessmentId=408454926,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=0,
@NeedTotalValues=1,
@NeedTotalOriginalCost=0,
@NeedDetail=0,
@Accrual=0



--accrual report
exec spGetAssetList
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=0,
@NeedTotalValues=1,
@NeedTotalOriginalCost=0,
@NeedDetail=0,
@Accrual=1


--savings report  same as assessment screen
exec spGetAssetList
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=0,
@NeedTotalValues=1,
@NeedTotalOriginalCost=0,
@NeedDetail=0,
@Accrual=0

--asset reports
exec spGetAssetList
@ClientId=1898128216,
@LocationId=1830798966,
@AssessmentId=656884323,
@TaxYear=2019,
@FactorEntityId=0,
@NeedFactoredAmounts=1,
@NeedFactoringEntityNames=0,
@NeedTotalValues=0,
@NeedTotalOriginalCost=0,
@NeedDetail=1,
@Accrual=0

