// <auto-generated />
using FoldersStructure_Client.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoldersStructure_Client.Migrations
{
    [DbContext(typeof(FoldersStructureDbContext))]
    [Migration("20230228132421_InnitDatabase")]
    partial class InnitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("FoldersStructure_Client.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentFolderName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Creating Digital Images",
                            ParentFolderName = ""
                        },
                        new
                        {
                            Id = 2,
                            Name = "Resources",
                            ParentFolderName = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Evidence",
                            ParentFolderName = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Graphic Products",
                            ParentFolderName = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Primary Sources",
                            ParentFolderName = "Resources"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Secondary Sources",
                            ParentFolderName = "Resources"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Process",
                            ParentFolderName = "Graphic Products"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Final Product",
                            ParentFolderName = "Graphic Products"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
