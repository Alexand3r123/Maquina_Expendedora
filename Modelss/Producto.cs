using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss
{ 
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public double Cambio { get; set; }
        public void sumarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;
        }

        public bool validarCantidad()
        {
            if (this.Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool validarValor(double valor)
        {
            if (this.Valor <= valor)
            {

                this.Cambio = valor - this.Valor;

                return true;
            }

            return false;
        }

        public void restarProducto()
        {
            this.Cantidad--;
        }

    }
}