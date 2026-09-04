# Class Notes

## Lecture 5 : Points to remember

### Types of Network
- **Client–Server:** Clients request services or resources from a central server.
- **Peer-to-Peer (P2P):** Each device can act as both a client and a server.
- **Cluster + Server:** Multiple connected computers work together as a cluster and are managed or accessed through a server. 

<br>

---

### Inter Process Communication (IPC)

- **Inter Object Communication**
    - allows clients to communicate transparently with objects , regardless of where those objects are running (in the same process , on the same computer , or on different computer)
    - The underlying technique is called `Marshalling`
    - Techonolgies which provide IOC are : .NET Remoting , COM , Remote Procedural Call 
    - **Drawback** : IOC increases object complexity because objects must deal with communication and data-structure/marshalling details, making them responsible for more than their core functionality and violating the Single Responsibility Principle.

- **Serialized Message Passing**
    - Requires the client to serialize the data into bytes before they are shared across process.
    - `Serialization` is the technique of converting the state of the object into a form that can be persisted or transported.
    - Technologies which provide Serialization for IPC : Pipes , Socket , UDP / TCP

<br>

---

### WPF and XAML

- UX logic mixing with functionalities , make the code unmaintainable.
- To tackle this problem , there are design patterns 
    - Model-View-Presenter (MVP)
    - Model-View-Controller (MVC)
    - Model-View-ViewModel (MVVM)

<br>

---
### MVVVM:

- **Model** - Business / Functional logic .
- **ViewModel** - Is the layer the acts as a bridge between the `View` and the `Model`. It may or may not transforem the raw data from the `Model` into presentable from the `View` 
- **View** - The GUI that the user sees.
- **Data Bindings** - Two-way communication between the `View` and the `ViewModel`

<br>

---

### Home Work (Not Graded)

- Try implementing a simple WPF

<br>

---

