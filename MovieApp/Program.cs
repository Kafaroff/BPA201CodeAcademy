using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

public enum Genre
{
    Action,
    Comedy,
    Drama,
    Horror,
    SciFi,
    Romance,
    Documentary
}


interface IPlayable
{
    void Play();
    void Stop();
}


public abstract class Media
{
    public string title { get; set; }
    public int year { get; set; }

    protected Media() { }

    protected Media(string title, int year)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("title bosh ola bilmez");

        if (year < 0)
            throw new ArgumentException("year menfi ola bilmez");

        this.title = title.Trim();
        this.year = year;
    }

    public abstract void DisplayInfo();
}


public class Movie : Media, IPlayable
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genre genre { get; set; }
    public bool watched { get; private set; }

    public Movie() : base() { }

    public Movie(string title, int year, Genre genre, bool watched = false)
        : base(title, year)
    {
        this.genre = genre;
        this.watched = watched;
    }

    public override void DisplayInfo()
    {
        var status = watched ? "İzlenilib " : "İzlenilmeyib ";
        Console.WriteLine($"Film: {title} | İl: {year} | Janr: {genre} | Status: {status}");
    }

    public void Play()
    {
        Console.WriteLine($"Playing {title}...");
    }

    public void Stop()
    {
        Console.WriteLine($"{title} stopped");
    }

    public void MarkAsWatched(MovieManager manager)
    {
        watched = true;
        manager.Update(this);
    }

    public void MarkAsUnwatched(MovieManager manager)
    {
        watched = false;
        manager.Update(this);
    }
}


public class MovieManager
{
    readonly string filePath;
    List<Movie> movies = new List<Movie>();

    readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public MovieManager()
    {
        var baseDir = AppContext.BaseDirectory;
        var dataDir = Path.Combine(baseDir, "Data");
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        filePath = Path.Combine(dataDir, "movie.json");
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]");

        Load();
    }

    void Load()
    {
        try
        {
            var txt = File.ReadAllText(filePath);
            movies = JsonSerializer.Deserialize<List<Movie>>(txt, jsonOptions) ?? new List<Movie>();
            movies = movies
                .Where(m => m != null && !string.IsNullOrWhiteSpace(m.title) && m.year >= 0)
                .ToList();
            Save();
        }
        catch
        {
            movies = new List<Movie>();
            Save();
        }
    }

    void Save()
    {
        var txt = JsonSerializer.Serialize(movies, jsonOptions);
        File.WriteAllText(filePath, txt);
    }

    public void Add(Movie movie)
    {
        if (string.IsNullOrWhiteSpace(movie.title))
        {
            Console.WriteLine("title bosh ola bilmez.");
            return;
        }
        if (movie.year < 0)
        {
            Console.WriteLine("year menfi ola bilmez.");
            return;
        }
        if (movies.Any(m => m.title.Equals(movie.title, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Bu adda film artiq var.");
            return;
        }

        movies.Add(movie);
        Save();
        Console.WriteLine($"\"{movie.title}\" elave olundu.");
    }

    public void Show()
    {
        if (movies.Count == 0)
        {
            Console.WriteLine("Hele film yoxdur.");
            return;
        }

        Console.WriteLine("—— Butun Filmler ——");
        foreach (var m in movies)
            m.DisplayInfo();
    }

    public void Remove(string title)
    {
        var item = movies.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (item == null)
        {
            Console.WriteLine("Tapilmadi.");
            return;
        }

        movies.Remove(item);
        Save();
        Console.WriteLine($"\"{title}\" silindi.");
    }

    public void Update(Movie movie)
    {
        var idx = movies.FindIndex(m => m.title.Equals(movie.title, StringComparison.OrdinalIgnoreCase));
        if (idx >= 0)
        {
            movies[idx] = movie;
            Save();
        }
    }

    public Movie Find(string title)
    {
        return movies.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        var manager = new MovieManager();
        int secim;

        do
        {
            Console.WriteLine("\n==== Movie Console App ====");
            Console.WriteLine("1) Film elave et");
            Console.WriteLine("2) Butun filmleri goster");
            Console.WriteLine("3) İzlenilib et");
            Console.WriteLine("4) İzlenilmeyib et");
            Console.WriteLine("5) Play/Stop");
            Console.WriteLine("6) Film sil");
            Console.WriteLine("0) cixish");
            Console.Write("Secim: ");

            if (!int.TryParse(Console.ReadLine(), out secim)) secim = -1;

            switch (secim)
            {
                case 1:
                    AddMovie(manager);
                    break;

                case 2:
                    manager.Show();
                    break;

                case 3:
                    ToggleWatch(manager, toWatched: true);
                    break;

                case 4:
                    ToggleWatch(manager, toWatched: false);
                    break;

                case 5:
                    PlayStop(manager);
                    break;

                case 6:
                    Console.Write("Silinecek filmin adi: ");
                    var del = Console.ReadLine();
                    manager.Remove(del ?? "");
                    break;

                case 0:
                    Console.WriteLine("Bye");
                    break;

                default:
                    Console.WriteLine("Yanlish secim.");
                    break;
            }

        } while (secim != 0);
    }

    static void AddMovie(MovieManager manager)
    {
        try
        {
            Console.Write("Ad: ");
            var title = Console.ReadLine();

            Console.Write("İl: ");
            var yearStr = Console.ReadLine();
            if (!int.TryParse(yearStr, out int year)) year = -1;

            Console.Write("Janr (Action,Comedy,Drama,Horror,SciFi,Romance,Documentary): ");
            var g = Console.ReadLine();

            if (!Enum.TryParse<Genre>(g, true, out var genre))
            {
                Console.WriteLine("Yanlish janr.");
                return;
            }

            var movie = new Movie(title ?? "", year, genre);
            manager.Add(movie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
    }

    static void ToggleWatch(MovieManager manager, bool toWatched)
    {
        Console.Write("Filmin adi: ");
        var title = Console.ReadLine();
        var movie = manager.Find(title ?? "");

        if (movie == null)
        {
            Console.WriteLine("Tapilmadi.");
            return;
        }

        if (toWatched)
            movie.MarkAsWatched(manager);
        else
            movie.MarkAsUnwatched(manager);

        Console.WriteLine(toWatched ? "Status: izlenilib." : "Status: izlenilmeyib.");
    }

    static void PlayStop(MovieManager manager)
    {
        Console.Write("Filmin adi: ");
        var title = Console.ReadLine();
        var movie = manager.Find(title ?? "");

        if (movie == null)
        {
            Console.WriteLine("Tapilmadi.");
            return;
        }

        movie.Play();
        Console.Write("Dayandirmaq ucun Enter bas: ");
        Console.ReadLine();
        movie.Stop();
    }
}
