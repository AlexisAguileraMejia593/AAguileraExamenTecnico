using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Ex { get; set; }
        public List<Object> Objects { get; set; }
        public object Object { get; set; }
    }
}
