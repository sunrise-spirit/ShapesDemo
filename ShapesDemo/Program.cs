using ShapesDemo.Shapes;

var shapes = new List<IShape>
{
    ShapeFactory.Create(ShapeType.Circle, 6),
    ShapeFactory.Create(ShapeType.Square, 8),
    ShapeFactory.Create(ShapeType.Rectangle, 16, 5),
    ShapeFactory.Create(ShapeType.Triangle, 6, 6, 6),
    ShapeFactory.Create(ShapeType.RegularPolygon, 6, 3),
};

Console.WriteLine("Демонстрация фигур");

foreach (var shape in shapes)
{
    Console.WriteLine(shape); // ShapeBase.ToString()

    if (shape is IDrawable drawable)
    {
        drawable.Draw();
    }

    Console.WriteLine(new string('-', 40));
}

double totalArea = shapes.Sum(s => s.Area);
Console.WriteLine($"\nСуммарная площадь всех фигур: {totalArea:F2}");

try
{
    ShapeFactory.Create(ShapeType.Triangle, 1, 1, 10);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\nОжидаемая ошибка при некорректных данных: {ex.Message}");
}
