using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Windows.SystemControl
{
    public class ToolBoxButtonCollection : IList
    {
        private ToolBox owner;

        public ToolBoxButtonCollection(ToolBox owner)
        {
            this.owner = owner;
        }

        public virtual ToolBoxButton this[int index]
        {
            get
            {
                if ((index < 0) && owner.buttons != null && index > owner.buttons.Length)
                    throw new ArgumentException("无效的 index");
                return owner.buttons[index];
            }
            set
            {
                if ((index < 0) && owner.buttons != null && index > owner.buttons.Length)
                    throw new ArgumentException("无效的 index");
                if (value == null) throw new ArgumentNullException("value");
                owner.NativeUpdateButtonAt(value, index);
            }
        }
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (value is ToolBoxButton) this[index] = (ToolBoxButton)value;
                else throw new ArgumentException("无效的 value");
            }
        }

        public int Add(ToolBoxButton value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            int index = owner.buttonsCount;

            if (owner.buttons == null)
                owner.buttons = new ToolBoxButton[5];
            else if (owner.buttons.Length == owner.buttonsCount)
            {
                ToolBoxButton[] newButtons = new ToolBoxButton[owner.buttonsCount + 5];
                Array.Copy(owner.buttons, 0, newButtons, 0, owner.buttonsCount);
                owner.buttons = newButtons;
            }

            if (index < owner.buttonsCount)
                Array.Copy(owner.buttons, index, owner.buttons, index + 1, owner.buttonsCount - index);
            value.owner = owner;
            owner.buttons[index] = value;
            owner.buttonsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        public int Add(string text)
        {
            ToolBoxButton value = new ToolBoxButton(text);
            int index = owner.buttonsCount;

            if (owner.buttons == null)
                owner.buttons = new ToolBoxButton[5];
            else if (owner.buttons.Length == owner.buttonsCount)
            {
                ToolBoxButton[] newButtons = new ToolBoxButton[owner.buttonsCount + 5];
                Array.Copy(owner.buttons, 0, newButtons, 0, owner.buttonsCount);
                owner.buttons = newButtons;
            }

            if (index < owner.buttonsCount)
                Array.Copy(owner.buttons, index, owner.buttons, index + 1, owner.buttonsCount - index);
            value.owner = owner;
            owner.buttons[index] = value;
            owner.buttonsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        public int Add(int imageIndex)
        {
            ToolBoxButton value = new ToolBoxButton(imageIndex);
            int index = owner.buttonsCount;

            if (owner.buttons == null)
                owner.buttons = new ToolBoxButton[5];
            else if (owner.buttons.Length == owner.buttonsCount)
            {
                ToolBoxButton[] newButtons = new ToolBoxButton[owner.buttonsCount + 5];
                Array.Copy(owner.buttons, 0, newButtons, 0, owner.buttonsCount);
                owner.buttons = newButtons;
            }

            if (index < owner.buttonsCount)
                Array.Copy(owner.buttons, index, owner.buttons, index + 1, owner.buttonsCount - index);
            value.owner = owner;
            owner.buttons[index] = value;
            owner.buttonsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        public int Add(string text, int imageIndex)
        {
            ToolBoxButton value = new ToolBoxButton(text, imageIndex);
            int index = owner.buttonsCount;

            if (owner.buttons == null)
                owner.buttons = new ToolBoxButton[5];
            else if (owner.buttons.Length == owner.buttonsCount)
            {
                ToolBoxButton[] newButtons = new ToolBoxButton[owner.buttonsCount + 5];
                Array.Copy(owner.buttons, 0, newButtons, 0, owner.buttonsCount);
                owner.buttons = newButtons;
            }

            if (index < owner.buttonsCount)
                Array.Copy(owner.buttons, index, owner.buttons, index + 1, owner.buttonsCount - index);
            value.owner = owner;
            owner.buttons[index] = value;
            owner.buttonsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        int IList.Add(object value)
        {
            if (value is ToolBoxButton) return Add((ToolBoxButton)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Clear()
        {
            if (owner.buttons == null) return;
            for (int x = owner.buttonsCount; x > 0; x--)
            {
                owner.NativeRemoveAt(x - 1);
                owner.buttons[x - 1].owner = null;
                owner.buttonsCount--;
                if (x < owner.buttonsCount)
                    Array.Copy(owner.buttons, x + 1, owner.buttons, x, owner.buttonsCount - x);
                owner.buttons[owner.buttonsCount] = null;
            }
            owner.buttons = null;
            owner.buttonsCount = 0;
        }
        void IList.Clear()
        {
            Clear();
        }

        public bool Contains(ToolBoxButton value)
        {
            return IndexOf(value) != -1;
        }
        bool IList.Contains(object value)
        {
            if (value is ToolBoxButton) return Contains((ToolBoxButton)value);
            else throw new ArgumentException("无效的 value");
        }

        public int IndexOf(ToolBoxButton value)
        {
            for (int index = 0; index < Count; ++index)
            {
                if (this[index] == value)
                {
                    return index;
                }
            }
            return -1;
        }
        int IList.IndexOf(object value)
        {
            if (value is ToolBoxButton) return IndexOf((ToolBoxButton)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Insert(int index, ToolBoxButton value)
        {
            if (value == null)
                throw new ArgumentNullException("无效 value");
            if (index < 0 || ((owner.buttons != null) && (index > owner.buttonsCount)))
                throw new ArgumentOutOfRangeException("无效 index");

            if (owner.buttons == null)
                owner.buttons = new ToolBoxButton[5];
            else if (owner.buttons.Length == owner.buttonsCount)
            {
                ToolBoxButton[] newButtons = new ToolBoxButton[owner.buttonsCount + 5];
                Array.Copy(owner.buttons, 0, newButtons, 0, owner.buttonsCount);
                owner.buttons = newButtons;
            }
            if (index < owner.buttonsCount) Array.Copy(owner.buttons, index, owner.buttons, index + 1, owner.buttonsCount - index);

            owner.buttons[index] = value;
            owner.buttonsCount++;

            owner.NativeInsert(value, index);
        }
        public void Insert(int index, string text)
        {
            ToolBoxButton value = new ToolBoxButton(text);
            Insert(index, value);
        }
        public void Insert(int index, string text, int imageIndex)
        {
            ToolBoxButton value = new ToolBoxButton(text, imageIndex);
            Insert(index, value);
        }
        void IList.Insert(int index, object value)
        {
            if (value is ToolBoxButton) Insert(index, (ToolBoxButton)value);
            else throw new ArgumentException("无效的 value");
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }
        bool IList.IsReadOnly
        {
            get { return false; }
        }

        public void Remove(ToolBoxButton value)
        {
            int index = IndexOf(value);
            if (index != -1) RemoveAt(index);
        }
        void IList.Remove(object value)
        {
            if (value is ToolBoxButton) Remove((ToolBoxButton)value);
            else throw new ArgumentException("无效的 value");
        }

        public void RemoveAt(int index)
        {
            int count = (owner.buttons == null) ? 0 : owner.buttonsCount;
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("无效 index");

            if (owner.IsHandleCreated)
                owner.NativeRemoveAt(index);

            owner.buttons[index].owner = null;
            owner.buttonsCount--;
            if (index < owner.buttonsCount) Array.Copy(owner.buttons, index + 1, owner.buttons, index, owner.buttonsCount - index);
            owner.buttons[owner.buttonsCount] = null;
        }
        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (owner.buttonsCount > 0) Array.Copy(owner.buttons, 0, array, index, owner.buttonsCount);
        }

        public int Count
        {
            get
            {
                return owner.buttonsCount;
            }
        }
        int ICollection.Count
        {
            get { return Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return owner; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayEnumerator(owner.buttons, owner.buttonsCount);
        }
    }
}
