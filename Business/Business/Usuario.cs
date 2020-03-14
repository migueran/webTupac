using System;
using System.Collections.Generic;
using System.Text;
using Basica;
using System.Security.Cryptography;

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
            if (MailExists())
            {
                throw new Exception("Existe otro usuario con el mismo Mail");
            }
            if (DNIExists())
            {
                throw new Exception("Existe otro usuario con el mismo DNI");
            }
            this.Password = this.DNI.ToString();
            this.Dispersar();
            ISU.Add(this);
            SaveImage();
        }

        public void Dispersar()
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(this.Password);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Devolvemos la cadena con el hash en mayúsculas para que quede más chuli 🙂
            this.Password = sb.ToString().ToUpper();
        }

        public bool DNIExists()
        {
            return ISU.DNIExists(this);
        }

        public override void Erase()
        {
            ISU.Erase(this);
        }


        public override string Find()
        {
            return ISU.Find(this);
        }

        public override List<Usuario> List()
        {
            return ISU.List(this);
        }

        public string Login()
        {
            return ISU.Login(this);
            
        }

        public bool MailExists()
        {
            return ISU.MailExists(this);
        }

        public override void Modify()
        {
            if (MailExists())
            {
                throw new Exception("Existe otro usuario con el mismo Mail");
            }
            if (DNIExists())
            {
                throw new Exception("Existe otro usuario con el mismo DNI");
            }
            if (Password != "")
            {
                this.Dispersar();
            }
            ISU.Modify(this);
            SaveImage();
        }
    }
}
