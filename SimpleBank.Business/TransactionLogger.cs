using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Business
{
    public interface ITransactionLogger
    {
        void Log(string message);
    }
    public class TransactionLogger : ITransactionLogger
    {
        public void Log(string msg)
        {
            StreamWriter w = new StreamWriter("C:\\Chitti\\test\\banktran.txt");
            w.WriteLine(msg);
            w.Close();
        }
       
    }
}
