﻿// <auto-generated />
using System;
using FakeSurveyGenerator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeSurveyGenerator.Infrastructure.Migrations
{
    [DbContext(typeof(SurveyContext))]
    [Migration("20200612064505_AddExternalUserIdToUser")]
    partial class AddExternalUserIdToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:Survey.SurveyOptionSeq", "'SurveyOptionSeq', 'Survey', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:Survey.SurveySeq", "'SurveySeq', 'Survey', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:Survey.UserSeq", "'UserSeq', 'Survey', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeSurveyGenerator.Domain.AggregatesModel.SurveyAggregate.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SurveySeq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Survey")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<System.DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfRespondents")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("RespondentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Survey","Survey");
                });

            modelBuilder.Entity("FakeSurveyGenerator.Domain.AggregatesModel.SurveyAggregate.SurveyOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SurveyOptionSeq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Survey")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("NumberOfVotes")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("PreferredNumberOfVotes")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyOption","Survey");
                });

            modelBuilder.Entity("FakeSurveyGenerator.Domain.AggregatesModel.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "UserSeq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Survey")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ExternalUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("User","Survey");
                });

            modelBuilder.Entity("FakeSurveyGenerator.Domain.AggregatesModel.SurveyAggregate.Survey", b =>
                {
                    b.HasOne("FakeSurveyGenerator.Domain.AggregatesModel.UserAggregate.User", "Owner")
                        .WithMany("OwnedSurveys")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FakeSurveyGenerator.Domain.AggregatesModel.SurveyAggregate.SurveyOption", b =>
                {
                    b.HasOne("FakeSurveyGenerator.Domain.AggregatesModel.SurveyAggregate.Survey", null)
                        .WithMany("Options")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
