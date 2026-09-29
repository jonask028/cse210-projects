class Program
{
  static void Main()
  {
    Console.WriteLine("Hello Circle World!");

    Circle myCircle = new()
    {
      _radius = 10
    };

    double area = myCircle.GetArea();
    Console.WriteLine(area);

  }
}