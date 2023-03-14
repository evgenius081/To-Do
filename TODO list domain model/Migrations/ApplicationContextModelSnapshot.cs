﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODOListDomainModel.Context;

namespace TODOListDomainModel.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TODOListDomainModel.Classes.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<bool>("Remind")
                        .HasColumnType("bit");

                    b.Property<bool>("Starred")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ToDoListID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 2, 27, 10, 31, 28, 149, DateTimeKind.Utc).AddTicks(9521),
                            Deadline = new DateTime(2023, 3, 2, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(689),
                            Description = "Milk, bread, eggs, cheese",
                            IsHidden = false,
                            Remind = true,
                            Starred = true,
                            Status = 0,
                            Title = "Buy groceries",
                            ToDoListID = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 2, 25, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4448),
                            Deadline = new DateTime(2023, 3, 1, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4491),
                            Description = "Write up the findings from the experiments",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 1,
                            Title = "Finish project report",
                            ToDoListID = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 2, 21, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4699),
                            Deadline = new DateTime(2023, 2, 26, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4703),
                            Description = "Run for 30 minutes around the park",
                            IsHidden = true,
                            Remind = false,
                            Starred = false,
                            Status = 2,
                            Title = "Go for a run",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 2, 26, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4710),
                            Deadline = new DateTime(2023, 3, 3, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4712),
                            Description = "Check in with her and see how she's doing",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 0,
                            Title = "Call mom",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 2, 24, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4717),
                            Deadline = new DateTime(2023, 3, 2, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4721),
                            Description = "Complete the coding challenge for the job application",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 1,
                            Title = "Finish coding challenge",
                            ToDoListID = 2
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 2, 26, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4725),
                            Deadline = new DateTime(2023, 3, 1, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4727),
                            Description = "Vacuum the floors and dust the surfaces",
                            IsHidden = false,
                            Remind = false,
                            Starred = true,
                            Status = 0,
                            Title = "Clean the house",
                            ToDoListID = 1
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 2, 23, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4737),
                            Deadline = new DateTime(2023, 3, 1, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4742),
                            Description = "Mail the birthday card to your friend",
                            IsHidden = false,
                            Remind = true,
                            Starred = false,
                            Status = 2,
                            Title = "Send birthday card",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2023, 2, 27, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4744),
                            Deadline = new DateTime(2023, 3, 7, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4745),
                            Description = "Make an appointment for a teeth cleaning",
                            IsHidden = true,
                            Remind = false,
                            Starred = false,
                            Status = 0,
                            Title = "Schedule dentist appointment",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2023, 2, 25, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4752),
                            Deadline = new DateTime(2023, 2, 28, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4754),
                            Description = "Submit the expense report for reimbursement",
                            IsHidden = false,
                            Remind = false,
                            Starred = true,
                            Status = 1,
                            Title = "Submit expense report",
                            ToDoListID = 2
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2023, 2, 22, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4757),
                            Deadline = new DateTime(2023, 3, 3, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4763),
                            Description = "Read the next chapter in the book club book",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 0,
                            Title = "Read book",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2023, 2, 27, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4766),
                            Deadline = new DateTime(2023, 2, 28, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4768),
                            Description = "Review the agenda and prepare notes for the meeting",
                            IsHidden = false,
                            Remind = true,
                            Starred = false,
                            Status = 1,
                            Title = "Prepare for meeting",
                            ToDoListID = 2
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2023, 2, 23, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4775),
                            Deadline = new DateTime(2023, 3, 2, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4777),
                            Description = "Choose and purchase a gift for the upcoming birthday",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 0,
                            Title = "Buy birthday gift",
                            ToDoListID = 3
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2023, 2, 27, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4780),
                            Deadline = new DateTime(2023, 3, 1, 10, 31, 28, 150, DateTimeKind.Utc).AddTicks(4785),
                            Description = "Respond to the email from your coworker",
                            IsHidden = false,
                            Remind = false,
                            Starred = false,
                            Status = 0,
                            Title = "Reply to email",
                            ToDoListID = 2
                        });
                });

            modelBuilder.Entity("TODOListDomainModel.Classes.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsArchived = true,
                            Title = "House things"
                        },
                        new
                        {
                            Id = 2,
                            IsArchived = false,
                            Title = "Work tasks"
                        },
                        new
                        {
                            Id = 3,
                            IsArchived = false,
                            Title = "Being adult"
                        });
                });

            modelBuilder.Entity("TODOListDomainModel.Classes.ToDoItem", b =>
                {
                    b.HasOne("TODOListDomainModel.Classes.ToDoList", "TodoList")
                        .WithMany("Items")
                        .HasForeignKey("ToDoListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("TODOListDomainModel.Classes.ToDoList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
