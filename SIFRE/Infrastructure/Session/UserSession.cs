    using BE.DTO;
using BE.Entities;
using BE.Enums;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Infrastructure.Observer;

namespace Infrastructure.Session
{
    public class UserSession : ISubject
    {
        private List<IObserverForm> _forms = new List<IObserverForm> ();
        public UserDTO User { get; set; }
        public bool changeLanguage = false;
        private LanguageDTO _language;
        public LanguageDTO currentLanguage
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                Notify();
            }
        }


        public void Login(UserDTO usuario)
        {
            User = usuario;
        }

        public void Logout()
        {
            User = null;
        }

        public bool IsLogged()
        {
            return User != null;
        }

        public bool IsInRole(PermissionsType permission)
        {
            return RoleHelper.RoleExists(User.UserRole, permission);
        }

        public void AddObserver(IObserverForm observer)
        {
            if (!_forms.Contains(observer))
            {
                _forms.Add(observer);
                Notify();
            }
            else
            {
                throw new Exception("Formulario ya suscripto");
            }
        }

        public void RemoveObserver(IObserverForm observer)
        {
            if (_forms.Contains(observer))
            {
                _forms.Remove(observer);
            }
            else
            {
                throw new Exception("Formulario no existe");
            }
        }

        public void Notify()
        {
            foreach (var form in _forms)
            {
                form.UpdateLanguage(this);
            }
        }
    }
}
