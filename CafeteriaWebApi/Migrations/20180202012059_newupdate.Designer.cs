﻿// <auto-generated />
using CafeteriaWebApi.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CafeteriaWebApi.Migrations
{
    [DbContext(typeof(CafeteriaContext))]
    [Migration("20180202012059_newupdate")]
    partial class newupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CafeteriaWebApi.Models.Booking", b =>
                {
                    b.Property<string>("BookingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BookingDate");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("CustomerName");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("ReferenceId");

                    b.Property<int>("TotalPersons");

                    b.HasKey("BookingId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CafeteriaWebApi.Models.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookingId");

                    b.Property<DateTime?>("StatusDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("StatusDescription");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique()
                        .HasFilter("[BookingId] IS NOT NULL");

                    b.ToTable("BookingStatus");
                });

            modelBuilder.Entity("CafeteriaWebApi.Models.BookingStatus", b =>
                {
                    b.HasOne("CafeteriaWebApi.Models.Booking", "Booking")
                        .WithOne("BookingStatus")
                        .HasForeignKey("CafeteriaWebApi.Models.BookingStatus", "BookingId");
                });
#pragma warning restore 612, 618
        }
    }
}
