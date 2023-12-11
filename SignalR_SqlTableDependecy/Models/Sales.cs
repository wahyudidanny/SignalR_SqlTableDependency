using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_SqlTableDependecy.Models
{
    public class Sales
    {
        public Int32? Id { get; set; }
        public string? Customer { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PurchaseOn { get; set; }
    }
}