using System;

// Первый класс с событием
public class FirstClass
{
    private string _name;

    public event EventHandler<NameEventArgs> NameChanged;

    public FirstClass(string name)
    {
        _name = name;
    }

    public void GenerateEvent()
    {
        OnNameChanged(new NameEventArgs(_name));
    }

    protected virtual void OnNameChanged(NameEventArgs e)
    {
        NameChanged?.Invoke(this, e);
    }
}

// Класс аргументов события
public class NameEventArgs : EventArgs
{
    public string Name { get; }

    public NameEventArgs(string name)
    {
        Name = name;
    }
}

// Второй класс
public class SecondClass
{
    public void NameChangedHandler(object sender, NameEventArgs e)
    {
        Console.WriteLine($"Объект '{e.Name}' сгенерировал событие.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем два объекта первого класса и один объект второго класса
        FirstClass obj1 = new FirstClass("Объект 1");
        FirstClass obj2 = new FirstClass("Объект 2");
        SecondClass obj3 = new SecondClass();

        // Регистрируем обработчик события для двух объектов первого класса
        obj1.NameChanged += obj3.NameChangedHandler;
        obj2.NameChanged += obj3.NameChangedHandler;

        // Генерируем события для двух объектов первого класса
        obj1.GenerateEvent();
        obj2.GenerateEvent();
    }
}