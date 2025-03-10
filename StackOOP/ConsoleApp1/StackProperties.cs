using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackProperties

    {
        private List<object> _items = new List<object>(); // Internal list to store stack items

        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("Null values cannot be pushed to the stack.");

            _items.Add(obj);
        }

        public object Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty. Cannot pop an element.");

            int lastIndex = _items.Count - 1;
            object topItem = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            return topItem;
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
