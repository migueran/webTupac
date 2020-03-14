using System.Collections.Generic;

namespace Basica
{
    public interface IAbstractABM<T>
    {
        void Add();
        void Modify();
        void Erase();
        string Find();
        bool Exists();
        List<T> List();

    }
}