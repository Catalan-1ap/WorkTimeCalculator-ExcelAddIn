using Library;


var totalNeeded = new TimeSpan(32, 0, 0);
var outs = new Outs("4x5");
var employee = Employee.Doctor();
var totalWorkDays = 7;
var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);

Test();


void Test()
{
    var result = calculator.Calculate();
    Console.WriteLine($"\nMain Days - {result.NormalDays}, Per Day - {result.PerDay}");
    Console.WriteLine($"Additional Days - {result.ChangedDays.Count}");

    foreach (var day in result.ChangedDays)
        Console.WriteLine($" \t{day}");
}