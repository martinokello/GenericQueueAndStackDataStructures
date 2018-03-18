using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsMe.Test.StackAndQueue.Services
{
    public class DoubleNode<T>
    {
        public DoubleNode<T> LeftLink { get; set; }
        public DoubleNode<T> RightLink { get; set; }
        public T Value { get; set; }
    }
}
