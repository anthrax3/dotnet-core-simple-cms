﻿// <auto-generated />
using SimpleCms.PostContext.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace SimpleCms.Migrator.Migrations.PostContextDb
{
    [DbContext(typeof(PostDbContext))]
    [Migration("20171014100653_InitPostContext")]
    partial class InitPostContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogCore.PostContext.Domain.AuthorId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("AuthorIds","post");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.BlogId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("BlogIds","post");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorIdId");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("PostId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AuthorIdId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments","post");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("BlogId");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Excerpt")
                        .IsRequired();

                    b.Property<string>("Slug")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts","post");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Frequency");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Tags","post");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Comment", b =>
                {
                    b.HasOne("BlogCore.PostContext.Domain.AuthorId", "AuthorId")
                        .WithMany()
                        .HasForeignKey("AuthorIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogCore.PostContext.Domain.Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Post", b =>
                {
                    b.HasOne("BlogCore.PostContext.Domain.AuthorId", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogCore.PostContext.Domain.BlogId", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogCore.PostContext.Domain.Tag", b =>
                {
                    b.HasOne("BlogCore.PostContext.Domain.Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}
