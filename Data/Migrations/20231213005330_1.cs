using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCZN.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            

           

            migrationBuilder.DropIndex(
                name: "IX_Сведения_об_образовании_ID_резюме",
                table: "Сведения_об_образовании");

            migrationBuilder.AddColumn<int>(
                name: "ОбразованиеId_образования",
                table: "Сведения_об_образовании",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "РезюмеID_резюме",
                table: "Сведения_об_образовании",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Зарплата",
                table: "Резюме",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Личные_данныеID_личных_данных",
                table: "Заявления",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Форма_занятости",
                table: "График_работы",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_ОбразованиеId_образования",
                table: "Сведения_об_образовании",
                column: "ОбразованиеId_образования");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_РезюмеID_резюме",
                table: "Сведения_об_образовании",
                column: "РезюмеID_резюме");

            migrationBuilder.CreateIndex(
                name: "IX_Резюме_ID_формы_занятости",
                table: "Резюме",
                column: "ID_формы_занятости");

            migrationBuilder.CreateIndex(
                name: "IX_Заявления_Личные_данныеID_личных_данных",
                table: "Заявления",
                column: "Личные_данныеID_личных_данных");

            migrationBuilder.AddForeignKey(
                name: "FK_Заявления_Личные_данные_Личные_данныеID_личных_данных",
                table: "Заявления",
                column: "Личные_данныеID_личных_данных",
                principalTable: "Личные_данные",
                principalColumn: "ID_личных_данных");

            migrationBuilder.AddForeignKey(
                name: "FK_Резюме_График_работы_ID_формы_занятости",
                table: "Резюме",
                column: "ID_формы_занятости",
                principalTable: "График_работы",
                principalColumn: "ID_формы_занятости",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Сведения_об_образовании_Образование_ОбразованиеId_образования",
                table: "Сведения_об_образовании",
                column: "ОбразованиеId_образования",
                principalTable: "Образование",
                principalColumn: "Id_образования",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Сведения_об_образовании_Резюме_РезюмеID_резюме",
                table: "Сведения_об_образовании",
                column: "РезюмеID_резюме",
                principalTable: "Резюме",
                principalColumn: "ID_резюме",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Заявления_Личные_данные_Личные_данныеID_личных_данных",
                table: "Заявления");

            migrationBuilder.DropForeignKey(
                name: "FK_Резюме_График_работы_ID_формы_занятости",
                table: "Резюме");

            migrationBuilder.DropForeignKey(
                name: "FK_Сведения_об_образовании_Образование_ОбразованиеId_образования",
                table: "Сведения_об_образовании");

            migrationBuilder.DropForeignKey(
                name: "FK_Сведения_об_образовании_Резюме_РезюмеID_резюме",
                table: "Сведения_об_образовании");

            migrationBuilder.DropIndex(
                name: "IX_Сведения_об_образовании_ОбразованиеId_образования",
                table: "Сведения_об_образовании");

            migrationBuilder.DropIndex(
                name: "IX_Сведения_об_образовании_РезюмеID_резюме",
                table: "Сведения_об_образовании");

            migrationBuilder.DropIndex(
                name: "IX_Резюме_ID_формы_занятости",
                table: "Резюме");

            migrationBuilder.DropIndex(
                name: "IX_Заявления_Личные_данныеID_личных_данных",
                table: "Заявления");

            migrationBuilder.DropColumn(
                name: "ОбразованиеId_образования",
                table: "Сведения_об_образовании");

            migrationBuilder.DropColumn(
                name: "РезюмеID_резюме",
                table: "Сведения_об_образовании");

            migrationBuilder.DropColumn(
                name: "Личные_данныеID_личных_данных",
                table: "Заявления");

            migrationBuilder.AlterColumn<int>(
                name: "Зарплата",
                table: "Резюме",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Форма_занятости",
                table: "График_работы",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_Id_образования",
                table: "Сведения_об_образовании",
                column: "Id_образования");

            migrationBuilder.CreateIndex(
                name: "IX_Сведения_об_образовании_ID_резюме",
                table: "Сведения_об_образовании",
                column: "ID_резюме");

            migrationBuilder.CreateIndex(
                name: "IX_Заявления_ID_личных_данных",
                table: "Заявления",
                column: "ID_личных_данных");

            migrationBuilder.AddForeignKey(
                name: "FK_Заявления_Личные_данные_ID_личных_данных",
                table: "Заявления",
                column: "ID_личных_данных",
                principalTable: "Личные_данные",
                principalColumn: "ID_личных_данных",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Резюме_График_работы_ID_тип_занятости",
                table: "Резюме",
                column: "ID_тип_занятости",
                principalTable: "График_работы",
                principalColumn: "ID_формы_занятости",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Сведения_об_образовании_Образование_Id_образования",
                table: "Сведения_об_образовании",
                column: "Id_образования",
                principalTable: "Образование",
                principalColumn: "Id_образования");

            migrationBuilder.AddForeignKey(
                name: "FK_Сведения_об_образовании_Резюме_ID_резюме",
                table: "Сведения_об_образовании",
                column: "ID_резюме",
                principalTable: "Резюме",
                principalColumn: "ID_резюме");
        }
    }
}
