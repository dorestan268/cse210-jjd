public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

  
// Observe the syntax: the MathAssignment constructor takes 4 parameters and
// passes 2 of them directly to the "base" constructor, which is the "Assignment" class constructor.
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        
// Set the variables specific to the MathAssignment class here.
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}