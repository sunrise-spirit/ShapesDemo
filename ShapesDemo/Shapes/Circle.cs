namespace ShapesDemo.Shapes;

public sealed class Circle : ShapeBase
{
    public double Radius { get; }

    public Circle(double radius) : base("Круг")
    {
        EnsurePositive(radius, nameof(radius));
        Radius = radius;
    }

    public override double Area => Math.PI * Radius * Radius;
    public override double Perimeter => 2 * Math.PI * Radius;

    public override void Draw()
    {
        int r = (int)Math.Clamp(Radius, 2, 10);

        // символы в консоли примерно в 2 раза выше, чем шире, поэтому по X берём удвоенный диапазон и делим координату пополам
        for (int y = -r; y <= r; y++)
        {
            for (int x = -2 * r; x <= 2 * r; x++)
            {
                double dx = x / 2.0;
                double distance = Math.Sqrt(dx * dx + y * y);
                Console.Write(Math.Abs(distance - r) < 0.5 ? "*" : " ");
            }
            Console.WriteLine();
        }
    }
}
