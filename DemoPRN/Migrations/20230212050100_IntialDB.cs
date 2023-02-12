using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoPRN.Migrations
{
    public partial class IntialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("04e68dd3-f57c-45ab-b821-9186fe634e82"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("22f2d665-2618-438c-a55b-f557b7a0df0c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("9f0dd7dc-3005-4af9-937e-5b194d40948c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("da44f382-ea48-4af1-8cf2-577d0f797267"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("8bb4589f-9702-400d-836f-91d27522c3ab"), "Ha Noi", "Viet Nam", "Base Vn" },
                    { new Guid("9d80dfec-feb2-4c8e-8bdc-4422a7cef476"), "Ha Noi", "Viet Nam", "FPT SoftWare" },
                    { new Guid("ca9d6a4a-f5fa-4609-9ea1-8d37286eab07"), "Ha Noi", "Viet Nam", "NTQ" },
                    { new Guid("f149995b-7f54-42c6-807d-b43990de5ff4"), "Ha Noi", "Viet Nam", "Nash Tech" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("8bb4589f-9702-400d-836f-91d27522c3ab"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("9d80dfec-feb2-4c8e-8bdc-4422a7cef476"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("ca9d6a4a-f5fa-4609-9ea1-8d37286eab07"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("f149995b-7f54-42c6-807d-b43990de5ff4"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("04e68dd3-f57c-45ab-b821-9186fe634e82"), "Ha Noi", "Viet Nam", "FPT SoftWare" },
                    { new Guid("22f2d665-2618-438c-a55b-f557b7a0df0c"), "Ha Noi", "Viet Nam", "NTQ" },
                    { new Guid("9f0dd7dc-3005-4af9-937e-5b194d40948c"), "Ha Noi", "Viet Nam", "Base Vn" },
                    { new Guid("da44f382-ea48-4af1-8cf2-577d0f797267"), "Ha Noi", "Viet Nam", "Nash Tech" }
                });
        }
    }
}
