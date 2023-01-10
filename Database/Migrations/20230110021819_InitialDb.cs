using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BongOliver.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
