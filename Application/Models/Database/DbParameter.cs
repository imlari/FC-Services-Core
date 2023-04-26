using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Database
{
    public class DbParameter
    {
        public string Name { get; set; } = string.Empty;
        public object? Value { get; set; }
        public ParameterDirection Direction { get; set; }
    }
}
