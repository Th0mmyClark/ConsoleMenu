namespace ConsoleMenu;

public class MenuOption
{
    private readonly Action _onClick;
    public string Header { get; private set; }

    public MenuOption(string header, Action onClick)
    {
        Header = header;
        _onClick = onClick;
    }

    public void Execute()
    {
        _onClick?.Invoke();
    }
}