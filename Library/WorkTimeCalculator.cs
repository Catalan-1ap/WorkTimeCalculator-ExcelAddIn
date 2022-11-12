namespace Library;


public class WorkTimeCalculator
{
    public TimeSpan TotalNeeded { get; }
    public Outs Outs { get; }
    public Employee Employee { get; }
    public int TotalWorkDays { get; }


    public WorkTimeCalculator(TimeSpan totalNeeded, Outs outs, Employee employee, int totalWorkDays)
    {
        TotalNeeded = totalNeeded;
        Outs = outs;
        Employee = employee;
        TotalWorkDays = totalWorkDays;
    }


    public WorkedTimes Calculate()
    {
        var perDay = PerDay();
        var currentWorkedTime = WorkedTime(perDay);
        var currentWorkedTimeWithOuts = WithOuts(currentWorkedTime);
        var remain = TotalNeeded.Subtract(currentWorkedTimeWithOuts);
        var workedTimes = WorkedTimes(perDay, remain);

        ChaseUpWorkTime(workedTimes, currentWorkedTimeWithOuts);
        
        return workedTimes;
    }


    public bool Check(WorkedTimes workedTimes)
    {
        var currentWorkedTime = WorkedTime(workedTimes.PerDay);
        var currentWorkedTimeWithOuts = WithOuts(currentWorkedTime);
        ChaseUpWorkTime(workedTimes, currentWorkedTimeWithOuts);
        
        return true;
    }


    private void ChaseUpWorkTime(WorkedTimes workedTimes, TimeSpan totalTime)
    {
        totalTime = workedTimes.ChangedDays
            .Aggregate(totalTime, (current, changedDay) => current.Subtract(workedTimes.PerDay).Add(changedDay));

        if (TotalNeeded != totalTime)
            throw new($"Ошибка! Итоговое время не совпадает! Время: {TotalNeeded.Subtract(totalTime)}");
    }


    private WorkedTimes WorkedTimes(TimeSpan perDay, TimeSpan remain)
    {
        var normalDays = TotalWorkDays;
        var changedDays = new List<TimeSpan>();

        for (int i = 0; i < TotalWorkDays; i++)
        {
            var newDay = perDay.Add(remain);
            normalDays--;

            if (newDay > Employee.MaxWorkedHours)
            {
                newDay = Employee.MaxWorkedHours;
                var added = newDay - perDay;
                var remained = remain.Subtract(added);
                remain = new(remained.Hours, remained.Minutes, 0);
                changedDays.Add(newDay);
            }
            else
            {
                changedDays.Add(newDay);
                break;
            }
        }

        return new(normalDays, perDay, NormalizeDays(changedDays));
    }


    private static List<TimeSpan> NormalizeDays(List<TimeSpan> changedDays)
    {
        var times = changedDays.GroupBy(x => x).ToDictionary(x => x.Key);
        
        if (times.Keys.Count == 1)
            return changedDays;
        
        var average = changedDays.Mean();
        
        return Enumerable.Repeat(average, changedDays.Count).ToList();
    }


    private TimeSpan PerDay()
    {
        var totalWorkTime = TotalNeeded.Subtract(TimeSpan.FromHours(Outs.Total));

        return TimeSpan.FromMinutes((int)(totalWorkTime.TotalMinutes / TotalWorkDays));
    }


    private TimeSpan WorkedTime(TimeSpan perDay) =>
        new(
            TotalWorkDays * perDay.Hours,
            TotalWorkDays * perDay.Minutes,
            0
        );


    private TimeSpan WithOuts(TimeSpan time) => time.Add(TimeSpan.FromHours(Outs.Hours * Outs.Days));
}