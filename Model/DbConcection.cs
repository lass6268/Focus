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
        //please don't hardcode connections strings!!, what do you do if you switch database ?!?
        private static string connectionstring =
               "Server=EALSQL1.eal.local; Database = DB2017_C09; User Id = user_C09; PassWord=SesamLukOp_09;";

        //use config files :)
        public string ConStr
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["dbcon"]; }
        }
        public string AddProject(string name,int minBudget,int maxbudget,DateTime startDate,DateTime finishDate)
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

                    return "projekt has been made";
                }
                catch(SqlException e)
                {
                    
                        

                    return e.Message;      
                }
            }
        }
        public void ArchiveProject(string nameArchived,int minBudgetArchived,int maxbudgetArchived,DateTime startDateArchived,DateTime finishDateArchived, int obtainedBudget)
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
                    cmd.Parameters.Add(new SqlParameter("@ObtainedBudget",obtainedBudget));


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
            string ProjektID, ProjektName, minBudget, maxBudget, StartDate, FinishDate,IsArchived; 
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
                            //use this value to indicate if a project has been archived or not.
                            //so if value = False, show in UI.
                            IsArchived = showProjects["IsArchived"].ToString();
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
