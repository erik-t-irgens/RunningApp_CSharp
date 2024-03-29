﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RunningApp.Models;

namespace RunningApp.Migrations
{
    [DbContext(typeof(RunningAppContext))]
    [Migration("20191003230613_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RunningApp.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<int>("TrackId");

                    b.HasKey("EventId");

                    b.ToTable("events");
                });

            modelBuilder.Entity("RunningApp.Models.EventUserprofile", b =>
                {
                    b.Property<int>("EventUserprofileId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int>("UserprofileId");

                    b.HasKey("EventUserprofileId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserprofileId");

                    b.ToTable("EventUserprofiles");
                });

            modelBuilder.Entity("RunningApp.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<string>("TrackName");

                    b.Property<string>("Waypoints");

                    b.HasKey("TrackId");

                    b.ToTable("tracks");
                });

            modelBuilder.Entity("RunningApp.Models.Userprofile", b =>
                {
                    b.Property<int>("UserprofileId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Bio");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<int>("Pace");

                    b.Property<string>("Photo");

                    b.HasKey("UserprofileId");

                    b.ToTable("userprofiles");
                });

            modelBuilder.Entity("RunningApp.Models.EventUserprofile", b =>
                {
                    b.HasOne("RunningApp.Models.Event", "Event")
                        .WithMany("Userprofiles")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RunningApp.Models.Userprofile", "Userprofile")
                        .WithMany()
                        .HasForeignKey("UserprofileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
