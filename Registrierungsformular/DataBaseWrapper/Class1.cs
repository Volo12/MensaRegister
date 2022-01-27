using System;
using System.Data;
using System.Data.Odbc;

namespace DataBaseWrapper
{
    public class DataBase: IDisposable
    {
        OdbcConnection connection;

        public DataBase(string connStrg)
        {
            connection = new OdbcConnection(connStrg);
        }
        public bool ConnectionIsOpen
        {
            get
            {
                return connection.State == ConnectionState.Open;
            }
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }

        public DataTable RunQuery(string sqlCmd)
        {
            DataTable dataTable = new DataTable();
            // Connection open/close automatically
            // managed by DataAdapter
            OdbcDataAdapter da = new OdbcDataAdapter(sqlCmd, connection);


            da.Fill(dataTable);
            return dataTable;
        }
        // Bei geschlossener Connection wird diese geöffnet
        // und am Ende der Methoe wieder geschlossen
        // Bei geöffneter Connection wird diese nicht geöffnet und am Ende
        // der Methode nicht geschlossen
        // auch bei der LZF muss der ursprüngliche Verbindungsstatus wíeder hergestellt werden

        public int RunNoneQuery(string sqlCmd)
        {
            bool connectionIsClosed;
            connectionIsClosed = false;
            var isOpen = connection.State;
            if (isOpen == ConnectionState.Closed)
            {
                connectionIsClosed = true;
            }
            int numRecs;
            OdbcCommand cmd = new OdbcCommand();
            cmd.Connection = connection;
            cmd.CommandText = sqlCmd;
            if (connectionIsClosed)
            {
                connection.Open();
            }
            try
            {
                numRecs = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(connectionIsClosed)
                {
                    Close();
                }
            }
           
            return numRecs;

        }

        public object RunQueryScalar(string sqlCmd)
        {
            object returnObject;
            bool connectionIsClosed;
            connectionIsClosed = false;
            var isOpen = connection.State;
            if (isOpen == ConnectionState.Closed)
            {
                connectionIsClosed = true;
            }
            OdbcCommand cmd = new OdbcCommand();
            cmd.Connection = connection;
            cmd.CommandText = sqlCmd;
            if (connectionIsClosed)
            {
                connection.Open();
            }
            try
            {
                returnObject = cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(connectionIsClosed)
                {
                    Close();
                }
            }
            return returnObject;

        }

        public void Dispose()
        {
            Close();
        }
    }
}
