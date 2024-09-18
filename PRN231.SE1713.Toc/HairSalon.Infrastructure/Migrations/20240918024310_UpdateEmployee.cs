using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CitizenId",
                table: "Employee",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CustomerAddress", "DateOfBirth", "Email", "CustomerName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, CA 12345", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "securepassword123!", "0912345678", null, null },
                    { 2, "456 Elm St, Springfield, IL 54321", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@email.com", "Jane Smith", "anothersecurepassword!@#", "0987654321", null, null },
                    { 3, "789 Maple Ave, Hanoi, Vietnam 10000", new DateTime(1975, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.chen@company.com", "Michael Chen", "Myp@ssw0rd1sStr0ng", "0901234567", null, null },
                    { 4, "10 Downing St, London, UK SW1A 2AA", new DateTime(2000, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "aisha.khan@gmail.com", "Aisha Khan", "SuperSecurePassw0rd!", "0934567890", null, null },
                    { 5, "Müllerstraße 123, Berlin, Germany 10117", new DateTime(1965, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter.schmidt@deutschland.de", "Peter Schmidt", "S1ch3rheitsp@ssw0rt!", "0956789012", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "CitizenId", "DateOfBirth", "Email", "EmployeeName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "Role" },
                values: new object[,]
                {
                    { 1, "123 Le Loi, Ho Chi Minh City", "012345678901", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@example.com", "Nguyen Van A", "Nguyen@2024", "0901234567", null, null, 0 },
                    { 2, "456 Nguyen Hue, Ho Chi Minh City", "123456789012", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "Tran Thi B", "TranThiB@2024", "0912345678", null, null, 0 },
                    { 3, "789 Tran Hung Dao, Ho Chi Minh City", "234567890123", new DateTime(1992, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "le.thic@example.com", "Le Thi C", "LeThiC@2024", "0923456789", null, null, 1 },
                    { 4, "101 Pham Ngu Lao, Ho Chi Minh City", "345678901234", new DateTime(1988, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pham.vand@example.com", "Pham Van D", "PhamVanD@2024", "0934567890", null, null, 1 },
                    { 5, "202 Vo Van Kiet, Ho Chi Minh City", "456789012345", new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang.thie@example.com", "Hoang Thi E", "HoangThiE@2024", "0945678901", null, null, 1 },
                    { 6, "303 Le Lai, Ho Chi Minh City", "567890123456", new DateTime(1992, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.minhf@example.com", "Nguyen Minh F", "NguyenMinhF@2024", "0956789012", null, null, 1 },
                    { 7, "404 Tran Dai Nghia, Ho Chi Minh City", "678901234567", new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "truong.vang@example.com", "Truong Van G", "TruongVanG@2024", "0967890123", null, null, 1 },
                    { 8, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Administrator", "strongpass321!@", null, null, null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "CitizenId",
                table: "Employee",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
