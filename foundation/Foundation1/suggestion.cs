public class Suggestion
{
    public string Name {get; set; }
    public string Text { get; set; }

    public Suggestion(string name, string text)
    {
        Name = name;
        Text = text;
    }
}