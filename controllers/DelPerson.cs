using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class DelPerson : ICommand
{
    public string Name { get; set; } = "DelPerson";
    public QueueModel Manager { get; set; }
    public Display Display { get; set; }

    public DelPerson(Display disp)
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

        Display.Print("==== Queue ====");
        Display.PrintQueue(queue);
        Display.Print("\nChose a person by index :", false);
        var input = Display.GetUserInput();
        if (input == null) return;
        int index;
        try
        {
            index = short.Parse(input);
        }
        catch (Exception)
        {
            Display.Print($"{input} is an invalid input (or maybe to high)");
            return;
        }

        if (index < 1 || index > queue.Count)
        {
            Display.Print($"{index} is not valid, value must be between 1 and {queue.Count}");
            return;
        }
        Manager.Remove(index-1);
        Display.Print($"{queue.ElementAt(index-1)} has been removed from queue.");
    }
}