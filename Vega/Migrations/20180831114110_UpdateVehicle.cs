using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class UpdateVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_Features_FeatureId",
                table: "VehicleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_Vehicles_VehicleId",
                table: "VehicleFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeature",
                table: "VehicleFeature");

            migrationBuilder.RenameTable(
                name: "VehicleFeature",
                newName: "VehicleFeatures");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "Vehicles",
                newName: "Contact_Phone");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Vehicles",
                newName: "Contact_Name");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeature_FeatureId",
                table: "VehicleFeatures",
                newName: "IX_VehicleFeatures_FeatureId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact_Email",
                table: "Vehicles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures",
                columns: new[] { "VehicleId", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures");

            migrationBuilder.DropColumn(
                name: "Contact_Email",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleFeatures",
                newName: "VehicleFeature");

            migrationBuilder.RenameColumn(
                name: "Contact_Phone",
                table: "Vehicles",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Vehicles",
                newName: "ContactName");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeature",
                newName: "IX_VehicleFeature_FeatureId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeature",
                table: "VehicleFeature",
                columns: new[] { "VehicleId", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_Features_FeatureId",
                table: "VehicleFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_Vehicles_VehicleId",
                table: "VehicleFeature",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
