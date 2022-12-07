using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseHoldBudget.Infrastructure.Migrations
{
    public partial class ChangeInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HouseHolds_HouseHoldId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HouseHoldId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HouseHoldId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserHouseHold",
                columns: table => new
                {
                    HouseHoldId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHouseHold", x => new { x.UserId, x.HouseHoldId });
                    table.ForeignKey(
                        name: "FK_UserHouseHold_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHouseHold_HouseHolds_HouseHoldId",
                        column: x => x.HouseHoldId,
                        principalTable: "HouseHolds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHouseHold_HouseHoldId",
                table: "UserHouseHold",
                column: "HouseHoldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHouseHold");

            migrationBuilder.AddColumn<int>(
                name: "HouseHoldId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HouseHoldId",
                table: "AspNetUsers",
                column: "HouseHoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HouseHolds_HouseHoldId",
                table: "AspNetUsers",
                column: "HouseHoldId",
                principalTable: "HouseHolds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
