using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.DbContexts.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_Contracts_ContractId",
                table: "Interventions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_Technicians_TechnicianId",
                table: "Interventions");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Client 1" },
                    { 2, "Client 2" },
                    { 3, "Client 3" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ContractNumber", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, "C-001", new DateTime(2026, 3, 4, 9, 49, 58, 501, DateTimeKind.Local).AddTicks(6813), new DateTime(2025, 3, 4, 9, 49, 58, 499, DateTimeKind.Local).AddTicks(9549) },
                    { 2, "C-002", new DateTime(2027, 3, 4, 9, 49, 58, 501, DateTimeKind.Local).AddTicks(7073), new DateTime(2025, 3, 4, 9, 49, 58, 501, DateTimeKind.Local).AddTicks(7067) },
                    { 3, "C-003", new DateTime(2028, 3, 4, 9, 49, 58, 501, DateTimeKind.Local).AddTicks(7077), new DateTime(2025, 3, 4, 9, 49, 58, 501, DateTimeKind.Local).AddTicks(7075) }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Status 1" },
                    { 2, "Status 2" },
                    { 3, "Status 3" }
                });

            migrationBuilder.InsertData(
                table: "SystemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "System Type 1" },
                    { 2, "System Type 2" },
                    { 3, "System Type 3" }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "tech1@domain.com", "Technician 1" },
                    { 2, "tech2@domain.com", "Technician 2" },
                    { 3, "tech3@domain.com", "Technician 3" }
                });

            migrationBuilder.InsertData(
                table: "Interventions",
                columns: new[] { "Id", "ClientId", "CompletedAt", "ContractId", "CreatedAt", "Notes", "StatusId", "SystemTypeId", "TechnicianId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(1045), "Intervention 1", 1, 1, 1 },
                    { 2, 2, null, 2, new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(1367), "Intervention 2", 2, 2, 2 },
                    { 3, 3, null, 3, new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(1372), "Intervention 3", 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Geolocations",
                columns: new[] { "Id", "InterventionId", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, 1, 34.052199999999999, -118.2437 },
                    { 2, 2, 40.712800000000001, -74.006 },
                    { 3, 3, 51.507399999999997, -0.1278 }
                });

            migrationBuilder.InsertData(
                table: "Signatures",
                columns: new[] { "Id", "InterventionId", "SignatureData", "SignedAt", "SignedBy" },
                values: new object[,]
                {
                    { 1, 1, "data1", new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(2011), "Signer 1" },
                    { 2, 2, "data2", new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(2390), "Signer 2" },
                    { 3, 3, "data3", new DateTime(2025, 3, 4, 9, 49, 58, 502, DateTimeKind.Local).AddTicks(2395), "Signer 3" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_Contracts_ContractId",
                table: "Interventions",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_Technicians_TechnicianId",
                table: "Interventions",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_Contracts_ContractId",
                table: "Interventions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_Technicians_TechnicianId",
                table: "Interventions");

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Signatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Signatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Signatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interventions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interventions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interventions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SystemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SystemTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_Contracts_ContractId",
                table: "Interventions",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_Technicians_TechnicianId",
                table: "Interventions",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
