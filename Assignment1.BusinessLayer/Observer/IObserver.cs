using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Assignment1.Services.Observer
{
    public interface IObserver
    {
        string ProductAdded(int count);
    }
}
