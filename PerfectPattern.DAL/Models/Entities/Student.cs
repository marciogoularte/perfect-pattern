using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPattern.DAL.Models.Entities
{
    [TableName("Students")]
    public class Student
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Age")]
        public int Age { get; set; }
    }
}
