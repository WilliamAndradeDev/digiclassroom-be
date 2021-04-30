using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiClassroom.Infrastructure.Migrations
{
    public partial class BaseInfrastructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    LocationClassroom = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocatedAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assingments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Creation = table.Column<DateTime>(type: "date", nullable: false),
                    Deadline = table.Column<DateTime>(type: "date", nullable: false),
                    Updated = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Pontuation = table.Column<double>(type: "double precision", precision: 4, scale: 2, nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assingments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assingments_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_Classrooms_Id",
                        column: x => x.Id,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentAnswer = table.Column<string>(type: "text", nullable: false),
                    AssingmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Assingments_AssingmentId",
                        column: x => x.AssingmentId,
                        principalTable: "Assingments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    AssingmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Assingments_AssingmentId",
                        column: x => x.AssingmentId,
                        principalTable: "Assingments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryLibraryFiles",
                columns: table => new
                {
                    FilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    LibrariesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryLibraryFiles", x => new { x.FilesId, x.LibrariesId });
                    table.ForeignKey(
                        name: "FK_LibraryLibraryFiles_Libraries_LibrariesId",
                        column: x => x.LibrariesId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryLibraryFiles_LibraryFile_FilesId",
                        column: x => x.FilesId,
                        principalTable: "LibraryFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ClassroomId",
                table: "Announcements",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AssingmentId",
                table: "Answer",
                column: "AssingmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assingments_ClassroomId",
                table: "Assingments",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AssingmentId",
                table: "Comment",
                column: "AssingmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryLibraryFiles_LibrariesId",
                table: "LibraryLibraryFiles",
                column: "LibrariesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "LibraryLibraryFiles");

            migrationBuilder.DropTable(
                name: "Assingments");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "LibraryFile");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
