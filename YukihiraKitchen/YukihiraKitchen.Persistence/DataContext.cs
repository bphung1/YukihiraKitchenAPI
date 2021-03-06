using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RecipeIngredient>(x => x.HasKey(ri => new { ri.RecipeId, ri.IngredientId }));

            builder.Entity<RecipeIngredient>()
                .HasOne(r => r.Recipe)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            builder.Entity<RecipeIngredient>()
                .HasOne(r => r.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            builder.Entity<Direction>(x => x.HasKey(d => new { d.DirectionId } ));

            builder.Entity<Recipe>()
                .HasMany(x => x.Directions)
                .WithOne(x => x.Recipe)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Photo>(x => x.HasKey(d => new { d.RecipeId }));

        }
    }
}
