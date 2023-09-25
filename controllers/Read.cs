using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class Read : ICommand
{
    public string Name { get; set; } = "Read";
    public Queue<Person> Queue { get; set; }
    public Display Display { get; set; }

    public Read(Queue<Person> queue, Display disp)
    {
        Queue = queue;
        Display = disp;
    }
    
    public void OnCommand()
    {
        if (Queue.ElementAtOrDefault(0) is null)
        {
            Display.Print("Nobody in queue.");
            return;
        }
        string message = "===== Actual Queue =====\n";
        foreach (var person in Queue)
            message += $". {person}\n";
        Display.Print(message);
    }
}