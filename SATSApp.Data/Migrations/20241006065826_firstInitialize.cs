using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SATSApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstInitialize : Migration
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
                    { 1, "Description for Course1", "Ozz Akademi1", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7938), false },
                    { 2, "Description for Course2", "Ozz Akademi2", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7943), false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4", null, "TestRole", "TESTROLE" });

            migrationBuilder.InsertData(
                schema: "satsapp",
                table: "Students",
                columns: new[] { "student_id", "birth_date", "city", "crea_date", "email", "first_name", "is_deleted", "last_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 7, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7030), "Adıyaman", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7091), "ÖmerKoç@example.com", "Ömer", false, "Koç" },
                    { 2, new DateTime(2022, 10, 7, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7094), "Kayseri", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7095), "AlperKaya@example.com", "Alper", false, "Kaya" },
                    { 3, new DateTime(2021, 10, 7, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7096), "Tokat", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7096), "PinarÖzkan@example.com", "Pinar", false, "Özkan" },
                    { 4, new DateTime(2020, 10, 7, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7097), "Batman", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7098), "KadirÇetin@example.com", "Kadir", false, "Çetin" },
                    { 5, new DateTime(2019, 10, 8, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7100), "Aksaray", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7106), "EnginÇetin@example.com", "Engin", false, "Çetin" },
                    { 6, new DateTime(2018, 10, 8, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7112), "Bingöl", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7112), "EsraKoç@example.com", "Esra", false, "Koç" },
                    { 7, new DateTime(2017, 10, 8, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7113), "Antalya", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7114), "VolkanKaya@example.com", "Volkan", false, "Kaya" },
                    { 8, new DateTime(2016, 10, 8, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7115), "Kars", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7116), "AylinDuman@example.com", "Aylin", false, "Duman" },
                    { 9, new DateTime(2015, 10, 9, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7117), "Ardahan", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7117), "PinarKurt@example.com", "Pinar", false, "Kurt" },
                    { 10, new DateTime(2014, 10, 9, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7119), "Erzurum", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7120), "AbbasDemir@example.com", "Abbas", false, "Demir" },
                    { 11, new DateTime(2013, 10, 9, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7121), "Diyarbakır", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7121), "HaticeÖzkan@example.com", "Hatice", false, "Özkan" },
                    { 12, new DateTime(2012, 10, 9, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7122), "İstanbul", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7122), "ŞirinYavuz@example.com", "Şirin", false, "Yavuz" },
                    { 13, new DateTime(2011, 10, 10, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7123), "Iğdır", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7125), "SevgiYavuz@example.com", "Sevgi", false, "Yavuz" },
                    { 14, new DateTime(2010, 10, 10, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7126), "Kütahya", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7126), "MeryemYalçın@example.com", "Meryem", false, "Yalçın" },
                    { 15, new DateTime(2009, 10, 10, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7127), "Bartın", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7128), "HakanEkinci@example.com", "Hakan", false, "Ekinci" },
                    { 16, new DateTime(2008, 10, 10, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7128), "Gümüşhane", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7129), "TolgaÇetin@example.com", "Tolga", false, "Çetin" },
                    { 17, new DateTime(2007, 10, 11, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7129), "Ankara", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7130), "BarışÖzkan@example.com", "Barış", false, "Özkan" },
                    { 18, new DateTime(2006, 10, 11, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7132), "Şırnak", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7132), "MuratÇetin@example.com", "Murat", false, "Çetin" },
                    { 19, new DateTime(2005, 10, 11, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7133), "Osmaniye", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7133), "OrhanToprak@example.com", "Orhan", false, "Toprak" },
                    { 20, new DateTime(2004, 10, 11, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7134), "Afyonkarahisar", new DateTime(2024, 10, 6, 6, 58, 24, 637, DateTimeKind.Utc).AddTicks(7134), "EmineÇelik@example.com", "Emine", false, "Çelik" }
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
