using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    Birthday = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mark",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubjectId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Scores = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mark", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_tbl_mark_tbl_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_mark_tbl_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tbl_subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mark_SubjectId",
                table: "tbl_mark",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_mark");

            migrationBuilder.DropTable(
                name: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_subject");
        }
    }
}
