using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class Connection : IConnection
    {
        public SqlCommand mycommand { get; set; }
        public SqlConnection myconnection { get; set; }

        public Connection()
        {
            myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        }

        private void openconnection()
        {
            if (myconnection.State != ConnectionState.Open)
            {
                try
                {
                    myconnection.Open();
                }
                catch (Exception)
                {
                    throw new Exception ("La conexión no se pudo abrir, reintente más tarde");
                }                
            }
        }


        //Se definirá la conexión "myconnection" 
        public bool exists(string errMessage)
        {
            openconnection();
            try
            {
                int count = int.Parse(mycommand.ExecuteScalar().ToString());
                return count>0;
            }

            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                myconnection.Close();
            }
        }

        public DataRow find(string errMessage)
        {
            openconnection();
            try
            {
                DataTable dt = new DataTable();
                dt.Load(mycommand.ExecuteReader());
                return dt.Rows[0];
                
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                myconnection.Close();
            }
        }

        public int insert(string errMessage)
        {
            openconnection();
            try
            {
                int id = int.Parse(mycommand.ExecuteScalar().ToString());
                return id;
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);                
            }
            finally
            {
                myconnection.Close();
            }
        }

        public DataTable list(string errMessage)
        {
            openconnection();
            try
            {
                DataTable dt = new DataTable();
                dt.Load(mycommand.ExecuteReader());
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                myconnection.Close();
            }
        }

        public void update(string errMessage)
        {
            openconnection();
            try
            {
                mycommand.ExecuteNonQuery(); //ejecuta algo pero devuelve un int con la cant de registros afectados
               
            }
            catch (Exception err)
            {
                throw new Exception(errMessage);
            }
            finally
            {
                myconnection.Close();
            }
        }

        public void createcommand(string storedprocedure)
        {
            mycommand = new SqlCommand(storedprocedure, myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
        }

        public void parameteraddvarchar(string nombre, int length, string value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.VarChar, length).Value = value;

        }

        public void parameteraddint(string nombre, int value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.Int).Value = value;
        }

        public void parameteradddatetime(string nombre, DateTime value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.SmallDateTime).Value = value.ToString();
        }

        public void parameteraddfloat(string nombre, double value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.Float).Value = value;
        }

        public void parameteraddbool(string nombre, bool value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.Bit).Value = value;
        }

        public void parameteraddtext(string nombre, string value)
        {
            mycommand.Parameters.Add("@" + nombre, SqlDbType.Text).Value = value;
        }
    }
}
