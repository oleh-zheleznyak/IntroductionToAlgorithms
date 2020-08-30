namespace IntroductionToAlgorithms.DataStructures
{
    public interface IQueue<T>
    {
        void Enqueue(T t);
        T Dequeue();
    }
}
