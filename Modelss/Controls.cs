using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss
{
    public class Controls
    {
        public List<Producto> Productos { get; set; }

        public string Pago { get; set; }

        public Controls()
        {

            this.Productos = new List<Producto>();

            Producto chocolatina = new Producto();
            chocolatina.Codigo = "01";
            chocolatina.Nombre = "Chocolatina Blanca";
            chocolatina.Cantidad = 10;
            chocolatina.Valor = 2000;

            Producto gaseosa = new Producto();
            gaseosa.Codigo = "02";
            gaseosa.Nombre = "Gaseosa Manzana";
            gaseosa.Cantidad = 15;
            gaseosa.Valor = 2500;

            this.Productos.Add(chocolatina);
            this.Productos.Add(gaseosa);
        }

        public int validarProducto(string Codigo)
        {
            int encontro = -1;


            for (int i = 0; i < this.Productos.Count; i++)
            {
                if (this.Productos[i].Codigo == Codigo)
                {
                    encontro = i;
                }
            }
            return encontro;

        }

        public bool Proveedor(Producto producto)
        {
            int enc = this.validarProducto(producto.Codigo);
            if (enc >= 0)
            {
                this.Productos[enc].sumarCantidad(producto.Cantidad);
            }
            else
            {
                this.Productos.Add(producto);
            }
            return true;
        }


        public double validarMonedas(string[] monedas)
        {
            double total = 0;
            foreach (string item in monedas)
            {
                try
                {
                    total += float.Parse(item);
                }
                catch (Exception) { }
            }
            return total;
        }

        public Producto cliente(string codigo)
        {
            int enc = this.validarProducto(codigo);
            if (enc >= 0)
            {
                if (this.Productos[enc].validarCantidad())
                {
                    string[] monedas = this.Pago.Split('-');


                    double total = this.validarMonedas(monedas);

                    if (this.Productos[enc].validarValor(total))
                    {
                        this.Productos[enc].restarProducto();

                        return this.Productos[enc];
                    }
                }

            }
            return null;

        }

        public string listaProductos()
        {
            string lista = "";
            foreach (Producto item in this.Productos)
            {
                lista += item.Codigo + " " + item.Nombre + " " + item.Cantidad + " " + item.Valor + "\n";
            }

            return lista;
        }


    }
}