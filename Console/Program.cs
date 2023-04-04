using Library;

var totalNeeded = new TimeSpan(68, 18, 0);
var outs = new Outs("4x5,00");
var employee = Employee.Doctor();
var totalWorkDays = 7;
var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);

Test();
//var res = ExcelFunctions.WorkTime("1,0=69,18", "4x5,00", "Врачи", "7");

void Check()
{
    var result = calculator.Check(
        new(
            6,
            new(6, 36, 0),
            Enumerable.Repeat(new TimeSpan(4, 51, 0), 2).ToList()
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