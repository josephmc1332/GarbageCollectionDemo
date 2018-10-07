using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionDemo
{
    class Calculator : IDisposable
    {
        private bool disposed = false;
        public Calculator()
        {
            Console.WriteLine("Calculator being created");
        }
        public void Dispose()
        {
            lock(this)
            if (!this.disposed)
            {
                Console.WriteLine("Calculator being disposed");
            }
            this.disposed = true;
            GC.SuppressFinalize(this);
        }
        public int Divide(int first, int second)
        {
            return first / second;
        }
        ~Calculator()
        {
            Console.WriteLine("Calculator being finalized");
            this.Dispose();
        }
    }
   
}
