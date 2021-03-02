using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.CommonUtility.Interface
{
    public interface IMessenger
    {
        Task<bool> SendMessage();
    }
}
