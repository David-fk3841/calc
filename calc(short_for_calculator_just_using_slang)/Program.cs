using System.Collections;
using System.Transactions;

namespace calc_short_for_calculator_just_using_slang_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            int Choice;
            Console.Clear();
            Console.WriteLine("Select a function using 1, 2, 3 or 4");
            Console.WriteLine("1. Basic Calculator\n2. Cryptography\n3. option\n4. option\n:");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    BasicCalculator();
                    Console.ReadLine();
                    break;
                case 2:
                    Cryptography();
                    break;
                case 3:
                    Binary();
                    break;
                case 4:
                    Option4();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Menu();
                    break;
            }
        }


        //Basic calculator, takes 2 numbers and an operator and displays the result.
        //protects against division by 0 and invalid operators.
        static void BasicCalculator()
        {
            Double num1, num2;
            string op;
            Console.WriteLine("Basic Calculator");
            Console.WriteLine("Enter first number:");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select an operator (+,-,*,/, ^ for squares and sr for square roots)\n:");
            if (Console.ReadLine() == "sr")
            {
                Console.WriteLine("Result: " + Math.Sqrt(num1));
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
                Menu();
            }
            Console.WriteLine("Enter second number:");
            num2 = Convert.ToDouble(Console.ReadLine());
            
            op  = Console.ReadLine();
            switch (op)
            {
                case "+":
                    Console.WriteLine("Result: " + (num1 + num2));
                    break;
                case "-":
                    Console.WriteLine("Result: " + (num1 - num2));
                    break;
                case "*":
                    Console.WriteLine("Result: " + (num1 * num2));
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error, Cannot divide by 0");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + (num1 / num2));
                    }
                    break;
                case "^":
                    Console.WriteLine("Result: " + (Math.Pow(num1, num2)));
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
            Menu();
        }
        // ^ pressed tab ONCE and it filled out that full switch statement lol. was what i was gonna write anyway sooo
        static void Cryptography()
        {
            int Choice;
            Console.WriteLine("What function would you like to use?\n1. CaesarEn\n2. CaesarDe\n3.AffineEn\n4. AffineDe\n5. AffineBrute\n: ");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    //Caesar cipher encryption, shifts each character by 3 and mod 26
                    string input = "", encrypted = "";
                    Console.WriteLine("Enter a string to encrypt:");
                    input = Console.ReadLine();
                    input = input.ToUpper().Replace(" ", "");
                    foreach (char n in input)
                    {
                        encrypted += (char)(((n - 'A' + 3) % 26) + 'A');
                    }
                    Console.WriteLine($"Encrypted message: {encrypted}");
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadLine();
                    Menu();
                    break;
                case 2:
                    //Caesar cipher decryption, shifts each character by -3 and mod 26
                    string decrypted = "";
                    Console.WriteLine("Enter a string to decrypt:");
                    input = Console.ReadLine();
                    input = input.ToUpper().Replace(" ", "");
                    foreach (char n in input)
                    {
                        decrypted += (char)(((n - 'A' - 3 + 26  ) % 26) + 'A');
                    }
                    Console.WriteLine($"Decrypted message: {decrypted}");
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Cryptography();
                    break;
            }
            

        }

        static void Binary()
        {
            
        }

        static void Option4()
        {
            
        }
    }
}
