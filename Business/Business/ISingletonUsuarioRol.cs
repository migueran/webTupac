using System;
using System.Collections.Generic;
using Basica;


namespace Business
{
    interface ISingletonUsuarioRol:ISingletonGeneric<UsuarioRol>
    {
        List<UsuarioRol> ListByUsuario(UsuarioRol data);
        bool RolExists(UsuarioRol data);
    }
}
