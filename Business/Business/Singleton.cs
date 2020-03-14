using System;
using DataAccess;
using Basica;

namespace Business
{
    partial class Singleton:Connection
    {
        ISingletonUsuario ISU;
        ISingletonUsuarioRol ISUR;

        static Singleton Instancia = new Singleton();
        
        private Singleton()
        {
            ISU = this;
            ISUR = this;
        }
        public static Singleton GetInstance { get
            {
                return Instancia;
            }
        }
    }
}
