using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public interface IUsuarioRol
    {
        Usuario Usuario { get; set; }
        string Rol { get; set; }
        List<UsuarioRol> ListByUsuario();
        bool RolExists();
    }
}