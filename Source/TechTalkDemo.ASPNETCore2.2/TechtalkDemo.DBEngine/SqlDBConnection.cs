using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace TechtalkDemo.DBEngine
{

    public interface  ISqlDBConnection
    {
        object ExecuteScalar(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null);

        int ExecuteNonQuery(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null);

        DataTable ExecuteTable(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null);
        DataSet ExecuteDataSet(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null);
    }


    public class SqlDBConnection : ISqlDBConnection
    {
        public string sConn = "";

        public SqlDBConnection(IConfiguration configuration)
        {
            sConn = configuration.GetConnectionString("DemoConnString");
        }
        
        public object ExecuteScalar(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null)
        {
            object obj = new object();

            using (SqlConnection connection = new SqlConnection(sConn))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sQuery, connection);
                command.CommandType = commandType;

                if (objSqlPar != null)
                    command.Parameters.AddRange(objSqlPar);

                obj = command.ExecuteScalar();    // To return the Objects  int ,string
                connection.Close();
            }

            return obj;

        }

        public int ExecuteNonQuery(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null)
        {
            int result = new int();
            using (SqlConnection connection = new SqlConnection(sConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sQuery, connection);
                command.CommandType = commandType;

                if (objSqlPar != null)
                    command.Parameters.AddRange(objSqlPar);



                result = command.ExecuteNonQuery();    // To return the Objects  int ,string
                connection.Close();
            }
            return result;

        }
        
        public DataTable ExecuteTable(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(sConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sQuery, connection);
                command.CommandType = commandType;
                if (objSqlPar != null)
                    command.Parameters.AddRange(objSqlPar);

                SqlDataAdapter adpt = new SqlDataAdapter(command);  /// To return data table, datatset
                adpt.Fill(table);
                connection.Close();
            }
            return table;
        }
        public DataSet ExecuteDataSet(string sQuery, CommandType commandType = CommandType.Text, SqlParameter[] objSqlPar = null)
        {
            DataSet table = new DataSet();
            using (SqlConnection connection = new SqlConnection(sConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sQuery, connection);
                command.CommandType = commandType;
                if (objSqlPar != null)
                    command.Parameters.AddRange(objSqlPar);

                SqlDataAdapter adpt = new SqlDataAdapter(command);  /// To return data table, datatset
                adpt.Fill(table);
                connection.Close();
            }
            return table;
        }

    }

}
