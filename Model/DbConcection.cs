using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class DbConcection
    {
        private static string connectionstring =
               "Server=EALSQL1.eal.local; Database = DB2017_C09; User Id = user_C09; PassWord=SesamLukOp_09;";

        public bool AddProject(string name,int minBudget,int maxbudget,DateTime startDate,DateTime finishDate)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_InvalidProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjectName",name));
                    cmd.Parameters.Add(new SqlParameter("@minBudget",minBudget));
                    cmd.Parameters.Add(new SqlParameter("@maxBudget",maxbudget));
                    cmd.Parameters.Add(new SqlParameter("@Startdate",startDate));
                    cmd.Parameters.Add(new SqlParameter("@Finishdate",finishDate));

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch(SqlException)
                {

                    return false;
                }
            }
        }

    }
}
