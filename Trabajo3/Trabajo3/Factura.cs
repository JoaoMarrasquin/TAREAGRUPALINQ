using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo3
{
    public class Factura
    {
        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        private int idcliente;

        public int IDcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

 

    }
}
