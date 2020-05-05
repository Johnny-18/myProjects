
namespace Task2_1Ex
{
    public class Node<T>
    {
        public Position pos;
        public Node<T> left;
        public Node<T> right;
        public Node<T> parent;
        public T data;

        public Node()
        {
            left = null;
            right = null;
            parent = null;
            data = default(T);
        }

        public Node(T data)
        {
            this.data = data;
            left = null;
            right = null;
            parent = null;
        }

        public Node(Node<T> other)
        {
            this.pos = other.pos;
            this.left = other.left;
            this.right = other.right;
            this.parent = other.parent;
            this.data = other.data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
