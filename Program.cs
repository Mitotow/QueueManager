using QueueManager.controllers;
using QueueManager.views;

var display = new Display();
var manager = new QueueManager.AppManager(display);

manager.RegisterCommand(new Add(display));
manager.RegisterCommand(new Del(display));
manager.RegisterCommand(new DelPerson(display));
manager.RegisterCommand(new Read(display));

manager.Manage();