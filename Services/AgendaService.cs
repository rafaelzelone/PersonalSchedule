using System.Text.Json;
using PersonalSchedule.Models;

namespace PersonalSchedule.Services;

public class AgendaService
{
    private const string FILE = "agenda.json";

    public List<Schedule> Load()
    {
        if (!File.Exists(FILE))
            return new List<Schedule>();

        var json = File.ReadAllText(FILE);
        return JsonSerializer.Deserialize<List<Schedule>>(json)!
               ?? new List<Schedule>();
    }

    public void Save(List<Schedule> schedules)
    {
        var json = JsonSerializer.Serialize(schedules, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FILE, json);
    }
}