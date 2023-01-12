using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIYnovArchiM1.Migrations
{
    public partial class fixed_eng_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balises");

            migrationBuilder.DropTable(
                name: "BalisesActives");

            migrationBuilder.DropTable(
                name: "ChoixMults");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "TextsToWrites");

            migrationBuilder.RenameColumn(
                name: "Pseudo",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "IDTExt",
                table: "Quizzs",
                newName: "IDText");

            migrationBuilder.RenameColumn(
                name: "IDChoix",
                table: "Quizzs",
                newName: "IDChoice");

            migrationBuilder.RenameColumn(
                name: "IDCourse",
                table: "Events",
                newName: "IDRace");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Quizzs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Quizzs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "QuizzChoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    choice1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodOne = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzChoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuizzText",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzText", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TagActives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDRace = table.Column<int>(type: "int", nullable: false),
                    IDTag = table.Column<int>(type: "int", nullable: false),
                    IDQuizz = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagActives", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizzChoices");

            migrationBuilder.DropTable(
                name: "QuizzText");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "TagActives");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Quizzs");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Pseudo");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IDText",
                table: "Quizzs",
                newName: "IDTExt");

            migrationBuilder.RenameColumn(
                name: "IDChoice",
                table: "Quizzs",
                newName: "IDChoix");

            migrationBuilder.RenameColumn(
                name: "IDRace",
                table: "Events",
                newName: "IDCourse");

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Quizzs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Balises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BalisesActives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBalise = table.Column<int>(type: "int", nullable: false),
                    IDCourse = table.Column<int>(type: "int", nullable: false),
                    IDQuizz = table.Column<int>(type: "int", nullable: false),
                    ordre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalisesActives", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChoixMults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodOne = table.Column<int>(type: "int", nullable: false),
                    choix1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choix2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choix3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choix4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoixMults", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TextsToWrites",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextsToWrites", x => x.ID);
                });
        }
    }
}
