class Rectangle(int length, int height, string color) : Shape(color)
{
  private readonly int _length = length;
  private readonly int _height = height;

  public override double GetArea()
  {
    return _length * _height * 1.0;
  }
}