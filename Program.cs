using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "-+Discord Tool+-";
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        while (true)
        {
            ShowBanner();
            ShowMenu();

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                return; // Exit the program
            }
            else if (choice == "2")
            {
                await MessageSender();
            }
        }
    }

    static void ShowBanner()
    {
        Console.WriteLine();
        Console.WriteLine("   ██████╗ ██╗███████╗ ██████╗ ██████╗ ██████╗ ██████╗     ████████╗ ██████╗  ██████╗ ██╗     ");
        Console.WriteLine("   ██╔══██╗██║██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔══██╗    ╚══██╔══╝██╔═══██╗██╔═══██╗██║     ");
        Console.WriteLine("   ██║  ██║██║███████╗██║     ██║   ██║██████╔╝██║  ██║       ██║   ██║   ██║██║   ██║██║     ");
        Console.WriteLine("   ██║  ██║██║╚════██║██║     ██║   ██║██╔══██╗██║  ██║       ██║   ██║   ██║██║   ██║██║     ");
        Console.WriteLine("   ██████╔╝██║███████║╚██████╗╚██████╔╝██║  ██║██████╔╝       ██║   ╚██████╔╝╚██████╔╝███████╗");
        Console.WriteLine("   ╚═════╝ ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝        ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝");
        Console.WriteLine();
        Console.WriteLine();
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("   ┌────────────────────────────────┐");
        Console.WriteLine("   │     Discord Webhook Sender     │");
        Console.WriteLine("   ├────────────────────────────────┤");
        Console.WriteLine("   │ 1. Exit                        │");
        Console.WriteLine("   │ 2. Discord webhook Send        │");
        Console.WriteLine("   └────────────────────────────────┘");
        Console.Write("   Enter your choice: ");
    }

    static async Task MessageSender()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("   ┌────────────────────────────────┐");
        Console.WriteLine("   │    Discord Webhook Sender      │");
        Console.WriteLine("   ├────────────────────────────────┤");

        Console.Write("   Enter Discord webhook URL for Message Sender: ");
        string webhookUrl = Console.ReadLine();

        Console.Write("   Enter the message to send: ");
        string message = Console.ReadLine();

        Console.Write("   Enter the number of times to send the message: ");
        int numTimes = int.Parse(Console.ReadLine());

        using (HttpClient client = new HttpClient())
        {
            for (int i = 0; i < numTimes; i++)
            {
                var content = new StringContent($"{{\"content\": \"{message}\"}}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(webhookUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Message sent {i + 1}/{numTimes}.");
                }
                else
                {
                    Console.WriteLine("Failed to send message.");
                }
            }
        }

        Console.WriteLine("   Messages sent successfully.");
        Console.WriteLine("   Press any key to return to the menu...");
        Console.ReadKey();
    }
}
