# ConsoleMenu

## About the project
This is a simple console menu that allows you to navigate through its items using preconfigured keys. Each menu item has an Action that will be called when the menu item is executed

## How it works
There are two classes at the heart of menu:
- Menu
- MenuOption
- MenuConfiguration
  
MenuOption is used to describe the menu options, title and callable callback. Menu describes the menu itself and stores all items. MenuConfiguration has methods for fine-tuning menu

## Usage

### Example 1. Creating menu
To create a menu, all you need to do is create an instance of the Menu class, add the necessary items using the AddOption and AddExitOption methods, and then call the Loop method to pass control to the Menu object

```c#
var menu = new Menu();

//Each AddOption method returns a Мenu
//Thanks to which it is possible to add multiply options in a chain
menu.AddOption("Hello")
    .AddOption("This is ConsoleMenu")
    .AddExitOption("Exit")

menu.Loop();
```

- AddOption method adds a new item to the end of the Menu, specifying either a MenuOption object or a title and callback
- AddExitOption method adds an item to the end of the Menu to terminate the current menu execution
- Loop method starts the Menu handler and passes control

### Example 2. Using callbacks
To add a callback function you need to pass Action as the second parameter of the AddOption method. This Action will be called when the corresponding menu item is selected

```c#
public static void Main(string[] args)
{
    var menu = new Menu();

    menu.AddOption("Hello", FirstAction)
        .AddOption("This is ConsoleMenu", SecondAction)
        .AddExitOption("Exit")
        .Configure()
        .SetCursorVisible(false)
        .SetUsePointer(true)
        .SetUseNumeration(true)
        .SetNumerationStartIndex(1);

    menu.Loop();
}

private static void FirstAction()
{
    //This method will be called when the first menu item is selected
}

private static void SecondAction()
{
    //This method will be called when the second menu item is selected
}
```

### Example 3. Customization
To customize the appearance of the menu, the Configure method is used to start the configuration process. This method is followed by calls to configuration methods for more precise customization

```c#
var menu = new Menu();

//Each method from MenuConfiguration class returns a MenuConfiguration itselfs
//Thanks to which it is possible to configure Menu in a chain
menu.AddOption("Hello", FirstAction)
    .AddOption("This is ConsoleMenu", SecondAction)
    .AddExitOption("Exit")
    .Configure()
    .SetCursorVisible(false)
    .SetUsePointer(true)
    .SetUseNumeration(true)
    .SetNumerationStartIndex(1);

menu.Loop();
```

- Configure method starts the menu configuration process, it returns a MenuConfiguration object for further customization.
- SetCursorVisible method configures the visibility of the console carriage in the Menu.
- SetUsePointer is used to set the pointer to display to the left of the selected menu item.
- SetUseNumeration is used to customize the display of menu item numbers to the left of the menu items themselves.
- SetNumerationStartIndex is used to set the start index of the first menu item, provided UseNumeration = true
