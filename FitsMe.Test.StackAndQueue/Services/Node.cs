using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsMe.Test.StackAndQueue.Services
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Link { get; set; }
    }
}
