using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace warehouse.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palettes_PalletId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Palettes_Addresses_AddressId",
                table: "Palettes");

            migrationBuilder.DropForeignKey(
                name: "FK_Palettes_Clients_ClientId",
                table: "Palettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palettes",
                table: "Palettes");

            migrationBuilder.RenameTable(
                name: "Palettes",
                newName: "Pallets");

            migrationBuilder.RenameIndex(
                name: "IX_Palettes_ClientId",
                table: "Pallets",
                newName: "IX_Pallets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Palettes_AddressId",
                table: "Pallets",
                newName: "IX_Pallets_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_StatusId",
                table: "Pallets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Pallets_PalletId",
                table: "Boxes",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Addresses_AddressId",
                table: "Pallets",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Clients_ClientId",
                table: "Pallets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Status_StatusId",
                table: "Pallets",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Pallets_PalletId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Addresses_AddressId",
                table: "Pallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Clients_ClientId",
                table: "Pallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Status_StatusId",
                table: "Pallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_StatusId",
                table: "Pallets");

            migrationBuilder.RenameTable(
                name: "Pallets",
                newName: "Palettes");

            migrationBuilder.RenameIndex(
                name: "IX_Pallets_ClientId",
                table: "Palettes",
                newName: "IX_Palettes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallets_AddressId",
                table: "Palettes",
                newName: "IX_Palettes_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palettes",
                table: "Palettes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palettes_PalletId",
                table: "Boxes",
                column: "PalletId",
                principalTable: "Palettes",
                principalColumn: "Id");

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
    }
}
