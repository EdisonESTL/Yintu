using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Yintu.DataBase
{
    public class AsyncLazy<T> : Lazy<Task<T>> 
    {
        readonly Lazy<Task<T>> instance;

        public AsyncLazy(Func<T> Factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(Factory));
        }

        public AsyncLazy(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }
}
