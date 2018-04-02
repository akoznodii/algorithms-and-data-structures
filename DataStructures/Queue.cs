using System;

namespace DataStructures
{
    public class Queue<T> : IQueue<T>
    {
        private T[] _array;
        private int _head;
        private int _tail;

        public Queue(int length)
        {
            _array = new T[length + 1];

            _head = 0;
            _tail = 0;
        }

        public bool IsEmpty => _head == _tail;

        public void Enqueue(T item)
        {
            if(_tail + 1 == _head || (_head == 0 && _tail == _array.Length - 1))
            {
                throw new InvalidOperationException("Full");
            }

            _array[_tail] = item;

            _tail = _tail == _array.Length - 1 ? 0 : _tail + 1;
        }

        public T Dequeue()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("Empty");
            }

            var item = _array[_head];
            
            _head = _head == _array.Length - 1 ? 0 : _head + 1;

            return item;
        }
    }
}
