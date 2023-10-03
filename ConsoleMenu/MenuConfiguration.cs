namespace ConsoleMenu;

public class MenuConfiguration
{
    public Dictionary<InputAction, ConsoleKey> KeyBindings { get; }
    public Dictionary<InputAction, Action> ActionsBinding { get; }
    
    public bool UseNumeration { get; private set; }
    public string NumerationFormat { get; private set; } = "[{0}] ";
    public int NumerationStartIndex { get; private set; }
    public bool UsePointer { get; private set; }
    public string PointerStyle { get; private set; } = "-> ";
    public bool ShiftAllItems { get; private set; } = true;
    
    public ConsoleColor DefaultBackgroundColor { get; private set; } = ConsoleColor.Black;
    public ConsoleColor DefaultTextColor { get; private set; } = ConsoleColor.White;
    public ConsoleColor SelectedBackgroundColor { get; private set; } = ConsoleColor.White;
    public ConsoleColor SelectedTextColor { get; private set; } = ConsoleColor.Black;

    internal MenuConfiguration(Action onMoveUp, Action onMoveDown, Action onExecute)
    {
        KeyBindings = new()
        {
            { InputAction.MoveUp, ConsoleKey.UpArrow },
            { InputAction.MoveDown, ConsoleKey.DownArrow },
            { InputAction.Execute, ConsoleKey.Enter }
        };

        ActionsBinding = new()
        {
            { InputAction.MoveUp, onMoveUp },
            { InputAction.MoveDown, onMoveDown },
            { InputAction.Execute, onExecute }
        };
    }
    

    public MenuConfiguration SetUseNumeration(bool useNumeration)
    {
        UseNumeration = useNumeration;
        return this;
    }

    public MenuConfiguration SetNumerationFormat(string format)
    {
        NumerationFormat = format;
        return this;
    }

    public MenuConfiguration SetNumerationStartIndex(int startIndex)
    {
        NumerationStartIndex = startIndex;
        return this;
    }

    public MenuConfiguration SetUsePointer(bool usePointer)
    {
        UsePointer = usePointer;
        return this;
    }

    public MenuConfiguration SetPointerStyle(string pointerStyle)
    {
        PointerStyle = pointerStyle;
        return this;
    }

    public MenuConfiguration SetShiftAllItems(bool shiftItems)
    {
        ShiftAllItems = shiftItems;
        return this;
    }

    public MenuConfiguration SetDefaultBackgroundColor(ConsoleColor color)
    {
        DefaultBackgroundColor = color;
        return this;
    }
    
    public MenuConfiguration SetDefaultTextColor(ConsoleColor color)
    {
        DefaultTextColor = color;
        return this;
    }
    
    public MenuConfiguration SetSelectedBackgroundColor(ConsoleColor color)
    {
        SelectedBackgroundColor = color;
        return this;
    }
    
    public MenuConfiguration SetSelectedTextColor(ConsoleColor color)
    {
        SelectedTextColor = color;
        return this;
    }
    
    public MenuConfiguration SetCursorVisible(bool isVisible)
    {
        Console.CursorVisible = isVisible;
        return this;
    }
    
    public MenuConfiguration BindKey(ConsoleKey key, InputAction action)
    {
        KeyBindings[action] = key;
        return this;
    }

    public MenuConfiguration BindCallback(InputAction action, Action callback)
    {
        ActionsBinding[action] = callback;
        return this;
    }
    
    internal InputAction GetInputActionByKey(ConsoleKey key)
    {
        return KeyBindings.Keys.ToList()[KeyBindings.Values.ToList().IndexOf(key)];
    }

    internal bool ContainsKeyInBindings(ConsoleKey key)
    {
        return KeyBindings.ContainsValue(key);
    }
    
    public enum InputAction
    {
        MoveUp,
        MoveDown,
        Execute
    }
}