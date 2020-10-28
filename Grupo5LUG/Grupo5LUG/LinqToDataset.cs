using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Grupo5LUG
{
    class LinqToDataset
    {
        public void consulta()
        {
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
            da.Fill(ds);
            
            //Creo una datatable para contener la informacion.
            DataTable servers = ds.Tables["Servers"];

            //Lleno la tabla con los campos que necesito utilizando LinQ
            var query = from d in servers.AsEnumerable()
                        select new
                        {
                            Name = d.Field<string>("Name"),
                            Status = d.Field<string>("Status")
                        };

            foreach (var q in query)
            {
                //Console.WriteLine("Server Name = {0}, Status = {1}", q.Name, q.Status);
            }
        }
    }
}
