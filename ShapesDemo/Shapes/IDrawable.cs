namespace ShapesDemo.Shapes;

/// <summary>
/// можно заменить на отрисовку на Canvas в WPF/AvaloniaUI, не трогая бизнес-логику расчётов.
/// </summary>
public interface IDrawable
{
    void Draw();
}
