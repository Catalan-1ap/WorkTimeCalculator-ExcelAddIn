namespace Library;


public record class Outs
{
    public int Days { get; }
    public int Hours { get; }
    public int Total => Days * Hours;


    public Outs(string input)
    {
        var splitted = input.Split('x').ToArray();
        
        Days = int.Parse(splitted[0]);
        Hours = int.Parse(splitted[1].Split(',').First());
    }
}