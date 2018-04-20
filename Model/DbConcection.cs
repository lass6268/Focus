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

        public void AddProject(string name,int minBudget,int maxbudget,DateTime startDate,DateTime finishDate)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_InvalidProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjektName",name));
                    cmd.Parameters.Add(new SqlParameter("@minBudget",minBudget));
                    cmd.Parameters.Add(new SqlParameter("@maxBudget",maxbudget));
                    cmd.Parameters.Add(new SqlParameter("@Startdate",startDate));
                    cmd.Parameters.Add(new SqlParameter("@Finishdate",finishDate));

                    cmd.ExecuteNonQuery();

                    
                }
                catch(SqlException e)
                {

                    throw e;
                }
            }
        }
        public void ArchiveProject(string nameArchived,int minBudgetArchived,int maxbudgetArchived,DateTime startDateArchived,DateTime finishDateArchived)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_ArchiveProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjectName_Archived",nameArchived));
                    cmd.Parameters.Add(new SqlParameter("@minBudget_Archived",minBudgetArchived));
                    cmd.Parameters.Add(new SqlParameter("@maxBudget_Archived",maxbudgetArchived));
                    cmd.Parameters.Add(new SqlParameter("@Startdate_Archived",startDateArchived));
                    cmd.Parameters.Add(new SqlParameter("@Finishdate_Archived",finishDateArchived));

                    cmd.ExecuteNonQuery();

                    
                }
                catch(SqlException e)
                {

                    throw e;
                }
            }
        }

        public bool AddBudget(int BudgetTotal, int CurrentBudget, DateTime BudgetStartdate, DateTime BudgetFinishDate)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_CreateBudget", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@BudgetMin", BudgetStartdate ));
                    cmd.Parameters.Add(new SqlParameter("@BudgetMax", BudgetFinishDate));

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException)
                {

                    return false;
                }
            }
        }

        public List<string> OverviewOverProjects()
        {
            List<string> projectList = new List<string>();
            string ProjektID, ProjektName, minBudget, maxBudget, StartDate, FinishDate; 
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand ProjectOverview = new SqlCommand("Spu_Focus_ProjectOverview", con);
                    ProjectOverview.CommandType = CommandType.StoredProcedure;
                    SqlDataReader showProjects = ProjectOverview.ExecuteReader();

                    if (showProjects.HasRows)
                    {
                        while (showProjects.Read())
                        {
                            ProjektID = showProjects["ProjektID"].ToString();
                            ProjektName = showProjects["ProjektName"].ToString();
                            minBudget = showProjects["minBudget"].ToString();
                            maxBudget = showProjects["maxBudget"].ToString();
                            StartDate = showProjects["StartDate"].ToString();
                            FinishDate = showProjects["FinishDate"].ToString();
                            projectList.Add(ProjektID + " " + ProjektName + " " + minBudget + " " + maxBudget + " " + StartDate + " " + FinishDate);
                            
                        }
                    } return projectList;
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
        }

    }
}
