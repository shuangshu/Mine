using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Windows;

namespace Windows.SystemControl
{
    public class MenuBoxItemCollection : IList
    {
        private MenuBox owner;
        public MenuBoxItemCollection(MenuBox owner)
        {
            this.owner = owner;
        }

        public virtual MenuBoxItem this[int index]
        {
            get
            {
                if ((index < 0) && owner.items != null && index > owner.items.Length)
                    throw new ArgumentException("无效的 index");
                return owner.items[index];
            }
            set
            {
                if ((index < 0) && owner.items != null && index > owner.items.Length)
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
                if (value is MenuBoxItem) this[index] = (MenuBoxItem)value;
                else throw new ArgumentException("无效的 value");
            }
        }

        public int Add(MenuBoxItem value)
        {
            if (value == null)
                throw new ArgumentNullException("button");
            int index = owner.itemsCount;

            if (owner.items == null)
                owner.items = new MenuBoxItem[5];
            else if (owner.items.Length == owner.itemsCount)
            {
                MenuBoxItem[] newItems = new MenuBoxItem[owner.itemsCount + 5];
                Array.Copy(owner.items, 0, newItems, 0, owner.itemsCount);
                owner.items = newItems;
            }

            if (index < owner.itemsCount)
                Array.Copy(owner.items, index, owner.items, index + 1, owner.itemsCount - index);
            value.owner = owner;
            owner.items[index] = value;
            owner.itemsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        public int Add(string text)
        {
            MenuBoxItem value = new MenuBoxItem(text);
            int index = owner.itemsCount;

            if (owner.items == null)
                owner.items = new MenuBoxItem[5];
            else if (owner.items.Length == owner.itemsCount)
            {
                MenuBoxItem[] newItems = new MenuBoxItem[owner.itemsCount + 5];
                Array.Copy(owner.items, 0, newItems, 0, owner.itemsCount);
                owner.items = newItems;
            }

            if (index < owner.itemsCount)
                Array.Copy(owner.items, index, owner.items, index + 1, owner.itemsCount - index);
            value.owner = owner;
            owner.items[index] = value;
            owner.itemsCount++;
            owner.NativeInsert(value, index);
            return index;
        }

        int IList.Add(object value)
        {
            if (value is MenuBoxItem) return Add((MenuBoxItem)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Clear()
        {
            if (owner.items == null)
                return;
            for (int x = owner.itemsCount; x > 0; x--)
            {
                if (owner.IsHandleCreated)
                    owner.NativeRemoveAt(x - 1);
                owner.items[x - 1].owner = null;
                owner.itemsCount--;
                if (x < owner.itemsCount)
                    Array.Copy(owner.items, x + 1, owner.items, x, owner.itemsCount - x);
                owner.items[owner.itemsCount] = null;
            }
            owner.items = null;
            owner.itemsCount = 0;
        }
        void IList.Clear()
        {
            Clear();
        }

        public bool Contains(MenuBoxItem value)
        {
            return IndexOf(value) != -1;
        }
        bool IList.Contains(object value)
        {
            if (value is MenuBoxItem) return Contains((MenuBoxItem)value);
            else throw new ArgumentException("无效的 value");
        }

        public int IndexOf(MenuBoxItem value)
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
            if (value is MenuBoxItem) return IndexOf((MenuBoxItem)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Insert(int index, MenuBoxItem value)
        {
            if (value == null)
                throw new ArgumentNullException("无效 value");
            if (index < 0 || ((owner.items != null) && (index > owner.itemsCount)))
                throw new ArgumentOutOfRangeException("无效 index");

            if (owner.items == null)
                owner.items = new MenuBoxItem[5];
            else if (owner.items.Length == owner.itemsCount)
            {
                MenuBoxItem[] newItems = new MenuBoxItem[owner.itemsCount + 5];
                Array.Copy(owner.items, 0, newItems, 0, owner.itemsCount);
                owner.items = newItems;
            }
            if (index < owner.itemsCount)
                Array.Copy(owner.items, index, owner.items, index + 1, owner.itemsCount - index);

            owner.items[index] = value;
            owner.itemsCount++;

            owner.NativeInsert(value, index);
        }
        void IList.Insert(int index, object value)
        {
            if (value is MenuBoxItem) Insert(index, (MenuBoxItem)value);
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

        public void Remove(MenuBoxItem value)
        {
            int index = IndexOf(value);
            if (index != -1) RemoveAt(index);
        }
        void IList.Remove(object value)
        {
            if (value is MenuBoxItem) Remove((MenuBoxItem)value);
            else throw new ArgumentException("无效的 value");
        }

        public void RemoveAt(int index)
        {
            int count = (owner.items == null) ? 0 : owner.itemsCount;
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("无效 index");

            if (owner.IsHandleCreated)
                owner.NativeRemoveAt(index);

            owner.items[index].owner = null;
            owner.itemsCount--;
            if (index < owner.itemsCount)
                Array.Copy(owner.items, index + 1, owner.items, index, owner.itemsCount - index);
            owner.items[owner.itemsCount] = null;
        }
        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (owner.itemsCount > 0) Array.Copy(owner.items, 0, array, index, owner.itemsCount);
        }

        public int Count
        {
            get
            {
                return owner.itemsCount;
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
            return new ArrayEnumerator(owner.items, owner.itemsCount);
        }
    }
}
