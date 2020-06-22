using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T>
    {
        private T[] m;
        private int count = 0;
        private int h = 0, g = 1;

        public int Count { get => count; }
        public bool IsEmpty { get => (count == 0); }
        public T Top { get => (count != 0) ? m[g] : throw new QueueEmptyException(); }

        public Queue(int length)
        {
            m = new T[length];
        }
        public void Push(T c)
        {
            if (count < m.Length)
            {
                h = (h + 1 == m.Length) ? 0 : h + 1;
                m[h] = c;
                count++;
            }
            else
                throw new QueueOverflowException();
        }
        public T Pop()
        {
            if (count > 0)
            {
                T temp = m[g];
                g = (g + 1 == m.Length) ? 0 : g + 1;
                count--;
                return temp;
            }
            else
                throw new QueueEmptyException(); 
        }
        public void Clear()
        {
            h = 0;
            g = 1;
            count = 0;
        }
    }
    
    public class QueueEmptyException : Exception
    {
        public QueueEmptyException(string message = "Очередь пуста") : base(message)
        {
        }
    }
    public class QueueOverflowException : Exception
    {
        public QueueOverflowException(string message = "Очередь заполнена") : base(message)
        {
        }
    }
}
