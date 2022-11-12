namespace Library;


public class Employee
{
    public TimeSpan MaxWorkedHours { get; }


    private Employee(TimeSpan maxWorkedHours) => MaxWorkedHours = maxWorkedHours;


    public static Employee FromString(string input) =>
        input switch
        {
            _ when input.ContainsOrdinalIgnoreCase("Врачи") => Doctor(),
            _ when input.ContainsOrdinalIgnoreCase("Средний медперсонал") => Middle(),
            _ when input.ContainsOrdinalIgnoreCase("Младший") => Junior(),
            _ => throw new("Нет типа для работника")
        };


    public static Employee Doctor() => new(new(6, 36, 0));

    public static Employee Middle() => new(new(7, 42, 0));

    public static Employee Junior() => new(new(8, 0, 0));
}