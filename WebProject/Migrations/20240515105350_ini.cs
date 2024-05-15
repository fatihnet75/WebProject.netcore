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
                name: "Kullanicilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
