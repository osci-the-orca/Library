using System;
static class Utilities
{


    public static string ReadString(string prompt = "", bool readKey = false)
    {
        if (!string.IsNullOrWhiteSpace(prompt))
        {
            Console.Write(prompt);
        }

        string output = "";
        if (readKey == false)
        {
            while (true)
            {
                output = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(output))
                {
                    Console.WriteLine("You cant leave this field empty, try again\n");
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            Console.ReadKey();
        }

        return output;
    }

    public static int ReadIntYear(string prompt = "")
    {
        if (!string.IsNullOrWhiteSpace(prompt))
        {
            Console.Write(prompt);
        }

        int output;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int num) && num.ToString().Length == 4 && num <= DateTime.Now.Year)
            {
                output = num;
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid input, try again\n");
            }
        }

        return output;
    }
}