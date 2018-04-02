namespace DataStructures
{
    public class StackBasedOnQueue<T> : IStack<T>
    {
        private Queue<T> _input;
        private Queue<T> _output;

        public StackBasedOnQueue(int length)
        {
            _input = new Queue<T>(length);
            _output = new Queue<T>(length);
        }

        public bool IsEmpty => _input.IsEmpty && _output.IsEmpty;

        public T Pop()
        {
            T last = default(T);

            while (true)
            {
                last = _input.Dequeue();

                if (_input.IsEmpty)
                {
                    break;
                }

                _output.Enqueue(last);
            }

            var temp = _input;
            _input = _output;
            _output = temp;

            return last;
        }

        public void Push(T item)
        {
            _input.Enqueue(item);
        }
    }
}
