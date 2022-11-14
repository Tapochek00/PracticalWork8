using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork8
{
    interface ISeries
    {
        int Next { get; }

        int GetNext();

        void Reset();

        void SetStart(int x);
    }
}
