using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class Add : ICommand
{
    public string Name { get; set; } = "Add";
    public QueueModel Manager { get; set; }
    public Display Display { get; set; }

    public Add(Display disp)
    {
        Manager = QueueModel.GetInstance();
        Display = disp;
    }
    
    public void OnCommand()
    {
        Queue<Person> queue = Manager.GetQueue();
        bool firstIteration = true;
        while (true)
        {
            Display.Print("===== Name and Surname =====", firstIteration); // Print question and clear console if it's the first time
            string? input = Display.GetUserInput(); // Get user input
            if(firstIteration) firstIteration = false; 
            if (input == null) continue;
            List<string> args = input.Split(" ").ToList();
            if (args.Count < 2)
            {
                Display.Print("A person need a Name and a Surname !");
                continue;
            }

            Person person = new Person(args[0], args[1]);
            Display.Print($"You added {person} to the queue");
            queue.Enqueue(person);
            break;
        }
    }
}