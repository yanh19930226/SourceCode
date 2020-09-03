using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lambda表达式树简化查询.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int Age { get; set; }
    }
}