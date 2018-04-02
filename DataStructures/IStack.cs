namespace DataStructures
{
    public interface IStack<T>
    {
        bool IsEmpty { get; }

        T Pop();

        void Push(T item);
    }
}