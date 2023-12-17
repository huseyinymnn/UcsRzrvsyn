using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcusRez.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Giris",
                columns: table => new
                {
                    GirisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giris", x => x.GirisID);
                });

            migrationBuilder.CreateTable(
                name: "Guzergah",
                columns: table => new
                {
                    GuzergahID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalkisSehri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VarisSehri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guzergah", x => x.GuzergahID);
                });

            migrationBuilder.CreateTable(
                name: "Kayit",
                columns: table => new
                {
                    KayitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KayitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfKayitPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kayit", x => x.KayitID);
                });

            migrationBuilder.CreateTable(
                name: "Ucak",
                columns: table => new
                {
                    UcakID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucak", x => x.UcakID);
                });

            migrationBuilder.CreateTable(
                name: "Yolcu",
                columns: table => new
                {
                    YolcuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YolcuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YolcuSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YolcuTC = table.Column<int>(type: "int", nullable: false),
                    YolcuDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YolcuGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YolcuMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YolcuPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yolcu", x => x.YolcuID);
                });

            migrationBuilder.CreateTable(
                name: "Ucus",
                columns: table => new
                {
                    UcusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuzergahID = table.Column<int>(type: "int", nullable: false),
                    UcakID = table.Column<int>(type: "int", nullable: false),
                    UcusTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucus", x => x.UcusID);
                    table.ForeignKey(
                        name: "FK_Ucus_Guzergah_GuzergahID",
                        column: x => x.GuzergahID,
                        principalTable: "Guzergah",
                        principalColumn: "GuzergahID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ucus_Ucak_UcakID",
                        column: x => x.UcakID,
                        principalTable: "Ucak",
                        principalColumn: "UcakID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoltukNumarasi = table.Column<int>(type: "int", nullable: false),
                    YolcuID = table.Column<int>(type: "int", nullable: false),
                    UcusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilet_Ucus_UcusID",
                        column: x => x.UcusID,
                        principalTable: "Ucus",
                        principalColumn: "UcusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilet_Yolcu_YolcuID",
                        column: x => x.YolcuID,
                        principalTable: "Yolcu",
                        principalColumn: "YolcuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_UcusID",
                table: "Bilet",
                column: "UcusID");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_YolcuID",
                table: "Bilet",
                column: "YolcuID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucus_GuzergahID",
                table: "Ucus",
                column: "GuzergahID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucus_UcakID",
                table: "Ucus",
                column: "UcakID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Giris");

            migrationBuilder.DropTable(
                name: "Kayit");

            migrationBuilder.DropTable(
                name: "Ucus");

            migrationBuilder.DropTable(
                name: "Yolcu");

            migrationBuilder.DropTable(
                name: "Guzergah");

            migrationBuilder.DropTable(
                name: "Ucak");
        }
    }
}
