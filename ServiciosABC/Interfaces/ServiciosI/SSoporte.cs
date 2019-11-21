using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosABC.EntityFramework;
using ServiciosABC.Objetos;

namespace ServiciosABC.Interfaces.ServiciosI
{
    public class SSoporte : ISoporte
    {   
    
    private readonly BaseDatosTickets dataBase;
    private readonly BdSoporte nuevoSoporte;
        public SSoporte(BaseDatosTickets con, BdSoporte dataSop)
        {
             dataBase = con;
             nuevoSoporte = dataSop;
            
        }
       
        public DataSet listarTecnico()
        {
            SqlConnection conexion = new SqlConnection("Data Source = DESKTOP - B2SUJI2; Initial Catalog = SistemaDBA; Integrated Security = True; ");
            conexion.Open();
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter("Select * from Soportes", conexion);
            DA.Fill(DS);
            conexion.Close();
            return DS;
        }

        public void registrar(Soporte nuevo)
        {
            nuevoSoporte.unSoporte.Add(nuevo);
            nuevoSoporte.SaveChanges();
        }

        public List<Tickets> tickesAsignados(string soporte)
        {
            List<Tickets> soporteTicket = new List<Tickets>();
            string comando = "";
            string nombre = "";
            string cs = "Data Source=.;Initial Catalog=SistemaDBA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                comando = string.Format("select * from Soportes where Usuario like '{0}'", soporte);
                SqlCommand cmd1 = new SqlCommand(comando, con);
                cmd1.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr1 = cmd1.ExecuteReader();
                rdr1.Read();
                 nombre = rdr1["Nombre"].ToString();
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                comando = string.Format("select * from Tickets where soporteAsignado like '{0}'", nombre);


                SqlCommand cmd2 = new SqlCommand(comando, con);
                cmd2.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    Tickets ticketAsig = new Tickets();

                    ticketAsig.cliente = rdr2["cliente"].ToString();
                    ticketAsig.descripcion = rdr2["descripcion"].ToString();
                    ticketAsig.fechaSolicitud = Convert.ToDateTime(rdr2["fechaSolicitud"].ToString());
                    ticketAsig.codigo = Int32.Parse(rdr2["codigo"].ToString());
                    soporteTicket.Add(ticketAsig);
                }

            }
            return soporteTicket;
        
            
        }

        public Soporte VerificarUsuario(string Usuario)
        {
            return nuevoSoporte.unSoporte.SingleOrDefault(e => e.Usuario == Usuario);
        }
    }
}
