using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedList
{
    public class Node<T>
    {
        private Node<T> _previous;
        private Node<T> _next;

        private T _value;

        public Node<T> Previous
        {
            get => _previous;
            set => _previous = value;
        }

        public Node<T> Next
        {
            get => _next;
            set => _next = value;
        }

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public Node(T value)
        {
            this._value = value;
        }
    }
}
