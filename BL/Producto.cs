using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public bool Correct { get; set; }

        public List<object> Productos { get; set; }

        public object Object { get; set; }
        public static Producto GetAll()
        {
            Producto result = new Producto();
           
            try
            {
                using(DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.GetAllProducto();
                    if (query != null)
                    {

                         result.Productos = new List<object>().ToList();
                        foreach (var obj in query)
                        {
                            Producto producto = new Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.NombreProducto = obj.NombreProducto;
                            producto.Descripcion = obj.Descripcion;
                            producto.Precio = obj.Precio;
                            result.Productos.Add(producto);
                        }
                        result.Correct = true;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
            }

            return result;

        }

        public static Producto GetById(int IdProducto)
        {
            Producto result = new Producto();
           
            try
            {
                using(DL.LBastidaEKSSolutionEntities contex = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = contex.GetByIdProducto(IdProducto).SingleOrDefault();
                    if(query != null)
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.NombreProducto = query.NombreProducto;
                        producto.Descripcion = query.Descripcion;
                        producto.Precio = query.Precio;
                        result.Object = producto;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static bool Add(Producto producto)
        {
            Producto result = new Producto();

            try
            {
                using(DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.AddProducto(producto.NombreProducto, producto.Descripcion, producto.Precio);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }


            }catch(Exception ex)
            {

            }
            return result.Correct;

        }

        public static bool Delete(int IdProducto)
        {
            Producto result = new Producto();

            try
            {
                using (DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.DeleteProducto(IdProducto);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return result.Correct;

        }

        public static bool Update(Producto producto)
        {
            Producto result = new Producto();

            try
            {
                using (DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.UpdateProducto(producto.IdProducto,producto.NombreProducto, producto.Descripcion, producto.Precio);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return result.Correct;

        }
    }
}
