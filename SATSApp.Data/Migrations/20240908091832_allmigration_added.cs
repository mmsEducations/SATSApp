using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SATSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class allmigration_added : Migration
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "satsapp",
                table: "Courses",
                columns: new[] { "course_id", "course_description", "course_name", "crea_date", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Description for Course1", "Ozz Akademi1", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2634), false },
                    { 2, "Description for Course2", "Ozz Akademi2", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2637), false }
                });

            migrationBuilder.InsertData(
                schema: "satsapp",
                table: "Students",
                columns: new[] { "student_id", "birth_date", "city", "crea_date", "email", "first_name", "is_deleted", "last_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 9, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2456), "Sivas", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2468), "VolkanArslan@example.com", "Volkan", false, "Arslan" },
                    { 2, new DateTime(2022, 9, 9, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2471), "Zonguldak", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2472), "MuratAkman@example.com", "Murat", false, "Akman" },
                    { 3, new DateTime(2021, 9, 9, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2473), "Muş", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2473), "BüşraAcar@example.com", "Büşra", false, "Acar" },
                    { 4, new DateTime(2020, 9, 9, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2474), "Denizli", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2474), "CanerYılmaz@example.com", "Caner", false, "Yılmaz" },
                    { 5, new DateTime(2019, 9, 10, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2475), "Kayseri", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2475), "BurakYalçın@example.com", "Burak", false, "Yalçın" },
                    { 6, new DateTime(2018, 9, 10, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2477), "Kastamonu", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2478), "MuhammedGül@example.com", "Muhammed", false, "Gül" },
                    { 7, new DateTime(2017, 9, 10, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2479), "Kars", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2479), "AylinAkman@example.com", "Aylin", false, "Akman" },
                    { 8, new DateTime(2016, 9, 10, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2480), "İstanbul", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2481), "CanYavuz@example.com", "Can", false, "Yavuz" },
                    { 9, new DateTime(2015, 9, 11, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2481), "Ağrı", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2482), "MuhammedKaya@example.com", "Muhammed", false, "Kaya" },
                    { 10, new DateTime(2014, 9, 11, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2483), "Sakarya", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2484), "VolkanArı@example.com", "Volkan", false, "Arı" },
                    { 11, new DateTime(2013, 9, 11, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2484), "Bartın", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2485), "İbrahimKaya@example.com", "İbrahim", false, "Kaya" },
                    { 12, new DateTime(2012, 9, 11, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2485), "Elazığ", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2486), "EbruYurt@example.com", "Ebru", false, "Yurt" },
                    { 13, new DateTime(2011, 9, 12, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2486), "Karabük", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2487), "HakanErdem@example.com", "Hakan", false, "Erdem" },
                    { 14, new DateTime(2010, 9, 12, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2487), "Kilis", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2488), "YasinArı@example.com", "Yasin", false, "Arı" },
                    { 15, new DateTime(2009, 9, 12, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2489), "Şanlıurfa", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2489), "KemalAkman@example.com", "Kemal", false, "Akman" },
                    { 16, new DateTime(2008, 9, 12, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2490), "Amasya", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2490), "NurBozkurt@example.com", "Nur", false, "Bozkurt" },
                    { 17, new DateTime(2007, 9, 13, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2491), "Nevşehir", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2491), "SinanKaya@example.com", "Sinan", false, "Kaya" },
                    { 18, new DateTime(2006, 9, 13, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2493), "Afyonkarahisar", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2493), "AbbasKaya@example.com", "Abbas", false, "Kaya" },
                    { 19, new DateTime(2005, 9, 13, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2494), "İstanbul", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2494), "PinarKurt@example.com", "Pinar", false, "Kurt" },
                    { 20, new DateTime(2004, 9, 13, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2495), "Erzincan", new DateTime(2024, 9, 8, 9, 18, 31, 903, DateTimeKind.Utc).AddTicks(2496), "AbbasArı@example.com", "Abbas", false, "Arı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "satsapp");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "satsapp");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
