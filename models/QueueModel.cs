using System.Runtime.CompilerServices;

namespace QueueManager.models;

public class QueueModel
{
    private Queue<Person> Queue;
    private static QueueModel? Manager = null;
    
    protected QueueModel()
    {
        Queue = new Queue<Person>();
    }

    public static QueueModel GetInstance()
    {
        return Manager ??= new QueueModel();
    }

    public Queue<Person> GetQueue()
    {
        return Queue;
    }

    public void Remove(int index)
    {
        Queue = new Queue<Person>(Queue.Where(p => p != Queue.ElementAt(index)));
    }
}