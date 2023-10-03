# ConsoleMenu

## About the project
This is a simple console menu that allows you to navigate through its items using preconfigured keys. Each menu item has an Action that will be called when the menu item is executed

## How it works
There are two classes at the heart of menu:
- Menu
- MenuOption
  
MenuOption is used to describe the menu options, title and callable callback. Menu describes the menu itself, stores all items, and has methods for fine-tuning it.

## Documentation

Example 1.
```c#
var menu = new Menu();

//Each customizing method returns a Мenu
//Thanks to which it is possible to customize the Мenu in a chain
menu.AddOption("Hello", () => { })
    .AddOption("This is ConsoleMenu", () => { })
    .AddExitOption("Exit")
    .SetCursorVisible(false)
    .Loop();
```

- The AddOption method adds a new item to the end of the Menu, specifying either a MenuOption object or a title and callback.
- The AddExitOption method adds an item to the end of the Menu to terminate the current menu execution.
- The SetCursorVisible method configures the visibility of the console carriage in the Menu.
- The Loop method starts the Menu handler and passes control.
