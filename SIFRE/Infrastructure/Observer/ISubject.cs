using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Observer
{
    public interface ISubject
    {
        void AddObserver(IObserverForm observer);
        void RemoveObserver(IObserverForm observer);
        void Notify();
    }
}
