using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SATSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "satsapp");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "satsapp",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    course_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    crea_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "satsapp",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    crea_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                });

            migrationBuilder.InsertData(
                schema: "satsapp",
                table: "Courses",
                columns: new[] { "course_id", "course_description", "course_name", "crea_date", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Description for Course1", "Ozz Akademi1", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2727), false },
                    { 2, "Description for Course2", "Ozz Akademi2", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2733), false }
                });

            migrationBuilder.InsertData(
                schema: "satsapp",
                table: "Students",
                columns: new[] { "student_id", "birth_date", "city", "crea_date", "email", "first_name", "is_deleted", "last_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 25, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2367), "Bartın", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2384), "NazlıÇetin@example.com", "Nazlı", false, "Çetin" },
                    { 2, new DateTime(2022, 8, 25, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2393), "Bayburt", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2396), "BüşraArslan@example.com", "Büşra", false, "Arslan" },
                    { 3, new DateTime(2021, 8, 25, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2399), "Sivas", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2400), "PinarÇakmak@example.com", "Pinar", false, "Çakmak" },
                    { 4, new DateTime(2020, 8, 25, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2403), "Kırşehir", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2406), "CanYavuz@example.com", "Can", false, "Yavuz" },
                    { 5, new DateTime(2019, 8, 26, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2486), "Adana", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2487), "BurakKaraoğlu@example.com", "Burak", false, "Karaoğlu" },
                    { 6, new DateTime(2018, 8, 26, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2496), "Kars", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2499), "EbruKara@example.com", "Ebru", false, "Kara" },
                    { 7, new DateTime(2017, 8, 26, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2503), "Bursa", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2505), "EbruGül@example.com", "Ebru", false, "Gül" },
                    { 8, new DateTime(2016, 8, 26, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2506), "Erzincan", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2509), "ElifKara@example.com", "Elif", false, "Kara" },
                    { 9, new DateTime(2015, 8, 27, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2511), "Ardahan", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2514), "NazlıKaya@example.com", "Nazlı", false, "Kaya" },
                    { 10, new DateTime(2014, 8, 27, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2520), "Ağrı", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2521), "MeryemÇakır@example.com", "Meryem", false, "Çakır" },
                    { 11, new DateTime(2013, 8, 27, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2522), "Adana", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2523), "SibelErdoğan@example.com", "Sibel", false, "Erdoğan" },
                    { 12, new DateTime(2012, 8, 27, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2524), "Kastamonu", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2525), "İsmailKurt@example.com", "İsmail", false, "Kurt" },
                    { 13, new DateTime(2011, 8, 28, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2527), "Yalova", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2528), "EbruÖzkan@example.com", "Ebru", false, "Özkan" },
                    { 14, new DateTime(2010, 8, 28, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2529), "Aydın", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2531), "TolgaKaraoğlu@example.com", "Tolga", false, "Karaoğlu" },
                    { 15, new DateTime(2009, 8, 28, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2532), "Diyarbakır", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2533), "CanerKaya@example.com", "Caner", false, "Kaya" },
                    { 16, new DateTime(2008, 8, 28, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2535), "Konya", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2536), "MustafaAksu@example.com", "Mustafa", false, "Aksu" },
                    { 17, new DateTime(2007, 8, 29, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2538), "Tekirdağ", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2539), "PinarÇelik@example.com", "Pinar", false, "Çelik" },
                    { 18, new DateTime(2006, 8, 29, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2542), "Mersin", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2543), "MuhammedKaraoğlu@example.com", "Muhammed", false, "Karaoğlu" },
                    { 19, new DateTime(2005, 8, 29, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2545), "Kırklareli", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2546), "CengizBozkurt@example.com", "Cengiz", false, "Bozkurt" },
                    { 20, new DateTime(2004, 8, 29, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2547), "Kırklareli", new DateTime(2024, 8, 24, 9, 59, 58, 913, DateTimeKind.Utc).AddTicks(2548), "GamzeUysal@example.com", "Gamze", false, "Uysal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "satsapp");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "satsapp");
        }
    }
}
