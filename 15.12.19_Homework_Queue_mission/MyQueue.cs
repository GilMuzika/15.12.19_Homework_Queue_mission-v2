using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _15._12._19_Homework_Queue_mission
{
    class MyQueue<T> : IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        #region interfaces implementation
        // interfaces implementation
        public object Current => ((IEnumerator)dataHolderList).Current;

        T IEnumerator<T>.Current => ((IEnumerator<T>)dataHolderList).Current;

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)dataHolderList).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)dataHolderList).GetEnumerator();
        }

        public bool MoveNext()
        {
            return ((IEnumerator)dataHolderList).MoveNext();
        }

        public void Reset()
        {
            ((IEnumerator)dataHolderList).Reset();
        }

        public void Dispose()
        {
            ((IEnumerator<T>)dataHolderList).Dispose();
        }
        // End: interfaces implementation
        #endregion



        private MyLinkedList<T> dataHolderList = new MyLinkedList<T>();

        public int Count { get => dataHolderList.Count; }

        public T this[int index]
        {
            get
            {
                return dataHolderList[index];
            }
            set
            {
                if (index < this.Count) dataHolderList[index] = value;
                else throw new Exception($"You're attempt to accsess a place Num. {index+1} in the queue, and it's beyond the queue current capacity({this.Count})");
            }
        }

        public void Enqueue(T extVal)
        {
            dataHolderList.Add(extVal);
        }
        public T Dequeue()
        {
            if (dataHolderList.First != null)
            {
                T temp = dataHolderList.First.Data;
                dataHolderList.RemoveAt(0);
                return temp;
            }
            throw new Exception("Queue empty");
        }
        public T WhoIsNext()
        {
            if (dataHolderList.First == null) throw new Exception("Queue empty");
            

                return dataHolderList.First.Data;
        }
        public void Init(IEnumerable<T> initList)
        {
            dataHolderList.Clear();
            T temp = default(T);
            this.Enqueue(temp);
            dataHolderList.InsertRange(0, initList);
            dataHolderList.Remove(temp);
        }
        

        public void Clear()
        {
            dataHolderList.Clear();
        }

        public List<T> DequeueCustomer(int num)
        {
            if (num > this.Count) num = this.Count;
            for(int i = 0; i < num; i++) dataHolderList.RemoveAt(i);
            

            if (num > this.Count) num = this.Count;

            List<T> lst = new List<T>();
            for (int i = 0; i < num; i++) lst.Add(this[i]);

            return lst;
        }

        public void AniRakSheeela(T genObj)
        {
            dataHolderList.Insert(0, genObj);
        }

        private void SortBy(string determiner)
        {
            if (typeof(T).GetProperty(determiner) == null) throw new Exception($"Sorry, but the type {typeof(T).Name} don't have a property named {determiner}");

            CustomerComparerByIntProperty<T> comparer = new CustomerComparerByIntProperty<T>();
            comparer.PropertyName = determiner;
            T[] queueAsArray = this.ToArray();
            Array.Sort<T>(queueAsArray, comparer);
            this.Init(queueAsArray);
        }
        public void SortBy(string determinerValue, string determinerType)
        {
            if (typeof(T).GetProperty(determinerValue) == null) throw new Exception($"Sorry, but the type {typeof(T).Name} don't have a property named {determinerValue}");

            CustomerComparerBase<T> comparer;
            T[] queueAsArray = this.ToArray();
            switch (determinerType)
            {
                case "Int32":
                    comparer = new CustomerComparerByIntProperty<T>();
                    comparer.PropertyName = determinerValue;                    
                    Array.Sort<T>(queueAsArray, comparer);
                    
                    break;
                case "String":
                    comparer = new CustomerComparerByStringProperty<T>();
                    comparer.PropertyName = determinerValue;                    
                    Array.Sort<T>(queueAsArray, comparer);

                    break;

            }
            this.Init(queueAsArray);
        }

        public void SortByProtection()
        {
            SortBy("Protection");
        }
        public void SortByTotalPurchases()
        {
            SortBy("TotalPurchases");
        }
        public void SortByBirthYear()
        {
            SortBy("BirthYear");
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach (T s in this) str += s.ToString() + Environment.NewLine;
            return str;
        }



    }




















    class MyLinkedList<T> : IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        public MyListItem<T> First { get; private set; } = null;
        public MyListItem<T> Last { get; private set; } = null;
        private MyListItem<T> CurrentNow { get; set; } = null;
        private Mutex MultiAcsessGuard = new Mutex();
        private int _count = -1;

        //the next two rows are the same, written with different syntax
        //the first is normal propery with only getter, and the second is written with "expression body", where "=>" means "is", 
        //so "Count => _count + 1" means "Count is _count  + 1".
        //public int Count { get { return _count + 1; } }
        public int Count => _count + 1;

        private int _position = 0;

        object IEnumerator.Current
        {
            get { return this[_position]; }
        }

        public T Current
        {
            get { return this[_position]; }
        }

        public T this[int i]
        {
            get
            {
                return GoToNode(i).Data;
            }

            set
            {
                MyListItem<T> newValue = new MyListItem<T>(value);
                MyListItem<T> temp = null;
                if (i == 0)
                {
                    temp = First.Next;
                    First = newValue;
                    First.Next = temp;
                }
                else
                {
                    CurrentNow = GoToNode(i - 1);

                    temp = CurrentNow.Next.Next;

                    newValue.Previous = CurrentNow;
                    newValue.Next = temp;
                    CurrentNow.Next = newValue;
                    CurrentNow.Next.Previous = newValue;
                }
            }
        }

        //constractor plase. This class has only default constractor
        //-----------------------------

        //methods
        //-----------------------------

        public T Get(int ind)
        {
            return GoToNode(ind).Data;
        }


        private MyListItem<T> GoToNode(int ind)
        {
            if (ind >= 0 && ind <= _count)
            {


                MyListItem<T> m = First;
                for (int i = 0; i < ind; i++)
                {
                    m = m.Next;
                }

                /*
                MyListItem<T> m = Last;
                for (int i = 0; i < _count - ind; i++)
                {
                    m = m.Previous;
                }*/

                return m;
            }
            else throw new CustomOutOfBoundsException(ind, this.GetType());


        }

        public void RemoveAt(int ind)
        {
            if (ind >= 0 && ind <= _count)
            {

                MultiAcsessGuard.WaitOne();
                if (ind == 0) { First = First.Next; }
                else if (_count == 1) { Last = Last.Previous; }
                else if (ind == _count && _count != 1) { Last = Last.Previous; Last.Next = null; }
                else
                {
                    CurrentNow = GoToNode(ind - 1);
                    MyListItem<T> temp = new MyListItem<T>();

                    CurrentNow.Next = CurrentNow.Next.Next;
                    CurrentNow.Next.Next.Previous = CurrentNow;


                }
                MultiAcsessGuard.ReleaseMutex();
                _count--;
            }
            else throw new CustomOutOfBoundsException(ind, this.GetType());
        }

        public void Remove(T genObj)
        {
            int ind = FindIndex(genObj);
            RemoveAt(ind);
        }

        private int FindIndex(T genObj)
        {
            int ind = -1;
           for(int i = 0; i < this.Count; i++)
            {
                if (ReferenceEquals(genObj, this[i])) { ind = i; break; }
            }
            if (ind == -1) throw new Exception($"the object {genObj} isn't in the collection");
            else return ind;
           
        }


        public void Insert(int ind, T extVal)
        {
            MyListItem<T> newValue = new MyListItem<T>(extVal);

            if (First == null) { Add(extVal); return; }

            if (ind >= 0 && ind <= _count)
            {

                MultiAcsessGuard.WaitOne();
                if (ind == 0)
                {
                    MyListItem<T> temp = First;
                    First = newValue;
                    First.Next = temp;
                }

                else
                {
                    CurrentNow = GoToNode(ind - 1);

                    MyListItem<T> temp = CurrentNow.Next;

                    CurrentNow.Next = newValue;
                    newValue.Previous = temp;
                    newValue.Next = temp;
                    temp.Previous = newValue;
                }
                MultiAcsessGuard.ReleaseMutex();

                _count++;
            }
            else throw new CustomOutOfBoundsException(ind, this.GetType());

        }

        public void InsertRange(int ind, IEnumerable<T> extVal)
        {
            foreach (var s in extVal) Insert(ind++, s);
        }

        public void Add(T extVal)
        {
            MultiAcsessGuard.WaitOne();
            CurrentNow = new MyListItem<T>(extVal);

            if (Last == null)
            {
                CurrentNow.Previous = null;
                CurrentNow.Next = null;
                First = CurrentNow;
                Last = CurrentNow;
            }
            else
            {
                Last.Next = CurrentNow;
                CurrentNow.Previous = Last;
                Last = CurrentNow;
            }
            MultiAcsessGuard.ReleaseMutex();
            _count++;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            _count = -1;
        }

        public T[] GetAllAsArray()
        {
            T[] arrNodeList = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                arrNodeList[i] = GoToNode(i).Data;
            }
            return arrNodeList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllAsArray().GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }

        }

        public bool MoveNext()
        {
            _position++;
            return _position < Count;
        }

        public void Reset()
        {
            _position = 0;
        }

        void IDisposable.Dispose() { }
    }



    class MyListItem<T>
    {
        public MyListItem<T> Next { get; set; } = null;
        public MyListItem<T> Previous { get; set; } = null;
        public T Data { get; set; } = default(T);

        public MyListItem(T data)
        {
            Data = data;
        }

        public MyListItem()
        {
            Data = default(T);
        }
    }



   
}
