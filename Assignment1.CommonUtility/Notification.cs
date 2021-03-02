using Assignment1.CommonUtility.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.CommonUtility
{
    public class Notification
    {
        private IMessenger _iMessenger;

        //constructor Dependency injection
        public Notification(IMessenger messenger)
        {
            _iMessenger = messenger;
        }
        public async Task<bool> DoNotify()
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
                await _iMessenger.SendMessage();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
