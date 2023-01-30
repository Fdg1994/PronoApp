﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230130093302_UsernameRequired")]
    partial class UsernameRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamOutcome")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("Infrastructure.Data.Entities.CompanyUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("CompanyMembers", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTimeEvent")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
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

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

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

                    b.Property<string>("CompanyBranch")
                        .HasColumnType("TEXT");

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
                        .WithMany()
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CompanyUserEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

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
                    b.HasOne("Infrastructure.Data.Entities.CompanyEntity", "PredictionGroupCompany")
                        .WithMany("PredictionGroups")
                        .HasForeignKey("CompanyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Data.Entities.EventEntity", "PredictionGroupEvent")
                        .WithMany()
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PredictionGroupCompany");

                    b.Navigation("PredictionGroupEvent");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CompanyEntity", b =>
                {
                    b.Navigation("PredictionGroups");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.EventEntity", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
