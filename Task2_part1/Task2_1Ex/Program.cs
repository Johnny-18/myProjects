using System;

namespace Task2_1Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.Add(12);
            bt.Add(1);
            bt.Add(2);
            bt.Add(3);
            bt.Add(4);
            bt.Add(9);
            bt.Add(100);
            bt.Add(10);
            //bt.Add(0);
            foreach (var item in bt.Inorder())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
