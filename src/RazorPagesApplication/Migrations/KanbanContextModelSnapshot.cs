﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesApplication.Context;

namespace RazorPagesApplication.Migrations
{
    [DbContext(typeof(KanbanContext))]
    partial class KanbanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("RazorPagesApplication.Models.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("RazorPagesApplication.Models.Column", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("RazorPagesApplication.Models.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ColumnId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RazorPagesApplication.Models.ItemDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long>("ItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemDetails");
                });

            modelBuilder.Entity("RazorPagesApplication.Models.Column", b =>
                {
                    b.HasOne("RazorPagesApplication.Models.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RazorPagesApplication.Models.Item", b =>
                {
                    b.HasOne("RazorPagesApplication.Models.Column", "Column")
                        .WithMany()
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RazorPagesApplication.Models.ItemDetail", b =>
                {
                    b.HasOne("RazorPagesApplication.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
