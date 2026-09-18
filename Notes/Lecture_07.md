# Class Notes

## Lecture 7 : Points to remember

### Model-View-ViewModel (MVVM)

- **Model** - Has the functional logic
- **View** - It is the UX (usually XAML)
- **ViewModel** - Connects the data processing to the UX

<br>

---

### Thread States while Scheduling

- Running 
- Blocked/Suspended (during I/O operations)
- Ready to Run 

```
In .NET provides Managed Threads , which gives a nice interface to schedule and manage threads
```
---

### Multithreading

#### Benefits

- **Concurrency** : Multiple tasks can execute concurrently.
- **UI Responsiveness** : Keeps the UI responsive by moving long-running tasks to background threads.
- **Multicore Friendly** : Can utilize multiple CPU cores for parallel execution.

#### Challenges

- **Complexity** : Difficult to develop, debug, and understand.
- **Shared Resource Conflicts** : Multiple threads accessing the same resource can cause problems.

#### Common issues: 

- **Race Condition** : Result depends on the unpredictable order of thread execution.
- **Starvation** : A lower-priority thread may wait indefinitely because other threads keep getting CPU/resources.
- **Priority Inversion** : A high-priority thread is blocked because a lower-priority thread holds a resource it needs.
- **Deadlock** : Two or more threads wait indefinitely for resources held by each other.

<br>

---

### Thread Synchronization

**Thread synchronization** is the process of controlling access to shared resources so that multiple threads do not interfere with each other.

#### Synchronization Approaches

- **Interlocked Operations** : Performs simple operations atomically.
- **Critical Section** : Allows only one thread at a time to execute a section of code.
- **Semaphore** : Controls access to a resource using a counter; allows multiple threads up to a specified limit.
- **Monitor / Lock** : Ensures mutual exclusion when accessing shared resources.
- **Events** : Allows threads to signal and wait for specific conditions or actions.

<br>

```
There are 3 catergories in synchronisation :

1. Semaphore , Critical Section , Mutex , Lock , Monitor 
2. InterLock Operation 
3. Events - (auto / manual reset event)
```

---

### Home Work

- Learn about MVVM from a simple project from Sir
- complete GUI Reader 
- Study the code of (https://github.com/chittur/multithreading-demo)

<br>

---