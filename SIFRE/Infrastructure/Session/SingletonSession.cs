using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.Session
{
    public class SingletonSession
    {
        private static UserSession _instancia;
        private static Object _lock = new object();

        public static UserSession Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new UserSession();
                }

                return _instancia;
            }
        }
    }
}
