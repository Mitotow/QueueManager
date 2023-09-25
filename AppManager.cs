using QueueManager.interfaces;
using QueueManager.views;

namespace QueueManager;

public class AppManager
{
    private readonly Display _display;
    private readonly Dictionary<string, ICommand> _commands = new();
    private readonly ConsoleKey[] _validKeys = { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8 };

    
    public AppManager(Display display)
    {
        _display = display;
    }
    
    private ICommand? GetCommand(string name)
    {
        return _commands.GetValueOrDefault(name);
    }

    private string[] CmdsName()
    {
        return _commands.Keys.ToArray();
    }

    public void RegisterCommand(ICommand command)
    {
        _commands.Add(command.Name, command);
    }
    
    public void Manage()
    {
        var loop = true;
        while (loop)
        {
            var cmd = "";
            var cmdsName = CmdsName(); // List of commands name
            while (true)
            {
                _display.MainMenu(cmdsName); // Display main menu
                ConsoleKeyInfo read = _display.GetUserKey(); // Get user key pressed
                if (read.Key == ConsoleKey.D0) { loop = false; break; } // Leave when escape pressed
                int index = _validKeys.ToList().IndexOf(read.Key); // Searching for key typed in validkeys array
                if (index < 0) continue; // Key not in valid keys
                try { cmd = cmdsName.ToList()[index]; } // Try to find cmd in commands name list
                catch(ArgumentOutOfRangeException) { Console.WriteLine("test");continue; } // Command name not found
                break; // Everything work fine, leave loop
            }
            var command = GetCommand(cmd);
            command?.OnCommand();
            if (command is not null)
            {
                _display.Print("\nPress a key to continue", false);
                _display.GetUserKey();
            }
        }

        _display.Print("Goodbye !");
    }
}