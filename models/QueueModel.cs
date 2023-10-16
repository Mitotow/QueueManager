using System.Runtime.CompilerServices;

namespace QueueManager.models;

public class QueueModel
{
    private Queue<Person> _queue;
    private static QueueModel? _manager;

    private QueueModel()
    {
        _queue = new Queue<Person>();
    }

    public static QueueModel GetInstance()
    {
        return _manager ??= new QueueModel();
    }

    public Queue<Person> GetQueue()
    {
        return _queue;
    }

    public void Remove(int index)
    {
        _queue = new Queue<Person>(_queue.Where(p => p != _queue.ElementAt(index)));
    }
}