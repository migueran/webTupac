using System;
using System.Collections.Generic;
using Basica;

namespace Business
{
    public class UsuarioRol : CID<UsuarioRol>, IUsuarioRol
    {
        ISingletonUsuarioRol ISUR = Singleton.GetInstance;

        public Usuario Usuario { get; set; }
        public string Rol { get; set; }

        public override void Add()
        {
            if (RolExists()) {
                throw new Exception("Error: Ya se ha ingresado el mismo rol en este usuario");
            }
            ISUR.Add(this);
        }

        public override void Erase()
        {
            ISUR.Erase(this);
        }

        public override string Find()
        {
           return ISUR.Find(this);
        }

        public override List<UsuarioRol> List()
        {
          return ISUR.List(this);
        }

        public List<UsuarioRol> ListByUsuario()
        {
            return ISUR.ListByUsuario(this);
        }

        public override void Modify()
        {
            if (RolExists())
            {
                throw new Exception("Error: Ya se ha ingresado el mismo rol en este usuario");
            }
            ISUR.Modify(this);
        }

        public bool RolExists()
        {
            return ISUR.RolExists(this);
        }
    }
}
