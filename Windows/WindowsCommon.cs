using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Windows
{
    public class ArrayEnumerator : IEnumerator
    {
        private object[] array;
        private int total;
        private int current;

        public ArrayEnumerator(object[] array, int count)
        {
            Debug.Assert(count == 0 || array != null, "if array is null, count should be 0");
            Debug.Assert(array == null || count <= array.Length, "Trying to enumerate more than the array contains");
            this.array = array;
            this.total = count;
            current = -1;
        }

        public bool MoveNext()
        {
            if (current < total - 1)
            {
                current++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            current = -1;
        }

        public object Current
        {
            get
            {
                if (current == -1)
                    return null;
                else
                    return array[current];
            }
        }
    }
    public class ArraySubsetEnumerator : IEnumerator
    {
        private object[] array;
        private int total;
        private int current;

        public ArraySubsetEnumerator(object[] array, int count)
        {
            Debug.Assert(count == 0 || array != null, "if array is null, count should be 0");
            Debug.Assert(array == null || count <= array.Length, "Trying to enumerate more than the array contains");
            this.array = array;
            this.total = count;
            current = -1;
        }

        public bool MoveNext()
        {
            if (current < total - 1)
            {
                current++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            current = -1;
        }

        public object Current
        {
            get
            {
                if (current == -1)
                    return null;
                else
                    return array[current];
            }
        }
    }
}
