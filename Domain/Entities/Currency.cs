using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public Currency() { }
        public Currency (Guid id, string code, string symbol, string name)
        {
            Id = id;
            Code = code;
            Symbol = symbol;
            Name = name;
        }
    }
}
