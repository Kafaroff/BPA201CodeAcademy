using System;
using System.Collections.Generic;

class Meeting
{
    public DateTime fromDate;
    public DateTime toDate;
    public string name;

    public Meeting(DateTime fromDate, DateTime toDate, string name)
    {
        this.fromDate = fromDate;
        this.toDate = toDate;
        this.name = name;
    }
}

class MeetingSchedule
{
    List<Meeting> Meetings = new List<Meeting>();

    public void SetMeeting(DateTime from, DateTime to, string name)
    {
        bool conflict = false;

        foreach (var meeting in Meetings)
        {
            if (from < meeting.toDate && to > meeting.fromDate)
            {
                conflict = true;
                break;
            }
        }

        if (conflict)
        {
            Console.WriteLine(" Xeta! Bu tarixler arasinda artiq meeting var!");
        }
        else
        {
            Meetings.Add(new Meeting(from, to, name));
            Console.WriteLine(" Meeting ugurla elave edildi!");
        }
    }

    public int FindMeetingsCount(DateTime startDate)
    {
        int count = 0;
        foreach (var meeting in Meetings)
        {
            if (meeting.fromDate > startDate)
                count++;
        }
        return count;
    }

    public bool IsExistsMeetingByName(string isname)
    {
        foreach (var meeting in Meetings)
        {
            if (meeting.name == isname)
                return true;
        }
        return false;
    }

    public List<Meeting> GetExistMeetings(string isname)
    {
        List<Meeting> list = new List<Meeting>();

        foreach (var meeting in Meetings)
        {
            if (meeting.name == isname)
                list.Add(meeting);
        }

        return list;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MeetingSchedule schedule = new MeetingSchedule();

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Yeni meeting elave et");
            Console.WriteLine("2. Verilen tarixden sonra olan meeting sayini tap");
            Console.WriteLine("3. Ada gore meeting olub-olmadigini yoxla");
            Console.WriteLine("4. Ada gore butun meetingleri tap");
            Console.WriteLine("0. Çixiş");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Başlama tarixi (YYYY-MM-DD): ");
                    DateTime from = DateTime.Parse(Console.ReadLine());

                    Console.Write("Bitme tarixi (YYYY-MM-DD): ");
                    DateTime to = DateTime.Parse(Console.ReadLine());

                    Console.Write("Meeting adi: ");
                    string name = Console.ReadLine();

                    schedule.SetMeeting(from, to, name);
                    break;

                case "2":
                    Console.Write("Tarix daxil et (YYYY-MM-DD): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    int count = schedule.FindMeetingsCount(date);
                    Console.WriteLine($"Meeting sayi: {count}");
                    break;

                case "3":
                    Console.Write("Meeting adi: ");
                    string n = Console.ReadLine();
                    bool exists = schedule.IsExistsMeetingByName(n);
                    Console.WriteLine(exists ? "Var" : "Yoxdur");
                    break;

                case "4":
                    Console.Write("Meeting adi: ");
                    string nn = Console.ReadLine();

                    var list = schedule.GetExistMeetings(nn);

                    foreach (var m in list)
                    {
                        Console.WriteLine($"{m.name} | {m.fromDate} - {m.toDate}");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Yanliş seçim!");
                    break;
            }
        }
    }
}
