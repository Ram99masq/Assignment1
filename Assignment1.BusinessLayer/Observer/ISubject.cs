using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Assignment1.Services.Observer
{
    public interface ISubject
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
        IEnumerable<Observer> GetObservers();
    }
}
