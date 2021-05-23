using System;

namespace main.c
{
    class Program
    {
        static int OutputErrorMessage()
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            return (1);
        }

        static double ThreatmentRepaymentDecreaseSum(double sum, double rate, int term, int selectedMonth, double payment)
        {
            double annualInterestRate = rate / 12.0f / 100.0f;
            DateTime date = DateTime.Today;
            double annuityPayment = (sum * annualInterestRate * Math.Pow((1 + annualInterestRate), term)
                / (Math.Pow((1 + annualInterestRate), term) - 1));
            double overpayment = 0;
            for (int i = 1; i <= term; ++i)
            {
                double procent = (sum * rate * DateTime.DaysInMonth(date.Year, (date.Month + i - 2) % 12 + 1))
                                / (100 * (DateTime.IsLeapYear(date.Year) ? 366 : 365));
                overpayment += procent;
                sum -= annuityPayment - procent;
                if (i == selectedMonth)
                {
                    sum -= payment;
                    annuityPayment = (sum * annualInterestRate * Math.Pow((1 + annualInterestRate), term - i)
                / (Math.Pow((1 + annualInterestRate), term - i) - 1));
                }
            }
            return (overpayment);
        }
        static double ThreatmentRepaymentDecreaseTerm(double sum, double rate, int term, int selectedMonth, double payment)
        {
            double annualInterestRate = rate / 12.0f / 100.0f;
            DateTime date = DateTime.Today;
            double annuityPayment = (sum * annualInterestRate * Math.Pow((1 + annualInterestRate), term)
                / (Math.Pow((1 + annualInterestRate), term) - 1));
            double overpayment = 0;
            for (int i = 1; i <= term; ++i)
            {
                double procent = (sum * rate * DateTime.DaysInMonth(date.Year, (date.Month + i - 2) % 12 + 1))
                                / (100 * (DateTime.IsLeapYear(date.Year) ? 366 : 365));
                overpayment += procent;
                sum -= annuityPayment - procent;
                if (i == selectedMonth)
                {
                    sum -= payment;
                }
                if (sum <= 0)
                    break;
            }
            return (overpayment);
        }

        static int Main(string[] args)
        {
            // Сумма кредита, р
            double sum = 0;
            // Годовая процентная ставка, %
            double rate = 0;
            // Количество месяцев кредита
            int term = 0;
            // Номер месяца кредита, в котором вносится досрочный платёж
            int selectedMonth = 0;
            // Сумма досрочного платежа, р
            double payment = 0;
            int lengthArray = args.GetLength(0);
            bool checkValide = false;

            if (lengthArray == 5)
            {
                checkValide = Double.TryParse(args[0], out sum);
                if (checkValide == false)
                    return (OutputErrorMessage());
                checkValide = Double.TryParse(args[1], out rate);
                if (checkValide == false)
                    return (OutputErrorMessage());
                checkValide = Int32.TryParse(args[2], out term);
                if (checkValide == false)
                    return (OutputErrorMessage());
                checkValide = Int32.TryParse(args[3], out selectedMonth);
                if (checkValide == false)
                    return (OutputErrorMessage());
                checkValide = Double.TryParse(args[4], out payment);
                if (checkValide == false)
                    return (OutputErrorMessage());
                double overpayment1 = ThreatmentRepaymentDecreaseSum(sum, rate, term, selectedMonth, payment);
                double overpayment2 = ThreatmentRepaymentDecreaseTerm(sum, rate, term, selectedMonth, payment);
                System.Console.WriteLine("Переплата при уменьшении платежа: {0:F2}р.", overpayment1);
                System.Console.WriteLine("Переплата при уменьшении срока: {0:F2}р.", overpayment2);
                if ((int)overpayment1 > (int)overpayment2)
                    System.Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на {0:F2}р.", overpayment1 - overpayment2);
                else if ((int)overpayment1 < (int)overpayment2)
                    System.Console.WriteLine("Уменьшение платежа выгоднее уменьшения срока на {0:F2}р.", overpayment2 - overpayment1);
                else
                    System.Console.WriteLine("Переплата одинакова в обоих вариантах.");
            }
            else
            {
                return (OutputErrorMessage());
            }
            return (0);
        }
    }
}
