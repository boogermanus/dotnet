using System;
using System.Text;

namespace DataStructures.Basic
{
    public class Node<T> 
    {
        public Node(T pData)
        {
            Data = pData;
        }

        public T Data {get;set;}
        
        public Node<T> Next {get;set;} = null;
    }

    public class LinkedList<T>
    {
        private Node<T> _head = null;
        private Node<T> _tail = null;

        public void Append(T pData)
        {
            if(_head == null)
            {
                _head = new Node<T>(pData);
                _tail = _head;
                return;
            }

            _tail.Next = new Node<T>(pData);
            _tail = _tail.Next;
        }

        public string Print()
        {
            var builder = new StringBuilder();
            for(Node<T> node = _head;node != null;node = node.Next)
            {
                builder.Append($"{node.Data},");
            }

            builder.Length--;
            return builder.ToString();
        }
    }
}