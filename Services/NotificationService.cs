using PersonalSchedule.Models;

namespace PersonalSchedule.Services;

public class NotificationService
{
    public async Task StartAsync(List<Schedule> schedules, AgendaService agenda)
    {
        Console.WriteLine("Scheduler started...\n");

        while (true)
        {
            var now = DateTime.Now;

            foreach (var s in schedules.Where(x => !x.Notified))
            {
                if (now >= s.DateTime)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🔔 {s.Title}");
                    Console.WriteLine($"📅 {s.DateTime}");
                    Console.WriteLine($"📝 {s.Description}\n");
                    Console.ResetColor();

                    s.Notified = true;
                    agenda.Save(schedules);
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(30));
        }
    }
}