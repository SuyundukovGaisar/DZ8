using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab_9
{
    public class BankTransaction
    {
        public readonly DateTime DateTime;
        public readonly decimal Sum;
        public BankTransaction(DateTime dateTime, decimal sum)
        {
            DateTime = dateTime;
            Sum = sum;
        }
    }
}
