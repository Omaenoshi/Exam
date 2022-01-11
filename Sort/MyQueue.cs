using System;

namespace Sort
{
    public class MyQueue<TValue>
    {
        private Item<TValue> _head;
        private Item<TValue> _tail;

        public void Enqueue(TValue value)
        {
            if (IsEmpty())
            {
                var item = new Item<TValue>() {Value = value, NextItem = null, LastItem = null};
                _head = _tail = item;
            }
            else
            {
                var item = new Item<TValue>() {Value = value, NextItem = null, LastItem = _tail};
                _tail.NextItem = item;
                _tail = item;
            }
        }

        public TValue Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            if (_head == _tail)
            {
                var value = _head.Value;
                _head = _tail = null;
                return value;
            }
            
            var result = _head.Value;
            _head = _head.NextItem;
            _head.LastItem = null;
            if (IsEmpty())
                _tail = null;
            
            return result;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
    }

    public class Item<TValue>
    {
        public TValue Value { get; set; }
        
        public Item<TValue> NextItem { get; set; }
        
        public Item<TValue> LastItem { get; set; }
        
    }

    public class MyStack<TValue>
    {
        private Item<TValue> _head;
        private Item<TValue> _tail;

        public void Push(TValue value)
        {
            if (IsEmpty())
            {
                var item = new Item<TValue>() {Value = value};
                _head = _tail = item;
            }
            else
            {
                var item = new Item<TValue>() {Value = value, LastItem = _tail};
                _tail.NextItem = item;
                _tail = item;
            }
        }

        public TValue Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");

            if (_head == _tail)
            {
                var item = _tail;
                _head = _tail = null;
                return item.Value;
            }

            var result = _tail;
            _tail = _tail.LastItem;
            _tail.NextItem = null;

            return result.Value;
        }

        public bool IsEmpty() => _head == null;
    }
}