using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._12._19_Homework_Queue_mission
{
    class CustomerComparerByStringProperty<T> : CustomerComparerBase<T>
    {
        public override int Compare(T x, T y)
        {
            string propertyX = (string)x.GetType().GetProperties().Where(n => n.Name.Equals(PropertyName)).First().GetValue(x);
            string propertyY = (string)y.GetType().GetProperties().Where(n => n.Name.Equals(PropertyName)).First().GetValue(y);

            if (ReferenceEquals(propertyX, propertyY)) return 0;
            else return compareCharsNumericReprsentation(propertyX, propertyY);

        }

        private int compareCharsNumericReprsentation(string x, string y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    if ((int)x[i] != (int)y[j])
                    {
                        if ((int)x[i] > (int)y[j]) return 1;
                        if ((int)x[i] < (int)y[j]) return -1;
                    }

                }
            }

            return 0;



        }
    }
}
