using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace task_3._2._1
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        protected T[] _array;

        public DynamicArray()
        {
            _array = new T[8];
        }

        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            Length = collection.Count();
            _array = collection.ToArray();
        }

        public object Clone()
        {
            DynamicArray<T> clone = new DynamicArray<T>(Capacity)
            {
                Length = Length
            };
            Array.Copy(_array, clone._array, Length);
            return clone;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Length { get; protected set; }

        public int Capacity
        {
            get => _array.Length;
            set
            {
                if (value < _array.Length && Length > value)
                {
                    Length = value;
                }

                ChangeSizeArray(value); 
            }
        }

        public T this [int index]
        {
            get
            {
                if (Length != 0 && index < Length && index > -Length)
                {
                    if (index < 0)
                    {
                        return _array[index + Length];
                    }
                    else
                    {
                        return _array[index];
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Index {index} is outside the array");
                }
            }
            set
            {
                if (Length != 0 && index > -Length && index < Length)
                {
                    if (index < 0)
                    {
                        _array[index + Length] = value;
                    }
                    else
                    {
                        _array[index] = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Index {index} is outside the array");
                }
            }
        }

        public void Add(T item)
        {
            if(Length == Capacity)
            {
                ChangeSizeArray(Capacity * 2);
            }
            _array[Length] = item;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if(Length + collection.Count() > Capacity)
            {
                ChangeSizeArray(Length + collection.Count() + 2);
            }
            foreach (var item in collection)
            {
                _array[Length] = item;
                Length++;
            }
        }

        public bool Remove(T item)
        {
            if(_array.Contains(item))
            {
                for (int i = 0; i < Length; i++)
                {
                    if(_array[i].Equals(item))
                    {
                        Array.Copy(_array, i+1, _array, i, Length - (i+1));
                        Length--;
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert(T item, int index)
        {
            if(index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException($"Index {index} is outside the array");
            }
            else
            {
                if(Length==Capacity)
                {
                    ChangeSizeArray(Capacity * 2);
                }
                Array.Copy(_array, index, _array, index + 1, Length - index);
                _array[index] = item;
                Length++;
                return true;
            }
        }

        public T[] ToArray()
        {
            T[] temp = new T[Length];
            Array.Copy(_array, temp, Length);
            return temp;
        }

        protected void ChangeSizeArray(int size)
        {
            T[] temp = _array;
            _array = new T[size];
            Array.Copy(temp, _array, Length);
        }

    }
}
