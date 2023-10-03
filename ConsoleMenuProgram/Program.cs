using ConsoleMenu;

public class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();

        menu.AddOption("Hello", () => { })
            .AddOption("This is ConsoleMenu", () => { })
            .AddExitOption("Exit")
            .SetCursorVisible(false)
            .Loop();
    }
}