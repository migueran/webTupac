using System.Collections.Generic;

namespace Basica
{
    public interface IAbstractABM<T>
    {
        void Add();
        void Modify();
        void Erase();
        string Find();
        List<T> List();
    }
}