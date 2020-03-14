using System;
namespace Business
{
   public interface IUsuario
    {
        string Nombre { get; set; }
        int DNI { get; set; }
        string Domicilio { get; set; }
        string Telefono { get; set; }
        string Mail { get; set; }
        DateTime FechaNac { get; set; }
        string Password { get; set; }
        string Estudios { get; set; }
        string MateriasAdeudadas { get; set; }
        string Login();
        bool MailExists();
        bool DNIExists();
        void Dispersar();
    }
}