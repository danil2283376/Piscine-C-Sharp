using System;

namespace ExchangeRate
{
    class ExchangeRate1
    {
        public string ofName;
        public double ofCoifecent;
        public string inName;
        public double inCoifecent;

        public ExchangeRate1(string ofName, double ofCoifecent, string inName, double inCoifecent)
        {
            this.ofName = ofName;
            this.ofCoifecent = ofCoifecent;
            this.inName = inName;
            this.inCoifecent = inCoifecent;
        }
    }
}