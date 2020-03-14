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
            throw new NotImplementedException();
        }

        void ISingletonGeneric<UsuarioRol>.Erase(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonGeneric<UsuarioRol>.Exists(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<UsuarioRol>.Find(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        List<UsuarioRol> ISingletonGeneric<UsuarioRol>.List(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        List<UsuarioRol> ISingletonUsuarioRol.ListByUsuario(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<UsuarioRol>.MakeObject(DataRow DR, UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<UsuarioRol>.Modify(UsuarioRol data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonUsuarioRol.RolExists(UsuarioRol data)
        {
            throw new NotImplementedException();
        }
    }
}
