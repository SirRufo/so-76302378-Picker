namespace MyApp.Models;

public class Account : ReactiveObject
{
    [Reactive] public string Number { get; set; }
    [Reactive] public string Name { get; set; }
    [Reactive] public string Category { get; set; }
}

