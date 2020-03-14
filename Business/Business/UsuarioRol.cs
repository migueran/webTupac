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
            if (Exists()) {
                throw new Exception("Error: Ya se ha ingresado el mismo rol en este usuario");
            }
            ISUR.Add(this);
        }

        public override void Erase()
        {
            ISUR.Erase(this);
        }

        public override bool Exists() //corregir, si existe rol!!!!
        {
            return ISUR.Exists(this);
        }

        public override void Find()
        {
            ISUR.Find(this);
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
            if (Exists())
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
