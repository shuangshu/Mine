using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Windows.SystemControl
{
    public class RebarBandCollection : IList
    {
        public Rebar owner;
        public RebarBandCollection(Rebar owner)
        {
            this.owner = owner;
        }

        public int Add(Control child)
        {
            RebarBand value = new RebarBand(child);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(int imageIndex)
        {
            RebarBand value = new RebarBand(imageIndex);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(int imageIndex, Control child)
        {
            RebarBand value = new RebarBand(imageIndex, child);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(RebarBand value)
        {
            if (value == null)
                throw new ArgumentNullException("无效 TRebarBand");
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(string text)
        {
            RebarBand value = new RebarBand(text);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(string text, int imageIndex)
        {
            RebarBand value = new RebarBand(text, imageIndex);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(string text, Control child)
        {
            RebarBand value = new RebarBand(text, child);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        public int Add(string text, int imageIndex, Control child)
        {
            RebarBand value = new RebarBand(text, imageIndex, child);
            int index = owner.bandsCount;
            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }

            if (index < owner.bandsCount)
                Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            value.owner = owner;
            owner.bands[index] = value;
            owner.bandsCount++;
            owner.InsertRebarBand(value, index);
            return index;
        }

        int IList.Add(object value)
        {
            if (value is RebarBand) return Add((RebarBand)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Clear()
        {
            if (owner.bands == null) return;
            for (int x = owner.bandsCount; x > 0; x--)
            {
                if (owner.IsHandleCreated)
                    owner.DeleteRebarBand(x - 1);
                owner.bands[x - 1].owner = null;
                owner.bandsCount--;
                if (x < owner.bandsCount)
                    Array.Copy(owner.bands, x + 1, owner.bands, x, owner.bandsCount - x);
                owner.bands[owner.bandsCount] = null;
            }
            owner.bands = null;
            owner.bandsCount = 0;
        }
        void IList.Clear()
        {
            Clear();
        }

        public bool Contains(RebarBand value)
        {
            return IndexOf(value) != -1;
        }
        bool IList.Contains(object value)
        {
            if (value is RebarBand) return Contains((RebarBand)value);
            else throw new ArgumentException("无效的 value");
        }

        public int IndexOf(RebarBand value)
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
            if (value is RebarBand) return IndexOf((RebarBand)value);
            else throw new ArgumentException("无效的 value");
        }

        public void Insert(int index, RebarBand value)
        {
            if (value == null)
                throw new ArgumentNullException("无效 value");
            if (index < 0 || ((owner.bands != null) && (index > owner.bandsCount)))
                throw new ArgumentOutOfRangeException("无效 index");

            if (owner.bands == null)
                owner.bands = new RebarBand[5];
            else if (owner.bands.Length == owner.bandsCount)
            {
                RebarBand[] newBands = new RebarBand[owner.bandsCount + 5];
                Array.Copy(owner.bands, 0, newBands, 0, owner.bandsCount);
                owner.bands = newBands;
            }
            if (index < owner.bandsCount) Array.Copy(owner.bands, index, owner.bands, index + 1, owner.bandsCount - index);

            owner.bands[index] = value;
            owner.bandsCount++;

            owner.InsertRebarBand(value, index);
        }
        void IList.Insert(int index, object value)
        {
            if (value is RebarBand) Insert(index, (RebarBand)value);
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

        public void Remove(RebarBand value)
        {
            int index = IndexOf(value);
            if (index != -1) RemoveAt(index);
        }
        void IList.Remove(object value)
        {
            if (value is RebarBand) Remove((RebarBand)value);
            else throw new ArgumentException("无效的 value");
        }

        public void RemoveAt(int index)
        {
            int count = (owner.bands == null) ? 0 : owner.bandsCount;
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("无效 index");
            if (owner.IsHandleCreated)
                owner.DeleteRebarBand(index);
            owner.bands[index].owner = null;
            owner.bandsCount--;
            if (index < owner.bandsCount) Array.Copy(owner.bands, index + 1, owner.bands, index, owner.bandsCount - index);
            owner.bands[owner.bandsCount] = null;
        }
        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        public virtual RebarBand this[int index]
        {
            get
            {
                if ((index < 0) && owner.bands != null && index > owner.bands.Length)
                    throw new ArgumentException("无效的 index");
                return owner.bands[index];
            }
            set
            {
                if ((index < 0) && owner.bands != null && index > owner.bands.Length)
                    throw new ArgumentException("无效的 index");
                if (value == null) throw new ArgumentNullException("value");
                owner.UpdateRebarBand(value, index);
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
                if (value is RebarBand) this[index] = (RebarBand)value;
                else throw new ArgumentException("无效的 value");
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (owner.bandsCount > 0) Array.Copy(owner.bands, 0, array, index, owner.bandsCount);
        }

        public int Count
        {
            get { return owner.bandsCount; }
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
            return new ArrayEnumerator(owner.bands, owner.bandsCount);
        }
    }
}
