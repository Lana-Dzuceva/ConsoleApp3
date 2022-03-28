using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Node
    {
        public Node Next;
        public int Value;

        public Node(int value)
        {
            Value = value;
        }
    }
    public class SinglyLinkedList
    {
        public Node Head;
        private int count = 0;

        public int GetCount()
        {
            return count;
        }
        public string Print()
        {
            string result = "";
            Node current = Head;
            while (current != null)
            {
                result += current.Value + " ";
                current = current.Next;
            }

            return result;
        }
        public Node Find(int key)
        {
            if (count == 0)
            {
                return null;
            }

            Node current = Head;
            while (current.Value != key)
            {
                current = current.Next;
                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }
        public Node FindByIndex(int index)
        {
            if (index > count || index < 0) return null;
            Node current = Head;
            while (index-- > 0)
            {
                current = current.Next;
            }
            return current;
        }
        public Node FindLast(int key)
        {
            if (count == 0)
            {
                return null;
            }

            Node current = Head;
            Node goodNode = null;
            while (current != null)
            {
                if (current.Value == key)
                {
                    goodNode = current;
                }
                current = current.Next;
                
            }
            return goodNode;
        }
        private Node FindTail()
        {
            if (count == 0)
            {
                return null;
            }

            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public void PushBack(int item)
        {
            Node newNode = new Node(item);
            if (count == 0)
            {
                Head = newNode;
            }
            else
            {
                Node tail = FindTail();
                tail.Next = newNode;
            }

            count++;
        }
        public void PushFront(int item)
        {
            Node newNode = new Node(item);

            if (count != 0)
            {
                newNode.Next = Head;
            }

            Head = newNode;
            count++;
        }
        public void AddAfter(Node node, int item)
        {
            if (node == null)
            {
                return;
            }

            Node newNode = new Node(item);

            newNode.Next = node.Next;
            node.Next = newNode;

            count++;
        }
        public void AddBefore(Node node, int item)
        {
            if (node == Head)
            {
                PushFront(item);
                return;
            }
            Node temp = new Node(item);
            
            Node cur = Head;
            while(cur.Next != null)
            {
                if(cur.Next == node)
                {
                    temp.Next = cur.Next;
                    cur.Next = temp;
                    break;
                }
                cur = cur.Next;
            }
            count++;
        }
        public void PushBackRange(int[] array)
        {
            foreach (var item in array)
            {
                PushBack(item);
            }
        }
        public void RemoveFirst()
        {
            if (count == 0)
            {
                throw new Exception("Список пуст");
            }

            Head = Head.Next;
            count--;
        }
        public void RemoveLast()
        {
            if (count == 0)
            {
                throw new Exception("Список пуст");
            }

            if (count == 1)
            {
                Head = null;
            }
            else
            {
                Node current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                current.Next = null;
            }

            count--;
        }
        public void RemoveNode(Node node)
        {
            if (Head == node)
            {
                Head = node.Next;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    if (current.Next == node)
                    {
                        break;
                    }

                    current = current.Next;
                }

                current.Next = node.Next;
            }

            count--;
        }
        public bool Remove(int item)
        {
            Node cur = Head;
            if(cur.Value == item)
            {
                RemoveFirst();
                return true;
            }
            while (cur.Next != null)
            {
                if(cur.Next.Value == item)
                {
                    cur.Next = cur.Next.Next;
                    count--;
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }
        public bool RemoveLast(int item)
        {
            int c = count;
            Node temp = FindLast(item);
            if (temp == null) return false;
            RemoveNode(temp);
            return c != count;
        }
        public int RemoveAll(int item)
        {
            int c = 0;
            while (Remove(item)) { c++; }
            return c;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList hmm = new SinglyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                hmm.PushBack(i % 5);
            }
            Console.WriteLine(hmm.Print());
            
            hmm.RemoveLast(3);
            Console.WriteLine(hmm.Print());
        }
    }
}
