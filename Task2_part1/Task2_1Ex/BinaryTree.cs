using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2_1Ex
{
    public class BinaryTree<T> : IEnumerable<T>,IComparer<T> where T : IComparable
    {
        public delegate void BinaryTreeHandler(string message);
        private Node<T> head = new Node<T>();
        private event BinaryTreeHandler _notify;
        private Queue<Node<T>> queue;

        public event BinaryTreeHandler Notify
        {
            add
            {
                _notify += value;
                Console.WriteLine($"{value.Method.Name} added");
            }
            remove
            {
                _notify -= value;
                Console.WriteLine($"{value.Method.Name} deleted");
            }
        }

        public BinaryTree()
        {

        }
        
        public BinaryTree(Node<T> data)
        {
            if (data != null)
                head = data;
        }

        public BinaryTree(T data)
        {
            head.data = data;
        }

        public Node<T> GetHead()
        {
            return head;
        }

        public void RemoveAll()
        {
            head = null;
            _notify?.Invoke("Tree is removed!");
        }

        public void Remove(T data)
        {
            if (head == null)
                throw new ArgumentNullException();
            Node<T> value = new Node<T>(data);
            Node<T> temp = head;

            while (temp != null)
            {
                if (value.data.CompareTo(temp.data) > 0) temp = temp.right;
                else if (data.CompareTo(temp.data) < 0) temp = temp.left;
                else
                {
                    if (temp.right == null && temp.left == null)
                    {
                        if (temp.pos == (Position)1) temp.parent.left = null;
                        else temp.parent.right = null;
                        temp = null;
                    }
                    else if(temp.right == null)
                    {
                        if (temp.pos == (Position)1) temp.parent.left = temp.left;
                        else temp.parent.right = temp.left;

                        temp.left.parent = temp.parent;
                        temp = null;
                    }
                    else if(temp.left == null)
                    {
                        if (temp.pos == (Position)1) temp.parent.left = temp.right;
                        else temp.parent.right = temp.right;

                        temp.right.parent = temp.parent;
                        temp = null;
                    }
                    else
                    {
                        Node<T> tmpNode = Minimum(temp);
                        temp.data = tmpNode.data;

                        if (tmpNode.right != null)
                        {
                            tmpNode.parent.left = tmpNode.right;
                            tmpNode.right.parent = tmpNode.parent;
                        }
                    }
                }
            }
            _notify?.Invoke("One node of Tree is removed!");

        }

        public void Add(T data)
        {
            if (head == null)
                throw new ArgumentNullException();

            Node<T> value = new Node<T>(data);
            Node<T> tmp = head;

            _notify?.Invoke("One node added to Tree!");

            while (true)
            {
                if (data.CompareTo(tmp.data) > 0)
                {
                    if (tmp.right == null)
                    {
                        tmp.right = value;
                        value.parent = tmp;
                        value.pos = (Position)2;
                        return;
                    }
                    else
                    {
                        tmp = tmp.right;
                    }
                }
                else
                {
                    if (tmp.left == null)
                    {
                        tmp.left = value;
                        value.parent = tmp;
                        value.pos = (Position)1;
                        return;
                    }
                    else
                    {
                        tmp = tmp.left;
                    }
                }
            }

        }

        public IEnumerable<T> Inorder() => Order(InOrderTravers);

        public IEnumerable<T> Preorder() => Order(PreOrderTravers);

        public IEnumerable<T> Postorder() => Order(PostOrderTravers);

        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();

        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }

        private Node<T> Minimum(Node<T> value)
        {
            while (value.left != null)
            {
                value = value.left;
            }
            return value;
        }

        private void PreOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                queue.Enqueue(traver);
                PreOrderTravers(traver.left);
                PreOrderTravers(traver.right);
            }
        }

        private void InOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                InOrderTravers(traver.left);
                queue.Enqueue(traver);
                InOrderTravers(traver.right);
            }
        }

        private void PostOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                PostOrderTravers(traver.left);
                PostOrderTravers(traver.right);
                queue.Enqueue(traver);
            }
        }

        private IEnumerable<T> Order(Action<Node<T>> fun)
        {
            queue = new Queue<Node<T>>();
            fun(head);
            while (queue.Count > 0)
            {
                yield return queue.Dequeue().data;
            }
        }
    }
}
