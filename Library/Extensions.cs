namespace Library;


public static class Extensions
{
    public static bool ContainsOrdinalIgnoreCase(this string input, string contains) =>
        input.Contains(contains, StringComparison.OrdinalIgnoreCase);


    public static string ToExcelString(this TimeSpan timeSpan) => $"{timeSpan.Hours}.{timeSpan.Minutes}";


    public static TimeSpan TimeSpanFromString(string input)
    {
        var section = input.Split('=').Last();
        var timeData = section.Split(',');
        var hour = int.Parse(timeData.First());
        var minute = int.Parse(timeData.Last());

        return new(hour, minute, 0);
    }


    public static TimeSpan Mean(this IEnumerable<TimeSpan> source) =>
        TimeSpan.FromTicks(
            source.Aggregate((m: 0L, r: 0L, n: source.Count()),
                (tm, s) =>
                {
                    var r = tm.r + s.Ticks % tm.n;
                    return (tm.m + s.Ticks / tm.n + r / tm.n, r % tm.n, tm.n);
                }).m);
}