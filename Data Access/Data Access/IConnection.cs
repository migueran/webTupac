using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public interface IConnection
    {
        //definir comando
         SqlCommand mycommand { get; set; }
         SqlConnection myconnection { get; set; }
        
        //myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);

        //definir el contrato
         int insert(string errMessage);
         void update(string errMessage);
         DataTable list(string errMessage);
         DataRow find(string errMessage);
         bool exists(string errMessage);
         void createcommand(string storedprocedure);
        void parameteraddvarchar(string nombre, int length, string value);
        void parameteraddint(string nombre, int value);
        void parameteradddatetime(string nombre, DateTime value);
        void parameteraddfloat(string nombre, double value);
        void parameteraddbool(string nombre, bool value);
        void parameteraddtext(string nombre, string value);
    }
}
