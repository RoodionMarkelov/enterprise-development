using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Db.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Doctors",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Passport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                Specialization = table.Column<int>(type: "int", nullable: true),
                WorkExperience = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Doctors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Passport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                BloodGroup = table.Column<int>(type: "int", nullable: true),
                RhFactor = table.Column<int>(type: "int", nullable: true),
                Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Visits",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PatientId = table.Column<int>(type: "int", nullable: false),
                DoctorId = table.Column<int>(type: "int", nullable: false),
                DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                NumberOfCabinet = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                IsAgain = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Visits", x => x.Id);
                table.ForeignKey(
                    name: "FK_Visits_Doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "Doctors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Visits_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.InsertData(
            table: "Doctors",
            columns: new[] { "Id", "Birthday", "Name", "Passport", "Specialization", "WorkExperience" },
            values: new object[,]
            {
                { 1, new DateOnly(1984, 1, 20), "Timofeev Oleg Borisovich", "1223 456782", 0, 10 },
                { 2, new DateOnly(1989, 7, 15), "Ivanova Anna Sergeevna", "1234 567893", 2, 8 },
                { 3, new DateOnly(1979, 3, 8), "Petrov Dmitry Viktorovich", "1345 678904", 1, 15 },
                { 4, new DateOnly(1986, 11, 25), "Sidorova Elena Mikhailovna", "1456 789015", 4, 12 },
                { 5, new DateOnly(1982, 5, 30), "Kozlov Artem Igorevich", "1567 890126", 3, 14 },
                { 6, new DateOnly(1976, 8, 12), "Fedorov Sergey Vasilyevich", "1678 901237", 5, 9 },
                { 7, new DateOnly(1957, 2, 28), "Fedorov Ivan Vasilyevich", "2465 436678", 5, 4 },
                { 8, new DateOnly(1994, 10, 5), "Fedorov Oleg Vasilyevich", "9999 999999", 5, 1 },
                { 9, new DateOnly(1995, 12, 15), "Fedorov Petr Vasilyevich", "6666 666666", 5, 4 },
                { 10, new DateOnly(1996, 4, 3), "Fedorov Kirill Vasilyevich", "7777 777771", 5, 2 }
            });

        migrationBuilder.InsertData(
            table: "Patients",
            columns: new[] { "Id", "Address", "Birthday", "BloodGroup", "Gender", "Name", "Passport", "Phone", "RhFactor" },
            values: new object[,]
            {
                { 1, "Moscow, Sadovaya st., 147, apt. 1", new DateOnly(1989, 5, 15), 0, 0, "Ivanov Petr Sidorovich", "2003 256748", "+79371234567", 0 },
                { 2, "St. Petersburg, Lenina st., 25, apt. 45", new DateOnly(1992, 8, 22), 1, 1, "Petrova Maria Ivanovna", "2015 123456", "+79161234567", 0 },
                { 3, "Novosibirsk, Tsentralnaya st., 10, apt. 12", new DateOnly(1982, 3, 10), 2, 0, "Sidorov Andrey Vladimirovich", "1998 654321", "+79031234567", 1 },
                { 4, "Yekaterinburg, Pushkina st., 33, apt. 78", new DateOnly(1993, 11, 30), 3, 1, "Kuznetsova Elena Sergeevna", "2010 987654", "+79261234567", 0 },
                { 5, "Kazan, Gagarina st., 15, apt. 23", new DateOnly(1999, 7, 5), 0, 0, "Smirnov Alexey Petrovich", "2005 456789", "+79501234567", 1 },
                { 6, "Nizhny Novgorod, Sovetskaya st., 47, apt. 56", new DateOnly(2005, 2, 14), 1, 1, "Vasilyeva Olga Dmitrievna", "2018 321654", "+79991234567", 1 },
                { 7, "Moscow, Tsentralnaya st., 10", new DateOnly(1974, 12, 5), 1, 0, "Nikolaev Viktor Ivanovich", "1975 111111", "+79111111111", 0 },
                { 8, "St. Petersburg, Nevsky pr., 25", new DateOnly(1981, 9, 18), 2, 1, "Orlova Svetlana Petrovna", "1980 222222", "+79222222222", 1 },
                { 9, "St. Petersburg, Nevsky pr., 40", new DateOnly(2004, 4, 25), 1, 0, "Olegov Svetoslav Petrovich", "1742 123575", "+79133546362", 1 },
                { 10, "St. Petersburg, Nevsky pr., 120", new DateOnly(2004, 6, 12), 0, 1, "Revenkova Olga Igorevna", "1980 222223", "+79123456123", 1 }
            });

        migrationBuilder.InsertData(
            table: "Visits",
            columns: new[] { "Id", "DateOfVisit", "DoctorId", "IsAgain", "NumberOfCabinet", "PatientId" },
            values: new object[,]
            {
                { 1, new DateTime(2024, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, false, "101-A", 1 },
                { 2, new DateTime(2024, 1, 17, 14, 15, 0, 0, DateTimeKind.Unspecified), 2, true, "205-B", 2 },
                { 3, new DateTime(2024, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "315-C", 5 },
                { 4, new DateTime(2024, 1, 22, 11, 45, 0, 0, DateTimeKind.Unspecified), 4, false, "112-D", 6 },
                { 5, new DateTime(2024, 1, 13, 16, 20, 0, 0, DateTimeKind.Unspecified), 5, true, "308-E", 3 },
                { 6, new DateTime(2024, 1, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "101-A", 4 },
                { 7, new DateTime(2024, 1, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, false, "101-A", 7 },
                { 8, new DateTime(2024, 1, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 2, true, "205-B", 7 },
                { 9, new DateTime(2024, 1, 5, 15, 45, 0, 0, DateTimeKind.Unspecified), 3, false, "315-C", 8 },
                { 10, new DateTime(2024, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, true, "308-E", 8 },
                { 11, new DateTime(2023, 12, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, true, "101-A", 2 },
                { 12, new DateTime(2024, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "112-D", 2 },
                { 13, new DateTime(2024, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "111-D", 1 },
                { 14, new DateTime(2024, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, false, "121-C", 3 }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Visits_DoctorId",
            table: "Visits",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_Visits_PatientId",
            table: "Visits",
            column: "PatientId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Visits");

        migrationBuilder.DropTable(
            name: "Doctors");

        migrationBuilder.DropTable(
            name: "Patients");
    }
}
