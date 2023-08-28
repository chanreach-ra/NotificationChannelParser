using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a notification title:");
        string input = Console.ReadLine();

        List<string> notificationChannels = ParseNotificationChannels(input);

        if (notificationChannels.Any())
        {
            string channels = string.Join(", ", notificationChannels);
            Console.WriteLine($"Received channels: {channels}");
        }
        else
        {
            Console.WriteLine("No valid notification channels found.");
        }
    }

    static List<string> ParseNotificationChannels(string input)
    {
        List<string> channels = new List<string>();

        // Use regular expression to match tags within square brackets
        var matches = Regex.Matches(input, @"\[([A-Za-z]+)\]");

        foreach (Match match in matches)
        {
            // Get the matched tag
            string tag = match.Groups[1].Value;

            // Map the tag to a notification channel (if valid)
            string channel = MapTagToChannel(tag);

            if (!string.IsNullOrEmpty(channel) && !channels.Contains(channel))
            {
                channels.Add(channel);
            }
        }

        return channels;
    }

    static string MapTagToChannel(string tag)
    {
        switch (tag.ToUpper())
        {
            case "BE":
                return "Backend";
            case "FE":
                return "Frontend";
            case "QA":
                return "Quality Assurance";
            case "URGENT":
                return "Urgent";
            default:
                return null; // Invalid or irrelevant tag
        }
    }
}
