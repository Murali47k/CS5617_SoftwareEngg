# Class Notes

## Lecture 5 : Points to remember

### Project Discussion

#### Types of Network
- Client - Server
- Peer - Peer
- Cluster + Server 

#### Inter Process Communication (IPC)

- **Inter Object Communication**
    - allows clients to communicate transparently with objects , regardless of where those objects are running (in the same process , on the same computer , or on different computer)
    - The underlying technique is called `Marshalling`
    - Techonolgies which provide IOC are : .NET Remoting , COM , Remote Procedural Call 
    - **Drawback** : IOC increases object complexity because objects must deal with communication and data-structure/marshalling details, making them responsible for more than their core functionality and violating the Single Responsibility Principle.

- **Serialized Message Passing**
    - Requires the client to serialize the data into bytes before they are shared across process.
    - `Serialization` is the technique of converting the state of the object into a form that can be persisted or transported.
    - Technologies which provide Serialization for IPC : Pipes , Socket , UDP / TCP




---

### WPF and XAML

