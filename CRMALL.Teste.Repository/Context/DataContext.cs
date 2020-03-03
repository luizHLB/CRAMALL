﻿using CRMALL.Teste.Domain.Models.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
namespace CRMALL.Teste.Repository.Context
{
    public class DataContext : DbContext
    {
        public DbSet<PessoaModel> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql("");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.RemoveCascadeDeleteBehavior();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes().ToList().ForEach(entity => entity.Relational().TableName = entity.DisplayName());
        }

        public static void RemoveCascadeDeleteBehavior(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys())
                .Where(w => !w.IsOwnership && w.DeleteBehavior.Equals(DeleteBehavior.Cascade)).ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }

        public static void SetStringColumnType(this ModelBuilder modelBuilder, int length)
        {
            modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetProperties()).Where(w => w.ClrType == typeof(string)).ToList()
                .ForEach(property =>
                {
                    property.Relational().ColumnType = "varchar";
                    property.AsProperty().Builder.HasMaxLength(length, ConfigurationSource.DataAnnotation);
                });
        }
    }
}
