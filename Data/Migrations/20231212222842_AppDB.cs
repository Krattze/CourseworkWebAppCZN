using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCZN.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
          

            migrationBuilder.CreateIndex(
                name: "IX_Личные_данные_ID_пола",
                table: "Личные_данные",
                column: "ID_пола");

            migrationBuilder.CreateIndex(
                name: "IX_Опыт_работы_ID_резюме",
                table: "Опыт_работы",
                column: "ID_резюме");

            migrationBuilder.CreateIndex(
                name: "IX_Резюме_ID_заявления",
                table: "Резюме",
                column: "ID_заявления");

            migrationBuilder.CreateIndex(
                name: "IX_Резюме_ID_тип_занятости",
                table: "Резюме",
                column: "ID_тип_занятости");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_о_последнем_месте_работы_ID_заявления",
                table: "Сведения_о_последнем_месте_работы",
                column: "ID_заявления");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_о_последнем_месте_работы_ID_основания_увольнения",
                table: "Сведения_о_последнем_месте_работы",
                column: "ID_основания_увольнения");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_ОбразованиеId_образования",
                table: "Сведения_об_образовании",
                column: "Id_образования");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_ID_резюме",
                table: "Сведения_об_образовании",
                column: "ID_резюме");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Опыт_работы");

            migrationBuilder.DropTable(
                name: "Сведения_о_последнем_месте_работы");

            migrationBuilder.DropTable(
                name: "Сведения_об_образовании");

            migrationBuilder.DropTable(
                name: "Основания_увольнения");

            migrationBuilder.DropTable(
                name: "Образование");

            migrationBuilder.DropTable(
                name: "Резюме");

            migrationBuilder.DropTable(
                name: "График_работы");

            migrationBuilder.DropTable(
                name: "Заявления");

            migrationBuilder.DropTable(
                name: "Тип_занятости");

            migrationBuilder.DropTable(
                name: "Личные_данные");

            migrationBuilder.DropTable(
                name: "Пол");
        }
    }
}
