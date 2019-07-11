using System;

namespace src
{
    public class BST
    {
        public Node Root { get; set; }
        public BST() {}

        public void Add(int data)
        {
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            var current = Root;
            while (true)
            {
                if (data < current.Data)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(data);
                        return;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(data);
                        return;
                    }
                    current = current.Right;
                }
            }
        }
    }
}
