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
    [Migration("20210519124402_CreatePlanCalendar")]
    partial class CreatePlanCalendar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Dal.Domain.Files.File", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("FileBinary")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastPart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Md5Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OriginalName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("AutorFio")
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

                    b.Property<string>("LastChangeAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NewsItems");
                });

            modelBuilder.Entity("Application.Dal.Domain.News.PinNews", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NewsItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "NewsItemId");

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

                    b.Property<int>("Month")
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
                            Id = "534f7a3a-52a5-4ec1-a501-d5f9c4a18a34",
                            Name = "StoreFilesInDb",
                            Value = "false"
                        },
                        new
                        {
                            Id = "feb8f9d2-47db-467b-b9d1-b08cd402d0ac",
                            Name = "Application.Icon",
                            Value = "/images/layout_icons/header.png"
                        },
                        new
                        {
                            Id = "49f7f29d-12ff-4c94-beb8-e62fd8a6cce1",
                            Name = "Application.Name",
                            Value = ""
                        },
                        new
                        {
                            Id = "7720f9c9-5007-432c-ab33-398ac162822b",
                            Name = "Application.Copy",
                            Value = ""
                        },
                        new
                        {
                            Id = "98146902-9f2d-4339-be0e-6c9f29d7ff8b",
                            Name = "BirthdayPath",
                            Value = "http://localhost:50510/api/People/Birthdate?skip=0&take=10"
                        },
                        new
                        {
                            Id = "e1e44c75-d726-496e-82d1-bfaa93f3720f",
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

            modelBuilder.Entity("Application.Dal.Domain.Files.File", b =>
                {
                    b.HasOne("Application.Dal.Domain.News.NewsItem", null)
                        .WithMany("Files")
                        .HasForeignKey("NewsItemId");
                });

            modelBuilder.Entity("Application.Dal.Domain.PlanCalendar.EventCalendar", b =>
                {
                    b.HasOne("Application.Dal.Domain.PlanCalendar.PlanCalendar", "PlanCalendar")
                        .WithMany("Events")
                        .HasForeignKey("PlanCalendarId");

                    b.Navigation("PlanCalendar");
                });

            modelBuilder.Entity("Application.Dal.Domain.Users.UserRole", b =>
                {
                    b.HasOne("Application.Dal.Domain.Menu.MenuItem", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("MenuItemId");
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