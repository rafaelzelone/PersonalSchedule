namespace PersonalSchedule.Models;

public class Schedule
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public bool Notified { get; set; } = false;
}