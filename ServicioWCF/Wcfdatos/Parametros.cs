using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Wcfdatos
{
    public class Parametros
    {
        public string ProcedureOrQuery { get; set; }
        public string Table { get; set; }
        public string Field { get; set; }
        public string Condition { get; set; }
        public CommandType commandType { get; set; }
        public IList<SqlParameter> Parameters { get; set; }
    }
}