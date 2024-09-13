using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGreenway.Migrations
{
    /// <inheritdoc />
    public partial class AttUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_user_type",
                table: "T_GRW_USER",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "id_company_representative",
                table: "T_GRW_USER",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "dt_created_at",
                table: "T_GRW_BADGE",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "dt_finished_at",
                table: "T_GRW_BADGE",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "dt_updated_at",
                table: "T_GRW_BADGE",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dt_created_at",
                table: "T_GRW_BADGE");

            migrationBuilder.DropColumn(
                name: "dt_finished_at",
                table: "T_GRW_BADGE");

            migrationBuilder.DropColumn(
                name: "dt_updated_at",
                table: "T_GRW_BADGE");

            migrationBuilder.AlterColumn<int>(
                name: "id_user_type",
                table: "T_GRW_USER",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_company_representative",
                table: "T_GRW_USER",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);
        }
    }
}
