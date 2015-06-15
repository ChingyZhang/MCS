using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.Model
{
    public class Dictionay
    {
        int tableId;
        string tableName;
        string tableCode;
        int colID;
        string colName;
        string colCode;

        public int TableId
        {
            get { return tableId; }
            set { tableId = value; }
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public string TableCode
        {
            get { return tableCode; }
            set { tableCode = value; }
        }


        public int ColID
        {
            get { return colID; }
            set { colID = value; }
        }

        public string ColName
        {
            get { return colName; }
            set { colName = value; }
        }

        public string ColCode
        {
            get { return colCode; }
            set { colCode = value; }
        }
    }
}
