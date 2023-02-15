using GestionPedidoCF.contextDb;
using GestionPedidoCF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionPedidoCF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var dc = new GestionPedidosCF())
            {
                Cliente cliente = new Cliente
                {
                    Id = 1,
                    Nombre = "Anita la huerfanita",
                    FechaNac = new DateTime(1991, 06, 03)
                };
                dc.Clientes.Add(cliente);

                Producto producto = new Producto
                {
                    Id = Guid.NewGuid(),
                    Descripcion = "Boligrafo",
                    Precio = 500f
                };

                dc.Productos.Add(producto);

                Pedido pedido = new Pedido
                {
                    Id = 1,
                    IdCliente = 1,
                    FechaPedido = new DateTime(2023, 02, 15)
                };

                LineaPedido lineaPedido = new LineaPedido
                {
                    Id = 1,
                    IdPedido = 1,
                    IdProducto = 1,
                    Cantidad = 10
                };

                dc.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}