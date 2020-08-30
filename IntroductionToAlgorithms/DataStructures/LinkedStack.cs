namespace IntroductionToAlgorithms.DataStructures
{
    /// <summary>
    /// A stack implemented on top of singly linked list
    /// </summary>
    /// <typeparam name="T">type of element in the stack</typeparam>
    public class LinkedStack<T> : IStack<T>
    {
        private readonly SinglyLinkendList<T> linkedList = new SinglyLinkendList<T>();

        public T Pop()
        {
            return linkedList.RemoveFirst();
        }

        public void Push(T value)
        {
            linkedList.AddFirst(value);
        }
    }
}
