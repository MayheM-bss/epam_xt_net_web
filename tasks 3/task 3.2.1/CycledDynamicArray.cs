using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._2._1
{
    class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>
    {

        public CycledDynamicArray() : base ()
        {

        }

        public CycledDynamicArray(int capacity) : base (capacity)
        {

        }

        public CycledDynamicArray(IEnumerable<T> collection) : base (collection)
        {

        }

        public override IEnumerator<T> GetEnumerator()
        {
            while(true)
            {
                for (int i = 0; i < Length; i++)
                {
                    yield return _array[i];
                }
            }
        }

    }
}
