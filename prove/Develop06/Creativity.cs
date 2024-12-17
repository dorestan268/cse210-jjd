public class Creativity : Goal
{
    private string _creativeTask;
    private bool _isComplete;
    private DateTime _completionDate;


    public Creativity(string name, string description, int points, string creativeTask)
        : base(name, description, points)
    {
        _creativeTask = creativeTask;
        _isComplete = false;
        _completionDate = DateTime.MinValue; 
    }

   
    public override void RecordEvent()
    {
        _isComplete = true;
        _completionDate = DateTime.Now;  
    }

    
    public override bool IsComplete() => _isComplete;

   
    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_shortName} - {_description} - Task: {_creativeTask}" +
               (_isComplete ? $" (Completed on: {_completionDate.ToShortDateString()})" : "");
    }

    
    public override string GetStringRepresentation()
    {
        return $"Creativity:{_shortName},{_description},{_points},{_creativeTask},{_isComplete},{_completionDate}";
    }
}
