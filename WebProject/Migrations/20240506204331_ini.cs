using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bolumno = table.Column<int>(type: "int", nullable: false),
                    Rutbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolumAdı = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolum", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenelAyarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedln = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKisiID = table.Column<int>(type: "int", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KisaTarihce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelAyarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    AkademisyenNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumNo = table.Column<int>(type: "int", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNUmarası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hakkında = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doktora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YüksekLisans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lisans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArastirmaAlanı = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.AkademisyenNo);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeHakkında = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeNe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjeNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolum");

            migrationBuilder.DropTable(
                name: "GenelAyarlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
