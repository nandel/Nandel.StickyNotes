﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Providers.EntityFramework.Sqlite;

namespace Providers.EntityFramework.Sqlite.Migrations
{
    [DbContext(typeof(SqliteStikyNotesDbContext))]
    [Migration("20211109201001_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Core.Entities.Media", b =>
                {
                    b.Property<ulong>("TenantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TenantId", "Key");

                    b.ToTable("Media");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");
                });

            modelBuilder.Entity("Core.Entities.HttpGet", b =>
                {
                    b.HasBaseType("Core.Entities.Media");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FieldToDisplay")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("http-get");
                });

            modelBuilder.Entity("Core.Entities.Text", b =>
                {
                    b.HasBaseType("Core.Entities.Media");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("text");
                });
#pragma warning restore 612, 618
        }
    }
}