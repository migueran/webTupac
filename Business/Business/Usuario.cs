using System;
using System.Collections.Generic;
using Basica;


namespace Business
{
    public class Usuario : CID<Usuario>, IUsuario
    {
        ISingletonUsuario ISU = Singleton.GetInstance;

        public Usuario()
        {
            this.Directory = "Usuarios";
            this.Prefix = "Usuario";

        }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNac { get; set; }
        public string Password { get; set; }
        public string Estudios { get; set; }
        public string MateriasAdeudadas { get; set; }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public string Dispersar(string Password)
        {
            throw new NotImplementedException();
        }

        public bool DNIExists()
        {
            throw new NotImplementedException();
        }

        public override void Erase()
        {
            throw new NotImplementedException();
        }

        public override bool Exists()
        {
            throw new NotImplementedException();
        }

        public override void Find()
        {
            throw new NotImplementedException();
        }

        public override List<Usuario> List()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public bool MailExists()
        {
            throw new NotImplementedException();
        }

        public override void Modify()
        {
            throw new NotImplementedException();
        }
    }
}
