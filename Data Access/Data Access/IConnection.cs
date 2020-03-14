using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public interface IConnection
    {
        //definir comando
         SqlCommand MyCommand { get; set; }
         SqlConnection MyConnection { get; set; }
        
        //myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);

        //definir el contrato
         int Insert(string errMessage);
         void Update(string errMessage);
         DataTable List(string errMessage);
         DataRow Find(string errMessage);
         bool Exists(string errMessage);
         void CreateCommand(string storedprocedure);
        void ParameterAddVarchar(string nombre, int length, string value);
        void ParameterAddInt(string nombre, int value);
        void ParameterAddDatetime(string nombre, DateTime value);
        void ParameterAddFloat(string nombre, double value);
        void ParameterAddBool(string nombre, bool value);
        void ParameterAddText(string nombre, string value);
    }
}
