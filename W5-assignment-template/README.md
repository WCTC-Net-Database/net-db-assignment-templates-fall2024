## Week 5 Assignment: Refactor ConsoleRPG to Adhere to LSP and Implement New Behaviors

### Objective

The goal of this assignment is to refactor the existing `ConsoleRPG` program to follow the Liskov Substitution Principle (LSP) and apply the Interface Segregation Principle (ISP) by creating new, focused interfaces and implementing additional behaviors. You will:

1. Remove the `Fly()` method from `IEntity` and create an appropriate behavior class to handle this functionality.
2. Implement at least two new classes with their own unique behaviors (following ISP).
3. Integrate these new behaviors into the `GameEngine`.

### Instructions

#### Part 1: Refactor `IEntity` to Fix LSP Violation

1. **Remove `Fly()` from `IEntity`**: The current design violates the Liskov Substitution Principle because not all entities can fly.
2. **Create `IFlyable` Interface**:
   - Define an `IFlyable` interface that includes the `Fly()` method.
   - Update the `Ghost` class to implement `IFlyable`.
   - Use a delegate or behavior class to encapsulate the `Fly()` functionality.
3. **Update `GameEngine`**:
   - Modify `GameEngine` to use the new `IFlyable` interface correctly, checking if an entity can fly before calling `Fly()`.

#### Part 2: Create Additional Classes and Behaviors

1. **Design Two New Classes**:
   - Create at least two new classes that extend `IEntity` and implement unique behaviors.
   - You are free to design any behaviors or classes you like. Some examples include:
     - **Archer** with an `IShootable` interface that defines a `Shoot()` method.
     - **Mage** with an `ICastable` interface that defines a `CastSpell(string spellName)` method.
   - Use the **Interface Segregation Principle (ISP)** to design small, focused interfaces for these new behaviors.

2. **Implement the New Behaviors**:
   - Implement these behaviors in the new classes you create.
   - Ensure each behavior is appropriately encapsulated and extendable.

3. **Integrate with `GameEngine`**:
   - Update the `GameEngine` to support the new behaviors.
   - Ensure the `GameEngine` can interact with entities dynamically using these new behaviors.

#### Examples of New Behaviors

- **IShootable**:
  - Interface: `public interface IShootable { void Shoot(); }`
  - Implementation in `Archer`: Defines `Shoot()` to allow the archer to attack with a bow.
- **ICastable**:
  - Interface: `public interface ICastable { void CastSpell(string spellName); }`
  - Implementation in `Mage`: Defines `CastSpell(string spellName)` to allow the mage to perform magic.

#### Part 3: Testing and Demonstration

1. **Test Your Code**: 
   - Make sure your new behaviors work correctly with the `GameEngine`.
   - Test the existing `Character`, `Ghost`, and your new classes to ensure they adhere to the Liskov Substitution Principle.

2. **Demonstrate**:
   - Run the `GameEngine` with different entities to demonstrate the new behaviors in action.
   - Show how the `GameEngine` can interact with the entities using their respective interfaces.

### Stretch Goals

1. **Implement the Command Pattern**:
   - Enhance your code by implementing a simplified **Command Pattern** for one or more behaviors.
   - **Explanation**:
     - The Command Pattern encapsulates a request as an object, allowing you to parameterize clients with queues, logs, or undoable operations.
     - To simplify this:
       1. **Create a Command Interface**: Define a single interface, such as `ICommand`, with a method `Execute()`.
       2. **Implement Concrete Command Classes**: Create classes like `FlyCommand` or `AttackCommand` that implement `ICommand` and encapsulate the logic for each action.
       3. **Modify the Game Engine**: Adjust the `GameEngine` to hold a list of commands and execute them sequentially.
   - **Benefits**:
     - This approach enables you to encapsulate behaviors as commands, providing flexibility to execute, queue, or log actions in the game engine.

### Submission

- **Code Submission**:
  - Refactor the existing code and add your new classes in the provided project.
  - Ensure your project builds and runs successfully.
- **Documentation**:
  - Update the README file to include a brief description of each new behavior and how they are used in the game.
- **GitHub**:
  - Push your changes to the GitHub Classroom repository.

### Rubric (100 Points Total)

| Criteria                                  | Points |
|-------------------------------------------|--------|
| **Refactoring for LSP**                   |        |
| - Correctly removed `Fly()` from `IEntity` and created an `IFlyable` interface. | 20     |
| - Updated `GameEngine` to use the new `IFlyable` interface. | 10     |
| **Implementing New Behaviors**            |        |
| - Created at least two new classes with unique behaviors. | 20     |
| - Designed and implemented small, focused interfaces for each new behavior. | 10     |
| - Integrated new behaviors into `GameEngine` without violating LSP. | 10     |
| **Integration and Testing**               |        |
| - Successfully integrated new behaviors into the game logic. | 10     |
| - Demonstrated that the program runs and behaves as expected. | 10     |
| **Code Quality and Documentation**        |        |
| - Code is clean, well-documented, and follows best practices. | 10     |
| **Stretch Goal: Implement Command Pattern** |        |
| - Successfully implemented a simplified Command Pattern for one or more behaviors. | +10    |

Here are some resource links to help students better understand the concepts covered in the assignment:

### Resources
- [Interfaces in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) - Official Microsoft documentation on using interfaces in C#.
- [Type Casting in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions) - A guide to casting and type conversions in C#.

#### SOLID Principles
- [SOLID Principles: A Guide for Developers](https://www.freecodecamp.org/news/solid-principles-every-developer-should-know/) - A detailed guide covering all the SOLID principles with examples.
- [Liskov Substitution Principle Explained](https://stackify.com/solid-design-liskov-substitution-principle/) - An easy-to-understand explanation of LSP with examples.
- [LSP in C#](https://www.tutorialsteacher.com/csharp/liskov-substitution-principle) - A tutorial focused on implementing LSP in C#.
- [Interface Segregation Principle (ISP)](https://www.baeldung.com/cs/interface-segregation-principle) - A guide to understanding and implementing ISP.
- [Interface Segregation in C#](https://www.tutorialsteacher.com/csharp/interface-segregation-principle) - A detailed tutorial with examples in C#.

#### Stretch Goal: Command Pattern
- [Command Design Pattern in C#](https://refactoring.guru/design-patterns/command/csharp/example) - A comprehensive guide on implementing the Command Pattern in C#.
- [The Command Pattern Explained](https://www.dofactory.com/net/command-design-pattern) - An overview of the Command Pattern with examples in .NET.
