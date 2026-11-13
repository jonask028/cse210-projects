using System;

class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new(3, "blue");
        Rectangle myRectangle = new(4, 5, "red");
        Circle myCircle = new(6, "purple");
        List<Shape> myShapes = [mySquare, myRectangle, myCircle];
        foreach (Shape shape in myShapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}