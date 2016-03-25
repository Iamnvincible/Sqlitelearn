using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitetry
{
    public class Person
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [MaxLength(5)]
        public string Name { get; set; }

    }
}
