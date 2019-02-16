using System;
using System.Collections;
using System.Collections.Generic;

namespace LCRSTree
{
    public class Tree<T> : IEnumerable<Node<T>>
    {
        public Tree(Node<T> root)
        {
            Root = root;
        }
        public readonly Node<T> Root;

        public IEnumerator<Node<T>> GetEnumerator()
        {
            var back = new Stack<Node<T>>();

            var current = Root;
            while (current != null)
            {
                yield return current;

                if (current.Child != null)
                {
                    back.Push(current);
                    current = current.Child;
                }
                else if (current.Sibling !=null)
                {
                    current = current.Sibling;
                }
                else if (back.Count>0)
                {
                    var previous = back.Pop();
                    while (previous.Sibling!=null && back.Count>0)
                    {
                       previous= back.Pop();
                    }
                    if (previous.Sibling !=null)
                    {
                        current = previous.Sibling;
                    }
                        else
                    {
                        current = null;
                    }
                }
                else
                {
                    current = null; 
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


}
