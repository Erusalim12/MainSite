﻿// <auto-generated />
using System;
using Application.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Dal.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211206124435_g1")]
    partial class g1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Dal.Domain.Birthday.Birtday", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentFullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Department");

                    b.Property<string>("DepartmentShortName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ShortDep");

                    b.Property<string>("FIO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("birthday_Table");
                });

            modelBuilder.Entity("Application.Dal.Domain.Counters.VisitorsCounter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TodayCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalDailyCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalNotUniqueCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VisitiorCounter");
                });

            modelBuilder.Entity("Application.Dal.Domain.ExternalLinks.ExternalLink", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("PathIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExternalLinks");
                });

            modelBuilder.Entity("Application.Dal.Domain.FeedBack.Answer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisit")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Application.Dal.Domain.FeedBack.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Application.Dal.Domain.Files.File", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DownloadBinary")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DownloadUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsItemId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NewsItemId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Application.Dal.Domain.Files.FileBinary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("BinaryData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileBinary");
                });

            modelBuilder.Entity("Application.Dal.Domain.Files.Picture", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AltAttribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("MimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoFilename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleAttribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VirtualPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Application.Dal.Domain.Menu.MenuItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToolTip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlIcone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Application.Dal.Domain.News.NewsItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorFio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdvancedEditor")
                        .HasColumnType("bit");

                    b.Property<string>("LastChangeAuthorFio")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastChangeAuthor");

                    b.Property<string>("LastChangeAuthorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NewsItems");
                });

            modelBuilder.Entity("Application.Dal.Domain.News.PinNews", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("NewsItemId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PinnedNews");
                });

            modelBuilder.Entity("Application.Dal.Domain.Permissions.PermissionRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Category = "Standart",
                            Name = "Access admin area",
                            SystemName = "AccessAdminPanel"
                        },
                        new
                        {
                            Id = "2",
                            Category = "Configuration",
                            Name = "Admin area. Manage ACL",
                            SystemName = "ManageACL"
                        });
                });

            modelBuilder.Entity("Application.Dal.Domain.Permissions.PermissionRecordUserRoleMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PermissionRecordId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PRURM");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            PermissionRecordId = "1",
                            UserRoleId = "1"
                        },
                        new
                        {
                            Id = "2",
                            PermissionRecordId = "2",
                            UserRoleId = "1"
                        });
                });

            modelBuilder.Entity("Application.Dal.Domain.PlanCalendar.EventCalendar", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Leader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAllStav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanCalendarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanCalendarId");

                    b.ToTable("EventCalendars");
                });

            modelBuilder.Entity("Application.Dal.Domain.PlanCalendar.PlanCalendar", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlanCalendars");
                });

            modelBuilder.Entity("Application.Dal.Domain.Settings.Setting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = "745ae46d-dbc4-4184-970a-186d46d3ddce",
                            Name = "StoreFilesInDb",
                            Value = "false"
                        },
                        new
                        {
                            Id = "81d911ac-2d16-47ce-9278-b176e4e4a8d8",
                            Name = "Application.Icon",
                            Value = "/images/layout_icons/header.png"
                        },
                        new
                        {
                            Id = "769f6ba4-483f-4b90-ba6a-b6150df72299",
                            Name = "Application.Name",
                            Value = ""
                        },
                        new
                        {
                            Id = "2a56db7b-3d7d-4ffa-8356-7f02e9856ebe",
                            Name = "Application.Copy",
                            Value = ""
                        },
                        new
                        {
                            Id = "b3fd8208-b087-4a17-9a80-19644f9398ec",
                            Name = "BirthdayPath",
                            Value = "http://localhost:50510/api/People/Birthdate?skip=0&take=10"
                        },
                        new
                        {
                            Id = "6c13f9e1-2b9c-44a8-ba6a-217754d2505f",
                            Name = "Application.Header",
                            Value = "Main_Application"
                        },
                        new
                        {
                            Id = "b2d83e42-ea66-4805-a99a-a23c16201dfa",
                            Name = "Page.PageSize",
                            Value = "3"
                        });
                });

            modelBuilder.Entity("Application.Dal.Domain.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubdivisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Application.Dal.Domain.Users.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemRole")
                        .HasColumnType("bit");

                    b.Property<string>("MenuItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Active = true,
                            IsSystemRole = true,
                            Name = "Администратор",
                            SystemName = "Administrator"
                        },
                        new
                        {
                            Id = "2",
                            Active = true,
                            IsSystemRole = true,
                            Name = "Модератор",
                            SystemName = "Moderator"
                        },
                        new
                        {
                            Id = "3",
                            Active = true,
                            IsSystemRole = true,
                            Name = "Сотрудник",
                            SystemName = "Registered"
                        });
                });

            modelBuilder.Entity("Application.Dal.Domain.Users.UserUserRoleMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UURM");
                });

            modelBuilder.Entity("Application.Dal.Domain.FeedBack.Answer", b =>
                {
                    b.HasOne("Application.Dal.Domain.FeedBack.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Application.Dal.Domain.Files.File", b =>
                {
                    b.HasOne("Application.Dal.Domain.News.NewsItem", null)
                        .WithMany("Files")
                        .HasForeignKey("NewsItemId");
                });

            modelBuilder.Entity("Application.Dal.Domain.PlanCalendar.EventCalendar", b =>
                {
                    b.HasOne("Application.Dal.Domain.PlanCalendar.PlanCalendar", null)
                        .WithMany("Events")
                        .HasForeignKey("PlanCalendarId");
                });

            modelBuilder.Entity("Application.Dal.Domain.Users.UserRole", b =>
                {
                    b.HasOne("Application.Dal.Domain.Menu.MenuItem", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("MenuItemId");
                });

            modelBuilder.Entity("Application.Dal.Domain.FeedBack.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Application.Dal.Domain.Menu.MenuItem", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Application.Dal.Domain.News.NewsItem", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("Application.Dal.Domain.PlanCalendar.PlanCalendar", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
