using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataService
    {
        public DataTable GetDataTableByText(string cnString, SqlCommand com, string comText)
        {
            //SqlConnection con = new SqlConnection { ConnectionString = cnString };
            //com.Connection = con;
            //com.CommandType = CommandType.Text;
            //com.CommandText = comText;

            //SqlDataAdapter adapt = new SqlDataAdapter { SelectCommand = com };
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);

            //return dt;

            SqlConnection con = new SqlConnection { ConnectionString = cnString };

            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = comText;
            con.Open();
            DataTable dt = new DataTable();

            using (SqlDataReader sdr = com.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            return dt;

        }


        public DataTable GetDataTableBySP(string cnString, SqlCommand com, string comText)
        {
            //SqlConnection con = new SqlConnection { ConnectionString = cnString };
            //com.Connection = con;
            //com.CommandType = CommandType.StoredProcedure;
            //com.CommandText = comText;

            //SqlDataAdapter adapt = new SqlDataAdapter { SelectCommand = com };
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);

            //return dt;

            SqlConnection con = new SqlConnection { ConnectionString = cnString };

            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = comText;
            con.Open();
            DataTable dt = new DataTable();

            using (SqlDataReader sdr = com.ExecuteReader())
            {
                dt.Load(sdr);

            }
            con.Close();
            return dt;
        }

        public void ExecuteNonQueryBySp(string cnString, SqlCommand com, string comText)
        {
            SqlConnection con = new SqlConnection { ConnectionString = cnString };
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = comText;

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataTable LoadData(string ConString, string Fields, string From, string WHERE, string OrderBy)
        {
            string TSQL = null;

            if (Fields != null)
            {
                TSQL = TSQL + " SELECT " + Fields + " ";
            }

            if (From != null)
            {
                TSQL = TSQL + " FROM " + From + " ";
            }

            if (WHERE != null)
            {
                TSQL = TSQL + " WHERE " + WHERE;
            }

            if (OrderBy != null)
            {
                TSQL = TSQL + " Order by " + OrderBy;
            }

            SqlCommand com = new SqlCommand();

            DataService dalData = new DataService();
            return dalData.GetDataTableByText(ConString, com, TSQL);
        }
    }
}