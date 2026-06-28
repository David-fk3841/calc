using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Transactions;
using System.Xml.Serialization;

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
                        Console.WriteLine("Error. You know what you're doing...");
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
            int[] keys = [1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25];
            int[] inversekeys = [1, 9, 21, 15, 3, 19, 7, 23, 11, 5, 17, 25];
            string decrypted = "", input = "", encrypted = ""; ;
            int Choice, shiftkey, multikey,inverse;
            Console.WriteLine("What function would you like to use?\n1. CaesarEn\n2. CaesarDe\n3.AffineEn\n4. AffineDe\n5. AffineBrute\n: ");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    //Caesar cipher encryption, shifts each character by 3 and mod 26
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
                    Console.WriteLine("Enter a string to encrypt:");
                    input = Console.ReadLine();
                    input = input.ToUpper().Replace(" ", "");
                    //choosing keys
                    Console.WriteLine("valid multiplication keys are: 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23 and 25");
                    Console.WriteLine("Enter a key to multiply the message by: ");
                    multikey = Convert.ToInt32(Console.ReadLine());
                    while (!keys.Contains(multikey))
                    {
                        Console.WriteLine("Please enter a valid key: ");
                        multikey = Convert.ToInt32(Console.ReadLine());

                    }
                    Console.WriteLine("Enter a key to shift the message by (1-25): ");
                    shiftkey = Convert.ToInt32(Console.ReadLine());
                    while (shiftkey > 25)
                    {
                        Console.WriteLine("Invalid input, Please enter a number between 1 and 25: ");
                        shiftkey = Convert.ToInt32(Console.ReadLine());
                    }
                    foreach (char n in input)
                    {
                        encrypted += (char)((((multikey)*(n - 'A') + (shiftkey)) % 26) + 'A');
                    }
                    Console.WriteLine($"Encrypted message: {encrypted}");
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadLine();
                    Menu();
                    break;
                case 4:
                    Console.WriteLine("Enter a string to decrypt:");

                    input = Console.ReadLine();
                    input = input.ToUpper().Replace(" ", "");
                    Console.WriteLine("Multi:  1   3   5   7    9   11   15   17   19   21   23   25");
                    Console.WriteLine("Inverse:1   9   21  15   3   19   7    23   11   5    17   25");
                    Console.WriteLine("Enter the inverse multiplication key: ");
                    inverse = Convert.ToInt32(Console.ReadLine());
                    while (!inversekeys.Contains(inverse))
                    {
                        Console.WriteLine("Please enter a valid inverse key: ");
                        inverse = Convert.ToInt32(Console.ReadLine());

                    }
                    Console.WriteLine("Enter the shift key: ");
                    shiftkey = Convert.ToInt32(Console.ReadLine());
                    while (shiftkey > 25)
                    {
                        Console.WriteLine("Invalid input, Please enter a number between 1 and 25: ");
                        shiftkey = Convert.ToInt32(Console.ReadLine());
                    }
                    foreach (char n in input)
                    {
                        decrypted += (char)(((inverse)*((n - 'A') - (shiftkey) + 26) % 26) + 'A');
                    }
                    Console.WriteLine($"Decrypted message: {decrypted}");
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadLine();
                    Menu();
                    break;
                case 5:

                    Console.WriteLine("Enter a string to decrypt:");
                    input = Console.ReadLine();
                    input = input.ToUpper().Replace(" ", "");
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    foreach (int i in inversekeys)
                    {
                        for (int b = 0; b < 26 ;b++)
                        {
                            decrypted = "";

                            foreach (char n in input)
                            {
                                decrypted += (char)((i * (((n - 'A') - (b) + 26)) % 26) + 'A');

                            }
                            Console.WriteLine($"Key: {i}, Shift: {b} -> {decrypted}");
                        }
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"Brute force completed in: {stopwatch.ElapsedMilliseconds} ms");
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadLine();
                    Menu();
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
            int Choice, input, deci;
            string binary, hex, input1, input2;
            Console.WriteLine("1. Decimal to Binary\n2. Binary to Decimal\n3. Hex to Binary\n4. Binary Addition\n5. Binary Subtraction");
            Choice = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(1500);
            Console.Clear();
            switch (Choice)
            {
                case 1:
                    Console.WriteLine("Enter the number you would like to convert to binary:");
                    input = Convert.ToInt32(Console.ReadLine());
                    binary = Convert.ToString(input, 2).PadLeft(8, '0');
                    Console.WriteLine(binary);
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("Enter the Binary you would like to convert to decimal:");
                    binary = Console.ReadLine();
                    input = Convert.ToInt32(binary, 2);
                    Console.WriteLine(input);
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;

                case 3:
                    Console.WriteLine("Enter the hex you would like to convert to binary:");
                    hex = Console.ReadLine();
                    deci = Convert.ToInt32(hex, 16);
                    binary = Convert.ToString(deci, 2).PadLeft(8, '0');
                    Console.WriteLine(binary);
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;

                case 4:
                    Console.WriteLine("Enter your first binary number");
                    input1 = Console.ReadLine();
                    Console.WriteLine("Enter your second binary number");
                    input2 = Console.ReadLine();
                    input = Convert.ToInt32(input1, 2);
                    deci = Convert.ToInt32(input2, 2);
                    Choice = (input + deci);
                    binary = Convert.ToString(Choice, 2).PadLeft(8, '0');
                    Console.WriteLine(binary);
                    //didnt wanna add a million names so fuck it *reuses other variables*
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;

                case 5:
                    Console.WriteLine("Enter your first binary number");
                    input1 = Console.ReadLine();
                    Console.WriteLine("Enter your second binary number");
                    input2 = Console.ReadLine();
                    input = Convert.ToInt32(input1, 2);
                    deci = Convert.ToInt32(input2, 2);
                    Choice = (input - deci);
                    binary = Convert.ToString(Choice, 2).PadLeft(8, '0');
                    Console.WriteLine(binary);
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Binary();
                    break;


            }





        }

        static void Option4()
        {
            
        }
    }
}
