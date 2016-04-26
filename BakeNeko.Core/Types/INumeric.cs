using System;

namespace BakeNeko.Core.Types
{
    public interface INumeric<T> 
        where T : INumeric<T>, new()
    {
        T Add(T a);
        T Subtract(T a);
        T Identity();
    }


   
}
