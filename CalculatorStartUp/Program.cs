﻿using System;
using CalculatorLibrary;
namespace CalculatorStartUp
{
    public static class Program
        {
            private static void Main()
            {
                // Display title as the C# console calculator app.
                Console.WriteLine("Console Calculator in C#\r");
                Console.WriteLine("------------------------\n");
                Calculator calculator = new();
                
                while (true)
                {
                    // Declare variables and set to empty.

                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter: ");
                    var numInput1 = Console.ReadLine();

                    double cleanNum1;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter: ");
                    var numInput2 = Console.ReadLine();

                    double cleanNum2;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");

                    var option = Console.ReadLine();

                    try
                    {
                        var result = calculator.DoOperation(cleanNum1, cleanNum2, option);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " +
                                          e.Message);
                    }

                    Console.WriteLine("------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write(
                        "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n") break;

                    Console.WriteLine("\n"); // Friendly linespacing.
                }
                
                // And call to close the JSON writer before return
                calculator.Finish();
            }
        }
    }