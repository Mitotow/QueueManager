using QueueManager.interfaces;
using QueueManager.views;

namespace QueueManager;

public class AppManager
{
    private readonly Display _display;
    private readonly Dictionary<string, ICommand> _commands = new();
    private readonly ConsoleKey[] _menuKeys = { ConsoleKey.DownArrow, ConsoleKey.UpArrow, ConsoleKey.Enter };
    private bool _stop;
    
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

    public void Quit()
    {
        _stop = true;
        _display.Print("Goodbye !");
    }
    
    public void Manage()
    {
        while (!_stop)
        {
            var cmd = "";
            var cmdsName = CmdsName(); // List of commands name
            while (true)
            {
                _display.MainMenu(cmdsName); // Display main menu
                var read = Display.GetUserKey(); // Get user key pressed
                if(_menuKeys.ToList().IndexOf(read.Key) != -1)
                {
                    switch (read.Key)
                    {
                        case ConsoleKey.UpArrow:
                        {
                            if (_display.SelectedCommand == 0) _display.SelectedCommand = cmdsName.Length - 1;
                            else _display.SelectedCommand--;
                            continue;
                        }
                        case ConsoleKey.DownArrow:
                        {
                            if (_display.SelectedCommand == cmdsName.Length - 1) _display.SelectedCommand = 0;
                            else _display.SelectedCommand++;
                            continue;
                        }
                        case ConsoleKey.Enter:
                            try { cmd = cmdsName.ToList()[_display.SelectedCommand]; } // Try to find cmd in commands name list
                            catch(ArgumentOutOfRangeException) { _display.Print("Error when starting command"); } // Command name not found
                            break;
                    }
                }
                break; // Everything work fine, leave loop
            }
            var command = GetCommand(cmd);
            command?.OnCommand();
            if (command is null || _stop) continue;
            _display.Print("\nPress a key to continue", false);
            Display.GetUserKey();
        }
    }
}