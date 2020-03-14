using System;
using System.Collections.Generic;
using System.Data;
using Basica;

namespace Business
{
    partial class Singleton : ISingletonUsuario
    {
        void ISingletonGeneric<Usuario>.Add(Usuario data)
        {
            CreateCommand("usuarios_insert");
            ParameterAddVarchar("nombre", 80, data.Nombre);
            ParameterAddInt("dni", data.DNI);
            ParameterAddVarchar("domicilio", 80, data.Domicilio);
            ParameterAddVarchar("telefono", 15, data.Telefono);
            ParameterAddVarchar("mail", 80, data.Mail);
            ParameterAddDatetime("fechanac", data.FechaNac);
            ParameterAddVarchar("password", 40, data.Password);
            ParameterAddVarchar("estudios", 200, data.Estudios);
            ParameterAddVarchar("materiasadeudadas", 200, data.MateriasAdeudadas);
            data.Id = Insert("Error no se pudo ingresar el Usuario");
        }

        bool ISingletonUsuario.DNIExists(Usuario data)
        {
            CreateCommand("usuarios_dniexists");
            ParameterAddInt("id", data.Id);
            ParameterAddInt("dni", data.DNI);
            return Exists("Error no se pudo determinar si existe el usuario");
        }

        void ISingletonGeneric<Usuario>.Erase(Usuario data)
        {
            CreateCommand("usuarios_delete");
            ParameterAddInt("id", data.Id);
            Update("Error no se pudo eliminar el Usuario");
        }
      

        string ISingletonGeneric<Usuario>.Find(Usuario data)
        {
            throw new NotImplementedException();
        }

        List<Usuario> ISingletonGeneric<Usuario>.List(Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonUsuario.Login(Usuario data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonUsuario.MailExists(Usuario data)
        {
            CreateCommand("usuarios_mailexists");
            ParameterAddInt("id", data.Id);
            ParameterAddVarchar("mail", 80, data.Mail);
            return Exists("Error no se pudo saber si existe el Mail");
        }

        void ISingletonGeneric<Usuario>.MakeObject(DataRow DR, Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<Usuario>.Modify(Usuario data)
        {
            CreateCommand("usuarios_update");
            ParameterAddInt("id", data.Id);
            ParameterAddVarchar("nombre", 80, data.Nombre);
            ParameterAddInt("dni", data.DNI);
            ParameterAddVarchar("domicilio", 80, data.Domicilio);
            ParameterAddVarchar("telefono", 15, data.Telefono);
            ParameterAddVarchar("mail", 80, data.Mail);
            ParameterAddDatetime("fechanac", data.FechaNac);
            ParameterAddVarchar("password", 40, data.Password);
            ParameterAddVarchar("estudios", 200, data.Estudios);
            ParameterAddVarchar("materiasadeudadas", 200, data.MateriasAdeudadas);
            Update("Error no se pudo modificar Usuario");
        }
    }
}
