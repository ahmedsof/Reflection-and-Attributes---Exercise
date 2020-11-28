using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        [MyRange(12, 90)]
       // [Range(12, 90)]
        public int Age { get; set; }

        [MyRequired]
        //[Required]
        public string FullName { get; set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

    }
}
