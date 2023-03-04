﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Infrastructure.Data.Entities.BetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BetAmount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CloseBetTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OpenBetTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PredictedOutcome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTimeEvent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTimeEvent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTimeGame")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTimeGame")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Team1")
                        .HasColumnType("TEXT");

                    b.Property<int>("Team1Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Team2")
                        .HasColumnType("TEXT");

                    b.Property<int>("Team2Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventEntityId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.PredictionGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PredictionGroupPoints")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyEntityId");

                    b.HasIndex("EventEntityId");

                    b.ToTable("PredictionGroups");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Branch")
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyRole")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.BetEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.GameEntity", "Game")
                        .WithMany()
                        .HasForeignKey("GameEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Data.Entities.UserEntity", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.GameEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.EventEntity", "Event")
                        .WithMany("Games")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.PredictionGroupEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.CompanyEntity", "Company")
                        .WithMany("PredictionGroups")
                        .HasForeignKey("CompanyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Data.Entities.EventEntity", "Event")
                        .WithMany("PredictionGroups")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Members")
                        .HasForeignKey("CompanyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("PredictionGroups");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.EventEntity", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("PredictionGroups");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("Bets");
                });
#pragma warning restore 612, 618
        }
    }
}
