# Class Notes

## Lecture 6 : Points to remember

### Serial Execution 

- **One operation at a time:** CPU executes instructions sequentially, one after another.
- **Single processing flow:** Each instruction must generally finish before the next instruction is executed.
- **Time complexity:** For *n* operations, serial execution typically takes *\(O(n)\)* time.


```csharp
class Test{
    private int i = 0;

    // the function is guaranteed to return 2 during serial execution

    void SimpleFunc(){
        i = i + 1;
        i = i + 1; 
    }
}
```
In a multithreaded environment, threads may access `i` at the same time, causing race conditions and potentially producing a value other than 2.


> **Key idea** :  Shared data + simultaneous access which can lead to possibility of a **race condition**.

---

### Why Do We Need Multithreading?

- Sequential execution is suitable for many batch-processing systems, where tasks can be completed one after another.
- However, in a real-world OS , we usually need to run multiple applications seemingly at the same time.
- For example, a user may want to use *Notepad* while an *MP3 player* is playing music.

#### Time Sharing

The operating system achieves this by giving each process/thread a small amount of CPU time.

```text
CPU
 ↓
Notepad → MP3 Player → Browser → Notepad → MP3 Player → ...
```

- The CPU rapidly switches between tasks.
- This switching is called *context switching*.
- The technique of sharing CPU time among multiple processes/threads is called *time sharing*.

<br>

---

### Processes

A process is a program that is currently being executed.

- A process provides the resources and environment required for execution.
- A process contains at least one thread.
- The first thread created when a process starts is commonly called the primary/main thread.
- Threads within a process share many of the process's resources, especially its address space.

<br>

---

### 5. Threads

A thread is the smallest unit of execution that can be independently scheduled by the operating system.

- A thread is an entity that can be scheduled for execution.
- Threads perform the actual execution of instructions within a process.
- Threads belonging to the same process share the process's memory space.
- Threads can access shared data and resources.
- Threads have their own execution state, program counter, and stack.

### Process vs Thread

| Process                      | Thread                                                |
| ---------------------------- | ----------------------------------------------------- |
| Provides resources           | Performs execution                                    |
| Has its own address space    | Shares address space with threads in the same process |
| Relatively heavyweight       | Relatively lightweight                                |
| Contains one or more threads | Exists within a process                               |
| Resource container           | Unit of execution                                     |
|

#### Race Condition 
A situation where multiple threads access and modify shared data simultaneously, causing the final result to depend on the order/timing of execution.


---

### Home Work (Not Graded)

- Try implementing a Threading and Lock example in C#

<br>

---

