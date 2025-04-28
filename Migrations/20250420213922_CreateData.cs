using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Custumer_Tennis_TennisId",
                table: "Custumer");

            migrationBuilder.DropTable(
                name: "UserSeller");

            migrationBuilder.DropIndex(
                name: "IX_Custumer_TennisId",
                table: "Custumer");

            migrationBuilder.DropColumn(
                name: "TennisId",
                table: "Custumer");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "User",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Seller",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSale",
                table: "Seller",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Seller",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Seller",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Seller",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Userprofile",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userprofile", x => new { x.SellerId, x.profileId });
                    table.ForeignKey(
                        name: "Fk_UserProfile_ProfileId",
                        column: x => x.SellerId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_UserProfile_UserId",
                        column: x => x.profileId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_Seller",
                table: "Seller",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_SaleId",
                table: "Seller",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_UserId",
                table: "Seller",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Userprofile_profileId",
                table: "Userprofile",
                column: "profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Sale_SaleId",
                table: "Seller",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Seller",
                table: "Seller",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Sale_SaleId",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Seller",
                table: "Seller");

            migrationBuilder.DropTable(
                name: "Userprofile");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Email_Seller",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_SaleId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_UserId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Seller");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSale",
                table: "Seller",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TennisId",
                table: "Custumer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSeller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeller", x => new { x.SellerId, x.UserId });
                    table.ForeignKey(
                        name: "Fk_UserSller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_UserSller_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Custumer_TennisId",
                table: "Custumer",
                column: "TennisId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeller_UserId",
                table: "UserSeller",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Custumer_Tennis_TennisId",
                table: "Custumer",
                column: "TennisId",
                principalTable: "Tennis",
                principalColumn: "Id");
        }
    }
}
