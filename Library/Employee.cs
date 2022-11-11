namespace Library;


public class Employee
{
    public TimeSpan MaxWorkedHours { get; }


    private Employee(TimeSpan maxWorkedHours) => MaxWorkedHours = maxWorkedHours;


    public static Employee FromString(string input) =>
        input switch
        {
            "ВРАЧИ" => Doctor(),
            "Средний медперсонал" => Middle(),
            "Младший" => Junior(),
            _ => throw new("Нет типа для работника")
        };


    public static Employee Doctor() => new(new(6, 36, 0));

    public static Employee Middle() => new(new(7, 42, 0));

    public static Employee Junior() => new(new(8, 0, 0));
}