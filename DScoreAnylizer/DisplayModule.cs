using DScoreAnylizer.DisplayText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DScoreAnylizer;
internal static class DisplayModule
{
    private static string gross_2021 = "C:\\Users\\Don\\Desktop\\NWPL\\Pre_Draft\\DScoreAnylizer\\Data\\Scores_2021.csv";
    private static string adjusted_2021 = "C:\\Users\\Don\\Desktop\\NWPL\\Pre_Draft\\DScoreAnylizer\\Data\\Scores_Against_DST_2021.csv";
    private static string gross_2022 = "C:\\Users\\Don\\Desktop\\NWPL\\Pre_Draft\\DScoreAnylizer\\Data\\Scores_2022.csv";
    private static string adjusted_2022 = "C:\\Users\\Don\\Desktop\\NWPL\\Pre_Draft\\DScoreAnylizer\\Data\\Scores_Against_DST_2022.csv";

    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine(MenuText.Title);
        Console.WriteLine(MenuText.MainMenu_1);
        Console.WriteLine(MenuText.MainMenu_2);
        Console.WriteLine(MenuText.MainMenu_3);
        Console.WriteLine(MenuText.MainMenu_4);
        Console.WriteLine(MenuText.MainMenu_0);
        Console.WriteLine();

        var input = ArgResolver.Convert_StrToInt(Console.ReadLine()?? string.Empty);
        string fileLocation = "";
        switch(input)
        {
            case 1:
                fileLocation = gross_2021;
                break;
            case 2:
                fileLocation = adjusted_2021;
                break;
            case 3:
                fileLocation = gross_2022;
                break;
            case 4:
                fileLocation = adjusted_2022;
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Enter '1' or '2'");
                MainMenu();
                break;
        }

        string? file = File.ReadAllText(fileLocation);
        var nums = new List<int>();
        var strings = file.Split(',');
        for (int i = 0; i < strings.Length; i++)
        {
            nums.Add(ArgResolver.Convert_StrToInt(strings[i]));
        }

        nums.Sort();

        Stack<int> scores = new();
        Stack<int> quantities = new();
        for (int i = 0; i < nums.Count; i++)
        {
            if (i > 0 && 
                scores.Peek() == nums[i])
            {
                var q = quantities.Pop();
                quantities.Push(q + 1);
            }
            else
            {
                scores.Push(nums[i]);
                quantities.Push(1);
            }

            i++;
        }

        Stack<KeyValuePair<int, int>> scoreGraph = new();
        
        while(scores.Count > 0)
        {
            scoreGraph.Push(new KeyValuePair<int, int>(scores.Pop(), quantities.Pop()));
        }

        DisplayResults(scoreGraph);
    }

    public static void DisplayResults(Stack<KeyValuePair<int, int>> scoreGraph)
    {
        Console.Clear();
        while (scoreGraph.Count > 0)
        {
            var data = scoreGraph.Pop();
            Console.WriteLine(DisplayText.DisplayText.GetBar(data.Key, data.Value));
        }

        MainMenu();
    }

    public static void ShowError(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine();
    }
}
