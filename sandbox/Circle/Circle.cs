class Circle
{
  private double _radius;

  public Circle()
  {
    _radius = 1.0;
  }

  public Circle(double radius)
  {
    SetRadius(radius);
  }

  public double GetArea()
  {
    return Math.Pow(_radius, 2) * 3.14159;

  }

  public double GetCircumference()
  {
    return _radius * 2 * 3.14159;
  }

  private void SetRadius(double radius)
  {
    if (radius <= 0.0)
    {
      _radius = 1.0;
      Console.WriteLine("Error: radius must be larger than 0, setting to default of 1.0");
    }
    else
    {
      _radius = radius;
    }
  }

  public double GetRadius()
  {
    return _radius;
  }
}