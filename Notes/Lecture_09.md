# Class Notes

## Lecture 9 : Points to remember

### Multi-Threading (Again)

#### Mutex and Lock

A **Mutex** is used to ensure that only one thread can access a shared resource at a time.

```csharp
m.Enter();

m.Exit();
```

- `Enter()`: Acquires the mutex.
- `Exit()`: Releases the mutex.

**Lock** is a primitive built on top of `Monitor`. When we use `lock(o)` in C#, the compiler uses `Monitor` internally to ensure mutual exclusion.

> **Note:** We cannot lock integers directly; we should lock objects.

---

### Reader-Writer Lock

Consider a `Stream` class, such as a memory stream, with two functions: `Read()` and `Write()`.

We have three threads:
- One writer thread
- Two reader threads

We want to perform `s.Write()` and `s.Read()` safely using a **Reader-Writer Lock**.

The main idea is to allow:
- Multiple readers to read simultaneously.
- Only one writer to write at a time.
- A writer should not modify the resource while readers are accessing it.

For example, we may have 7 readers and 2 writers.

#### Reader-Writer Lock (Pseudo Code)

```csharp
class RWLock
{
    int n = 0;
    Mutex m;

    WriterAcquire()
    {
        m.Enter();
    }

    WriterRelease()
    {
        m.Exit();
    }

    ReaderAcquire()
    {
        lock (n);
        n++;

        if (n == 1)
        {
            m.Enter();
        }

        unlock(n);
    }

    ReaderRelease()
    {
        lock (n);
        n--;

        if (n == 0)
        {
            m.Exit();
        }

        unlock(n);
    }
}
```

**Working:**
- `n` keeps track of the number of readers.
- The first reader acquires the mutex to prevent writers from accessing the resource.
- Other readers can enter while the first reader holds the mutex.
- The last reader releases the mutex, allowing a writer to proceed.
- Writers acquire the mutex before accessing the resource.

> **Note:** The above is pseudocode to understand the concept. In actual C#, `lock(n)` is invalid because integers cannot be used as lock objects. A separate object should be used for synchronization.

#### Reader-Writer Lock and Starvation

A writer may starve if readers continuously acquire the lock before the writer gets a chance to write.

**TODO:** Improve the reader-writer lock so that when a writer is starving, no more than 3 readers can hold the lock. This introduces a limit on reader access to help prevent writer starvation.

---

### Inter-Process Communication (IPC)

Processes cannot directly share their data without using operating-system-supported mechanisms. IPC is an operating system concern.

- IPC allows different processes to exchange data.
- Different operating systems may provide different IPC mechanisms.
- An IPC implementation on Windows may not work directly on Linux.

#### Question: Serializing a Linked List

Consider a singly linked list:

```csharp
class Node
{
    int val;
    Node* next;
}
```

How do we serialize this linked list into bytes?

**Hint:** XML Serializer.

Serialization converts an object's data into a format that can be stored or transmitted. For a linked list, we need to represent the nodes and their relationships in a serializable format.

---

### Inter-Object Communication

Inter-Object Communication allows objects to communicate across processes or devices.

- We can define an `INode` interface to specify the operations that an object exposes.
- An operating system can provide mechanisms to make an object accessible remotely, similar to a **Remote Procedure Call (RPC)**.
- Marshalling involves preparing parameters and objects for communication between processes. Serialization is commonly part of this process.

**Important:** Ask Raagam for notes.

#### Homework

- Implement Inter-Object Communication using Java RPC, WCF, or .NET remoting.
- WCF was mentioned as the preferred option.

---

### Serialized Message Passing

**Question:** What are the advantages of serialized message passing?

Serialized messages allow data to be exchanged between processes or devices in a standard format.

---

### Advantages and Disadvantages of Inter-Object Communication

**Advantages:**
- Simplifies code when communicating with remote or non-local objects.
- Hides some of the underlying communication details from the caller.

**Disadvantages:**
- May not support a priority queue by default.
- There may not be a single point of exit or centralized control over the communication flow.