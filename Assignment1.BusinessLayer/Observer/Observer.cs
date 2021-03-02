using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Assignment1.Services.Observer
{
    public class Observer:IObserver
    {
        public string ObserverName { get; private set; }
        public string _name;
        public Observer(string name)
        {
            this.ObserverName = name;
        }
        public string ProductAdded(int count)
        {            
            Console.WriteLine($" Observer name:  {ObserverName} change event triggered when product added.");
            return this.ObserverName;
        }
    }
}
