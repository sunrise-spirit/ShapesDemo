namespace ShapesDemo.Shapes;

public enum ShapeType
{
    Circle,
    Square,
    Rectangle,
    Triangle,
    RegularPolygon
}

public static class ShapeFactory
{
    public static IShape Create(ShapeType type, params double[] parameters) => type switch
    {
        ShapeType.Circle => new Circle(parameters[0]),
        ShapeType.Square => new Square(parameters[0]),
        ShapeType.Rectangle => new Rectangle(parameters[0], parameters[1]),
        ShapeType.Triangle => new Triangle(parameters[0], parameters[1], parameters[2]),
        ShapeType.RegularPolygon => new RegularPolygon((int)parameters[0], parameters[1]),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестный тип фигуры")
    };
}
