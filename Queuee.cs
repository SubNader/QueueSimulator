using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class Queuee
    {
        int head, tail;

        int n_items;

        Object[] _myObjectsList;

        public Queuee(Object[] _MyObjectsList)
        {
            this.head = 0;
            this.tail = 0;
            this.n_items = 0;
            this._myObjectsList = _MyObjectsList;
        }

        public bool isEmpty()
        {
            if (this.n_items == 0)
                return true;
            return false;
        }

        public void enqueue(object _myObject)
        {
            _myObjectsList[tail] = _myObject;
            this.tail = this.tail + 1;
            this.n_items++;
        }

        public object dequeue()
        {
            object data = _myObjectsList[this.head];
            this.head++;
            this.n_items--;
            return data;
        }
    }
}
