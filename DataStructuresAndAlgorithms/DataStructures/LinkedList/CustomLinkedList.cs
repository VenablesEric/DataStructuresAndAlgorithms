using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedList
{
    public class CustomLinkedList<T>
    {
        private Node<T> first;
        private Node<T> last;

        private int _count = 0;

        public int Count => _count;

        public CustomLinkedList()
        { }

        public CustomLinkedList(T value)
        {
            ValidateObject(value);

            Node<T> node = new Node<T>(value);
            first = node;
            last = node;

            _count++;
        }

        public void Add(T value)
        {
            ValidateObject(value);

            Node<T> node = new Node<T>(value);

            if (first == null)
            {
                first = node;
                last = node;
            }
            else
            {
                last.Next = node;
                node.Previous = last;
                last = node;
            }

            _count++;
        }

        public void Add(int index, T value)
        {
            ValidateObject(value);

            if (index < 0)
                throw new IndexOutOfRangeException();

            if (index >= Count)
            {
                Add(value);
                return;
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            Node<T> parentNode = first;
            for (int i = 1; i < index; i++)
            {
                parentNode = parentNode.Next;
            }

            Node<T> node = new Node<T>(value);
            node.Next = parentNode.Next;
            parentNode.Next = node;
            node.Previous = parentNode;

            _count++;
        }

        public void AddFirst(T value)
        {
            ValidateObject(value);

            if (first == null)
            {
                Add(value);
                return;
            }

            Node<T> node = new Node<T>(value);
            node.Next = first;
            first.Previous = node;
            first = node;

            _count++;
        }

        public void AddLast(T value)
        {
            ValidateObject(value);

            if(first == null)
            {
                Add(value);
                return;
            }

            Node<T> node = new Node<T>(value);
            node.Previous = last;
            last.Next = node;
            last = node;

            _count++;
        }

        public void Clear()
        {
            first = null;
            last = null;

            _count = 0;
        }

        public CustomLinkedList<T> clone()
        {
            CustomLinkedList<T> clone = new CustomLinkedList<T>();

            Node<T> node = first;

            while (node != null)
            {
                clone.Add(node.Value);
                node = node.Next;
            }

            return clone;
        }

        public bool Contains(T value)
        {
            ValidateObject(value);

            Node<T> node = first;

            while (node != null)
            {
                if (node.Value.Equals(value))
                    return true;

                node = node.Next;
            }

            return false;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            Node<T> node;
            if (index < (_count / 2))
            {
                node = first;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
            }
            else
            {
                node = last;
                for (int i = (Count - 1); i > index; i--)
                {
                    node = node.Previous;
                }
            }

            return node.Value;
        }

        public T GetFirst()
        {
            if (first == null)
                throw new IndexOutOfRangeException();

            return first.Value;
        }

        public T GetLast()
        {
            if (last == null)
                throw new IndexOutOfRangeException();

            return last.Value;
        }

        public int IndexOf(T value)
        {
            ValidateObject(value);

            Node<T> node = first;
            for (int i = 0; i < _count; i++, node = node.Next)
            {
                if (node.Value.Equals(value))
                    return i;
            }

            return -1;
        }

        public int LastIndexOf(T value)
        {
            ValidateObject(value);

            Node<T> node = last;
            for (int i = (_count - 1); i >= 0; i--, node = node.Previous)
            {
                if (node.Value.Equals(value))
                    return i;
            }

            return -1;
        }

        public T Remove(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                return RemoveFirst();
            }
            if (index == (_count - 1))
            {
                return RemoveLast();
            }


            Node<T> parentNode;
            if (index < (_count / 2))
            {
                parentNode = first;
                for (int i = 1; i < index; i++)
                {
                    parentNode = parentNode.Next;
                }
            }
            else
            {
                parentNode = last;
                for (int i = (Count - 1); i > index; i--)
                {
                    parentNode = parentNode.Previous;
                }

                parentNode = parentNode.Previous;
            }

            Node<T> node = parentNode.Next;
            parentNode.Next = node.Next;
            if (parentNode.Next != null)
                parentNode.Next.Previous = parentNode;

            _count--;

            return node.Value;
        }

        public bool Remove(T value)
        {

            if (value == null || _count == 0)
                return false;

            if (first.Value.Equals(value))
            {
                RemoveFirst();
                return true;
            }
            if (last.Value.Equals(value))
            {
                RemoveLast();
                return true;
            }

            Node<T> node = first.Next;
            while (node != null)
            {
                if (node.Value.Equals(value))
                    break;

                node = node.Next;
            }

            if (node == null)
                return false;

            Node<T> parentNode = node.Previous;
            parentNode.Next = node.Next;

            if (parentNode.Next != null)
                parentNode.Next.Previous = parentNode;

            _count--;

            return true;
        }

        public T RemoveFirst()
        {
            if (first == null)
                throw new IndexOutOfRangeException();

            Node<T> node = first;

            first = first.Next;
            if (first == null)
                last = null;
            else
                first.Previous = null;

            _count--;

            return node.Value;
        }

        public T RemoveLast()
        {
            if (last == null)
                throw new IndexOutOfRangeException();

            Node<T> node = last;

            last = last.Previous;
            if (last == null)
                first = null;
            else
                last.Next = null;

            _count--;

            return node.Value;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();

            Node<T> node = first;
            while(node != null)
            {
                list.Add(node.Value);
                node = node.Next;
            }

            return list;
        }

        public override string ToString()
        {
           return string.Join(", ", ToList());
        }

        private void ValidateObject(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "is null.");
        }
    }

}


