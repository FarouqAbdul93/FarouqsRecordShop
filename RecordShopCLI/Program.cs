using System.Net.Http.Json;
using System.Text.Json;

namespace RecordShopCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7090/");

            Console.WriteLine("Welcome to Farouq's Record Shop!");
            Console.WriteLine("==================================");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View all albums");
                Console.WriteLine("2. Search by artist");
                Console.WriteLine("3. Search by genre");
                Console.WriteLine("4. Search by release year");
                Console.WriteLine("5. Search by album name");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await GetAllAlbums(client);
                        break;
                    case "2":
                        Console.Write("Enter artist name: ");
                        var artist = Console.ReadLine();
                        await GetByArtist(client, artist);
                        break;
                    case "3":
                        Console.Write("Enter genre: ");
                        var genre = Console.ReadLine();
                        await GetByGenre(client, genre);
                        break;
                    case "4":
                        Console.Write("Enter release year: ");
                        var year = Console.ReadLine();
                        await GetByYear(client, year);
                        break;
                    case "5":
                        Console.Write("Enter album name: ");
                        var name = Console.ReadLine();
                        await GetByName(client, name);
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thanks for visiting Farouq's Record Shop!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static async Task GetAllAlbums(HttpClient client)
        {
            var response = await client.GetAsync("api/album");

            if (response.IsSuccessStatusCode)
            {
                var albums = await response.Content.ReadFromJsonAsync<List<Album>>();
                PrintAlbums(albums);
            }
            else
            {
                Console.WriteLine("Could not retrieve albums.");
            }
        }

        static async Task GetByArtist(HttpClient client, string artist)
        {
            var response = await client.GetAsync($"api/album/artist/{artist}");

            if (response.IsSuccessStatusCode)
            {
                var albums = await response.Content.ReadFromJsonAsync<List<Album>>();
                PrintAlbums(albums);
            }
            else
            {
                Console.WriteLine($"No albums found for artist '{artist}'.");
            }
        }

        static async Task GetByGenre(HttpClient client, string genre)
        {
            var response = await client.GetAsync($"api/album/genre/{genre}");

            if (response.IsSuccessStatusCode)
            {
                var albums = await response.Content.ReadFromJsonAsync<List<Album>>();
                PrintAlbums(albums);
            }
            else
            {
                Console.WriteLine($"No albums found for genre '{genre}'.");
            }
        }

        static async Task GetByYear(HttpClient client, string year)
        {
            var response = await client.GetAsync($"api/album/year/{year}");

            if (response.IsSuccessStatusCode)
            {
                var albums = await response.Content.ReadFromJsonAsync<List<Album>>();
                PrintAlbums(albums);
            }
            else
            {
                Console.WriteLine($"No albums found for year '{year}'.");
            }
        }

        static async Task GetByName(HttpClient client, string name)
        {
            var response = await client.GetAsync($"api/album/name/{name}");

            if (response.IsSuccessStatusCode)
            {
                var album = await response.Content.ReadFromJsonAsync<Album>();
                PrintAlbum(album);
            }
            else
            {
                Console.WriteLine($"No album found with name '{name}'.");
            }
        }

        static void PrintAlbums(List<Album> albums)
        {
            Console.WriteLine("\n--- Results ---");
            foreach (var album in albums)
            {
                PrintAlbum(album);
            }
        }

        static void PrintAlbum(Album album)
        {
            Console.WriteLine($"\nTitle: {album.Title}");
            Console.WriteLine($"Artist: {album.Artist}");
            Console.WriteLine($"Genre: {album.Genre}");
            Console.WriteLine($"Year: {album.ReleaseYear}");
            Console.WriteLine($"Stock: {album.Stock}");
        }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int Stock { get; set; }
    }
}
