# Class Notes

## Lecture 4 : Points to remember

### GUI Programming

Earlier GUI was ad-hoc and main goal was just making it work than optimising and presentable design  

We will be focusing on WPF and XAML:
- **WPF** : a UI framework for creating desktop clients application
- **XAML** : a declarative language that's based on XML , used extensively to build UX

---

### XAML

- Containers helps to group controls or other containers

- Containers include grid , stackpanel

- Controls helps to take actions and interact with the user

- Controls include button , scroll bar , progress bar , dropdown etc

- Controls and Containers have Properties which can be set , like background , margin , alignment etc

- There are also events like click which calls a function

- **WPF** - Windows Presentation Framework is the framework in which the `code behind` is running for `GUI_Demo`.


```text
ShortCut :

<TextBlock></TextBlock> can be defined as <TextBlock/> if nothing is inside the object 
```

---

### Coding Guildlines

- Code needs to be mainatable
- `.editorconfig` will give you errors , warnings and messaged when linked with solution.
- Make sure to have 0 errors and minimize warnings

---

### Testing

- All line of code should be tested
- Type of tests :
    1. Unit tests
    1. Integration tests
    1. End-to-End tests
    1. Stress tests
- Testing should focus on : 
    1. Functionality 
    1. Error
    1. Performance
    1. Globalization
    1. Security
    1. User experience
    1. Stree / Durability / Reliability 
    1. Portability 
    1. Localisation 
    1. Smoke
    1. Boundary
    1. Cost / resources
    1. Maintance 
- Try to have 100% code coverage and 100% branch coverage
- `MS test library` for testing

> **Def** > cyclomatic complexity : naively no of conditions/branching in your functions 

---

### Mock-Object Testing 
- MOQ - most common used mocking framework 
- Substitute and simulate objects that the components in test deal with
- This is typically done to enable testing various scenarios


---
### Home Work (Not Graded)

- Learn more about Design Patterns be through with it

- Not madatory but for learning if needed you can implement all the 23 design patterns

- read about coding & testing guidlines


