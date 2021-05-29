using System;
using ExchangeSum;
using ExchangeRate;

namespace Exchanger
{
    class Exchanger1
    {
        private ExchangeSum1[] exchangeSum1;
        private ExchangeRate1[] exchangeRate1;

        public void LoadCurrenceFromFile(string nameFile, double money, string convertFrom)
        {
            int countStringFile = CountStringFile(nameFile);

            exchangeSum1 = new ExchangeSum1[countStringFile];
            exchangeRate1 = new ExchangeRate1[countStringFile];
            // System.Console.WriteLine("{0}", countStringFile);
            string[] coifiecentsFile = System.IO.File.ReadAllLines(nameFile);
            // System.Console.WriteLine(convertFrom);
            for (int i = 0; i < countStringFile; i++) 
            {
                string[] splitStringFile = coifiecentsFile[i].Split(':');
                // System.Console.WriteLine(splitStringFile[1]);
                exchangeSum1[i] = new ExchangeSum1();
                exchangeRate1[i] = new ExchangeRate1(convertFrom, money, splitStringFile[0], Convert.ToDouble(splitStringFile[1]));
            }
            // for (int i = 0; i < exchangeRate1.Length; i++)
            // {
            //     System.Console.WriteLine("Из {0} = {1} => в {2} = {3}", exchangeRate1[i].ofName,
            //         exchangeRate1[i].ofCoifecent, exchangeRate1[i].inName, exchangeRate1[i].inCoifecent);
            // }
        }

        public ExchangeSum1[] ConvertationCurrence()
        {
            for (int i = 0; i < exchangeRate1.Length; i++) 
            {
                if (exchangeRate1[i].ofName == "EUR" && exchangeRate1[i].inName == "RUB")
                    ConvertMoney(i, exchangeRate1[i].inName);
                else if (exchangeRate1[i].ofName == "EUR" && exchangeRate1[i].inName == "USD")
                    ConvertMoney(i, exchangeRate1[i].inName);
                else if (exchangeRate1[i].ofName == "USD" && exchangeRate1[i].inName == "RUB")
                    ConvertMoney(i, exchangeRate1[i].inName);
                else if (exchangeRate1[i].ofName == "USD" && exchangeRate1[i].inName == "EUR")
                    ConvertMoney(i, exchangeRate1[i].inName);
                else if (exchangeRate1[i].ofName == "RUB" && exchangeRate1[i].inName == "USD")
                    ConvertMoney(i, exchangeRate1[i].inName);
                else if (exchangeRate1[i].ofName == "RUB" && exchangeRate1[i].inName == "EUR")
                    ConvertMoney(i, exchangeRate1[i].inName);
            }
            return (exchangeSum1);
        }

        private int CountStringFile(string nameFile)
        {
            return (System.IO.File.ReadAllLines(nameFile).Length);
        }

        private void ConvertMoney(int indexOffer, string inName)
        {
            double sum = exchangeRate1[indexOffer].ofCoifecent * exchangeRate1[indexOffer].inCoifecent;
            exchangeSum1[indexOffer].SetValues(inName, sum);
        }
    }
}