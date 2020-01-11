using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
                
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Substance> Substances { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinho { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Reparo> Reparo { get; set; }
    }
}
