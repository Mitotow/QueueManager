namespace QueueManager.models;

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    
    public override string ToString()
    {
        return $"{Surname.ToUpper()} {Name}";
    }
}