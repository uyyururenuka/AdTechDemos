using System.Runtime.Serialization;

namespace SimpleBank.Business
{
    [Serializable]
    public class AccountNotExistException : ApplicationException
    {
        public AccountNotExistException(string msg=null):base(msg)
        {

        }

       
    }
}