using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLearn.Data.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "WaterType",
                columns: table => new
                {
                    WaterTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterType", x => x.WaterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Exhibit",
                columns: table => new
                {
                    ExhibitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WaterTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibit", x => x.ExhibitId);
                    table.ForeignKey(
                        name: "FK_Exhibit_WaterType_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "WaterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    FishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Schooling = table.Column<bool>(nullable: false),
                    WaterTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExhibitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.FishId);
                    table.ForeignKey(
                        name: "FK_Fish_Exhibit_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibit",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_WaterType_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "WaterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hazard",
                columns: table => new
                {
                    HazardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WaterTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExhibitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hazard", x => x.HazardId);
                    table.ForeignKey(
                        name: "FK_Hazard_Exhibit_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibit",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hazard_WaterType_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "WaterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WaterTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExhibitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plant_Exhibit_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibit",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plant_WaterType_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "WaterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trash",
                columns: table => new
                {
                    TrashId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Schooling = table.Column<bool>(nullable: false),
                    WaterTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExhibitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trash", x => x.TrashId);
                    table.ForeignKey(
                        name: "FK_Trash_Exhibit_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibit",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trash_WaterType_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "WaterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserRoleRoleId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ClassroomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_UserRoleRoleId",
                        column: x => x.UserRoleRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TeacherUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomId);
                    table.ForeignKey(
                        name: "FK_Classroom_User_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quiz_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TeacherUserId",
                table: "Classroom",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibit_WaterTypeId",
                table: "Exhibit",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_ExhibitId",
                table: "Fish",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_WaterTypeId",
                table: "Fish",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hazard_ExhibitId",
                table: "Hazard",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_Hazard_WaterTypeId",
                table: "Hazard",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_ExhibitId",
                table: "Plant",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_WaterTypeId",
                table: "Plant",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_ExhibitId",
                table: "Trash",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_WaterTypeId",
                table: "Trash",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ClassroomId",
                table: "User",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleRoleId",
                table: "User",
                column: "UserRoleRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Classroom_ClassroomId",
                table: "User",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_User_TeacherUserId",
                table: "Classroom");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Hazard");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Trash");

            migrationBuilder.DropTable(
                name: "Exhibit");

            migrationBuilder.DropTable(
                name: "WaterType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
