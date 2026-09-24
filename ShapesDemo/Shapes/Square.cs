namespace ShapesDemo.Shapes;


public sealed class Square : Rectangle
{
    public double Side => Width;

    public Square(double side) : base(side, side, "Квадрат")
    {
    }
}
