﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class DbConnection
    {
        private static string connectionstring =
               "Server=EALSQL1.eal.local; Database = DB2017_C09; User Id = user_C09; PassWord=SesamLukOp_09;";

        //config fil til database connection
        public string ConStr
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["dbcon"]; }
        }
        public string AddProject(Project project)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_InvalidProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjectName",project.ProjectName));
                    cmd.Parameters.Add(new SqlParameter("@minBudget",project.MinBudget));
                    cmd.Parameters.Add(new SqlParameter("@maxBudget",project.MaxBudget));
                    cmd.Parameters.Add(new SqlParameter("@Startdate",project.StartDate));
                    cmd.Parameters.Add(new SqlParameter("@Finishdate",project.FinishDate));

                    cmd.ExecuteNonQuery();

                    return "projekt has been made";
                }
                catch(SqlException e)
                {

                    return e.Message;
                }
            }
        }

        public List<Project> GetArchivedProjects()
        {

            List<Project> archivedProjects = new List<Project>();
            int ProjectID, minBudget, maxBudget, BudgetObtained;
            string ProjectName;
            DateTime StartDate, FinishDate;
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand showArchivedProjects = new SqlCommand("[Spu_Get_Focus_ArchiveProject]",con);
                    showArchivedProjects.CommandType = CommandType.StoredProcedure;
                    SqlDataReader showProjects = showArchivedProjects.ExecuteReader();

                    if(showProjects.HasRows)
                    {
                        while(showProjects.Read())
                        {

                            ProjectID = int.Parse(showProjects["ProjektID_Archived"].ToString());
                            ProjectName = showProjects["ProjektName_Archived"].ToString();
                            minBudget = int.Parse(showProjects["minBudget_Archived"].ToString());
                            maxBudget = int.Parse(showProjects["maxBudget_Archived"].ToString());
                            StartDate = DateTime.Parse(showProjects["StartDate_Archived"].ToString());
                            FinishDate = DateTime.Parse(showProjects["FinishDate_Archived"].ToString());
                            BudgetObtained = int.Parse(showProjects["BudgetObtained"].ToString());
                            Project project = new Project(ProjectID,ProjectName,minBudget,maxBudget,StartDate,FinishDate,BudgetObtained);

                            archivedProjects.Add(project);
                        }
                    }
                    return archivedProjects;
                }
                catch(SqlException e)
                {

                    throw e;
                }

            }

        }
        public void ArchiveProject(Project project)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_ArchiveProject",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@projId",project.ProjectID));
                    cmd.Parameters.Add(new SqlParameter("@CurrentBudget",project.Optainedbudget));

                    cmd.ExecuteNonQuery();
                }
                catch(SqlException e)
                {

                    throw e;
                }

            }
        }
        public void RecoverArchivedProject(int projectID)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_RecoverArchivedProjekts",con);
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

       
        public List<Budget> GetBudgetForProjekt(Project project)
        {
            List<Budget> budgets = new List<Budget>();
            int EmployeeID, CurrentBudget, Minbudget, Maxbudget;
            string EmployeeName;
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Spu_Focus_GetBudgetForPID",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjectID",project.ProjectID));
                    SqlDataReader Reader = cmd.ExecuteReader();




                    if(Reader.HasRows)
                    {
                        while(Reader.Read())
                        {



                            EmployeeID = int.Parse(Reader["EmployeeID"].ToString());
                            if(Reader["CurrentBudget"] == DBNull.Value)
                            {
                                CurrentBudget = 0;
                            }
                            else
                            {
                                CurrentBudget = int.Parse(Reader["CurrentBudget"].ToString());
                            }

                            EmployeeName = Reader["EmployeeName"].ToString();
                            if(Reader["BudgetMin"] == DBNull.Value)
                            {
                                Minbudget = 0;
                            }
                            else
                            {
                                Minbudget = int.Parse(Reader["BudgetMin"].ToString());
                            }
                            if(Reader["BudgetMax"] == DBNull.Value)
                            {
                                Maxbudget = 0;
                            }
                            else
                            {
                                Maxbudget = int.Parse(Reader["BudgetMax"].ToString());
                            }

                            Employee employee = new Employee(EmployeeName,EmployeeID);
                            Budget budget = new Budget(employee,project,CurrentBudget,Minbudget,Maxbudget);
                            budgets.Add(budget);


                        }

                    }
                }

                catch(SqlException e)
                {
                    throw e;

                }


            }
            return budgets;
        }

        public List<Project> OverviewOverProjects()
        {
            List<Project> projectList = new List<Project>();
            int ProjectID, minBudget, maxBudget;
            string ProjectName, EmployeeName;
            DateTime StartDate, FinishDate;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand ProjectOverview = new SqlCommand("Spu_Focus_OverviewFrontPage", con);
                    ProjectOverview.CommandType = CommandType.StoredProcedure;
                    SqlDataReader showProjects = ProjectOverview.ExecuteReader();

                    if (showProjects.HasRows)
                    {
                        while (showProjects.Read())
                        {
                            ProjectID = int.Parse(showProjects["ProjektID"].ToString());
                            ProjectName = showProjects["ProjektName"].ToString();
                            minBudget = int.Parse(showProjects["minBudget"].ToString());


                            maxBudget = int.Parse(showProjects["maxBudget"].ToString());
                            StartDate = DateTime.Parse(showProjects["StartDate"].ToString());
                            FinishDate = DateTime.Parse(showProjects["FinishDate"].ToString());
                            EmployeeName = showProjects["EmployeeName"].ToString();
                            Employee employee = new Employee(EmployeeName);
                            Project project = new Project(ProjectID, ProjectName, minBudget, maxBudget, StartDate, FinishDate, employee);
                           
                            projectList.Add(project);

                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
            return projectList;
        }
        public int GetObtainedBudget(int projectID)
        {
            int CurrentBudget = 0;
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[Spu_Focus_TotalBudget]",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProjektID",projectID));
                    SqlDataReader Reader = cmd.ExecuteReader();

                    if(Reader.HasRows)
                    {
                        while(Reader.Read())
                        {



                            int budget = int.Parse((Reader["CurrentBudget"].ToString()));
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
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();


                    SqlCommand updatesEmployee = new SqlCommand("Spu_Focus_UpdateProject",con);
                    updatesEmployee.CommandType = CommandType.StoredProcedure;
                    updatesEmployee.Parameters.Add(new SqlParameter("@ProjektName",updateProject.ProjectName));
                    updatesEmployee.Parameters.Add(new SqlParameter("@minBudget",updateProject.MinBudget));
                    updatesEmployee.Parameters.Add(new SqlParameter("@maxBudget",updateProject.MaxBudget));
                    updatesEmployee.Parameters.Add(new SqlParameter("@Startdate",updateProject.StartDate));
                    updatesEmployee.Parameters.Add(new SqlParameter("@Finishdate",updateProject.FinishDate));
                    updatesEmployee.Parameters.Add(new SqlParameter("@ProjektID",updateProject.ProjectID));

                    updatesEmployee.ExecuteNonQuery();
                    return updateProject.ProjectName + " Er nu opdateret";
                }
                catch(SqlException e)
                {
                    return e.Message;

                }

            }

        }

        public string UpdateBudget(List<Budget> budgets)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {

                try
                {
                    con.Open();
                    foreach(var budget in budgets)
                    {


                        SqlCommand cmd = new SqlCommand("Spu_Focus_CreateBudget",con);
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.Add(new SqlParameter("@ProjektID",budget.Project.ProjectID));
                        cmd.Parameters.Add(new SqlParameter("@Min",budget.MinBudget));
                        cmd.Parameters.Add(new SqlParameter("@Max",budget.MaxBudget));
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID",budget.Employee.ID));
                        cmd.Parameters.Add(new SqlParameter("@Current",budget.CurrentBudget));

                        cmd.ExecuteNonQuery();
                    }

                }
                catch(SqlException e)
                {

                    return e.Message;
                }
            }
            return "Budgets has been updated";
        }
        public List<Employee> GetEmployeesList()
        {
            List<Employee> employees = new List<Employee>();
            int EmployeeID;
            string EmployeeName;
            using(SqlConnection con = new SqlConnection(connectionstring))

                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Spu_Focus_GetAllEmployees",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader showEmployees = cmd.ExecuteReader();

                    cmd.CommandType = CommandType.StoredProcedure;


                    if(showEmployees.HasRows)
                    {
                        while(showEmployees.Read())
                        {

                            EmployeeID = int.Parse(showEmployees["EmployeeID"].ToString());
                            EmployeeName = showEmployees["EmployeeName"].ToString();
                            Employee employee = new Employee(EmployeeName,EmployeeID);
                            employees.Add(employee);
                        }


                    }

                }
                catch(SqlException e)
                {

                    throw e;
                }
            return employees;
        }
        public List<Employee> GetCurrentBudgetForEmployees()
        {
            List<Employee> employees = GetEmployeesList();
            int CurrentBudget;
            int counter = 0;
            using(SqlConnection connect = new SqlConnection(connectionstring))
            {


                try
                {

                    foreach(var item in employees)
                    {
                        connect.Open();
                        counter = 0;

                        SqlCommand cmd = new SqlCommand("Spu_Focus_GetEmployeesCurrentBudget",connect);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID",item.ID));
                        SqlDataReader showEmployees = cmd.ExecuteReader();




                        if(showEmployees.HasRows)
                        {
                            while(showEmployees.Read())
                            {

                                CurrentBudget = int.Parse(showEmployees["CurrentBudget"].ToString());
                                item.TotalCurrent += CurrentBudget;
                                counter++;

                            }


                        }
                        if(counter == 0)
                        {
                            item.AvgCurrent = 0;
                        }
                        else
                        {
                            item.AvgCurrent = item.TotalCurrent / counter;
                        }
                       

                        connect.Close();
                    }

                }
                catch(SqlException e)
                {

                    throw e;
                }
            }


            return employees;
        }

        public List<Budget> GetBudgetForEMP(Employee employee)
        {
            List<Budget> budgets = new List<Budget>();
            int CurrentBudget, Minbudget, Maxbudget, projectid;
            string Projectname;
          
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Spu_Focus_GetBudgetForEID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EID", employee.ID));
                    SqlDataReader Reader = cmd.ExecuteReader();




                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {


                             Projectname = Reader["ProjektName"].ToString();
                             projectid = int.Parse(Reader["ProjektID"].ToString());
                            
                            if (Reader["BudgetMin"] == DBNull.Value)
                            {
                                Minbudget = 0;
                            }
                            else
                            {
                                Minbudget = int.Parse(Reader["BudgetMin"].ToString());
                            }


                          
                           
                           
                            if (Reader["BudgetMax"] == DBNull.Value)
                            {
                                Maxbudget = 0;
                            }
                            else
                            {
                                Maxbudget = int.Parse(Reader["BudgetMax"].ToString());
                            }
                          

                            if (Reader["CurrentBudget"] == DBNull.Value)
                            {
                                CurrentBudget = 0;
                            }
                            else
                            {
                                CurrentBudget = int.Parse(Reader["CurrentBudget"].ToString());
                            }

                            Project project = new Project(Projectname,projectid);
                            Budget budget = new Budget(employee, project, CurrentBudget, Minbudget, Maxbudget);
                            budgets.Add(budget);
                               


                        }

                    }
                    // Array.Resize(ref EmpBudget, EmpBudget.Length);

                    return budgets;
                }

                catch (SqlException e)
                {
                    throw e;

                }


            }
            
        }


    }
}
