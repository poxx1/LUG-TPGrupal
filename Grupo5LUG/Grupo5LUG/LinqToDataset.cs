using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace Grupo5LUG
{
    class LinqToDataset
    {
        public DataSet ConsultaSQL()
        {
         //   Form1 f1 = new Form1();

            //1. Genero lo necesario para realizar la consulta
            //El connection string y la query a realizar.
            string connectString = @"Server=AR-NB-415\SQLEXPRESS; Initial Catalog=ElasticSearch;Integrated Security=True";
            string qy = "SELECT * From Servers";

            //2. Instancion un dataAdapter para traer la info de la bd.
            SqlDataAdapter da = new SqlDataAdapter(qy, connectString);

            //Mapeo la tabla servidores a mi dataAdapter.
            da.TableMappings.Add("Table", "Servers");

            //Creo un nuevo dataset el cual va a contener la informacion que me traigo de la BD.
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            DataTable t1 = new DataTable("Servers");

            t1.Columns.Add("Server Name");
            t1.Columns.Add("Server Status");
            
            da.Fill(ds);
            
            //Creo una datatable para contener la informacion.
            DataTable servers = ds.Tables["Servers"];

            //Lleno la tabla con los campos que necesito utilizando LinQ
            var query = from s in servers.AsEnumerable()
                        select new
                        {
                            Name = s.Field<string>("Name"),
                            Status = s.Field<string>("Status")
                        };

            foreach (var q in query)
            {
                t1.Rows.Add(q.Name,q.Status);
            }

            ds2.Tables.Add(t1);
            
            return ds2;
        }

     
    }
}
