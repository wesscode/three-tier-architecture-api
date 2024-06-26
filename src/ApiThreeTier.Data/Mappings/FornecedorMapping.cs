﻿using ApiThreeTier.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiThreeTier.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(x => x.Documento)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(x => x.Endereco)
                   .WithOne(x => x.Fornecedor);

            // 1 : N => Fornecedores : Produtos
            builder.HasMany(x => x.Produtos)
                   .WithOne(x => x.Fornecedor)
                   .HasForeignKey(x => x.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}