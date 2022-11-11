namespace Library;


public record class WorkedTimes(int NormalDays, TimeSpan PerDay, List<TimeSpan> ChangedDays);