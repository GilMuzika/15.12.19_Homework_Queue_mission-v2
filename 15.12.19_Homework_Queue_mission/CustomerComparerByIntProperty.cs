using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._12._19_Homework_Queue_mission
{
    class CustomerComparerByIntProperty<T> : CustomerComparerBase<T>
    {
        public override int Compare(T x, T y)
        {
            int propertyX = (int)x.GetType().GetProperties().Where(n => n.Name.Equals(PropertyName)).First().GetValue(x);
            int propertyY = (int)y.GetType().GetProperties().Where(n => n.Name.Equals(PropertyName)).First().GetValue(y);

            return propertyX - propertyY;
        }

    }
}
