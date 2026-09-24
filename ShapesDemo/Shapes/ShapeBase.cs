namespace ShapesDemo.Shapes;


public abstract class ShapeBase : IShape, IDrawable
{
    public string Name { get; }

    protected ShapeBase(string name)
    {
        Name = name;
    }

    public abstract double Area { get; }
    public abstract double Perimeter { get; }

    public abstract void Draw();

    public override string ToString() =>
        $"{Name,-14} | Площадь: {Area,8:F2} | Периметр: {Perimeter,8:F2}";

    protected static void EnsurePositive(double value, string paramName)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(paramName, "Значение должно быть положительным.");
    }
}
