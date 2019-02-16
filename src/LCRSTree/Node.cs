using System;
using System.Collections.Generic;
using System.Text;

namespace LCRSTree
{
    public class Node<T>
    {
        public Node<T> Parent;
        public Node<T> Child;
        public Node<T> Sibling;

        public T Value;
    }
}
