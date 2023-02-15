using GestionPedidoCF.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPedidoCF.contextDb
{
    public class GestionPedidosCF:DbContext
    {
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Producto> Productos { get; set;}
        public DbSet<Pedido> Pedidos { get; set;}
        public DbSet<LineaPedido> LineaPedidos { get; set;}

    }
}
