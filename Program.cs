using PersonalSchedule.Models;
using PersonalSchedule.Services;

var agendaService = new AgendaService();
var schedules = agendaService.Load();
var notifier = new NotificationService();

_ = Task.Run(() => notifier.StartAsync(schedules, agendaService));

while (true)
{
    Console.WriteLine("===== PERSONAL SCHEDULE =====");
    Console.WriteLine("1 - New appointment");
    Console.WriteLine("2 - List");
    Console.WriteLine("0 - Exit");
    Console.Write("Choose: ");

    var op = Console.ReadLine();

    if (op == "1")
    {
        var s = new Schedule();

        Console.Write("Title: ");
        s.Title = Console.ReadLine()!;

        Console.Write("Description: ");
        s.Description = Console.ReadLine()!;

        Console.Write("Date (yyyy-MM-dd): ");
        var date = Console.ReadLine();

        Console.Write("Time (HH:mm): ");
        var time = Console.ReadLine();

        s.DateTime = DateTime.Parse($"{date} {time}");

        schedules.Add(s);
        agendaService.Save(schedules);

        Console.WriteLine("Saved!\n");
    }
    else if (op == "2")
    {
        foreach (var s in schedules.OrderBy(x => x.DateTime))
            Console.WriteLine($"{s.DateTime} - {s.Title}");

        Console.WriteLine();
    }
    else if (op == "0")
        break;
}