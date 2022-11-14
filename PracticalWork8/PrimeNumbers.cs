using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork8
{
    class PrimeNumbers : ISeries, IComparable, ICloneable
    {
        int start;
        int value;

        public int Next
        {
            get { return GetNext(); }
        }

        public int Value
        {
            get { return value; }
        }

        public int Start
        {
            set { start = value; }
        }

        public PrimeNumbers()
        {
            start = 2;
            value = start;
        }

        public PrimeNumbers(int start)
        {
            this.start = start;
            value = start;
        }


        public int GetNext()
        {
            bool isPrime = false;

            while (!isPrime)
            {
                value++;
                if (value < 6 && value != 4 && value != 1)
                {
                    isPrime = true;
                }
                else
                {
                    for (int i = 2; i < (int)(value / 2); i++)
                    {
                        if (value % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                        else
                        {
                            isPrime = true;
                        }
                    }
                }
            }
            return value;
        }

        public void Reset()
        {
            value = start;
        }

        public void SetStart(int x)
        {
            start = x;
            value = start;
        }

        public int CompareTo(object obj)
        {
            PrimeNumbers number = (PrimeNumbers)obj;
            if (value > number.value) return 1;
            if (value < number.value) return -1;
            return 0;
        }

        public object Clone()
        {
            PrimeNumbers number = new PrimeNumbers();
            number.start = start;
            number.value = value;
            return number;
        }
    }
}
