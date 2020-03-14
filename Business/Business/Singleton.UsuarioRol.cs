using System;
using System.Collections.Generic;
using System.Data;
using Basica;

namespace Business
{
    partial class Singleton : ISingletonUsuarioRol
    {
        void ISingletonGeneric<UsuarioRol>.Add(UsuarioRol data)
        {
            CreateCommand("usuariosroles_insert");
            ParameterAddInt("idusuario", data.Usuario.Id);
            ParameterAddVarchar("rol", 20, data.Rol);
            data.Id = Insert("Error: No se pudo agregar el rol al usuario");

        }

        void ISingletonGeneric<UsuarioRol>.Erase(UsuarioRol data)
        {
            CreateCommand("usuariosroles_delete");
            ParameterAddInt("id", data.Id);
            Update("Error: No se pudo eliminar este rol del usuario");

        }

        string ISingletonGeneric<UsuarioRol>.Find(UsuarioRol data)
        {
            CreateCommand("usuariosroles_find");
            ParameterAddInt("id", data.Id);
            DataRow DR = Find("Error: no se pudo encontrar el rol del usuario");
            ISUR.MakeObject(DR, data);
            return data.RowToJSON(DR);
        }

        List<UsuarioRol> ISingletonGeneric<UsuarioRol>.List(UsuarioRol data)
        {
            CreateCommand("usuariosroles_list");
            List<UsuarioRol> UsuariosRoles = new List<UsuarioRol>();
            DataTable DT = List("Error: No se pudo listar roles de usuarios");
            foreach (DataRow DR in DT.Rows)
            {
                UsuarioRol UsuarioRol = new UsuarioRol();
                ISUR.MakeObject(DR, UsuarioRol);
                UsuariosRoles.Add(UsuarioRol);
           
            }
            return UsuariosRoles;
        }

        List<UsuarioRol> ISingletonUsuarioRol.ListByUsuario(UsuarioRol data)
        {
            CreateCommand("usuariosroles_listbyusuario");
            ParameterAddInt("idusuario", data.Usuario.Id);
            List<UsuarioRol> UsuariosRoles = new List<UsuarioRol>();
            DataTable DT = List("Error: No se pudo listar roles de usuarios");
            foreach (DataRow DR in DT.Rows)
            {
                UsuarioRol UsuarioRol = new UsuarioRol();
                ISUR.MakeObject(DR, UsuarioRol);
                UsuariosRoles.Add(UsuarioRol);

            }
            return UsuariosRoles;
        }

        void ISingletonGeneric<UsuarioRol>.MakeObject(DataRow DR, UsuarioRol data)
        {
            data.Rol = DR["rol"].ToString();
            data.Id = int.Parse(DR["id"].ToString());
            data.Usuario = new Usuario();
            data.Usuario.Id = int.Parse(DR["idusuario"].ToString());
            data.Usuario.Find();
        }

        void ISingletonGeneric<UsuarioRol>.Modify(UsuarioRol data)
        {
            CreateCommand("usuariosroles_update");
            ParameterAddInt("id", data.Id);
            ParameterAddInt("idusuario", data.Usuario.Id);
            ParameterAddVarchar("rol", 20, data.Rol);
            Update("Error: No se pudo modificar el rol del usuario");

        }

        bool ISingletonUsuarioRol.RolExists(UsuarioRol data)
        {
            CreateCommand("usuariosroles_rolexists");
            ParameterAddInt("idusuario", data.Usuario.Id);
            ParameterAddVarchar("rol", 20, data.Rol);
            return Exists("Error: No se pudo determinar si existía el rol del usuario");
        }
    }
}
