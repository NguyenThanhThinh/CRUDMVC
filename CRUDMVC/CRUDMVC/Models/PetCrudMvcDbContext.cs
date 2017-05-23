using CRUDMVC.Models.Entities;
using System.Data.Entity;

namespace CRUDMVC.Models
{
    public class PetCrudMvcDbContext:DbContext
    {
        public PetCrudMvcDbContext() : base("PetCrudMvcDb")
        {

        }
        public DbSet<Category> Categorys { get; set; }

    }
}