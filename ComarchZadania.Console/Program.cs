using ComarchZadania.Console;
using System;

class Program
{
    public static void Main(string[] args)
    {
        bool isContinue;

        CarManager carManager = new CarManager();
        carManager.AddCar();

        do
        {
            ShowMenu();

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
                        try
                        {
                            result = calculator.Dividy(x, y);
                            Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {result}.");
                        }
                        catch (DivideByZeroException ex)
                        {
                            ShowError(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ShowError("Wystąpił nieprzewidziany wyjątek!");
                            throw;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj, który wyraz ciągu wibonacciego chcesz obliczyć.");
                        int n = int.Parse(Console.ReadLine());
                        result = calculator.Fibonacci(n);
                        Console.WriteLine($"{n}-ty wyraz ciągu to {result}.");
                        break;
                    case 6:
                        Console.WriteLine("Podaj jakieś liczby (rozdzielone spacją): ");
                        string numbersLine = Console.ReadLine();
                        string[] numbersString = numbersLine.Split(" ");
                        int[] data = new int[numbersString.Length];
                        int i = 0;
                        foreach (var item in numbersString)
                        {
                            data[i] = int.Parse(item);
                            i++;
                        }
                        int[] tab = calculator.Sort(data);
                        Console.WriteLine($"Wynik sortowania to: {string.Join(", ", tab)}");
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

            Console.ReadLine();
            Console.WriteLine("Czy chcesz jeszcze raz? [T | n]");
            isContinue = Console.ReadKey().Key != ConsoleKey.N;
        } while (isContinue);
    }

    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine(" 1. Dodawanie");
        Console.WriteLine(" 2. Odejmowanie");
        Console.WriteLine(" 3. Mnożenie");
        Console.WriteLine(" 4. Dzielenie");
        Console.WriteLine(" 5. Fibonacci");
        Console.WriteLine(" 6. Sortowanie");
        Console.Write("Podaj nr pozycji menu: ");
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
