using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class EngineerValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerMachine",
                table: "EngineerMachine");

            migrationBuilder.RenameTable(
                name: "EngineerMachine",
                newName: "EngineerMachines");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachine_MachineId",
                table: "EngineerMachines",
                newName: "IX_EngineerMachines_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachine_EngineerId",
                table: "EngineerMachines",
                newName: "IX_EngineerMachines_EngineerId");

            migrationBuilder.UpdateData(
                table: "Engineers",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Engineers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerMachines",
                table: "EngineerMachines",
                column: "EngineerMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachines_Engineers_EngineerId",
                table: "EngineerMachines",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachines_Machines_MachineId",
                table: "EngineerMachines",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachines_Engineers_EngineerId",
                table: "EngineerMachines");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachines_Machines_MachineId",
                table: "EngineerMachines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerMachines",
                table: "EngineerMachines");

            migrationBuilder.RenameTable(
                name: "EngineerMachines",
                newName: "EngineerMachine");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachines_MachineId",
                table: "EngineerMachine",
                newName: "IX_EngineerMachine_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachines_EngineerId",
                table: "EngineerMachine",
                newName: "IX_EngineerMachine_EngineerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Engineers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerMachine",
                table: "EngineerMachine",
                column: "EngineerMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
