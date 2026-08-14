# Class Notes


## Lecture 3 : Points to remeber

### UML (Unified Modelling Language)

- Visuaizes the architecture and design of software system
- Common types of UML diagram
    - Class diagram
    - Module diagram
    - Activity diagram

- **Module diagram** - shows dependnecies of various modules in the project

- **Activity diagram** - flow chart that shows sequence of activities between various components of software

- **Class diagram** - already mentioned in lecture 2

---

### SOLID Principles

- **Single-responsibility principle** - Every class should have only one responsibility 

- **Open-closed principle** - Open for extension , closed for modification 

- **Liskov substitution principle** - Clients that use pointers to base classes must be able to use objects of derived classes without knowing it

- **Interface segregation principle** - Clients should not need to depend upon interfaces that they do not use  (Note :  interface can depend on another in interface )

- **Dependency inversion principle** - Use abstractions , promote loose coupling

---

### More Software design patterns

- Creational Patterns 

    - Deals with object creation 
    - Examples :  Abstract factory , Builder , Factory method , Prototype , Singleton
    
    1. Factory  -  As discussed in lecture 2
    1. Singleton -  when you create an object of type A twice , you have two different instances , where as singleton only makes once instance and reuses it where ever required , hence it helps in serializing resource usage .   

- Structural Patterns 

    - Deals with structural relationship between various classes
    - Examples : Adapter, Bridge , Composite , Decorator , Facade , Flyweight , Proxy

- Behavioural Patterns 

    - Deals with communication between the various classes
    - Example : Chain of Responsibility , Command , Interpreter , Iterator , Mediator , Memento , Observer , State , Stratergy , Template Methord , Visitor
---

### Software Development Life Cycle (SDLC)

1. Gathering requiremnets
1. Writing specifications documents
1. Architecture and design
1. Development
1. Integration 
1. Testing and Validation 
1. Development 
1. Maintenance

--- 
### Common SDLC Models 

- Waterfall : all in one go methord and thoroughly planned , mostly used creating softawre like Linux , Kernel etc
- Agile : With continuos customer feedack and always changing , mostly used in Web Dev 
- Nowadays most companies prefer to choose a model which is roughly the hybrid of both

---

### Home Work (Not Graded)

- Learn more about UML 

- Distributed GUI in C# (https://github.com/chittur/distributed-and-gui-demo) make
    1. Class diagram
    1. Module diagram
    1. Activity diagram 


- Write a simple design document for each times as markdown for the main all class project

- Add Listener capabilities for Network Manager made in Lec 2

---

### Next Lecture Upcoming




