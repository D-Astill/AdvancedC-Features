using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    public class CustomList<T>
    {
        public T[] list;

        public int amount
        {
            get;
            private set;
        }

        public CustomList() {amount = 0;}
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            //Create a new arrayof ammount + 1
            T[] cache = new T[amount + 1];
            //check if the list has been initialized
            if (list != null)
            {
                //copy all exitsting items to new array
                for (int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
            }

            //place new item at end index
            cache[amount] = item;

            //replace old array wth new array
            list = cache;
            //increment
            amount++;
        }
    }

}
