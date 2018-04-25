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

        //config fil til database connection
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

        public List<Project> GetArchivedProjects(int projId)
        {

            List<Project> plst = new List<Project>();
            int ProjektID, minBudget, maxBudget;
            string ProjektName;
            DateTime StartDate, FinishDate;
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("[Spu_Get_Focus_ArchiveProject]",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@projId",projId));
                    SqlDataReader showProjects = cmd.ExecuteReader();

                    if(showProjects.HasRows)
                    {
                        while(showProjects.Read())
                        {

                            ProjektID = int.Parse(showProjects["ProjektID"].ToString());
                            ProjektName = showProjects["ProjektName"].ToString();
                            minBudget = int.Parse(showProjects["minBudget"].ToString());


                            maxBudget = int.Parse(showProjects["maxBudget"].ToString());
                            StartDate = DateTime.Parse(showProjects["StartDate"].ToString());
                            FinishDate = DateTime.Parse(showProjects["FinishDate"].ToString());
                            Project project = new Project(ProjektID,ProjektName,minBudget,maxBudget,StartDate,FinishDate);

                            plst.Add(project);
                        }
                    }
                }
                catch(SqlException e)
                {

                    throw e;
                }
                return plst;
            }
           
        }
        public void ArchiveProject(int projectID)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_ArchiveProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@projId",projectID));
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException e)
                {

                    throw e;
                }

            }
        }

        public bool AddBudget(int CurrentBudgetID, int CurrentBudget, int ProjektID, int EmployeeID)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_CreateBudget", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CurrentBudgetID", CurrentBudgetID));
                    cmd.Parameters.Add(new SqlParameter("@ProjektID", ProjektID));
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    cmd.Parameters.Add(new SqlParameter("@CurrentBudget", CurrentBudget ));

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException)
                {

                    return false;
                }
            }
        }

        public List<Project> OverviewOverProjects()
        {
            List<Project> projectList = new List<Project>();
            int ProjektID, minBudget, maxBudget;
            string ProjektName;
            DateTime StartDate, FinishDate; 
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
                            ProjektID = int.Parse(showProjects["ProjektID"].ToString());
                            ProjektName = showProjects["ProjektName"].ToString();
                            minBudget = int.Parse(showProjects["minBudget"].ToString());
                            

                            maxBudget = int.Parse(showProjects["maxBudget"].ToString());
                            StartDate = DateTime.Parse(showProjects["StartDate"].ToString());
                            FinishDate = DateTime.Parse(showProjects["FinishDate"].ToString());
                            //use this value to indicate if a project has been archived or not.
                            //so if value = False, show in UI.
                            Project project = new Project(ProjektID,ProjektName,minBudget,maxBudget,StartDate,FinishDate);
                            //IsArchived = showProjects["IsArchived"].ToString();
                            projectList.Add(project);
                            
                            //Lav det om til en Projektlist, mere end en StringList
                        }
                    } return projectList;
                }
                catch (SqlException e)
                {
                    throw e; 
                }

            }
        }
        public int GetObtainedBudget(int projectID)
        {
            int CurrentBudget = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[Spu_Focus_TotalBudget]",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjektID", projectID));
                    SqlDataReader showProjects = cmd.ExecuteReader();

                    if(showProjects.HasRows)
                    {
                        while(showProjects.Read())
                        {

                             
                           
                                int budget = int.Parse((showProjects["CurrentBudget"].ToString()));
                                CurrentBudget += budget;
                            
                          

                        }

                    }
                    return CurrentBudget;
                } 
                catch(SqlException e)
                {

                    throw e;
                }
            }


        }
        public string UpdateProject(Project updateProject)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand updatesEmployee = new SqlCommand("Spu_Focus_UpdateProject", con);
                    updatesEmployee.CommandType = CommandType.StoredProcedure;
                    updatesEmployee.Parameters.Add(new SqlParameter("@ProjektName", updateProject.ProjectName));
                    updatesEmployee.Parameters.Add(new SqlParameter("@minBudget", updateProject.MinBudget));
                    updatesEmployee.Parameters.Add(new SqlParameter("@maxBudget", updateProject.MaxBudget));
                    updatesEmployee.Parameters.Add(new SqlParameter("@Startdate", updateProject.StartDate));
                    updatesEmployee.Parameters.Add(new SqlParameter("@Finishdate", updateProject.FinishDate));
                    updatesEmployee.Parameters.Add(new SqlParameter("@ProjektID", updateProject.ProjectID));

                    updatesEmployee.ExecuteNonQuery();
                    return string.Empty;
                }
                catch (SqlException e)
                {
                    return e.Message;
                    
                }
                
            }
            
        }

    }
}
