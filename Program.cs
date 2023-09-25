using QueueManager.controllers;
using QueueManager.models;
using QueueManager.views;

var display = new Display();
var queue = new Queue<Person>();
var manager = new QueueManager.AppManager(display);

manager.RegisterCommand(new Add(queue, display));
manager.RegisterCommand(new Del(queue, display));
manager.RegisterCommand(new Read(queue, display));

manager.Manage();