using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PopcornWebApp.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieImage = table.Column<string>(nullable: false),
                    MovieTitle = table.Column<string>(maxLength: 100, nullable: false),
                    Synopsis = table.Column<string>(nullable: false),
                    Duration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(maxLength: 25, nullable: false),
                    SeatsQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDate = table.Column<DateTime>(nullable: false),
                    SessionStart = table.Column<DateTime>(nullable: false),
                    SessionEnd = table.Column<DateTime>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    AnimationTypesFK = table.Column<int>(nullable: false),
                    AudioTypesFK = table.Column<int>(nullable: false),
                    MoviesFK = table.Column<int>(nullable: false),
                    RoomsFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_AnimationTypes_AnimationTypesFK",
                        column: x => x.AnimationTypesFK,
                        principalTable: "AnimationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_AudioTypes_AudioTypesFK",
                        column: x => x.AudioTypesFK,
                        principalTable: "AudioTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MoviesFK",
                        column: x => x.MoviesFK,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Rooms_RoomsFK",
                        column: x => x.RoomsFK,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AnimationTypesFK",
                table: "Sessions",
                column: "AnimationTypesFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AudioTypesFK",
                table: "Sessions",
                column: "AudioTypesFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MoviesFK",
                table: "Sessions",
                column: "MoviesFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomsFK",
                table: "Sessions",
                column: "RoomsFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "AnimationTypes");

            migrationBuilder.DropTable(
                name: "AudioTypes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
