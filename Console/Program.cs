using Library;

var totalNeeded = new TimeSpan(169, 24, 0);
var outs = new Outs("2x8,00");
var employee = Employee.Junior();
var totalWorkDays = 22;
var calculator = new WorkTimeCalculator(totalNeeded, outs, employee, totalWorkDays);

Check();

void Check()
{
    var result = calculator!.Check(
        new(
            21,
            new(6, 58, 0),
            Enumerable.Repeat(new TimeSpan(7, 6, 0), 1).ToList()
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