using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalDiary.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonalDiary> PersonalDiaries { get; set; }
    }
}
