namespace QueueManager.views;

public class Display
{
    public void MainMenu(string[] cmdsName)
    {
        string message = "===== Queue Manager =====\n";
        for (var i = 0; i < cmdsName.Length; i++)
            message += $"{i+1}. {cmdsName[i]}\n";
        message += "0. Quit\n";
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

    public ConsoleKeyInfo GetUserKey() => Console.ReadKey();
}