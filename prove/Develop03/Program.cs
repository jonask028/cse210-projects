using System;

class Program
{
    static void Main(string[] args)
    {
        // I added a menu to create, display, load, and save scriptures. You can input your own scriptures to memorize and when hiding words it will write underscores in their place. You can also save scriptures and load them from a file.
        Menu mainMenu = new();
        mainMenu.ProcessMenu();
    }
}