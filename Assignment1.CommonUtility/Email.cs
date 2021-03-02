using Assignment1.CommonUtility.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.CommonUtility
{
    public class Email : IMessenger
    {
        public async Task<bool> SendMessage()
        {        

            try
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("SendMessage Email Method");
                    // Do something
                    Task.Delay(100).Wait();
                    //implmentation
                });
                //  send email implmentation
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
