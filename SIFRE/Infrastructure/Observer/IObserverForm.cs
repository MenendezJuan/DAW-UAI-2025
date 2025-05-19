using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Session;

namespace Infrastructure.Observer
{
    public interface IObserverForm
    {
        void UpdateLanguage(UserSession session);
    }
}
