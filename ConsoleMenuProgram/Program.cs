using ConsoleMenu;

public class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();

        menu.AddOption("Hello")
            .AddOption("This is ConsoleMenu")
            .AddExitOption("Exit")
            .Configure()
            .SetCursorVisible(false)
            .SetUsePointer(true)
            .SetUseNumeration(true)
            .SetNumerationStartIndex(1);

        menu.Loop();
    }
}