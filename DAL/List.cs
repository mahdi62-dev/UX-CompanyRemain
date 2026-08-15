using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class List
    {
        public DataTable LoadData(string ConString, string Fields, string TableName, string WHERE)
        {
            string TSQL = null;

            if (Fields != null)
            {
                TSQL = TSQL + " SELECT " + Fields + " ";
            }

            if (TableName != null)
            {
                TSQL = TSQL + " FROM " + TableName + " ";
            }

            if (WHERE != null)
            {
                TSQL = TSQL + " WHERE " + WHERE;
            }

            SqlCommand com = new SqlCommand();

            DataService dalData = new DataService();
            return dalData.GetDataTableByText(ConString, com, TSQL);
        }
    }
}