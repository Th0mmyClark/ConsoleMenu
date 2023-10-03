namespace ConsoleMenu;

public class Menu
{
    private int _selectedElement;
    private bool _isActive = true;

    private readonly MenuConfiguration _configuration;
    private readonly List<MenuOption> _options = new();

    public Menu()
    {
        _configuration = new MenuConfiguration(OnMoveUpPressed, OnMoveDownPressed, OnExecutePressed);
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

    public Menu AddOption(MenuOption option)
    {
        _options.Add(option);
        return this;
    }

    public Menu ClearOptions()
    {
        _options.Clear();
        return this;
    }

    public MenuConfiguration Configure() => _configuration;

    public void Loop()
    {
        while (_isActive)
        {
            Draw();
            var key = GetInput();

            if (!_configuration.ContainsKeyInBindings(key))
                continue;

            var act = _configuration.GetInputActionByKey(key);
            var callback = _configuration.ActionsBinding[act];

            callback();
        }
    }

    private void StopLoop() { _isActive = false; }

    private void Draw()
    {
        Console.Clear();

        for (var i = 0; i < _options.Count; i++)
        {
            if (i == _selectedElement)
            {
                SetColor(true);
                
                if(_configuration.UsePointer)
                    Console.Write(_configuration.PointerStyle);
            }
            else
            {
                if(_configuration is { UsePointer: true, ShiftAllItems: true })
                    Console.Write(new string(' ', _configuration.PointerStyle.Length));
            }
            
            if(_configuration.UseNumeration)
                Console.Write(_configuration.NumerationFormat, i + _configuration.NumerationStartIndex);
            
            Console.WriteLine(_options[i].Header);
            SetColor(false);
        }
    }

    private void SetColor(bool isSelected)
    {
        Console.BackgroundColor = isSelected ? _configuration.SelectedBackgroundColor : _configuration.DefaultBackgroundColor;
        Console.ForegroundColor = isSelected ? _configuration.SelectedTextColor : _configuration.DefaultTextColor;
    }

    private ConsoleKey GetInput() => Console.ReadKey(false).Key;

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