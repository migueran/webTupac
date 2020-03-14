using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class Connection : IConnection
    {
        public SqlCommand MyCommand { get; set; }
        public SqlConnection MyConnection { get; set; }

        public Connection()
        {
            MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        }

        private void OpenConnection()
        {
            if (MyConnection.State != ConnectionState.Open)
            {
                try
                {
                    MyConnection.Open();
                }
                catch (Exception)
                {
                    throw new Exception ("La conexión no se pudo abrir, reintente más tarde");
                }                
            }
        }


        //Se definirá la conexión "myconnection" 
        public bool Exists(string errMessage)
        {
            OpenConnection();
            try
            {
                int Count = int.Parse(MyCommand.ExecuteScalar().ToString());
                return Count>0;
            }

            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public DataRow Find(string errMessage)
        {
            OpenConnection();
            try
            {
                DataTable dt = new DataTable();
                dt.Load(MyCommand.ExecuteReader());
                return dt.Rows[0];
                
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public int Insert(string errMessage)
        {
            OpenConnection();
            try
            {
                int Id = int.Parse(MyCommand.ExecuteScalar().ToString());
                return Id;
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);                
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public DataTable List(string errMessage)
        {
            OpenConnection();
            try
            {
                DataTable dt = new DataTable();
                dt.Load(MyCommand.ExecuteReader());
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public void Update(string errMessage)
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery(); //ejecuta algo pero devuelve un int con la cant de registros afectados
               
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public void CreateCommand(string storedprocedure)
        {
            MyCommand = new SqlCommand(storedprocedure, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
        }

        public void ParameterAddVarchar(string nombre, int length, string value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.VarChar, length).Value = value;

        }

        public void ParameterAddInt(string nombre, int value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.Int).Value = value;
        }

        public void ParameterAddDatetime(string nombre, DateTime value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.SmallDateTime).Value = value.ToString();
        }

        public void ParameterAddFloat(string nombre, double value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.Float).Value = value;
        }

        public void ParameterAddBool(string nombre, bool value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.Bit).Value = value;
        }

        public void ParameterAddText(string nombre, string value)
        {
            MyCommand.Parameters.Add("@" + nombre, SqlDbType.Text).Value = value;
        }
    }
}
