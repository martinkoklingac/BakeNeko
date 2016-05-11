using System;

namespace BakeNeko.Core.Types
{
    public interface INumeric<T> 
        where T : INumeric<T>, new()
    {
        T Add(long a);
        T Add(T a);
        T Subtract(long a);
        T Subtract(T a);
        T Multiply(T a);
        T Multiply(long a);
        T Identity();
        T Zero();
    }


   
}
