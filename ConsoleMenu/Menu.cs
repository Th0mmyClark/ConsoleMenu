namespace ConsoleMenu;

public class Menu
{
    private int _selectedElement = 0;
    private bool _isActive = true;

    private List<MenuOption> _options = new();
    private Dictionary<InputAction, ConsoleKey> _keyBindings;
    private Dictionary<InputAction, Action> _actionsBinding;

    public ConsoleColor DefaultBackgroundColor { get; set; } = ConsoleColor.Black;
    public ConsoleColor DefaultTextColor { get; set; } = ConsoleColor.White;
    public ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleColor.White;
    public ConsoleColor SelectedTextColor { get; set; } = ConsoleColor.Black;

    public Menu()
    {
        _keyBindings = new()
        {
            { InputAction.MoveUp, ConsoleKey.UpArrow },
            { InputAction.MoveDown, ConsoleKey.DownArrow },
            { InputAction.Execute, ConsoleKey.Enter }
        };

        _actionsBinding = new()
        {
            { InputAction.MoveUp, OnMoveUpPressed },
            { InputAction.MoveDown, OnMoveDownPressed },
            { InputAction.Execute, OnExecutePressed }
        };
    }

    public Menu SetCursorVisible(bool isVisible)
    {
        Console.CursorVisible = isVisible;
        return this;
    }

    public Menu AddExitOption(string header)
    {
        return AddOption(header, StopLoop);
    }

    public Menu AddOption(string header, Action onClick)
    {
        var option = new MenuOption(header, onClick);

        _options.Add(option);
        return this;
    }

    public Menu ClearOptions()
    {
        _options.Clear();
        return this;
    }

    public Menu BindKey(ConsoleKey key, InputAction action)
    {
        _keyBindings[action] = key;
        return this;
    }

    public Menu BindCallback(InputAction action, Action callback)
    {
        _actionsBinding[action] = callback;
        return this;
    }

    public void Loop()
    {
        while (_isActive)
        {
            Draw();
            var key = GetInput();

            if (!_keyBindings.ContainsValue(key))
                continue;

            var act = GetInputActionByKey(key);
            var callback = _actionsBinding[act];

            callback();
        }
    }

    public void StopLoop() { _isActive = false; }

    private void Draw()
    {
        Console.Clear();

        for (var i = 0; i < _options.Count; i++)
        {
            if (i == _selectedElement)
                SetColor(true);

            Console.WriteLine(_options[i].Header);
            SetColor(false);
        }
    }

    private void SetColor(bool isSelected)
    {
        Console.BackgroundColor = isSelected ? SelectedBackgroundColor : DefaultBackgroundColor;
        Console.ForegroundColor = isSelected ? SelectedTextColor : DefaultTextColor;
    }

    private ConsoleKey GetInput() => Console.ReadKey(false).Key;

    private InputAction GetInputActionByKey(ConsoleKey key)
    {
        return _keyBindings.Keys.ToList()[_keyBindings.Values.ToList().IndexOf(key)];
    }

    private void OnMoveUpPressed()
    {
        if (_selectedElement - 1 >= 0)
            _selectedElement--;
    }

    private void OnMoveDownPressed()
    {
        if (_selectedElement + 1 < _options.Count)
            _selectedElement++;
    }

    private void OnExecutePressed() { _options[_selectedElement].Execute(); }

    public enum InputAction
    {
        MoveUp,
        MoveDown,
        Execute
    }
}