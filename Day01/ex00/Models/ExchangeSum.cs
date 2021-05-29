using System;

namespace ExchangeSum
{
    class ExchangeSum1
    {
        public string identificator;
        public double sum;

        public ExchangeSum1()
        {
            
        }

        public ExchangeSum1(string identificator, double sum)
        {
            this.identificator = identificator;
            this.sum = sum;
        }

        public void SetValues(string identificator, double sum)
        {
            this.identificator = identificator;
            this.sum = sum;
        }
    }
}