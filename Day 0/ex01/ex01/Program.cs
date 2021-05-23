using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ex01
{
    class Program
    {
        static int Rec(int i, int j, string a, string b)
        {
            if (i == 0 || j == 0)
                return (Math.Max(i, j));
            else if (a[i - 1] == b[j - 1])
                return (Rec(i - 1, j - 1, a, b));
            else
            {
                return (1 + 
                    Math.Min(
                            Math.Min(Rec(i, j - 1, a, b), Rec(i - 1, j, a, b)),
                                Rec(i - 1, j - 1, a, b)));
            }
        }

        static int DistanceLevenshtein(string a, string b)
        {
            return (Rec(a.Length, b.Length, a, b));
        }
        static int OutputErrorMessage(string message)
        {
            int error = 1;
            System.Console.WriteLine("{0}", message);
            return (error);
        }
        static int Main(string[] args)
        {
            string nameUser;
            int lengthString;

            Console.Write("Enter name: ");
            nameUser = Console.ReadLine();
            lengthString = nameUser.Length;

            if (lengthString == 0)
                return (OutputErrorMessage("Your name was not found."));

            string[] allNames = File.ReadAllLines("us.txt");
            if (allNames == null)
                return (OutputErrorMessage("File not exist!"));
            string closeWord = allNames[0];
            int minDistance = DistanceLevenshtein(allNames[0], nameUser);
            for (int i = 0; i < allNames.Length; i++) 
            {
                int dist = DistanceLevenshtein(allNames[i], nameUser);
                if (dist < 3)
                {
                    if (allNames[i][0] == nameUser[0])
                    {
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            closeWord = allNames[i];
                        }
                    }
                }
            }
            if (minDistance == 0)
                System.Console.WriteLine("Hello, {0}!", closeWord);
            else
            {
                System.Console.WriteLine("Did you mean \"{0}\"? Y/N", closeWord);
                string answer = Console.ReadLine();
                lengthString = answer.Length;
                if (lengthString > 1 || lengthString < 1)
                    return (OutputErrorMessage("Bad input!"));
                if (lengthString == 1 && answer == "Y")
                    System.Console.WriteLine("Hello, {0}!", closeWord);
                else
                    return (OutputErrorMessage("Your name was not found."));
            }
            return (0);
        }
    }
}
