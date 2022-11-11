using Library;

var totalNeeded = new TimeSpan(132, 0, 0);
var outs = new Outs("4x8,00");
var employee = Employee.Junior();
var totalWorkDays = 22;
var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);



void Check()
{
    var result = calculator!.Check(
        new(
            12,
            new(4, 35, 0),
            Enumerable.Repeat(new TimeSpan(4, 30, 0), 10).ToList()
        )
    );
    Console.WriteLine(result);
}


void Test()
{
    var result = calculator!.Calculate();
    Console.WriteLine($"\nMain Days - {result.NormalDays}, Per Day - {result.PerDay}");
    Console.WriteLine($"Additional Days - {result.ChangedDays.Count}");

    foreach (var day in result.ChangedDays)
        Console.WriteLine($" \t{day}");
}