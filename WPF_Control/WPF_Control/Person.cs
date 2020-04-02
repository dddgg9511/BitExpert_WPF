using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ElementBinding
{
    class Person
    {
        public Person()
        {
            Name = "홍길동";
            Age = 21;
        }
        public string Name
        {
            get;set;
        }
        public int Age
        {
            get;set;
        }
    }
}
