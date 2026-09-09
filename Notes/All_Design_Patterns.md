# All 23 Design Patterns

A quick reference guide to all 23 Gang of Four (GoF) design patterns with simple C# code examples.

## Creational Patterns

Deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

---

### 1. Abstract Factory
**Purpose:** Creates families of related objects without specifying concrete classes.

```csharp
interface IGuiFactory {
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

class WinFactory : IGuiFactory {
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

class MacFactory : IGuiFactory {
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Usage
IGuiFactory factory = new WinFactory();
IButton button = factory.CreateButton(); // Returns Windows button
```

---

### 2. Builder
**Purpose:** Constructs complex objects step by step.

```csharp
class PizzaBuilder {
    private string dough;
    private string sauce;
    private string topping;
    
    public PizzaBuilder SetDough(string dough) {
        this.dough = dough;
        return this;
    }
    
    public PizzaBuilder SetSauce(string sauce) {
        this.sauce = sauce;
        return this;
    }
    
    public PizzaBuilder SetTopping(string topping) {
        this.topping = topping;
        return this;
    }
    
    public Pizza Build() => new Pizza(dough, sauce, topping);
}

// Usage
var pizza = new PizzaBuilder()
    .SetDough("thin")
    .SetSauce("tomato")
    .SetTopping("cheese")
    .Build();
```

---

### 3. Factory Method
**Purpose:** Defines an interface for creating objects, but lets subclasses decide which class to instantiate.

```csharp
abstract class Logistics {
    public abstract ITransport CreateTransport();
}

class RoadLogistics : Logistics {
    public override ITransport CreateTransport() => new Truck();
}

class SeaLogistics : Logistics {
    public override ITransport CreateTransport() => new Ship();
}

// Usage
Logistics logistics = new RoadLogistics();
ITransport transport = logistics.CreateTransport(); // Returns Truck
```

---

### 4. Prototype
**Purpose:** Creates new objects by cloning an existing object.

```csharp
abstract class Shape {
    public abstract Shape Clone();
}

class Circle : Shape {
    public int Radius { get; set; }
    
    public override Shape Clone() => new Circle { Radius = this.Radius };
}

// Usage
var original = new Circle { Radius = 5 };
var copy = original.Clone(); // New Circle with radius 5
```

---

### 5. Singleton
**Purpose:** Ensures a class has only one instance and provides a global access point.

```csharp
class Database {
    private static Database instance;
    
    private Database() { }
    
    public static Database GetInstance() {
        if (instance == null) {
             instance = new Database();
        }
        return instance;
    }
}

// Usage
var db1 = Database.GetInstance();
var db2 = Database.GetInstance(); // Same instance as db1
```

---

## Structural Patterns

Deal with the composition of classes and objects to form larger structures.

---

### 6. Adapter
**Purpose:** Allows incompatible interfaces to work together.

```csharp
// Target Interface
interface IPrinter{
    void Print();
}

// Adaptee
class LegacyPrinter{
    public void PrintDocument(){
        Console.WriteLine("Legacy Printer is printing a document.");
    }
}

// Adapter
class PrinterAdapter : IPrinter{

    private LegacyPrinter legacyPrinter;

    public PrinterAdapter(){
        legacyPrinter = new LegacyPrinter();
    }

    public void Print(){
        legacyPrinter.PrintDocument();
    }
}

// Usage
IPrinter printer = new PrinterAdapter();
printer.Print();
```

---

### 7. Bridge
**Purpose:** Separates abstraction from implementation so they can vary independently.

```csharp
// Implementation
interface IColor{
    void ApplyColor();
}

class RedColor : IColor{

    public void ApplyColor(){
        Console.WriteLine("Red");
    }
}

class BlueColor : IColor{

    public void ApplyColor(){
        Console.WriteLine("Blue");
    }
}


// Abstraction
abstract class Shape{

    protected IColor color;

    public Shape(IColor color){
        this.color = color;
    }

    public abstract void Draw();
}


// Refined Abstraction
class Circle : Shape{

    public Circle(IColor color) : base(color){}

    public override void Draw(){
        Console.Write("Drawing Circle");
        color.ApplyColor();
    }
}

class Square : Shape{

    public Square(IColor color) : base(color){}

    public override void Draw(){
        Console.Write("Drawing Square");
        color.ApplyColor();
    }
}

// Usage
Shape circle = new Circle(new RedColor());
circle.Draw();

Shape square = new Square(new BlueColor());
square.Draw();

Shape circle2 = new Circle(new BlueColor());
circle2.Draw();
```

---

### 8. Composite
**Purpose:** Treats individual objects and compositions uniformly.

```csharp
abstract class Graphic {
    public abstract void Draw();
}

class Leaf : Graphic {
    public override void Draw() { } // Draws single element
}

class Composite : Graphic {
    private List<Graphic> children = new List<Graphic>();
    
    public void Add(Graphic graphic) => children.Add(graphic);
    
    public override void Draw() {
        foreach (var child in children) {
            child.Draw();
        }
    }
}

// Usage
var group = new Composite();
group.Add(new Circle());
group.Add(new Rectangle());
group.Draw(); // Draws both circle and rectangle
```

---

### 9. Decorator
**Purpose:** Dynamically adds responsibilities to objects.

```csharp
abstract class Coffee {
    public abstract int Cost();
}

class SimpleCoffee : Coffee {
    public override int Cost() => 5;
}

class MilkDecorator : Coffee {
    private Coffee coffee;
    
    public MilkDecorator(Coffee coffee) {
        this.coffee = coffee;
    }
    
    public override int Cost() => coffee.Cost() + 2;
}

class SugarDecorator : Coffee {
    private Coffee coffee;
    
    public SugarDecorator(Coffee coffee) {
        this.coffee = coffee;
    }
    
    public override int Cost() => coffee.Cost() + 1;
}

// Usage
Coffee coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee); // Total: 8
```

---

### 10. Facade
**Purpose:** Provides a simplified interface to a complex subsystem.

```csharp
class HomeTheater {
    private DvdPlayer dvdPlayer;
    private Projector projector;
    private SoundSystem soundSystem;
    
    public HomeTheater() {
        dvdPlayer = new DvdPlayer();
        projector = new Projector();
        soundSystem = new SoundSystem();
    }
    
    public void WatchMovie(string movie) {
        projector.On();
        soundSystem.On();
        dvdPlayer.Play(movie);
    }
}

// Usage
var theater = new HomeTheater();
theater.WatchMovie("Inception"); // One method controls everything
```

---

### 11. Flyweight
**Purpose:** Shares common parts of objects to reduce memory usage.

```csharp
class TreeType {
    public string Name { get; }
    public string Texture { get; }
    public string Color { get; }
    
    public TreeType(string name, string texture, string color) {
        Name = name;
        Texture = texture;
        Color = color;
    }
}

class Tree {
    private int x;
    private int y;
    private TreeType type;

    public Tree(int x, int y, TreeType type){
        this.x = x;
        this.y = y;
        this.type = type;
    }

    public void Display(){
        Console.WriteLine(
            $"{type.Name} tree at ({x}, {y})"
        );
    }
}

// Usage - Shared the same memory of oak object
TreeType oak = new TreeType("Oak", "Green", "oak.png");
Tree tree1 = new Tree(10, 20, oak);
Tree tree2 = new Tree(50, 80, oak);
Tree tree3 = new Tree(100, 40, oak);

```

---

### 12. Proxy
**Purpose:** Provides a surrogate or placeholder for another object to control access.

```csharp
class RealVideo {
    private string videoName;
    
    public RealVideo(string videoName) {
        this.videoName = videoName;
        Load();
    }
    
    private void Load() { } // Expensive operation
    
    public void Play() { }
}

class VideoProxy {
    private RealVideo realVideo;
    private string videoName;
    
    public VideoProxy(string videoName) {
        this.videoName = videoName;
    }
    
    public void Play() {
        if (realVideo == null) {
            realVideo = new RealVideo(videoName);
        }
        realVideo.Play();
    }
}

// Usage
var video = new VideoProxy("movie.mp4");
video.Play(); // Loads only when actually needed
```

---

## Behavioral Patterns

Deal with algorithms and the assignment of responsibilities between objects.

---

### 13. Chain of Responsibility
**Purpose:** Passes requests along a chain of handlers.

```csharp
abstract class Handler {
    protected Handler nextHandler;
    
    public Handler SetNext(Handler handler) {
        nextHandler = handler;
        return handler;
    }
    
    public abstract string Handle(string request);
}

class AuthHandler : Handler {
    public override string Handle(string request) {
        if (!IsAuthenticated()) {
            return "Access Denied";
        }
        return nextHandler?.Handle(request) ?? "Success";
    }
    
    private bool IsAuthenticated() => true;
}

class LoggingHandler : Handler {
    public override string Handle(string request) {
        Log(request);
        return nextHandler?.Handle(request) ?? "Success";
    }
    
    private void Log(string request) { }
}

// Usage
var chain = new AuthHandler();
chain.SetNext(new LoggingHandler());
chain.Handle(request);
```

---

### 14. Command
**Purpose:** Encapsulates a request as an object, allowing parameterization and queuing.

```csharp
interface ICommand {
    void Execute();
}

class TurnOnLightCommand : ICommand {
    public void Execute() {
        Console.WriteLine("Light turned ON");
    }
}

class TurnOffLightCommand : ICommand {
    public void Execute() {
        Console.WriteLine("Light turned OFF");
    }
}

class Button {
    private ICommand command;

    public void SetCommand(ICommand command) {
        this.command = command;
    }

    public void Press() {
        command.Execute();
    }
}

// Usage
Button button = new Button();

button.SetCommand(new TurnOnLightCommand());
button.Press(); // Light Turned ON

button.SetCommand(new TurnOffLightCommand());
button.Press(); // Light Turned OFF
```

---

### 15. Interpreter
**Purpose:** Defines a grammatical representation for a language and provides an interpreter.

```csharp
interface IExpression {
    int Interpret();
}

class NumberExpression : IExpression {
    private int value;
    
    public NumberExpression(int value) {
        this.value = value;
    }
    
    public int Interpret() => value;
}

class AddExpression : IExpression {
    private IExpression left;
    private IExpression right;
    
    public AddExpression(IExpression left, IExpression right) {
        this.left = left;
        this.right = right;
    }
    
    public int Interpret() => left.Interpret() + right.Interpret();
}

// Usage
IExpression expression = new AddExpression(
    new NumberExpression(5), 
    new NumberExpression(3)
);
int result = expression.Interpret(); // 8
```

---

### 16. Iterator
**Purpose:** Provides a way to access elements of a collection sequentially.

```csharp
interface IIterator<T> {
    T Next();
    bool HasNext();
}

class ArrayIterator<T> : IIterator<T> {
    private T[] collection;
    private int position = 0;
    
    public ArrayIterator(T[] collection) {
        this.collection = collection;
    }
    
    public bool HasNext() => position < collection.Length;
    
    public T Next() => collection[position++];
}

// Usage
var iterator = new ArrayIterator<int>(new[] { 1, 2, 3 });
while (iterator.HasNext()) {
    var item = iterator.Next();
}
```

---

### 17. Mediator
**Purpose:** Reduces coupling between objects by making them communicate through a mediator.

```csharp
class ChatRoom {
    private List<User> users = new List<User>();
    
    public void AddUser(User user) {
        users.Add(user);
    }
    
    public void SendMessage(User sender, string message) {
        foreach (var user in users) {
            if (user != sender) {
                user.Receive(message);
            }
        }
    }
}

class User {
    private ChatRoom room;
    private string name;
    
    public User(ChatRoom room, string name) {
        this.room = room;
        this.name = name;
    }
    
    public void Send(string message) {
        room.SendMessage(this, message);
    }
    
    public void Receive(string message) {
        Console.WriteLine($"{name} received: {message}");
    }
}

// Usage
var room = new ChatRoom();
var alice = new User(room, "Alice");
var bob = new User(room, "Bob");
room.AddUser(alice);
room.AddUser(bob);
alice.Send("Hello Bob!"); // Bob receives message
```

---

### 18. Memento
**Purpose:** Captures and externalizes an object's internal state to allow restoration.

```csharp
class Editor {
    public string Content { get; set; }
    
    public Memento CreateMemento() => new Memento(Content);
    
    public void Restore(Memento memento) {
        Content = memento.GetContent();
    }
}

class Memento {
    private string content;
    
    public Memento(string content) {
        this.content = content;
    }
    
    public string GetContent() => content;
}

// Usage
var editor = new Editor();
editor.Content = "Hello";
var saved = editor.CreateMemento();
editor.Content = "World";
editor.Restore(saved); // Content is "Hello" again
```

---

### 19. Observer
**Purpose:** Defines a one-to-many dependency where objects are notified of state changes.

```csharp
class Subject {
    private List<IObserver> observers = new List<IObserver>();
    private int temperature;
    
    public void Attach(IObserver observer) => observers.Add(observer);
    
    public int Temperature {
        get => temperature;
        set {
            temperature = value;
            Notify();
        }
    }
    
    private void Notify() {
        foreach (var observer in observers) {
            observer.Update();
        }
    }
}

interface IObserver {
    void Update();
}

class PhoneDisplay : IObserver {
    private Subject weatherStation;
    
    public PhoneDisplay(Subject weatherStation) {
        this.weatherStation = weatherStation;
    }
    
    public void Update() {
        ShowWeather();
    }
    
    private void ShowWeather() { }
}

// Usage
var station = new Subject();
var phone = new PhoneDisplay(station);
station.Attach(phone);
station.Temperature = 25; // Phone updates automatically
```

---

### 20. State
**Purpose:** Allows an object to change behavior when its internal state changes.

```csharp
interface IState {
    void Handle(TrafficLight context);
}

class TrafficLight {
    private IState currentState;
    
    public TrafficLight() {
        currentState = new RedState();
    }
    
    public void SetState(IState state) {
        currentState = state;
    }
    
    public void Change() {
        currentState.Handle(this);
    }
}

class RedState : IState {
    public void Handle(TrafficLight context) {
        Console.WriteLine("Stop");
        context.SetState(new GreenState());
    }
}

class GreenState : IState {
    public void Handle(TrafficLight context) {
        Console.WriteLine("Go");
        context.SetState(new RedState());
    }
}

// Usage
var light = new TrafficLight();
light.Change(); // Prints "Stop", changes to Green
light.Change(); // Prints "Go", changes to Red
```

---

### 21. Strategy
**Purpose:** Defines a family of algorithms and makes them interchangeable.

```csharp
interface ISortingStrategy {
    void Sort(int[] data);
}

class QuickSort : ISortingStrategy {
    public void Sort(int[] data) {
        // Quick sort algorithm
    }
}

class MergeSort : ISortingStrategy {
    public void Sort(int[] data) {
        // Merge sort algorithm
    }
}

class DataProcessor {
    private ISortingStrategy strategy;
    
    public DataProcessor(ISortingStrategy strategy) {
        this.strategy = strategy;
    }
    
    public void Process(int[] data) {
        strategy.Sort(data);
    }
}

// Usage
var processor = new DataProcessor(new QuickSort());
processor.Process(new[] { 3, 1, 4, 2 }); // Uses QuickSort
```

---

### 22. Template Method
**Purpose:** Defines the skeleton of an algorithm in a method, deferring some steps to subclasses.

```csharp
abstract class Beverage {
    public void Prepare() {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }
    
    private void BoilWater() { }
    private void PourInCup() { }
    protected abstract void Brew();
    protected abstract void AddCondiments();
}

class Tea : Beverage {
    protected override void Brew() { /* Steep tea bag */ }
    protected override void AddCondiments() { /* Add lemon */ }
}

class Coffee : Beverage {
    protected override void Brew() { /* Brew coffee grounds */ }
    protected override void AddCondiments() { /* Add sugar and milk */ }
}

// Usage
Tea tea = new Tea();
tea.Prepare(); // Follows template with tea-specific steps
```

---

### 23. Visitor
**Purpose:** Represents an operation to be performed on elements of an object structure.

```csharp
interface IVisitor {
    void VisitCircle(Circle circle);
    void VisitRectangle(Rectangle rect);
}

interface IShape {
    void Accept(IVisitor visitor);
}

class Circle : IShape {
    public double Radius { get; set; }
    
    public void Accept(IVisitor visitor) {
        visitor.VisitCircle(this);
    }
}

class Rectangle : IShape {
    public double Width { get; set; }
    public double Height { get; set; }
    
    public void Accept(IVisitor visitor) {
        visitor.VisitRectangle(this);
    }
}

class AreaVisitor : IVisitor {
    public double TotalArea { get; private set; }
    
    public void VisitCircle(Circle circle) {
        TotalArea += Math.PI * Math.Pow(circle.Radius, 2);
    }
    
    public void VisitRectangle(Rectangle rect) {
        TotalArea += rect.Width * rect.Height;
    }
}

// Usage
var shapes = new List<IShape> { 
    new Circle { Radius = 5 }, 
    new Rectangle { Width = 4, Height = 6 } 
};
var visitor = new AreaVisitor();
foreach (var shape in shapes) {
    shape.Accept(visitor);
}
Console.WriteLine(visitor.TotalArea); // Total area
```

---

## Quick Reference Guide

### Creational Patterns
| Pattern | When to Use |
|---------|-------------|
| Abstract Factory | Need families of related objects |
| Builder | Complex object construction |
| Factory Method | Subclasses decide object type |
| Prototype | Cloning is cheaper than creation |
| Singleton | Only one instance needed |

### Structural Patterns
| Pattern | When to Use |
|---------|-------------|
| Adapter | Interface mismatch |
| Bridge | Abstraction and implementation vary |
| Composite | Tree structures |
| Decorator | Adding features dynamically |
| Facade | Simplify complex system |
| Flyweight | Many fine-grained objects |
| Proxy | Control access to object |

### Behavioral Patterns
| Pattern | When to Use |
|---------|-------------|
| Chain of Responsibility | Processing pipeline |
| Command | Parameterize operations |
| Interpreter | Language processing |
| Iterator | Traverse collections |
| Mediator | Decouple objects |
| Memento | Save/restore state |
| Observer | One-to-many notification |
| State | State-dependent behavior |
| Strategy | Swap algorithms |
| Template Method | Skeleton algorithm |
| Visitor | Add operations to structures |

---

## Pattern Selection Tips

1. **Creational**: Use when object creation is complex or needs abstraction
2. **Structural**: Use when designing relationships between classes/objects
3. **Behavioral**: Use when focusing on communication and responsibility

*Remember: Design patterns are tools, not rules. Choose based on your specific needs!*
