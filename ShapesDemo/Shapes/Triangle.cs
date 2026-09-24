namespace ShapesDemo.Shapes;


public sealed class Triangle : ShapeBase
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC) : base("Треугольник")
    {
        EnsurePositive(sideA, nameof(sideA));
        EnsurePositive(sideB, nameof(sideB));
        EnsurePositive(sideC, nameof(sideC));

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Треугольник с такими сторонами не существует " +
                                         "(нарушено неравенство треугольника).");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double Perimeter => SideA + SideB + SideC;

    public override double Area
    {
        get
        {
            double s = Perimeter / 2; // полупериметр
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
    }

    public override void Draw()
    {
        
        const int height = 8;
        for (int row = 1; row <= height; row++)
        {
            string spaces = new string(' ', height - row);
            string stars = new string('*', 2 * row - 1);
            Console.WriteLine(spaces + stars);
        }
    }
}
