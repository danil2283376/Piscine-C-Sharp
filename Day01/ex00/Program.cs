using System;
using Exchanger;
using ExchangeSum;
using ExchangeRate;

namespace ex00
{
    class Program
    {
        static void OutputInformationTransfer(string ofName, double ofPay, ExchangeSum1[] exchangeSum1)
        {
            System.Console.WriteLine("Сумма в исходной валюте: {0:F2} {1}", ofPay, ofName);
            for (int i = 0; i < exchangeSum1.Length; i++) 
            {
                System.Console.WriteLine("Сумма в {0}: {1:F2} {2}", exchangeSum1[i].identificator, exchangeSum1[i].sum,
                    exchangeSum1[i].identificator);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
                System.Console.WriteLine("Error: argument!");
            else
            {
                bool directoryExist = System.IO.Directory.Exists(args[1]);
                if (directoryExist == false)
                    System.Console.WriteLine("Error: File not exist!");
                else
                {
                    string[] pathFiles = System.IO.Directory.GetFiles(args[1]);
                    string[] splitArgumentOne = args[0].Split(' ');
                    string pathToFile = null;
                    string convertFrom = null;
                    double sum = 0;
                    int i = 0;
                    for (; i < pathFiles.Length; i++)
                    {
                        string[] splitPathFiles = pathFiles[i].Split('/');
                        string[] splitTxtFile = splitPathFiles[1].Split('.');
                        if (splitArgumentOne[1] == splitTxtFile[0])
                        {
                            bool isDouble = Double.TryParse(splitArgumentOne[0], out sum);
                            if (isDouble == false)
                            {
                                System.Console.WriteLine("number error!");
                                break ;
                            }
                            pathToFile = pathFiles[i];
                            convertFrom = splitTxtFile[0];
                            break ;
                        }
                    }
                    if (i == pathFiles.Length)
                        System.Console.WriteLine("File not found!");
                    else
                    {
                        Exchanger1 exchanger1 = new Exchanger1();
                        exchanger1.LoadCurrenceFromFile(pathToFile, sum, convertFrom);
                        ExchangeSum1[] exchangeSum1 = exchanger1.ConvertationCurrence();
                        OutputInformationTransfer(splitArgumentOne[1],
                            Convert.ToDouble(splitArgumentOne[0]), exchangeSum1);
                    }
                }
            }
        }
    }
}
