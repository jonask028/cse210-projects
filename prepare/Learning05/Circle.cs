class Circle(int radius, string color) : Shape(color)
{
  private readonly int _radius = radius;

  public override double GetArea()
  {
    return Math.PI * _radius * _radius;
  }
}