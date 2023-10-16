using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class Quit : ICommand
{
    public string Name { get; set; } = "Quit";
    public QueueModel Manager { get; set; }
    public Display Display { get; set; }
    public AppManager AppManager { get; set; }

    public Quit(Display disp, AppManager appManager)
    {
        Manager = QueueModel.GetInstance();
        AppManager = appManager;
        Display = disp;
    }
    
    public void OnCommand()
    {
        bool isQuit = Display.GetUserValidation("Are you sure to leave ?");
        if(isQuit) AppManager.Quit();
        else Display.Print("Abort ...");
    }
}