using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddNguoiDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_TenDangNhap",
                table: "NguoiDungs",
                column: "TenDangNhap",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDungs");
        }
    }
}
