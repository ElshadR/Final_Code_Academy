using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstRealProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "jobs");

            migrationBuilder.EnsureSchema(
                name: "page");

            migrationBuilder.EnsureSchema(
                name: "real_estate");

            migrationBuilder.EnsureSchema(
                name: "transport");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PinCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceTypes",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Description = table.Column<string>(maxLength: 225, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    Description = table.Column<string>(maxLength: 225, nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    CheckInDate = table.Column<DateTime>(nullable: true),
                    CheckIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAreas",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicMenus",
                schema: "page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentTypes",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseTypes",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeTypes",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RSAnnounceTypes",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSAnnounceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryTypes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoEquipments",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusBodyTypes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusMakes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBodyTypes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarMakes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleBodyTypes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleMakes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeedBoxes",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false),
                    Controller = table.Column<string>(maxLength: 225, nullable: false),
                    Action = table.Column<string>(maxLength: 225, nullable: false),
                    BasicMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_BasicMenus_BasicMenuId",
                        column: x => x.BasicMenuId,
                        principalSchema: "page",
                        principalTable: "BasicMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEquipments",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    BusinessTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_BusinessTypes_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalSchema: "jobs",
                        principalTable: "BusinessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEquipments_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foods_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    ActivityAreaId = table.Column<int>(nullable: false),
                    JobTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_ActivityAreas_ActivityAreaId",
                        column: x => x.ActivityAreaId,
                        principalSchema: "jobs",
                        principalTable: "ActivityAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "jobs",
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    GarageLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Garages_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Garages_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garages_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Garages_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    LandLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lands_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lands_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lands_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lands_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lands_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    RSAnnounceTypeId = table.Column<int>(nullable: false),
                    ApartmentTypeId = table.Column<int>(nullable: false),
                    Area = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    RoomCount = table.Column<byte>(nullable: false),
                    ApartamentLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentTypes_ApartmentTypeId",
                        column: x => x.ApartmentTypeId,
                        principalSchema: "real_estate",
                        principalTable: "ApartmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_RSAnnounceTypes_RSAnnounceTypeId",
                        column: x => x.RSAnnounceTypeId,
                        principalSchema: "real_estate",
                        principalTable: "RSAnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    RSAnnounceTypeId = table.Column<int>(nullable: false),
                    HouseTypeId = table.Column<int>(nullable: false),
                    Area = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    HouseLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_HouseTypes_HouseTypeId",
                        column: x => x.HouseTypeId,
                        principalSchema: "real_estate",
                        principalTable: "HouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_RSAnnounceTypes_RSAnnounceTypeId",
                        column: x => x.RSAnnounceTypeId,
                        principalSchema: "real_estate",
                        principalTable: "RSAnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    RSAnnounceTypeId = table.Column<int>(nullable: false),
                    OfficeTypeId = table.Column<int>(nullable: false),
                    OfficeLocation = table.Column<string>(nullable: false),
                    OfficeArea = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offices_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offices_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offices_OfficeTypes_OfficeTypeId",
                        column: x => x.OfficeTypeId,
                        principalSchema: "real_estate",
                        principalTable: "OfficeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offices_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offices_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offices_RSAnnounceTypes_RSAnnounceTypeId",
                        column: x => x.RSAnnounceTypeId,
                        principalSchema: "real_estate",
                        principalTable: "RSAnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    AccessoryTypeId = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalSchema: "transport",
                        principalTable: "AccessoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessories_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessories_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessories_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessories_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    BusMakeId = table.Column<int>(nullable: false),
                    BusBodyTypeId = table.Column<int>(nullable: false),
                    BusYear = table.Column<int>(nullable: false),
                    BusKilometer = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false),
                    ConditionCredit = table.Column<bool>(nullable: false),
                    ConditionBarter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buses_BusBodyTypes_BusBodyTypeId",
                        column: x => x.BusBodyTypeId,
                        principalSchema: "transport",
                        principalTable: "BusBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buses_BusMakes_BusMakeId",
                        column: x => x.BusMakeId,
                        principalSchema: "transport",
                        principalTable: "BusMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buses_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buses_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 225, nullable: false),
                    CarMakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalSchema: "transport",
                        principalTable: "CarMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motocycle",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    MotocycleModel = table.Column<string>(nullable: false),
                    MotocycleBodyTypeId = table.Column<int>(nullable: false),
                    MotocycleMakeId = table.Column<int>(nullable: false),
                    MotocycleMotor = table.Column<int>(nullable: false),
                    MotocycleYear = table.Column<int>(nullable: false),
                    MotocycleKilometer = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false),
                    ConditionCredit = table.Column<bool>(nullable: false),
                    ConditionBarter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motocycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motocycle_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motocycle_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motocycle_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motocycle_MotocycleBodyTypes_MotocycleBodyTypeId",
                        column: x => x.MotocycleBodyTypeId,
                        principalSchema: "transport",
                        principalTable: "MotocycleBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motocycle_MotocycleMakes_MotocycleMakeId",
                        column: x => x.MotocycleMakeId,
                        principalSchema: "transport",
                        principalTable: "MotocycleMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motocycle_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motocycle_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEPhotos",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    BusinessEquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEPhotos_BusinessEquipments_BusinessEquipmentId",
                        column: x => x.BusinessEquipmentId,
                        principalSchema: "jobs",
                        principalTable: "BusinessEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodPhotos",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    FoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPhotos_Foods_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "jobs",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPhotos",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPhotos_Jobs_JobId",
                        column: x => x.JobId,
                        principalSchema: "jobs",
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaragePhotos",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    GarageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaragePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaragePhotos_Garages_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "real_estate",
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandPhotos",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    LandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandPhotos_Lands_LandId",
                        column: x => x.LandId,
                        principalSchema: "real_estate",
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentPhotos",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    ApartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentPhotos_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "real_estate",
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousePhotos",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousePhotos_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "real_estate",
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficePhotos",
                schema: "real_estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    OfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficePhotos_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "real_estate",
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryPhotos",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    AccessoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoryPhotos_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalSchema: "transport",
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusPhotos",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    BusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusPhotos_Buses_BusId",
                        column: x => x.BusId,
                        principalSchema: "transport",
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnounceName = table.Column<string>(maxLength: 225, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 225, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 225, nullable: false),
                    AnnounceAddedDate = table.Column<DateTime>(nullable: false),
                    AnnounceEndedDate = table.Column<DateTime>(nullable: true),
                    AnnouncePublishDate = table.Column<DateTime>(nullable: true),
                    AnnounceViewCount = table.Column<int>(nullable: false),
                    AnnouncePinCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceUniqueCode = table.Column<string>(maxLength: 225, nullable: true),
                    AnnounceTypeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    AnnouncePublished = table.Column<bool>(nullable: false),
                    AnnounceCheckIn = table.Column<bool>(nullable: false),
                    AnnounceEnded = table.Column<bool>(nullable: false),
                    AppendedPinCode = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    CarModelId = table.Column<int>(nullable: false),
                    CarBodyTypeId = table.Column<int>(nullable: false),
                    SpeedBoxId = table.Column<int>(nullable: false),
                    TransmissionId = table.Column<int>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    CarMotor = table.Column<int>(nullable: false),
                    CarMotorStrength = table.Column<int>(nullable: false),
                    CarYear = table.Column<int>(nullable: false),
                    CarKilometer = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false),
                    ConditionCredit = table.Column<bool>(nullable: false),
                    ConditionBarter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AnnounceTypes_AnnounceTypeId",
                        column: x => x.AnnounceTypeId,
                        principalSchema: "common",
                        principalTable: "AnnounceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarBodyTypes_CarBodyTypeId",
                        column: x => x.CarBodyTypeId,
                        principalSchema: "transport",
                        principalTable: "CarBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalSchema: "transport",
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "page",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalSchema: "transport",
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "common",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "common",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_SpeedBoxes_SpeedBoxId",
                        column: x => x.SpeedBoxId,
                        principalSchema: "transport",
                        principalTable: "SpeedBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalSchema: "transport",
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotocyclePhotos",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    MotocycleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocyclePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotocyclePhotos_Motocycle_MotocycleId",
                        column: x => x.MotocycleId,
                        principalSchema: "transport",
                        principalTable: "Motocycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarAutoEquipments",
                schema: "transport",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    AutoEquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAutoEquipments", x => new { x.CarId, x.AutoEquipmentId });
                    table.ForeignKey(
                        name: "FK_CarAutoEquipments_AutoEquipments_AutoEquipmentId",
                        column: x => x.AutoEquipmentId,
                        principalSchema: "transport",
                        principalTable: "AutoEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAutoEquipments_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "transport",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPhotos",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 225, nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPhotos_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "transport",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEPhotos_BusinessEquipmentId",
                schema: "jobs",
                table: "BusinessEPhotos",
                column: "BusinessEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_AnnounceTypeId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_AppUserId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_BusinessTypeId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_CityId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_PaymentTypeId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEquipments_PersonTypeId",
                schema: "jobs",
                table: "BusinessEquipments",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPhotos_FoodId",
                schema: "jobs",
                table: "FoodPhotos",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_AnnounceTypeId",
                schema: "jobs",
                table: "Foods",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_AppUserId",
                schema: "jobs",
                table: "Foods",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CityId",
                schema: "jobs",
                table: "Foods",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PaymentTypeId",
                schema: "jobs",
                table: "Foods",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PersonTypeId",
                schema: "jobs",
                table: "Foods",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPhotos_JobId",
                schema: "jobs",
                table: "JobPhotos",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ActivityAreaId",
                schema: "jobs",
                table: "Jobs",
                column: "ActivityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AnnounceTypeId",
                schema: "jobs",
                table: "Jobs",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AppUserId",
                schema: "jobs",
                table: "Jobs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityId",
                schema: "jobs",
                table: "Jobs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                schema: "jobs",
                table: "Jobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PaymentTypeId",
                schema: "jobs",
                table: "Jobs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PersonTypeId",
                schema: "jobs",
                table: "Jobs",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BasicMenuId",
                schema: "page",
                table: "Categories",
                column: "BasicMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentPhotos_ApartmentId",
                schema: "real_estate",
                table: "ApartmentPhotos",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AnnounceTypeId",
                schema: "real_estate",
                table: "Apartments",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentTypeId",
                schema: "real_estate",
                table: "Apartments",
                column: "ApartmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AppUserId",
                schema: "real_estate",
                table: "Apartments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CityId",
                schema: "real_estate",
                table: "Apartments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PaymentTypeId",
                schema: "real_estate",
                table: "Apartments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PersonTypeId",
                schema: "real_estate",
                table: "Apartments",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_RSAnnounceTypeId",
                schema: "real_estate",
                table: "Apartments",
                column: "RSAnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaragePhotos_GarageId",
                schema: "real_estate",
                table: "GaragePhotos",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_AnnounceTypeId",
                schema: "real_estate",
                table: "Garages",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_AppUserId",
                schema: "real_estate",
                table: "Garages",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_CityId",
                schema: "real_estate",
                table: "Garages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_PaymentTypeId",
                schema: "real_estate",
                table: "Garages",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_PersonTypeId",
                schema: "real_estate",
                table: "Garages",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HousePhotos_HouseId",
                schema: "real_estate",
                table: "HousePhotos",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AnnounceTypeId",
                schema: "real_estate",
                table: "Houses",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AppUserId",
                schema: "real_estate",
                table: "Houses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityId",
                schema: "real_estate",
                table: "Houses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseTypeId",
                schema: "real_estate",
                table: "Houses",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_PaymentTypeId",
                schema: "real_estate",
                table: "Houses",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_PersonTypeId",
                schema: "real_estate",
                table: "Houses",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RSAnnounceTypeId",
                schema: "real_estate",
                table: "Houses",
                column: "RSAnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandPhotos_LandId",
                schema: "real_estate",
                table: "LandPhotos",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_AnnounceTypeId",
                schema: "real_estate",
                table: "Lands",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_AppUserId",
                schema: "real_estate",
                table: "Lands",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_CityId",
                schema: "real_estate",
                table: "Lands",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_PaymentTypeId",
                schema: "real_estate",
                table: "Lands",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_PersonTypeId",
                schema: "real_estate",
                table: "Lands",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficePhotos_OfficeId",
                schema: "real_estate",
                table: "OfficePhotos",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_AnnounceTypeId",
                schema: "real_estate",
                table: "Offices",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_AppUserId",
                schema: "real_estate",
                table: "Offices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CityId",
                schema: "real_estate",
                table: "Offices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_OfficeTypeId",
                schema: "real_estate",
                table: "Offices",
                column: "OfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_PaymentTypeId",
                schema: "real_estate",
                table: "Offices",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_PersonTypeId",
                schema: "real_estate",
                table: "Offices",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_RSAnnounceTypeId",
                schema: "real_estate",
                table: "Offices",
                column: "RSAnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_AccessoryTypeId",
                schema: "transport",
                table: "Accessories",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_AnnounceTypeId",
                schema: "transport",
                table: "Accessories",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_AppUserId",
                schema: "transport",
                table: "Accessories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_CityId",
                schema: "transport",
                table: "Accessories",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_PaymentTypeId",
                schema: "transport",
                table: "Accessories",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_PersonTypeId",
                schema: "transport",
                table: "Accessories",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryPhotos_AccessoryId",
                schema: "transport",
                table: "AccessoryPhotos",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_AnnounceTypeId",
                schema: "transport",
                table: "Buses",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_AppUserId",
                schema: "transport",
                table: "Buses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusBodyTypeId",
                schema: "transport",
                table: "Buses",
                column: "BusBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusMakeId",
                schema: "transport",
                table: "Buses",
                column: "BusMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_CityId",
                schema: "transport",
                table: "Buses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_PaymentTypeId",
                schema: "transport",
                table: "Buses",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_PersonTypeId",
                schema: "transport",
                table: "Buses",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusPhotos_BusId",
                schema: "transport",
                table: "BusPhotos",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAutoEquipments_AutoEquipmentId",
                schema: "transport",
                table: "CarAutoEquipments",
                column: "AutoEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarMakeId",
                schema: "transport",
                table: "CarModels",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPhotos_CarId",
                schema: "transport",
                table: "CarPhotos",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AnnounceName",
                schema: "transport",
                table: "Cars",
                column: "AnnounceName");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AnnounceTypeId",
                schema: "transport",
                table: "Cars",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AppUserId",
                schema: "transport",
                table: "Cars",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyTypeId",
                schema: "transport",
                table: "Cars",
                column: "CarBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                schema: "transport",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarYear",
                schema: "transport",
                table: "Cars",
                column: "CarYear");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                schema: "transport",
                table: "Cars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                schema: "transport",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PaymentTypeId",
                schema: "transport",
                table: "Cars",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PersonTypeId",
                schema: "transport",
                table: "Cars",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Price",
                schema: "transport",
                table: "Cars",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SpeedBoxId",
                schema: "transport",
                table: "Cars",
                column: "SpeedBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                schema: "transport",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_AnnounceTypeId",
                schema: "transport",
                table: "Motocycle",
                column: "AnnounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_AppUserId",
                schema: "transport",
                table: "Motocycle",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_CityId",
                schema: "transport",
                table: "Motocycle",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_MotocycleBodyTypeId",
                schema: "transport",
                table: "Motocycle",
                column: "MotocycleBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_MotocycleMakeId",
                schema: "transport",
                table: "Motocycle",
                column: "MotocycleMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_PaymentTypeId",
                schema: "transport",
                table: "Motocycle",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocycle_PersonTypeId",
                schema: "transport",
                table: "Motocycle",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MotocyclePhotos_MotocycleId",
                schema: "transport",
                table: "MotocyclePhotos",
                column: "MotocycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Statics");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "common");

            migrationBuilder.DropTable(
                name: "BusinessEPhotos",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "FoodPhotos",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "JobPhotos",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "page");

            migrationBuilder.DropTable(
                name: "ApartmentPhotos",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "GaragePhotos",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "HousePhotos",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "LandPhotos",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "OfficePhotos",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "AccessoryPhotos",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "BusPhotos",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "CarAutoEquipments",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "CarPhotos",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "MotocyclePhotos",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BusinessEquipments",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "Foods",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "BasicMenus",
                schema: "page");

            migrationBuilder.DropTable(
                name: "Apartments",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "Garages",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "Houses",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "Lands",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "Offices",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "Accessories",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Buses",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "AutoEquipments",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Motocycle",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "BusinessTypes",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "ActivityAreas",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "ApartmentTypes",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "HouseTypes",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "OfficeTypes",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "RSAnnounceTypes",
                schema: "real_estate");

            migrationBuilder.DropTable(
                name: "AccessoryTypes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "BusBodyTypes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "BusMakes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "CarBodyTypes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "CarModels",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "FuelTypes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "SpeedBoxes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Transmissions",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "AnnounceTypes",
                schema: "common");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "page");

            migrationBuilder.DropTable(
                name: "MotocycleBodyTypes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "MotocycleMakes",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "PaymentTypes",
                schema: "common");

            migrationBuilder.DropTable(
                name: "PersonTypes",
                schema: "common");

            migrationBuilder.DropTable(
                name: "CarMakes",
                schema: "transport");
        }
    }
}
