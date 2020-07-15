using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FLA.Data.Migrations
{
    public partial class FLAData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    OrderEntry = table.Column<bool>(nullable: false),
                    DriverApp = table.Column<bool>(nullable: false),
                    Availability = table.Column<bool>(nullable: false),
                    SMSUpdate = table.Column<bool>(nullable: false),
                    QuickBooks = table.Column<bool>(nullable: false),
                    EDI = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerTrackings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    DispatchId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AllowsBilling = table.Column<bool>(nullable: false),
                    AllowsShipping = table.Column<bool>(nullable: false),
                    TwoLetterIsoCode = table.Column<string>(nullable: true),
                    ThreeLetterIsoCode = table.Column<string>(nullable: true),
                    NumericIsoCode = table.Column<long>(nullable: false),
                    SubjectToVat = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispatches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainersId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    DateTimeAssigned = table.Column<DateTime>(nullable: true),
                    SegmentTypeId = table.Column<long>(nullable: false),
                    PickupDeliveryId = table.Column<long>(nullable: false),
                    DropLocationId = table.Column<long>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    ApptDate = table.Column<DateTime>(nullable: true),
                    ApptTime = table.Column<string>(nullable: true),
                    ApptNumber = table.Column<string>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: true),
                    LoadStatus = table.Column<long>(nullable: false),
                    LoadMoney = table.Column<double>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverDispachDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<long>(nullable: false),
                    ContainerNo = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: false),
                    DispatchId = table.Column<long>(nullable: false),
                    PU = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    DriverNotes = table.Column<string>(nullable: true),
                    InvoiceNotes = table.Column<string>(nullable: true),
                    Check = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverDispachDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorsCompany = table.Column<string>(nullable: true),
                    FactorAddress1 = table.Column<string>(nullable: true),
                    FactorAddress2 = table.Column<string>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    FactorCity = table.Column<string>(nullable: true),
                    FactorState = table.Column<long>(nullable: false),
                    FactorZipCode = table.Column<string>(nullable: true),
                    FactorPhoneNumber = table.Column<string>(nullable: true),
                    FactorFaxNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormNames",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    MessageTime = table.Column<DateTime>(nullable: false),
                    ReadTime = table.Column<DateTime>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    MediaType = table.Column<long>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    ContainerNo = table.Column<string>(nullable: true),
                    OrderHeader = table.Column<bool>(nullable: false),
                    SenderTypeId = table.Column<long>(nullable: false),
                    SenderType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<long>(nullable: false),
                    DeliveryID = table.Column<long>(nullable: false),
                    PickupID = table.Column<long>(nullable: false),
                    BillToID = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    ReturnLocationID = table.Column<long>(nullable: false),
                    SalesRepID = table.Column<long>(nullable: true),
                    SalesPersonId = table.Column<long>(nullable: true),
                    OrderStatusId = table.Column<long>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    Import_ExportId = table.Column<long>(nullable: false),
                    Import_ExportStatus = table.Column<int>(nullable: false),
                    BillofLading = table.Column<string>(nullable: true),
                    BookingNumber = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    BrokerRefNumber = table.Column<string>(nullable: true),
                    InvoiceNotes = table.Column<string>(nullable: true),
                    InvoiceExceptionFlag = table.Column<bool>(nullable: false),
                    ReturnPickup = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOnDescription = table.Column<string>(nullable: true),
                    PayAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormNameId = table.Column<long>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    Modify = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<long>(nullable: false),
                    ZipCode = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPeople",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SegmentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    TerminationFlag = table.Column<bool>(nullable: false),
                    OrderSequence = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    FLACode = table.Column<string>(nullable: true),
                    EIDCode = table.Column<string>(nullable: true),
                    DropdownUse = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TwilioCredentials",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountSid = table.Column<string>(nullable: true),
                    AuthToken = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ShaKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwilioCredentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateProvinces",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<long>(nullable: false),
                    IsSenderDeleted = table.Column<bool>(nullable: false),
                    IsReceiverDeleted = table.Column<bool>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    IsRecieved = table.Column<bool>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    ContainerNo = table.Column<string>(nullable: true),
                    OrderHeader = table.Column<bool>(nullable: false),
                    SenderTypeId = table.Column<long>(nullable: false),
                    SenderType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chassis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalCompanyId = table.Column<long>(nullable: false),
                    ChassisNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chassis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chassis_RentalCompanies_RentalCompanyId",
                        column: x => x.RentalCompanyId,
                        principalTable: "RentalCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoleMappings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoleMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionRoleMappings_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoleMappings_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLoginGuid = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LoggedIn = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    TimeOutDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastIpAddress = table.Column<string>(nullable: true),
                    IsSystemAccount = table.Column<bool>(nullable: false),
                    SystemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    SizeId = table.Column<long>(nullable: true),
                    ContainerNumber = table.Column<string>(nullable: true),
                    ChassisId = table.Column<long>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    SealNumber = table.Column<string>(nullable: true),
                    Temperature = table.Column<long>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    POPChassisFlag = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Containers_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillTo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    TermsId = table.Column<long>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    InvoiceEmailAddress = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Factor = table.Column<bool>(nullable: false),
                    EDI = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    InvoicePreferenceId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    invoicePreference = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillTo_StateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "StateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    StartingDriverCodeNumber = table.Column<string>(nullable: true),
                    StartingOrderNumber = table.Column<string>(nullable: true),
                    CompanyImage = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    ClientPermissionsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientPermissions_ClientPermissionsId",
                        column: x => x.ClientPermissionsId,
                        principalTable: "ClientPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_StateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "StateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverTypeId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DriverCode = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    SmartPhoneFlag = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    DateStarted = table.Column<DateTime>(nullable: true),
                    DateLeft = table.Column<DateTime>(nullable: true),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyPhoneNumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    StatusFlag = table.Column<bool>(nullable: false),
                    DriverLicenseNumber = table.Column<string>(nullable: true),
                    DriverLicenseExpiry = table.Column<DateTime>(nullable: true),
                    MedicalCard = table.Column<string>(nullable: true),
                    MedicalCardExpiry = table.Column<DateTime>(nullable: true),
                    TractorLicense = table.Column<string>(nullable: true),
                    VINNumber = table.Column<string>(nullable: true),
                    EINNumber = table.Column<string>(nullable: true),
                    TruckMake = table.Column<string>(nullable: true),
                    TruckInspectionDate = table.Column<DateTime>(nullable: true),
                    CHPInspectionDate = table.Column<DateTime>(nullable: true),
                    SmokeCheckDate = table.Column<DateTime>(nullable: true),
                    CompanyInsuredFlag = table.Column<bool>(nullable: false),
                    DriverLiabilityInsuranceNumber = table.Column<string>(nullable: true),
                    DriverLiabilityExpiry = table.Column<DateTime>(nullable: true),
                    OccInsuranceStartDate = table.Column<DateTime>(nullable: true),
                    OccInsuranceEndDate = table.Column<DateTime>(nullable: true),
                    LiabilityInsuranceStartDate = table.Column<DateTime>(nullable: true),
                    LiabilityInsuranceEndDate = table.Column<DateTime>(nullable: true),
                    TruckOwnerFirstName = table.Column<string>(nullable: true),
                    TruckOwnerLastName = table.Column<string>(nullable: true),
                    TruckOwnerPhoneNumber = table.Column<string>(nullable: true),
                    DMVDateAdd = table.Column<DateTime>(nullable: true),
                    DMVDateDelete = table.Column<DateTime>(nullable: true),
                    ClassALicenseFlag = table.Column<bool>(nullable: false),
                    HazardousLicenseFlag = table.Column<bool>(nullable: false),
                    TankerLicenseFlag = table.Column<bool>(nullable: false),
                    TriplesLicenseFlag = table.Column<bool>(nullable: false),
                    DoublesLicenseFlag = table.Column<bool>(nullable: false),
                    TwicCardExpiry = table.Column<DateTime>(nullable: true),
                    TruckRegDate = table.Column<DateTime>(nullable: true),
                    ApportionedPlatesExpiry = table.Column<DateTime>(nullable: true),
                    RFIDNumber = table.Column<string>(nullable: true),
                    LeaseDateExpiry = table.Column<DateTime>(nullable: true),
                    PDTRLB = table.Column<DateTime>(nullable: true),
                    PDTRLA = table.Column<DateTime>(nullable: true),
                    EmodalFlag = table.Column<bool>(nullable: false),
                    UIIAFlag = table.Column<bool>(nullable: false),
                    ARBFlag = table.Column<bool>(nullable: false),
                    FuelCardNumber = table.Column<string>(nullable: true),
                    ActiveDriver = table.Column<bool>(nullable: false),
                    InsurenceExpiry = table.Column<DateTime>(nullable: true),
                    UserLogID = table.Column<long>(nullable: false),
                    Owner_Company_Driver = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    OperatorType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_StateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "StateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PickupDeliveries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    PortsId = table.Column<long>(nullable: true),
                    Port = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupDeliveries_StateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "StateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvinceId = table.Column<long>(nullable: true),
                    PortZipCode = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CheckPort = table.Column<bool>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false),
                    WebsiteURL = table.Column<string>(nullable: true),
                    PortLoginFlag = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ports_StateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "StateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainersId = table.Column<long>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    LastFreeDay = table.Column<DateTime>(nullable: true),
                    FirstDayAvailable = table.Column<DateTime>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    ETA = table.Column<DateTime>(nullable: true),
                    LastChecked = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TMF = table.Column<bool>(nullable: false),
                    FreightSSLHold = table.Column<bool>(nullable: false),
                    CustomsHold = table.Column<bool>(nullable: false),
                    USDAHold = table.Column<bool>(nullable: false),
                    FDAHold = table.Column<bool>(nullable: false),
                    HazmatHold = table.Column<bool>(nullable: false),
                    TerminalHold = table.Column<bool>(nullable: false),
                    StorageChargesHold = table.Column<bool>(nullable: false),
                    ExtraHold = table.Column<bool>(nullable: false),
                    XrayHold = table.Column<bool>(nullable: false),
                    FeeDueHold = table.Column<bool>(nullable: false),
                    TotalFees = table.Column<decimal>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CutOffDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Containers_ContainersId",
                        column: x => x.ContainersId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillToContacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    BillToId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailNotification = table.Column<bool>(nullable: false),
                    SMSNotification = table.Column<bool>(nullable: false),
                    ActiveFlag = table.Column<bool>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillToContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillToContacts_BillTo_BillToId",
                        column: x => x.BillToId,
                        principalTable: "BillTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugScreens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<long>(nullable: false),
                    ScreenDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    PassFlag = table.Column<bool>(nullable: false),
                    FailFlag = table.Column<bool>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    InvoiceAmt = table.Column<decimal>(nullable: false),
                    ScreenTypeId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    ScreenType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugScreens_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruckInspections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<long>(nullable: false),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    PassFlag = table.Column<bool>(nullable: false),
                    FailFlag = table.Column<bool>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    InvoiceAmt = table.Column<decimal>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckInspections_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickupDeliveryContacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    PickupDeliveryId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailNotification = table.Column<bool>(nullable: false),
                    SMSNotification = table.Column<bool>(nullable: false),
                    ActiveFlag = table.Column<bool>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupDeliveryContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupDeliveryContacts_PickupDeliveries_PickupDeliveryId",
                        column: x => x.PickupDeliveryId,
                        principalTable: "PickupDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortsId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortLogins_Ports_PortsId",
                        column: x => x.PortsId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProofOfDeliveries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(nullable: true),
                    SignatureImg = table.Column<byte[]>(nullable: true),
                    ReceiveDate = table.Column<DateTime>(nullable: true),
                    DispatchId = table.Column<long>(nullable: false),
                    PickupDeliveryContactsId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProofOfDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProofOfDeliveries_Dispatches_DispatchId",
                        column: x => x.DispatchId,
                        principalTable: "Dispatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProofOfDeliveries_PickupDeliveryContacts_PickupDeliveryContactsId",
                        column: x => x.PickupDeliveryContactsId,
                        principalTable: "PickupDeliveryContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_ContainersId",
                table: "Availabilities",
                column: "ContainersId");

            migrationBuilder.CreateIndex(
                name: "IX_BillTo_StateProvinceId",
                table: "BillTo",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillToContacts_BillToId",
                table: "BillToContacts",
                column: "BillToId");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_RentalCompanyId",
                table: "Chassis",
                column: "RentalCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_MessageId",
                table: "ChatMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientPermissionsId",
                table: "Clients",
                column: "ClientPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StateProvinceId",
                table: "Clients",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_OrderId",
                table: "Containers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_SizeId",
                table: "Containers",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_StateProvinceId",
                table: "Drivers",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugScreens_DriverId",
                table: "DrugScreens",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoleMappings_PermissionId",
                table: "PermissionRoleMappings",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoleMappings_RoleId",
                table: "PermissionRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupDeliveries_StateProvinceId",
                table: "PickupDeliveries",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupDeliveryContacts_PickupDeliveryId",
                table: "PickupDeliveryContacts",
                column: "PickupDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLogins_PortsId",
                table: "PortLogins",
                column: "PortsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_StateProvinceId",
                table: "Ports",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProofOfDeliveries_DispatchId",
                table: "ProofOfDeliveries",
                column: "DispatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProofOfDeliveries_PickupDeliveryContactsId",
                table: "ProofOfDeliveries",
                column: "PickupDeliveryContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvinces_CountryId",
                table: "StateProvinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspections_DriverId",
                table: "TruckInspections",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_RoleId",
                table: "UserLogins",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "BillToContacts");

            migrationBuilder.DropTable(
                name: "Chassis");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ContainerTrackings");

            migrationBuilder.DropTable(
                name: "DriverDispachDetails");

            migrationBuilder.DropTable(
                name: "DriverLogins");

            migrationBuilder.DropTable(
                name: "DrugScreens");

            migrationBuilder.DropTable(
                name: "FactorCompanies");

            migrationBuilder.DropTable(
                name: "FormNames");

            migrationBuilder.DropTable(
                name: "PayTypes");

            migrationBuilder.DropTable(
                name: "PermissionRoleMappings");

            migrationBuilder.DropTable(
                name: "PortLogins");

            migrationBuilder.DropTable(
                name: "ProofOfDeliveries");

            migrationBuilder.DropTable(
                name: "SalesPeople");

            migrationBuilder.DropTable(
                name: "SegmentTypes");

            migrationBuilder.DropTable(
                name: "TruckInspections");

            migrationBuilder.DropTable(
                name: "TwilioCredentials");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "BillTo");

            migrationBuilder.DropTable(
                name: "RentalCompanies");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ClientPermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Dispatches");

            migrationBuilder.DropTable(
                name: "PickupDeliveryContacts");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "PickupDeliveries");

            migrationBuilder.DropTable(
                name: "StateProvinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
