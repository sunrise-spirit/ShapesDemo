namespace ShapesDemo.Shapes;

public class Rectangle : ShapeBase
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height) : this(width, height, "Прямоугольник")
    {
    }

    // protected-конструктор с именем нужен, чтобы Square мог переиспользовать
    // логику валидации/расчётов, но подписаться собственным именем.
    protected Rectangle(double width, double height, string name) : base(name)
    {
        EnsurePositive(width, nameof(width));
        EnsurePositive(height, nameof(height));
        Width = width;
        Height = height;
    }

    public override double Area => Width * Height;
    public override double Perimeter => 2 * (Width + Height);

    public override void Draw()
    {
        int w = (int)Math.Clamp(Width, 2, 50);
        int h = (int)Math.Clamp(Height, 2, 20);

        for (int row = 0; row < h; row++)
        {
            for (int col = 0; col < w; col++)
            {
                bool border = row == 0 || row == h - 1 || col == 0 || col == w - 1;
                Console.Write(border ? "*" : " ");
            }
            Console.WriteLine();
        }
    }
}
