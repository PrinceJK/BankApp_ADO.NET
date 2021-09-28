using System;
using System.Data;
using System.Data.SqlClient;

namespace JohnBankAppADO.NET.Data
{
    public class SQLHelper
    {
        const string CONNECTION_STRING = @"Data Source=.;Initial Catalog=ADONETTEST;Integrated Security=True";


        public static DataTable ExecuteSelectCommand(string commandName, CommandType commandType)
        {
            DataTable dataTable = null;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                using SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = commandName;
                try
                {
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return dataTable;
        }


        public static DataTable ExecuteParameterizedCommand(string commandName, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = commandType;
                    sqlCommand.CommandText = commandName;
                    sqlCommand.Parameters.AddRange(parameters);

                    try
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                        {
                            sqlConnection.Open();
                        }
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                    catch
                    {

                        throw;
                    }
                }
            }
            return dataTable;
        }
        


        public static bool ExecuteNonQuery(string commandName, CommandType commandType, SqlParameter[] sqlParameters)
        {
            int result = 0;
            using(SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = commandType;
                    sqlCommand.CommandText = commandName;
                    sqlCommand.Parameters.AddRange(sqlParameters);
                   

                    try
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                        {
                            sqlConnection.Open();
                        }
                        result = sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {

                        throw;
                    }
                }
            }
            return (result > 0);
        }
    }
}
