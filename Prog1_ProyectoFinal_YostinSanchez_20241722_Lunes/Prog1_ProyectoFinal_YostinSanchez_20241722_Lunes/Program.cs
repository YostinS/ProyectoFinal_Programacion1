using System.Drawing;
using Microsoft.Data.SqlClient;
using Prog1_ProyectoFinal_YostinSanchez_20241722_Lunes;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Product
{
    public string Nombre { get; set; }
    public string Talla { get; set; }
    public string Color { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int CategoriaID { get; set; }
    public static void AgregarProducto(Product producto)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = "INSERT INTO Productos (Nombre, Talla, Color, Precio, Stock, CategoriaID) VALUES (@Nombre, @Talla, @Color, @Precio, @Stock, @CategoriaID)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Talla", producto.Talla);
            cmd.Parameters.AddWithValue("@Color", producto.Color);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Producto agregado correctamente.");
        }
    }
}
public class ViewProducts
{
    public static void VerProducto()
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = @"SELECT * FROM Productos WHERE Stock > 0;";

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("-------| PRODUCTOS EN STOCK |-------");

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}");
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Talla: {reader["Talla"]}");
                        Console.WriteLine($"Color: {reader["Color"]}");
                        Console.WriteLine($"Precio: {reader["Precio"]}");
                        Console.WriteLine($"Stock: {reader["Stock"]}");
                        Console.WriteLine($"Categoria: {reader["CategoriaID"]}");
                        Console.WriteLine("-----------------------------");
                    }

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No hay productos en stock.");
                    }
                }
            }
            conexion.Close();
        }
    }
}

public class Sale()
{
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string Cliente { get; set; }
    public static void AgregarVenta(Sale ventas)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = "INSERT INTO Ventas (Fecha, Total, Cliente) VALUES (@Fecha, @Total, @Cliente)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Fecha", ventas.Fecha);
            cmd.Parameters.AddWithValue("@Total", ventas.Total);
            cmd.Parameters.AddWithValue("@Cliente", ventas.Cliente);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Venta agregada correctamente.");
            Console.WriteLine("--------------------------------");
        }
    }
    public int VentaID { get; set; }
    public int ProductoID { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public static void AgregarDetallesVenta(Sale DetalleVenta)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = "INSERT INTO DetalleVenta (VentaID, ProductoID, Cantidad, PrecioUnitario) VALUES (@VentaID, @ProductoID, @Cantidad, @PrecioUnitario)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@VentaID", DetalleVenta.VentaID);
            cmd.Parameters.AddWithValue("@ProductoID", DetalleVenta.ProductoID);
            cmd.Parameters.AddWithValue("@Cantidad", DetalleVenta.Cantidad);
            cmd.Parameters.AddWithValue("@PrecioUnitario", DetalleVenta.PrecioUnitario);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Detalle de Venta agregada correctamente.");
            
        }
    }
}
public class Return
{
    public int VentaID { get; set; }
    public int ProductoID { get; set; }
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public string Motivo { get; set; }

    public static void AgregarDevolucion(Return devolucion)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = @"INSERT INTO Devoluciones (VentaID, ProductoID, Fecha, Cantidad, Motivo) 
                             VALUES (@VentaID, @ProductoID, @Fecha, @Cantidad, @Motivo)";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@VentaID", devolucion.VentaID);
            cmd.Parameters.AddWithValue("@ProductoID", devolucion.ProductoID);
            cmd.Parameters.AddWithValue("@Fecha", devolucion.Fecha);
            cmd.Parameters.AddWithValue("@Cantidad", devolucion.Cantidad);
            cmd.Parameters.AddWithValue("@Motivo", devolucion.Motivo);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Devolucion registrada correctamente.");
        }
    }
}
public class Category()
{
    public string Nombre { get; set; }

    public static void AgregarCategoria(Category categoria)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            conexion.Open();
            string query = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Categoria agregada correctamente.");
        }
    }
}

    public class ViewCategory()
    {
        public static void VerCategorias()
        {
            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT * FROM Categorias";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("------| CATEGORIAS DISPONIBLES |------");
                        Console.WriteLine("--------------------------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]} | Nombre: {reader["Nombre"]}");
                            Console.WriteLine("------------------------------");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No hay categorías registradas.");
                        }
                    }
                }
            }
        }
    }
public class Program()
{
    static void Main()
    {
        static extern SqlConnection ObtenerConexion();
        bool running = true;
        while (running)
        {
            try
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("\t     NOVACODE SOLUTIONS");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("\t---- MENU PRINCIPAL ----");
                Console.WriteLine("Selecciona una opcion: ");
                Console.WriteLine("1. Agregar productos");
                Console.WriteLine("2. Ver productos en stock");
                Console.WriteLine("3. Venta");
                Console.WriteLine("4. Devolucion");
                Console.WriteLine("5. Agregar categoria");
                Console.WriteLine("6. Ver categorias");
                Console.WriteLine("7. Salir");
                Console.WriteLine("----------------------------------------");
                int opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:
                        Product nuevo = new Product();
                        Console.Write("Nombre: ");
                        nuevo.Nombre = Console.ReadLine();
                        Console.Write("Talla: ");
                        nuevo.Talla = Console.ReadLine();
                        Console.Write("Color: ");
                        nuevo.Color = Console.ReadLine();
                        Console.Write("Precio: ");
                        nuevo.Precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Stock: ");
                        nuevo.Stock = int.Parse(Console.ReadLine());
                        Console.Write("ID Categoria: ");
                        nuevo.CategoriaID = int.Parse(Console.ReadLine());
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Resumen del producto:");
                        Console.WriteLine($"Nombre: {nuevo.Nombre}");
                        Console.WriteLine($"Talla: {nuevo.Talla}");
                        Console.WriteLine($"Color: {nuevo.Color}");
                        Console.WriteLine($"Precio: {nuevo.Precio}");
                        Console.WriteLine($"Stock: {nuevo.Stock}");
                        Console.WriteLine($"Categoria ID: {nuevo.CategoriaID}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("¿Desea guardar los cambios?");
                        Console.WriteLine("[1- SI] \t [2.- NO]");
                        int guardarProducto = int.Parse(Console.ReadLine());
                        if (guardarProducto == 1)
                        {
                            Console.WriteLine("Datos guardados correctamente");
                            Product.AgregarProducto(nuevo);
                        }
                        else
                        {
                            Console.WriteLine("Operacion cancelada");
                        }

                        break;

                    case 2:
                        ViewProducts.VerProducto();
                        break;

                    case 3:
                        Sale nuevaVenta = new Sale();
                        Console.Write("Fecha [yyyy/MM/dd]: ");
                        nuevaVenta.Fecha = DateTime.Parse(Console.ReadLine());
                        Console.Write("Total: ");
                        nuevaVenta.Total = decimal.Parse(Console.ReadLine());
                        Console.Write("Cliente: ");
                        nuevaVenta.Cliente = Console.ReadLine();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Resumen de la venta:");
                        Console.WriteLine($"Fecha: {nuevaVenta.Fecha}");
                        Console.WriteLine($"Total: {nuevaVenta.Total}");
                        Console.WriteLine($"Cliente: {nuevaVenta.Cliente}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("¿Desea guardar los cambios?");
                        Console.WriteLine("[1- SI] \t [2.- NO]");
                        int guardarVenta = int.Parse(Console.ReadLine());
                        if (guardarVenta == 1)
                        {
                            Console.WriteLine("Datos guardados correctamente");
                            Sale.AgregarVenta(nuevaVenta);
                            //---------------------------
                            Sale nuevoDetalleVenta = new Sale();
                            Console.Write("Venta ID: ");
                            nuevoDetalleVenta.VentaID = int.Parse(Console.ReadLine());
                            Console.Write("Producto ID: ");
                            nuevoDetalleVenta.ProductoID = int.Parse(Console.ReadLine());
                            Console.Write("Cantidad: ");
                            nuevoDetalleVenta.Cantidad = int.Parse(Console.ReadLine());
                            Console.Write("Precio Unitario: ");
                            nuevoDetalleVenta.PrecioUnitario = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Resumen del ventas:");
                            Console.WriteLine($"VentaID: {nuevoDetalleVenta.VentaID}");
                            Console.WriteLine($"ProductoID: {nuevoDetalleVenta.ProductoID}");
                            Console.WriteLine($"Cantidad: {nuevoDetalleVenta.Cantidad}");
                            Console.WriteLine($"PrecioUnitario: {nuevoDetalleVenta.PrecioUnitario}");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Datos guardados correctamente");
                            Sale.AgregarDetallesVenta(nuevoDetalleVenta);
                        }
                        else
                        {
                            Console.WriteLine("Operacion cancelada");
                        }
                        break;

                    case 4:
                        Return nuevaDevolucion = new Return();
                        Console.Write("Venta ID: ");
                        nuevaDevolucion.VentaID = int.Parse(Console.ReadLine());
                        Console.Write("Producto ID: ");
                        nuevaDevolucion.ProductoID = int.Parse(Console.ReadLine());
                        Console.Write("Fecha [yyyy/MM/dd]: ");
                        nuevaDevolucion.Fecha = DateTime.Parse(Console.ReadLine());
                        Console.Write("Cantidad devuelta: ");
                        nuevaDevolucion.Cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Motivo de la devolución: ");
                        nuevaDevolucion.Motivo = Console.ReadLine();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Resumen:");
                        Console.WriteLine($"VentaID: {nuevaDevolucion.VentaID}");
                        Console.WriteLine($"ProductoID: {nuevaDevolucion.ProductoID}");
                        Console.WriteLine($"Fecha: {nuevaDevolucion.Fecha}");
                        Console.WriteLine($"Cantidad: {nuevaDevolucion.Cantidad}");
                        Console.WriteLine($"Motivo: {nuevaDevolucion.Motivo}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("¿Desea guardar esta devolución?");
                        Console.WriteLine("[1- SI] \t [2.- NO]");
                        int confirmarDevolucion = int.Parse(Console.ReadLine());

                        if (confirmarDevolucion == 1)
                        {
                            Return.AgregarDevolucion(nuevaDevolucion);
                        }
                        else
                        {
                            Console.WriteLine("Devolucion cancelada.");
                        }
                        break;

                    case 5:
                        Category nuevaCategoria = new Category();
                        Console.Write("Nombre de la categoría: ");
                        nuevaCategoria.Nombre = Console.ReadLine();
                        Category.AgregarCategoria(nuevaCategoria);
                        break;

                    case 6:
                        ViewCategory.VerCategorias();
                        break;

                    case 7:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("ERROR");
                        Console.WriteLine("Debes seleccionar una opcion escribiendo el numero de la opcion deseada");
                        break;
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(e.Message);
                Console.WriteLine("Debes seleccionar una opcion escribiendo el numero de la opcion deseada");
            }
        }
        Console.WriteLine("Closing Program....");
        Console.ReadKey();

    }
}
