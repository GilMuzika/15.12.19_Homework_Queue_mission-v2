using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._12._19_Homework_Queue_mission
{
    class ComboItem<T>
    {
        public T ValueName { get; set; } = default(T);
        public T ValueType { get; set; } = default(T);

        public ComboItem(T valueName)
        {
            ValueName = valueName;
        }

        public ComboItem(T valueName, T valueType) : this(valueName)
        {
            ValueType = valueType;
        }

        public override string ToString()
        {
            return ValueName.ToString();
            //return ValueType.ToString();
        }
    }
}
