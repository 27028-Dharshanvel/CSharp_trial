using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Helpers;
using Assignment2.Models;

namespace Assignment2.Views
{
    /// <summary>
    /// Console View for Shape Menu.
    /// </summary>
    internal static class ConsoleShapeMenu
    {
        /// <summary>
        /// Displays shape Menu.
        /// </summary>
        public static void ShowShapeMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine(@"----- Shape Menu -----
1. Rectangle
2. Circle
3. Back");

                ShapeMenu choice = (ShapeMenu)InputReader.ReadInt("Enter your choice : ", "Choice", 1, 4, 3, -1);
                if ((int)choice == -1)
                {
                    Console.ReadKey();
                    choice = ShapeMenu.Back;
                }

                switch (choice)
                {
                    case ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Colour = InputReader.ReadString("Enter colour of the shape : ", "Colour", 10, 3, "@@@");
                        if (rect.Colour == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.Length = InputReader.ReadDouble("Enter the Length : ", "Length", 1, 1000000, 3, -1);
                        if (rect.Length == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.Width = InputReader.ReadDouble("Enter the Width : ", "Width", 1, 1000000, 3, -1);
                        if (rect.Width == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.PrintDetails();
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Circle:
                        ShapeModels.Circle circle = new ();
                        circle.Colour = InputReader.ReadString("Enter colour of the shape : ", "Colour", 10, 3, "@@@");
                        if (circle.Colour == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        circle.Radius = InputReader.ReadDouble("Enter the Radius : ", "Radius", 1, 1000000, 3, -1);
                        if (circle.Radius == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        circle.PrintDetails();
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Back:
                        back = true;
                        break;

                    default:
                        InputReader.Error("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
