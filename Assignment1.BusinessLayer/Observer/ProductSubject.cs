using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Assignment1.Services.Observer
{
    public class ProductSubject : ISubject
    {
        private int _count;
        
        public int ProductCount
        {
            get { return _count; }
            set
            {
                if (value > _count)
                    Notify();

                _count = value;
            }
        }

        #region ISubject Members  
        private List<IObserver> _observers = new List<IObserver>();
        private List<Observer> _observerList = new List<Observer>();
        
        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            _observers.ToList().ForEach(o => o.ProductAdded(ProductCount));
        }

        public IEnumerable<Observer> GetObservers()
        {

            foreach (IObserver observer in _observers)
                _observerList.Add(observer as Observer);
            return _observerList;
        }
        #endregion
    }
}
