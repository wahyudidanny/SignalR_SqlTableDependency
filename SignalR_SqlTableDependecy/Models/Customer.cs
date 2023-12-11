using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_SqlTableDependecy.Models
{
    public class Customer
    {
        public Int32? id { get; set; }
        public string? name { get; set; }
        public string? gender { get; set; }
        public string? mobile { get; set; }

    }
}