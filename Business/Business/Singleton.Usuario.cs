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
            CreateCommand("usuarios_find");
            ParameterAddInt("id", data.Id);
            DataRow DR = Find("Error: No se pudo encontrar usuario.");
            ISU.MakeObject(DR, data);
            return data.RowToJSON(DR);
        }

        List<Usuario> ISingletonGeneric<Usuario>.List(Usuario data)
        {
            List<Usuario> Usuarios = new List<Usuario>();
            CreateCommand("usuarios_list");
            DataTable DT = List("Error: No se pudo encontrar usuarios");
            foreach (DataRow DR in DT.Rows)
            {
                Usuario Usuario = new Usuario();
                ISU.MakeObject(DR, Usuario);
                Usuarios.Add(Usuario);
            }
            return Usuarios;
        }

        string ISingletonUsuario.Login(Usuario data)
        {
            CreateCommand("usuarios_login");
            ParameterAddVarchar("mail", 80, data.Mail);
            ParameterAddVarchar("password", 40, data.Password);
            DataRow DR = Find("Error: No se pudo encontrar usuario");
            ISU.MakeObject(DR, data);
            return data.RowToJSON(DR);
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
            data.Id = int.Parse(DR["id"].ToString());
            data.Nombre = DR["nombre"].ToString();
            data.DNI = int.Parse(DR["dni"].ToString());
            data.Domicilio = DR["domicilio"].ToString();
            data.Telefono = DR["telefono"].ToString();
            data.Mail = DR["mail"].ToString();
            data.FechaNac = DateTime.Parse(DR["fechanac"].ToString());
            data.Password = DR["password"].ToString();
            data.Estudios = DR["estudios"].ToString();
            data.MateriasAdeudadas = DR["materiasadeudadas"].ToString();

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
