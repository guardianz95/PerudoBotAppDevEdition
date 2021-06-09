﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerudoBot.Database.Data;

namespace PerudoBot.Database.Sqlite.Migrations
{
    [DbContext(typeof(PerudoBotDbContext))]
    partial class PerudoBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PerudoBot.Database.Data.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GamePlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamePlayerRoundId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentActionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.HasIndex("GamePlayerRoundId");

                    b.HasIndex("ParentActionId");

                    b.HasIndex("RoundId");

                    b.ToTable("Actions");

                    b.HasDiscriminator<string>("ActionType").HasValue("Action");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ChannelId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerTurnId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinnerPlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayerRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dice")
                        .HasColumnType("TEXT");

                    b.Property<int>("GamePlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("GamePlayerRounds");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoundType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StartingPlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");

                    b.HasDiscriminator<string>("RoundType").HasValue("Round");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Bid", b =>
                {
                    b.HasBaseType("PerudoBot.Database.Data.Action");

                    b.Property<ulong>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pips")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Bid");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.ExactCall", b =>
                {
                    b.HasBaseType("PerudoBot.Database.Data.Action");

                    b.HasDiscriminator().HasValue("ExactCall");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.LiarCall", b =>
                {
                    b.HasBaseType("PerudoBot.Database.Data.Action");

                    b.HasDiscriminator().HasValue("LiarCall");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.StandardRound", b =>
                {
                    b.HasBaseType("PerudoBot.Database.Data.Round");

                    b.HasDiscriminator().HasValue("StandardRound");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Action", b =>
                {
                    b.HasOne("PerudoBot.Database.Data.GamePlayer", "GamePlayer")
                        .WithMany()
                        .HasForeignKey("GamePlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerudoBot.Database.Data.GamePlayerRound", "GamePlayerRound")
                        .WithMany("Actions")
                        .HasForeignKey("GamePlayerRoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerudoBot.Database.Data.Action", "ParentAction")
                        .WithMany()
                        .HasForeignKey("ParentActionId");

                    b.HasOne("PerudoBot.Database.Data.Round", "Round")
                        .WithMany("Actions")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlayer");

                    b.Navigation("GamePlayerRound");

                    b.Navigation("ParentAction");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayer", b =>
                {
                    b.HasOne("PerudoBot.Database.Data.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerudoBot.Database.Data.Player", "Player")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayerRound", b =>
                {
                    b.HasOne("PerudoBot.Database.Data.GamePlayer", "GamePlayer")
                        .WithMany("GamePlayerRounds")
                        .HasForeignKey("GamePlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerudoBot.Database.Data.Round", "Round")
                        .WithMany("GamePlayerRounds")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlayer");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Round", b =>
                {
                    b.HasOne("PerudoBot.Database.Data.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Game", b =>
                {
                    b.Navigation("GamePlayers");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayer", b =>
                {
                    b.Navigation("GamePlayerRounds");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.GamePlayerRound", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Player", b =>
                {
                    b.Navigation("GamesPlayed");
                });

            modelBuilder.Entity("PerudoBot.Database.Data.Round", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("GamePlayerRounds");
                });
#pragma warning restore 612, 618
        }
    }
}
