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
    [Migration("20210528090926_birthday")]
    partial class birthday
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
                            Id = "c2083da3-c827-486e-b26f-fddbef088e36",
                            Name = "StoreFilesInDb",
                            Value = "false"
                        },
                        new
                        {
                            Id = "06af3fe6-12de-447c-9d4d-587e2d591b5a",
                            Name = "Application.Icon",
                            Value = "/images/layout_icons/header.png"
                        },
                        new
                        {
                            Id = "d3ddea25-7b4f-4ade-9e22-44f82136bddf",
                            Name = "Application.Name",
                            Value = ""
                        },
                        new
                        {
                            Id = "1a515f4c-f9c7-401d-b488-b92c780ffc0e",
                            Name = "Application.Copy",
                            Value = ""
                        },
                        new
                        {
                            Id = "541467c2-d274-449c-8932-a0a979d0752d",
                            Name = "BirthdayPath",
                            Value = "http://localhost:50510/api/People/Birthdate?skip=0&take=10"
                        },
                        new
                        {
                            Id = "5f9f2f36-01f9-4fe1-b016-40e270e2b4af",
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