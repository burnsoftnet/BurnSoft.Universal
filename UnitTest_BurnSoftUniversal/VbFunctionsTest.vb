Imports BurnSoft.Universal
<TestClass()> Public Class VbFunctionsTest

    <TestMethod(), TestCategory("Function Tests")> Public Sub ValueIsnumericTestTrue()
        Dim value As Boolean = VbFunctions.ValueIsnumeric(1)
        Assert.IsTrue(value)
    End Sub
    <TestMethod(), TestCategory("Function Tests")> Public Sub ValueIsnumericTestTrueString()
        Dim value As Boolean = VbFunctions.ValueIsnumeric("1")
        Assert.IsTrue(value)
    End Sub
    <TestMethod(), TestCategory("Function Tests")> Public Sub ValueIsnumericTestfalse()
        Dim value As Boolean = VbFunctions.ValueIsnumeric("N/A")
        Assert.IsFalse(value)
    End Sub
    <TestMethod(), TestCategory("Function Tests")> Public Sub GetDateDiffTest()
        Dim startDate = Convert.ToDateTime("1/1/2010")
        Dim endDate = Convert.ToDateTime("12/31/2022")
        Dim iDiff As Long = VbFunctions.GetDateDiff(startDate, endDate, DateInterval.Year)
        Assert.IsTrue(iDiff = 12)
    End Sub
End Class