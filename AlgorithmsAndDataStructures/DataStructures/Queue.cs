using System.Collections.Generic;
namespace DataStructures.Basic
{
    public class Queue<T>
    {
        private List<T> _data = new List<T>();
        private int _head = 0;
        private int _tail = 0;

        public bool Empty => _head == _tail;

        public void Push(T pItem)
        {
            _data.Insert(0, pItem);
        }

        public T Pull(T pItem)
        {
            var value = _data[_data.Count -1];
            _data.RemoveAt(_data.Count -1);
            return value;
        }

    }
}