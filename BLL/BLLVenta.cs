using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLVenta
    {

        private DALVenta dalVenta = new DALVenta();

        public Array FiltrarVentas(string fechaInicio, string fechaFin)
        {
            List<BEVenta> lista = new List<BEVenta>();
            DataTable tabla = dalVenta.TraerListaVentas(fechaInicio, fechaFin);



            foreach (DataRow row in tabla.Rows)
            {
                BEVenta venta = new BEVenta
                {
                    CodVenta = Convert.ToInt32(row["CodVenta"]),
                    Fecha = row["Fecha"].ToString(),
                    Hora = row["Hora"].ToString(),
                    MontoTotal = Convert.ToSingle(row["MontoTotal"]),
                    NombreUsuario = row["NombreUsuario"].ToString()
                };

                BEItemCarrito itemCarrito = new BEItemCarrito()
                {
                    CodVenta = venta.CodVenta,
                    CodProducto = Convert.ToInt32(row["CodigoProducto"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    PrecioVenta = Convert.ToInt32(row["PrecioVenta"]),
                    Producto = new BEProducto(
                        Convert.ToInt32(row["CodigoProducto"]),
                        row["Nombre"].ToString(),
                        row["Descripcion"].ToString(),
                        row["Marca"].ToString(),
                        row["Color"].ToString(),
                        row["ImgUrl"].ToString(),
                        Convert.ToDouble(row["Precio"]),
                        Convert.ToInt32(row["Stock"]),
                        Convert.ToInt32(row["StockMinimo"]),
                        Convert.ToInt32(row["StockMaximo"]),
                        Convert.ToBoolean(row["Activo"])
                    )
                };

                //trae las ventas
                if (lista.FirstOrDefault(v => v.CodVenta == venta.CodVenta) == null)
                {
                    lista.Add(venta);
                }

            }

            var productosMasVendidos = tabla.AsEnumerable()
            .GroupBy(r => r.Field<int>("CodigoProducto"))
            .Select(g => new
            {
                CodigoProducto = g.Key,
                Nombre = g.First().Field<string>("Nombre"),
                CantidadVendida = g.Sum(x => x.Field<int>("Cantidad"))
            })
            .OrderByDescending(x => x.CantidadVendida)
            .ToArray();

            return productosMasVendidos;
        }
    }
}
