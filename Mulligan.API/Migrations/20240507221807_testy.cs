using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mulligan.API.Migrations
{
    /// <inheritdoc />
    public partial class testy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GOLF_COURSE",
                columns: table => new
                {
                    GOLF_COURSE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUBDIVISION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YARDAGE = table.Column<int>(type: "int", nullable: false),
                    PAR = table.Column<int>(type: "int", nullable: false),
                    SLOPE_RATING = table.Column<int>(type: "int", nullable: false),
                    COURSE_RATING = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOLF_COURSE", x => x.GOLF_COURSE_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HANDICAP_INDEX = table.Column<float>(type: "real", nullable: false),
                    HOME_COURSE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOLF_COURSE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USER_GOLF_COURSE_GolfCourseDomainGOLF_COURSE_ID",
                        column: x => x.GOLF_COURSE_ID,
                        principalTable: "GOLF_COURSE",
                        principalColumn: "GOLF_COURSE_ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "POST",
                columns: table => new
                {
                    POST_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POST", x => x.POST_ID);
                    table.ForeignKey(
                        name: "FK_POST_USER_UserDomainUSER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCORE",
                columns: table => new
                {
                    SCORE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TOTAL = table.Column<int>(type: "int", nullable: false),
                    DIFFERENTIAL = table.Column<float>(type: "real", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GOLF_COURSE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCORE", x => x.SCORE_ID);
                    table.ForeignKey(
                        name: "FK_SCORE_GOLF_COURSE_GolfCourseDomainGOLF_COURSE_ID",
                        column: x => x.GOLF_COURSE_ID,
                        principalTable: "GOLF_COURSE",
                        principalColumn: "GOLF_COURSE_ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SCORE_USER_UserDomainUSER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POST_UserDomainUSER_ID",
                table: "POST",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCORE_GolfCourseDomainGOLF_COURSE_ID",
                table: "SCORE",
                column: "GOLF_COURSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCORE_UserDomainUSER_ID",
                table: "SCORE",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_GolfCourseDomainGOLF_COURSE_ID",
                table: "USER",
                column: "GOLF_COURSE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POST");

            migrationBuilder.DropTable(
                name: "SCORE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "GOLF_COURSE");
        }
    }
}
