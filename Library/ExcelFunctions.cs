using ExcelDna.Integration;


namespace Library;


public static class ExcelFunctions
{
    [ExcelFunction]
    public static object[,] WorkTime(string totalNeededInput, string outsInput, string employeeInput, string totalWorkDaysInput)
    {
        var totalNeeded = Extensions.TimeSpanFromString(totalNeededInput);
        var outs = new Outs(outsInput);
        var employee = Employee.FromString(employeeInput);
        var totalWorkDays = int.Parse(totalWorkDaysInput);
        
        var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);
        var result = calculator.Calculate();
        
        return new object[,]
        {
            { $"{result.NormalDays}x{result.PerDay.ToExcelString()}" },
            { $"{result.ChangedDays.Count}x{result.ChangedDays.First().ToExcelString()}" },
        };
    }
}