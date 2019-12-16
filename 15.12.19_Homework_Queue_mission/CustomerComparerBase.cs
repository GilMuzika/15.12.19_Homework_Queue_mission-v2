using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._12._19_Homework_Queue_mission
{
    abstract class CustomerComparerBase<T>: IComparer<T>
    {
        public string PropertyName { get; set; } = "xxx";

        public abstract int Compare(T x, T y);
    }
}
