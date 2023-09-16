using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL
{
      public class Common
    {
        public const string GetValues = "dbo.Sp_InsertMyUDTableByMyUDTableType";
    }


    public enum GetActionValues
    {
        Insert=1,
        Read=2
    }
}
