class Square(int side, string color) : Shape(color)
{
  private readonly int _side = side;

  public override double GetArea()
  {
    return _side * _side * 1.0;
  }

}