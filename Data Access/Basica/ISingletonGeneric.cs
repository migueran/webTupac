﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Basica
{
    public interface ISingletonGeneric<T>
    {
        void Add(T data);
        void Modify(T data);
        void Erase(T data);
        string Find(T data);        
        List<T> List(T data);
        void MakeObject(DataRow DR, T data);
    }
}
