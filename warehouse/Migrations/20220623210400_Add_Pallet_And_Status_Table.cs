using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace warehouse.Migrations
{
    public partial class Add_Pallet_And_Status_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Clients_ClientEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Addresses_AddressId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Clients_ClientId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_AddressId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_ClientId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ClientEntityId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ClientEntityId",
                table: "Addresses");

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

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Palettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AddressEntityId",
                table: "Boxes",
                column: "AddressEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalletEntityId",
                table: "Boxes",
                column: "PalletEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Clients_ClientId",
                table: "Addresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Clients_ClientId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Addresses_AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palettes_PalletEntityId",
                table: "Boxes");

            migrationBuilder.DropTable(
                name: "Palettes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_PalletEntityId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressEntityId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PalletEntityId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Boxes");

            migrationBuilder.AddColumn<int>(
                name: "ClientEntityId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AddressId",
                table: "Boxes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_ClientId",
                table: "Boxes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientEntityId",
                table: "Addresses",
                column: "ClientEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Clients_ClientEntityId",
                table: "Addresses",
                column: "ClientEntityId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Addresses_AddressId",
                table: "Boxes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Clients_ClientId",
                table: "Boxes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
