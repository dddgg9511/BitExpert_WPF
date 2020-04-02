using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WPFSparkClient
{
    class HrDAC
    {
        private string connectionString;
        private static readonly HrDAC instance = new HrDAC();

        private HrDAC()
        {
            connectionString = Properties.Settings.Default.ConnectionString;
        }

        public static HrDAC Instance
        {
            get
            {
                return instance;
            }
        }
        public Employee GetEmployee(long id)
        {
            Employee employee = new Employee();

            string sql = "SELECT E1.EMPLOYEE_ID 이름,E1.FIRST_NAME 성,E1.LAST_NAME 이름,E1.EMAIL,e1.PHONE_NUMBER,E1.HIRE_DATE,J.JOB_TITLE,E1.SALARY,E1.COMMISSION_PCT,E2.FIRST_NAME 매니저, D.DEPARTMENT_NAME" +
                        " FROM EMPLOYEES E1 left JOIN EMPLOYEES E2 ON E1.MANAGER_ID = E2.EMPLOYEE_ID" +
                        " left JOIN DEPARTMENTS D ON E1.DEPARTMENT_ID = D.DEPARTMENT_ID" +
                        " JOIN JOBS J ON J.JOB_ID = E1.JOB_ID   WHERE e1.EMPLOYEE_ID = :EMPLOYEE_ID"; 

            //string sql = "SELECT * FROM EMPLOYEES WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(sql, conn)
                {
                    CommandType = System.Data.CommandType.Text,
                    BindByName = true
                };
                cmd.Parameters.Add(":EMPLOYEE_ID", OracleDbType.Long).Value = id;
                conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        employee.Employee_id = reader.GetInt64(0);
                        employee.First_name = reader.GetString(1);
                        employee.Last_name = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.Phone_number = reader.GetString(4);
                        employee.Hire_date = reader.GetDateTime(5);
                        employee.Job_id = reader.GetString(6);
                        employee.Salary = reader.GetDouble(7);
                        employee.Commission = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        employee.Manager_ID = reader.IsDBNull(9) ? "0" : reader.GetString(9);
                        employee.Department_ID = reader.IsDBNull(10) ? "0" : reader.GetString(10);
                    }
                }
            }

            return employee;
        }

        public ICollection<Employee> GetEmployeeList()
        {
            ICollection<Employee> empList = new List<Employee>();
            string sql = "SELECT E1.EMPLOYEE_ID 이름,E1.FIRST_NAME 성,E1.LAST_NAME 이름,E1.EMAIL,e1.PHONE_NUMBER,E1.HIRE_DATE,J.JOB_TITLE,E1.SALARY,E1.COMMISSION_PCT,E2.FIRST_NAME 매니저, D.DEPARTMENT_NAME" +
                      " FROM EMPLOYEES E1 left JOIN EMPLOYEES E2 ON E1.MANAGER_ID = E2.EMPLOYEE_ID" +
                      " left JOIN DEPARTMENTS D ON E1.DEPARTMENT_ID = D.DEPARTMENT_ID" +
                      " JOIN JOBS J ON J.JOB_ID = E1.JOB_ID";
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = new OracleCommand(sql, conn)
                    {
                        CommandType = System.Data.CommandType.Text,
                        BindByName = true
                    };
                    conn.Open();

                    using(OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Employee_id = reader.GetInt64(0);
                            employee.First_name = reader.GetString(1);
                            employee.Last_name = reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.Phone_number = reader.GetString(4);
                            employee.Hire_date = reader.GetDateTime(5);
                            employee.Job_id = reader.GetString(6);
                            employee.Salary = reader.GetDouble(7);
                            employee.Commission = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                            employee.Manager_ID = reader.IsDBNull(9) ? "0" : reader.GetString(9);
                            employee.Department_ID = reader.IsDBNull(10) ? "0" : reader.GetString(10);

                            empList.Add(employee);
                        }
                    }
                }
            }
            catch(Exception e)
            {
              
            }

            return empList;
        }


        public ICollection<int> GetEmpNumList()
        {
            ICollection<int> empList = new List<int>();
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                  
                    conn.Open();

                    string sql = "Select Employee_id from Employees";
                    OracleCommand cmd = new OracleCommand(sql, conn)
                    {
                        CommandType = System.Data.CommandType.Text
                    };
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empList.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return empList;
        }


        public DataSet getInfo()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.TableDirect;
                    cmd.CommandText = "Locations";
                    cmd.Connection = conn;

                    OracleDataAdapter oracleAdapter = new OracleDataAdapter(cmd);

                    oracleAdapter.Fill(dataSet, "Locations");

                    cmd.CommandText = "Jobs";
                    oracleAdapter.Fill(dataSet, "Jobs");
                }
            }
            catch(Exception e)
            {
                
            }
            return dataSet;
        }
    }
}
