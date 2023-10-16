using System.Windows.Input;
using QueueManager.models;

namespace QueueManager.views;

public class Display
{
    public int SelectedCommand = 0;
    public void MainMenu(string[] cmdsName)
    {
        string message = "===== Queue Manager =====\n";
        for (var i = 0; i < cmdsName.Length; i++)
            message += (i == SelectedCommand ? "--> " : "    ") + $"{cmdsName[i]}\n";
        Print(message);
    }

    public void Print(string message, bool clear = true)
    {
        if(clear) Console.Clear();
        Console.WriteLine(message);
    }

    public string? GetUserInput()
    {
        Console.Write("$ ");
        return Console.ReadLine();
    }

    public void PrintQueue(Queue<Person> queue)
    {
        string message = "";
        Person[] arr = queue.ToArray();
        for (int i = 0; i < arr.Length; i++)
            message += $"{i+1}. {arr[i]}\n";
        Print(message, false);
    }

    public ConsoleKeyInfo GetUserKey() => Console.ReadKey();

    public bool GetUserValidation(string message)
    {
        Print(message + " [Y/n]", true);
        ConsoleKeyInfo read = Console.ReadKey();
        switch (read.Key)
        {
            case ConsoleKey.N:
                return false;
            default:
                return true;
        }
    }
}