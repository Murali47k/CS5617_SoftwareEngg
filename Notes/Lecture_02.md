# Class Notes


## Lecture 2 : Points to remeber


### OOPs 

- Lower level modules should not depend on higher level modules.
- Modules should not have cyclical dependencies.
- Classes are types that can be instanitated.
- Classes can have cyclical dependencies.
- There are two type of fields , value types and reference types.
	1. value types , eg : int, bool , float , string , struct etc.
	1. reference types , eg : reference of a class.

---


### Fundamnetals of OOPs
- **Abstraction** : Principle of exposing only the required methords and fields without going into much details.
- **Encapsulation** : Hiding data that user doesnt need to know about ( like private variables , those are implementation details that need not be accesible ).
- **Inheritance** : The child class inherits all the properties of parent class and upgrade it by overwriting its behaviour.
- **Polymorphism** (most important feature) : A base class pointer can point to a derived class object.

---

### Interface

- An interface is a most fundamental type in OOPs.
- An interface is a contract between a producer and consumer.
- For interfaces you dont give explaination or how it works.
- There are two type of inheritance :
	1. Inherit from class (Inheritance of Implimentaion) : inherits virtual methords from parent class
	2. Inherit from interface 

---

### Design Patterns

- There are 23 design patterns , we will see more in upcoming classes.
- 1 - Factory design manager
- Look up Abstract Factory

---

### 4 Relations between types in Class Diagram

Types are implementations and classes

- **Composition** : Class A creates Class B and B life time is same as A
- **Aggregations** : Class A creates Class B and B life time is less than A
- **Inheritances** : Child Class A inherits from Parent Class B
- **Using** : Class A does not creates Class B , but uses it .

1. If you use new in class , it is either aggregation or composition.
1. if class is made inside a function then it is aggregation.
1. Interface is an concept and hence it will be always using or inheritance.

---

### Additional Comments on Code

- Follow Pascal or Camel casing in C#.
	1. Pascal Casing - TcpManager (for function and classes)
	1. Camel Casing - tcpManager (for parameters and anything else)
- If you dont write private : it automatically recognizes as private class or function
- OOPs code are better since you can update the code with minimal changes
- Interface always start with "I" by convention.


---

### Home Work (Not Graded)

- Put it in github and send the link to sir.
- Refer sir's code and build a Ux module of Comunicator , for executive and TCP & HTTP Manager and Encoded/Extended TCPManager.
- But say (write in console , sending via TCP or HTTP) no need of actually implementing.
- Have two methords , public SendMessage() and public GetCount() using private int.
- Should have interface ICommunicator having SendMessage() and GetCount();
- Make a factory also and make it smart enough to change accordingly
- Executive and Connector module , based on LAN or internet choose.
- Then Draw the class diagram between all classes as a PNG

---

### Next Lecture Upcoming

- 5 principles of OOPs
- Look up Solid Principles
- More on Class Diagram
- More Design patterns