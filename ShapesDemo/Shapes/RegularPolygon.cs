namespace ShapesDemo.Shapes;


public sealed class RegularPolygon : ShapeBase
{
    public int SidesCount { get; }
    public double SideLength { get; }

    public RegularPolygon(int sidesCount, double sideLength) : base($"{sidesCount}-угольник")
    {
        if (sidesCount < 3)
            throw new ArgumentOutOfRangeException(nameof(sidesCount),
                "Многоугольник должен иметь минимум 3 стороны.");
        EnsurePositive(sideLength, nameof(sideLength));

        SidesCount = sidesCount;
        SideLength = sideLength;
    }

    /// <summary>Радиус описанной окружности.</summary>
    public double CircumRadius => SideLength / (2 * Math.Sin(Math.PI / SidesCount));

    public override double Perimeter => SidesCount * SideLength;

    public override double Area =>
        (SidesCount * SideLength * SideLength) / (4 * Math.Tan(Math.PI / SidesCount));

    public override void Draw()
    {
        // Масштабируем так же, как круг: радиус описанной окружности — от 4 до 10 строк.
        int r = (int)Math.Clamp(Math.Round(CircumRadius), 4, 10);
        double scale = r / CircumRadius;
        var vertices = GetVertices().Select(v => (X: v.X * scale, Y: v.Y * scale)).ToArray();

        // Выводим только строки, которые занимает фигура, чтобы не было пустых строк снизу.
        int top = (int)Math.Floor(vertices.Min(v => v.Y));
        int bottom = (int)Math.Ceiling(vertices.Max(v => v.Y));

        // Как и у круга: символ в консоли вдвое выше, чем шире, поэтому по X шаг в полклетки.
        for (int y = top; y <= bottom; y++)
        {
            for (int x = -2 * r; x <= 2 * r; x++)
            {
                double distance = DistanceToOutline(vertices, x / 2.0, y);
                Console.Write(distance < 0.5 ? "*" : " ");
            }
            Console.WriteLine();
        }
    }

    public IEnumerable<(double X, double Y)> GetVertices()
    {
        double radius = CircumRadius;
        for (int i = 0; i < SidesCount; i++)
        {
            double angle = 2 * Math.PI * i / SidesCount - Math.PI / 2;
            yield return (radius * Math.Cos(angle), radius * Math.Sin(angle));
        }
    }

    /// <summary>Расстояние от точки до ближайшей стороны многоугольника.</summary>
    private static double DistanceToOutline((double X, double Y)[] vertices, double px, double py)
    {
        double min = double.MaxValue;
        for (int i = 0; i < vertices.Length; i++)
        {
            var a = vertices[i];
            var b = vertices[(i + 1) % vertices.Length];
            min = Math.Min(min, DistanceToSegment(a, b, px, py));
        }
        return min;
    }

    private static double DistanceToSegment((double X, double Y) a, (double X, double Y) b, double px, double py)
    {
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;

        // Проекция точки на отрезок, ограниченная его концами.
        double t = Math.Clamp(((px - a.X) * dx + (py - a.Y) * dy) / (dx * dx + dy * dy), 0, 1);
        double cx = a.X + t * dx - px;
        double cy = a.Y + t * dy - py;
        return Math.Sqrt(cx * cx + cy * cy);
    }
}
