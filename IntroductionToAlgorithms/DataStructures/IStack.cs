namespace IntroductionToAlgorithms.DataStructures
{
    public interface IStack<T>
    {
        T Pop();
        void Push(T value);
    }
}
