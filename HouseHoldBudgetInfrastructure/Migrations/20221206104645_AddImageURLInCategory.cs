using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseHoldBudget.Infrastructure.Migrations
{
    public partial class AddImageURLInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BudgetInitials",
                type: "money",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://mpng.subpng.com/20200228/kzx/transparent-assets-icon-loan-icon-fintech-icon-5e59c31a69f9f5.2406849615829409544341.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://w7.pngwing.com/pngs/359/237/png-transparent-rail-transport-logistics-mode-of-transport-public-transport-beautifully-global-travel-background-material-freight-transport-service-logo.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://previews.123rf.com/images/fdsstudio/fdsstudio1905/fdsstudio190500013/122776211-food-icon-on-white-background-cutlery-as-a-symbol-of-food-vector-logo-for-graphic-design-.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://as1.ftcdn.net/v2/jpg/04/36/98/62/1000_F_436986282_xPXikgyys8ghwYx1rYJewxKPKHLM7lVv.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSco2fhPOojGcC3duj_oajm6FJyho3ugGP8NhojGwBAyfQs34CBMyud-ALrKcJ_bdxMNj8&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3LZt2J5V_rt89Jj1dsT09dFzfxWlfFaikUQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://cdn.iconscout.com/icon/premium/png-256-thumb/hobbies-1651245-1403352.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://png.pngtree.com/element_our/png/20180807/pngtree-pinmark-vacation-icon-and-concept-png-image_54653.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://img.freepik.com/premium-vector/restaurant-icon-concept-with-icon-design_24911-17835.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.all-free-download.com/images/graphiclarge/home_decor_background_chair_light_table_flowerpot_icons_6838281.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf4l7pqQ83E-tDbAKZNZEEn8Wi7mt-rBM-1w&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://cdn-icons-png.flaticon.com/512/4988/4988659.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://i1.sndcdn.com/avatars-000330114611-hkocch-t500x500.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BudgetInitials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
