using System;
using System.Collections.Generic;

namespace DataStructures.Basic
{
    public class Stack<T>
    {
        private List<T> _data = new List<T>();

        public bool Empty => _data.Count == 0;

        public int Count => _data.Count;

        public void Push(T pItem)
        {
            _data.Add(pItem);
        }

        public T Pop()
        {
            if(_data.Count == 0)
                throw new Exception("Empty Stack");

            var item = _data[_data.Count -1];
            _data.RemoveAt(_data.Count -1);

            return item;
        }
    }
}