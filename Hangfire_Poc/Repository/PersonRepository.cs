namespace Hangfire_Poc.Repository
{
    using Hangfire_Poc.Models;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="PersonRepository" />
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Defines the ConnectionString
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Defines the cmd
        /// </summary>
        private SqlCommand cmd;

        /// <summary>
        /// Defines the sqlData
        /// </summary>
        private SqlDataAdapter sqlData;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public PersonRepository()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[StaticConstants.TestConnectionString].ConnectionString;
        }

        /// <summary>
        /// The SetEmployeeDetails
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool SetEmployeeDetails(Person person)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (cmd = new SqlCommand(StaticConstants.SetEmployeeDetails.Procedure, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.Id, person.Id);
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.FirstName, person.FirstName);
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.LastName, person.LastName);
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.PayRate, person.PayRate);
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.StartDate, person.StartDate);
                        cmd.Parameters.AddWithValue(StaticConstants.SetEmployeeDetails.Parameters.EndDate, person.EndDate);
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        return cmd.ExecuteNonQuery() > 0;

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The GetPersonById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetPersonById(int id)
        {
            DataTable dtPerson = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (cmd = new SqlCommand(StaticConstants.GetPersonById.Procedure, conn))
                    {
                        using (sqlData = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue(StaticConstants.GetPersonById.Parameters.Id, id
                                );
                            sqlData.Fill(dtPerson);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return dtPerson;
        }

        /// <summary>
        /// The GetPersonList
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetPersonList()
        {
            DataTable dtPerson = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (cmd = new SqlCommand(StaticConstants.GetPersonById.Procedure, conn))
                    {
                        using (sqlData = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sqlData.Fill(dtPerson);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return dtPerson;
        }

        /// <summary>
        /// The DeleteEmployeeById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool DeleteEmployeeById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (cmd = new SqlCommand(StaticConstants.DeleteEmployeeById.Procedure, conn))
                    {
                        using (sqlData = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue(StaticConstants.DeleteEmployeeById.Parameters.Id, id);
                            if (conn.State == ConnectionState.Closed)
                            {
                                conn.Open();
                            }
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The UpdateEmployeeDetails
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="person">The person<see cref="Person"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateEmployeeDetails(int id, Person person)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (cmd = new SqlCommand(StaticConstants.UpdateEmployeeDetails.Procedure, conn))
                    {
                        using (sqlData = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.Id, id);
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.FirstName, person.FirstName);
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.LastName, person.LastName);
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.PayRate, person.PayRate);
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.StartDate, person.StartDate);
                            cmd.Parameters.AddWithValue(StaticConstants.UpdateEmployeeDetails.Parameters.EndDate, person.EndDate);
                            if (conn.State == ConnectionState.Closed)
                            {
                                conn.Open();
                            }
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
