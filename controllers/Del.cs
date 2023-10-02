using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class Del : ICommand
{
    public string Name { get; set; } = "Delete";
    public QueueModel Manager { get; set; }
    public Display Display { get; set; }

    public Del(Display disp)
    {
        Manager = QueueModel.GetInstance();
        Display = disp;
    }

    public void OnCommand()
    {
        Queue<Person> queue = Manager.GetQueue();
        if (queue.ElementAtOrDefault(0) is null)
        {
            Display.Print("Nobody in queue.");
            return;
        }
    
        Display.Print("Are you sure ? Y/n");
        ConsoleKeyInfo read = Display.GetUserKey();
        if (read.Key is ConsoleKey.Enter or ConsoleKey.Y)
        {
            var person = queue.First();
            queue.Dequeue();
            Display.Print($"{person} has been removed from queue.");
        } else 
            Display.Print("Nobody has been removed from queue.");
    }
}