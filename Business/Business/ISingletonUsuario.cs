using System;
using System.Collections.Generic;
using System.Data;
using Basica;

namespace Business
{
    interface ISingletonUsuario:ISingletonGeneric<Usuario> 
    {
        bool MailExists(Usuario data);
        bool DNIExists(Usuario data);

    }
}
