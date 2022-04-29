using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss;

namespace Maquina_Expendedora
{
    class Program
    {
        static void Main(string[] args)
        {
            Controls expendedora = new Controls();

            while (true)
            {
                Console.WriteLine("****  Bienvenid@ a la maquina Expendedora Parquesoft  **** \n");

                Console.WriteLine("-*-*-*-*-*-*-* Productos actualmente disponobles -*-*-*-*-*-*-* \n");

                Console.WriteLine(expendedora.listaProductos());

                Console.WriteLine("1. Cliente");
                Console.WriteLine("2. Proveedor \n");
                Console.WriteLine("Ingrese la opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el código del producto que desea comprar: ");
                        string codigo_venta = Console.ReadLine();

                        Console.WriteLine("Ingrese las monedas o billetes requeridos para realizar la compra, ejemplo (2000-2000 = 4000)");
                        expendedora.Pago = Console.ReadLine();

                        expendedora.cliente(codigo_venta);

                        Producto productoComprado = expendedora.cliente(codigo_venta);

                        if (productoComprado == null)
                        {
                            Console.WriteLine("No se pudo realizar el pago");
                        }
                        else
                        {
                            Console.WriteLine("Producto comprado es {0}, y el dinero sobrante es {1}", productoComprado.Codigo, productoComprado.Cambio);
                        }

                        break;

                    case "2":
                        Producto producto = new Producto();
                        Console.WriteLine("Bienvenid@ estimado proveedor");
                        Console.WriteLine("Ingrese los productos con el siguiente formato que se muestra a continuación -> \n");
                        Console.WriteLine("Código: ");
                        producto.Codigo = Console.ReadLine();
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Nombre del producto: ");
                        producto.Nombre = Console.ReadLine();
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Cantidad Ingresada: ");
                        producto.Cantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Valor del producto: ");
                        producto.Valor = double.Parse(Console.ReadLine());
                        Console.WriteLine("************************************************************************************");

                        expendedora.Proveedor(producto);


                        break;
                }

                Console.WriteLine("¿Desea realizar otra compra? [Si (1)] - [No (2)]");

                if (Console.ReadLine() == "2")
                {
                    break;
                }

            }


        }
    }
}
