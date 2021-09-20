using Microsoft.EntityFrameworkCore.Migrations;

namespace senai.hroads.webApi.Migrations
{
    public partial class criacaobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    idClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeClasse = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.idClasse);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    idPersonagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomePersonagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.idPersonagem);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabilidade",
                columns: table => new
                {
                    idTipoHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeTipoHabilidade = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabilidade", x => x.idTipoHabilidade);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeHabilidade = table.Column<string>(type: "varchar(40)", nullable: false),
                    idTipoHabilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.idHabilidade);
                    table.ForeignKey(
                        name: "FK_Habilidades_TipoHabilidade_idTipoHabilidade",
                        column: x => x.idTipoHabilidade,
                        principalTable: "TipoHabilidade",
                        principalColumn: "idTipoHabilidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    senha = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuarios);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoClasse",
                columns: table => new
                {
                    infoClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idClasse = table.Column<int>(type: "int", nullable: false),
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoClasse", x => x.infoClasse);
                    table.ForeignKey(
                        name: "FK_InfoClasse_Classes_idClasse",
                        column: x => x.idClasse,
                        principalTable: "Classes",
                        principalColumn: "idClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoClasse_Habilidades_idHabilidade",
                        column: x => x.idHabilidade,
                        principalTable: "Habilidades",
                        principalColumn: "idHabilidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[] { 2, "Administrador" });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[] { 4, "Cliente" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuarios", "email", "idTipoUsuario", "senha" },
                values: new object[] { 1, "admin@admin.com", 2, "admin" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuarios", "email", "idTipoUsuario", "senha" },
                values: new object[] { 2, "cliente@cliente.com", 4, "cliente" });

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_idTipoHabilidade",
                table: "Habilidades",
                column: "idTipoHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_InfoClasse_idClasse",
                table: "InfoClasse",
                column: "idClasse");

            migrationBuilder.CreateIndex(
                name: "IX_InfoClasse_idHabilidade",
                table: "InfoClasse",
                column: "idHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idTipoUsuario",
                table: "Usuarios",
                column: "idTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoClasse");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropTable(
                name: "TipoHabilidade");
        }
    }
}
