using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.Interfaces
{
    public interface ISoporte
    {
        DataSet listarTecnico();
        void registrar(Soporte nuevo);
        Soporte VerificarUsuario(string Usuario);

        List<Tickets> tickesAsignados(string soporte);
    }
}
