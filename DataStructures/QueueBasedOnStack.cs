using System;

namespace DataStructures
{
    public class QueueBasedOnStack<T> : IQueue<T>
    {
        private Stack<T> _input;
        private Stack<T> _output;
        
        public QueueBasedOnStack(int length)
        {
            _input = new Stack<T>(length);
            _output = new Stack<T>(length);
        }

        public bool IsEmpty => _input.IsEmpty && _output.IsEmpty;

        public T Dequeue()
        {
            Move(_input, _output);

            return _output.Pop();
        }

        public void Enqueue(T item)
        {
            Move(_output, _input);

            _input.Push(item);
        }

        private void Move(Stack<T> input, Stack<T> output)
        {
            while (!input.IsEmpty)
            {
                output.Push(input.Pop());
            }
        }
    }
}
