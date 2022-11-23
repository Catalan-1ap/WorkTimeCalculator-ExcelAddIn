using Library;

var totalNeeded = new TimeSpan(72, 36, 0);
var outs = new Outs("5x5,00");
var employee = Employee.Doctor();
var totalWorkDays = 8;
var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);

//Test();
//var res = ExcelFunctions.WorkTime("1,0=72,36", "5x5,00", "Врачи", "8");

void Check()
{
    var result = calculator.Check(
        new(
            8,
            new(5, 17, 0),
            Enumerable.Repeat(new TimeSpan(5, 20, 0), 1).ToList()
        )
    );
    Console.WriteLine(result);
}


void Test()
{
    var result = calculator.Calculate();
    Console.WriteLine($"\nMain Days - {result.NormalDays}, Per Day - {result.PerDay}");
    Console.WriteLine($"Additional Days - {result.ChangedDays.Count}");

    foreach (var day in result.ChangedDays)
        Console.WriteLine($" \t{day}");
}