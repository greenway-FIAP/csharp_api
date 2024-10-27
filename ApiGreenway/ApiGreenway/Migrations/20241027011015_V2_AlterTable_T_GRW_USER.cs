using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGreenway.Migrations
{
    /// <inheritdoc />
    public partial class V2_AlterTable_T_GRW_USER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ds_uid_fb",
                table: "T_GRW_USER",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ds_uid_fb",
                table: "T_GRW_USER",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);
        }
    }
}
