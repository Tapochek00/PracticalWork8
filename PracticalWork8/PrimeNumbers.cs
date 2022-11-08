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
            get { return value++; }
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
            start = 0;
            value = start;
        }

        public PrimeNumbers(int start)
        {
            this.start = start;
            value = start;
        }


        public object GetNext()
        {
            value++;
            return this;
        }

        public void SetStart()
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
