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
            throw new NotImplementedException();
        }

        bool ISingletonUsuario.DNIExists(Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<Usuario>.Erase(Usuario data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonGeneric<Usuario>.Exists(Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<Usuario>.Find(Usuario data)
        {
            throw new NotImplementedException();
        }

        List<Usuario> ISingletonGeneric<Usuario>.List(Usuario data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonUsuario.MailExists(Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<Usuario>.MakeObject(DataRow DR, Usuario data)
        {
            throw new NotImplementedException();
        }

        void ISingletonGeneric<Usuario>.Modify(Usuario data)
        {
            throw new NotImplementedException();
        }
    }
}
