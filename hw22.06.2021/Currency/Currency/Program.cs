using System;

namespace Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            Currency c1 = new Currency("USD", 10, 1);
            Currency c2 = new Currency("AMD", 100, 0.0019m);
            Currency c3 = new Currency("AMD", 100, 0.0019m);

            Console.WriteLine("is c1 equal to c3? " + (c1 == c3));
            Console.WriteLine("is c2 equal to c3? " + c2.Equals(c3));
            Console.WriteLine("is c1 bigger than c2? " + (c1 > c2));
            Console.WriteLine($"c1 is {c1}\nc2 is {c2}\nc3 is {c3}");

            Currency c4 = 200;
            Console.WriteLine(c4);
        }
    }

    public struct Currency
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }

        public Currency(string name = "USD", decimal amount = 0, decimal rate = 1)
        {
            this.Name = name;
            this.Amount = amount;
            this.Rate = rate;
        }

        #region OperatorOverloads

        //chishtn asac chem patkeracnum te vonca kareli currency-neri het 
        //matematikakan gorcoxucyunner anel dra hamar erku operandn el sarqum em USD

        public static Currency operator +(Currency c1, Currency c2) 
        {
            decimal newAmount = c1.Amount * c1.Rate + c2.Amount * c2.Rate;
            return new Currency("USD", newAmount, 1);
        }

        public static Currency operator -(Currency c1, Currency c2)
        {
            decimal newAmount = c1.Amount * c1.Rate - c2.Amount * c2.Rate;
            return new Currency("USD", newAmount, 1);
        }

        public static Currency operator /(Currency c1, Currency c2)
        {
            decimal newAmount = c1.Amount * c1.Rate / c2.Amount * c2.Rate;
            return new Currency("USD", newAmount, 1);
        }

        public static Currency operator *(Currency c1, Currency c2)
        {
            decimal newAmount = c1.Amount * c1.Rate * c2.Amount * c2.Rate;
            return new Currency("USD", newAmount, 1);
        }

        public static bool operator >(Currency c1, Currency c2)
        {
            return (c1.Amount * c1.Rate) > (c2.Amount * c2.Rate);
        }

        public static bool operator <(Currency c1, Currency c2)
        {
            return c1.Amount * c1.Rate < c2.Amount * c2.Rate;
        }

        public static bool operator >=(Currency c1, Currency c2)
        {
            return c1.Amount * c1.Rate >= c2.Amount * c2.Rate;
        }

        public static bool operator <=(Currency c1, Currency c2)
        {
            return c1.Amount * c1.Rate <= c2.Amount * c2.Rate;
        }

        public static bool operator ==(Currency c1, Currency c2)
        {
            return c1.Amount * c1.Rate == c2.Amount * c2.Rate;
        }

        public static bool operator !=(Currency c1, Currency c2)
        {
            return c1.Amount * c1.Rate != c2.Amount * c2.Rate;
        }
        #endregion OperatorOverloads

        public static implicit operator Currency(int c)
        {
            return new Currency("USD", c, 1);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Currency))
                return false;

            Currency c = (Currency)obj;
            return this.Name == c.Name && this.Amount == c.Amount && this.Rate == c.Rate;
        }

        public override int GetHashCode()
        {
            return (int)this.Amount ^ (int)this.Rate;
        }
        public override string ToString()
        {
            return $"{this.Amount} {this.Name}";
        }
    }
}
