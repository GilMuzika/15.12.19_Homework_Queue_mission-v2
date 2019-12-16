using System;
using System.Collections.Generic;
using System.Text;

namespace _15._12._19_Homework_Queue_mission
{

    class CustomOutOfBoundsException : Exception
    {
        public Exception BackFallSystemException { get; set; }
        public int InTheCaseOfTheException { get; set; }
        public Type TypeOftTheCollection { get; set; }




        public CustomOutOfBoundsException() : base("The number is out of bounds of the array") { }

        public CustomOutOfBoundsException(int num) : base("The object with index " + num.ToString() + " is  out of bounds of the collection") { InTheCaseOfTheException = num; }

        public CustomOutOfBoundsException(int num, Type type) : base("The object with index " + num.ToString() + " is  out of bounds of the collection " + type.Name) { InTheCaseOfTheException = num; TypeOftTheCollection = type; }


    }
}

