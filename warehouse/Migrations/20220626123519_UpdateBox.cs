using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace warehouse.Migrations
{
    public partial class UpdateBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Addresses_AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palettes_PalletEntityId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_PalletEntityId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PalletEntityId",
                table: "Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Palettes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Palettes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Boxes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PalletId",
                table: "Boxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Boxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Boxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Palettes_AddressId",
                table: "Palettes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Palettes_ClientId",
                table: "Palettes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AddressId",
                table: "Boxes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_ClientId",
                table: "Boxes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalletId",
                table: "Boxes",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_StatusId",
                table: "Boxes",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Addresses_AddressId",
                table: "Boxes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Clients_ClientId",
                table: "Boxes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palettes_PalletId",
                table: "Boxes",
                column: "PalletId",
                principalTable: "Palettes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Status_StatusId",
                table: "Boxes",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Palettes_Addresses_AddressId",
                table: "Palettes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Palettes_Clients_ClientId",
                table: "Palettes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Addresses_AddressId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Clients_ClientId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palettes_PalletId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Status_StatusId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Palettes_Addresses_AddressId",
                table: "Palettes");

            migrationBuilder.DropForeignKey(
                name: "FK_Palettes_Clients_ClientId",
                table: "Palettes");

            migrationBuilder.DropIndex(
                name: "IX_Palettes_AddressId",
                table: "Palettes");

            migrationBuilder.DropIndex(
                name: "IX_Palettes_ClientId",
                table: "Palettes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_AddressId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_ClientId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_PalletId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_StatusId",
                table: "Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Palettes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Palettes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Boxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PalletId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressEntityId",
                table: "Boxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PalletEntityId",
                table: "Boxes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AddressEntityId",
                table: "Boxes",
                column: "AddressEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalletEntityId",
                table: "Boxes",
                column: "PalletEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Addresses_AddressEntityId",
                table: "Boxes",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palettes_PalletEntityId",
                table: "Boxes",
                column: "PalletEntityId",
                principalTable: "Palettes",
                principalColumn: "Id");
        }
    }
}
