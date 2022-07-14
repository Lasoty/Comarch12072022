using ComarchZadania.Console;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine(" 1. Dodawanie");
        Console.WriteLine(" 2. Odejmowanie");
        Console.WriteLine(" 3. Mnożenie");
        Console.WriteLine(" 4. Dzielenie");
        Console.Write("Podaj nr pozycji menu: ");
        
        if (int.TryParse(Console.ReadLine(), out int wybor))
        {
            Calculator calculator = new Calculator();
            int x, y;
            float result;

            switch (wybor)
            {
                case 1:
                    GetXY(out x, out y);
                    result = calculator.Add(x, y);
                    Console.WriteLine($"Wynik dodawania {x} oraz {y} to {result}.");
                    break;
                case 2:
                    GetXY(out x, out y);
                    result = calculator.Subtract(x, y);
                    Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {result}.");
                    break;
                case 3:
                    GetXY(out x, out y);
                    result = calculator.Multiply(x, y);
                    Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {result}.");
                    break;
                case 4:
                    GetXY(out x, out y);
                    result = calculator.Dividy(x, y);
                    Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {result}.");
                    break;
                default:
                    ShowError("Wybrana pozycja menu jest spoza zakresu.");
                    break;
            }
        }
        else
        {
            ShowError("Wybrana pozycja menu jest nieprawidłowa.");
        }


    }

    private static void GetXY(out int x, out int y)
    {
        Console.Write("Podaj X: ");
        x = int.Parse(Console.ReadLine());
        Console.Write("Podaj y: ");
        y = int.Parse(Console.ReadLine());
    }

    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
