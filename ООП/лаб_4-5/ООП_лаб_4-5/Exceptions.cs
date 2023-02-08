using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    abstract class ExceptionPlant : Exception
    {
        public abstract uint Value { get; }
        public ExceptionPlant(string message)
        {

        }
    }

    class ExceptionAge : ExceptionPlant
    {
        public override uint Value { get; }
        public ExceptionAge(string message, uint val) : base(message)
        {
            Value = val;
        }
    }

    class ExceptionCost : ExceptionPlant
    {
        public override uint Value { get; }
        public ExceptionCost(string message, uint val) : base(message)
        {
            Value = val;
        }
    }





}
