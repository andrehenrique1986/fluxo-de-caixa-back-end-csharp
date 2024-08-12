using FluxoCaixa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Context
{
    public class FluxoContext : DbContext
    {
        public FluxoContext(DbContextOptions<FluxoContext> opts)
            : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Categoria>()
                .HasKey(categoria => categoria.IdCategoria);

            builder.Entity<Subcategoria>()
                .HasKey(subcategoria => subcategoria.IdSubcategoria);

            builder.Entity<Custo>()
                .HasKey(custo => custo.IdCusto);

            builder.Entity<Fluxo>()
                .HasKey(fluxo => fluxo.IdFluxo);

            builder.Entity<FormaDePagamento>()
                .HasKey(formaDePagamento => formaDePagamento.IdFormaDePagamento);

            builder.Entity<Registro>()
                .HasKey(registro => registro.IdRegistro);

           
   
            // Relacionando as tabelas Registro e Categoria 
            builder.Entity<Registro>()
                .HasOne(registro => registro.Categoria)
                .WithMany(categoria => categoria.Registros)
                .HasForeignKey(registro => registro.IdCategoria);

            // Relacionando as tabelas Registro e Subcategoria 
            builder.Entity<Registro>()
                .HasOne(registro => registro.Subcategoria)
                .WithMany(subcategoria => subcategoria.Registros)
                .HasForeignKey(registro => registro.IdSubcategoria);


            // Relacionando as tabelas Registro e Custo
            builder.Entity<Registro>()
                .HasOne(registro => registro.Custo)
                .WithMany(custo => custo.Registros)
                .HasForeignKey(registro => registro.IdCusto);

            // Relacionando as tabelas Registro e Fluxo
            builder.Entity<Registro>()
                .HasOne(registro => registro.Fluxo)
                .WithMany(fluxo => fluxo.Registros)
                .HasForeignKey(registro => registro.IdFluxo);


            // Relacionando as tabelas Registro e FormaDePagamento
            builder.Entity<Registro>()
                .HasOne(registro => registro.FormaDePagamento)
                .WithMany(formaDePagamento => formaDePagamento.Registros)
                .HasForeignKey(registro => registro.IdFormaDePagamento);

        }

        internal object CalcularTotalGeral()
        {
            throw new NotImplementedException();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Custo> Custos { get; set; }
        public DbSet<Fluxo> Fluxos { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}
