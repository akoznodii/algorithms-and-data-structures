using System;

namespace DataStructures
{
    public class Stack<T> : IStack<T>
    {
        private T[] _array;
        private int _top;

        public Stack(int length)
        {
            _array = new T[length];
            _top = -1;
        }

        public bool IsEmpty => _top == -1;

        public void Push(T item)
        {
            if (_top < _array.Length - 1)
            {
                _top++;
                _array[_top] = item;
            }
            else
            {
                throw new InvalidOperationException("Overflow");
            }
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                return _array[_top--];
            }

            throw new InvalidOperationException("Underflow");
        }
    }
}
