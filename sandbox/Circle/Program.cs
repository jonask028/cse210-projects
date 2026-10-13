class Program
{
  static void Main()
  {
    Console.WriteLine("Hello Circle World!");

    Circle myCircle = new(-5);

    double area = myCircle.GetArea();
    Console.WriteLine(area);

  }
}