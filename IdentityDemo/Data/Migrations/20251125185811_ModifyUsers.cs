using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        CategoryId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.CategoryId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Client",
            //    columns: table => new
            //    {
            //        ClientId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Mobile = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Client", x => x.ClientId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderStatuses",
            //    columns: table => new
            //    {
            //        OrderStatusId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vendors",
            //    columns: table => new
            //    {
            //        VendorId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
            //        Mobile = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        IsBlacklist = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vendors", x => x.VendorId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Photo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        StockQuantity = table.Column<int>(type: "int", nullable: false),
            //        CategoryId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.ProductId);
            //        table.ForeignKey(
            //            name: "FK_Products_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "CategoryId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ClientAddresses",
            //    columns: table => new
            //    {
            //        ClientAddressesId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ClientId = table.Column<int>(type: "int", nullable: false),
            //        Addresses = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        IsDefault = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClientAddresses", x => x.ClientAddressesId);
            //        table.ForeignKey(
            //            name: "FK_ClientAddresses_Client_ClientId",
            //            column: x => x.ClientId,
            //            principalTable: "Client",
            //            principalColumn: "ClientId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        OrderId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ClientId = table.Column<int>(type: "int", nullable: false),
            //        TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OrderStatusId = table.Column<int>(type: "int", nullable: false),
            //        ClientAddressesId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.OrderId);
            //        table.ForeignKey(
            //            name: "FK_Orders_Client_ClientId",
            //            column: x => x.ClientId,
            //            principalTable: "Client",
            //            principalColumn: "ClientId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Orders_OrderStatuses_OrderStatusId",
            //            column: x => x.OrderStatusId,
            //            principalTable: "OrderStatuses",
            //            principalColumn: "OrderStatusId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleUser",
            //    columns: table => new
            //    {
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UserId });
            //        table.ForeignKey(
            //            name: "FK_RoleUser_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_RoleUser_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SupplyOrders",
            //    columns: table => new
            //    {
            //        SupplyOrderId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
            //        SupplyDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        VendorId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SupplyOrders", x => x.SupplyOrderId);
            //        table.ForeignKey(
            //            name: "FK_SupplyOrders_Vendors_VendorId",
            //            column: x => x.VendorId,
            //            principalTable: "Vendors",
            //            principalColumn: "VendorId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItems",
            //    columns: table => new
            //    {
            //        OrderItemId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "OrderId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SupplyOrderDetails",
            //    columns: table => new
            //    {
            //        SupplyOrderDetailId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplyOrderId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        UnitPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
            //        Total = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SupplyOrderDetails", x => x.SupplyOrderDetailId);
            //        table.ForeignKey(
            //            name: "FK_SupplyOrderDetails_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SupplyOrderDetails_SupplyOrders_SupplyOrderId",
            //            column: x => x.SupplyOrderId,
            //            principalTable: "SupplyOrders",
            //            principalColumn: "SupplyOrderId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ClientAddresses_ClientId",
            //    table: "ClientAddresses",
            //    column: "ClientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_OrderId",
            //    table: "OrderItems",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_ProductId",
            //    table: "OrderItems",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ClientId",
            //    table: "Orders",
            //    column: "ClientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_OrderStatusId",
            //    table: "Orders",
            //    column: "OrderStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryId",
            //    table: "Products",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Role__737584F67E52834E",
            //    table: "Roles",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleUser_UserId",
            //    table: "RoleUser",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SupplyOrderDetails_ProductId",
            //    table: "SupplyOrderDetails",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SupplyOrderDetails_SupplyOrderId",
            //    table: "SupplyOrderDetails",
            //    column: "SupplyOrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SupplyOrders_VendorId",
            //    table: "SupplyOrders",
            //    column: "VendorId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__User__A9D105342C3BEA24",
            //    table: "Users",
            //    column: "Email",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ClientAddresses");

            //migrationBuilder.DropTable(
            //    name: "OrderItems");

            //migrationBuilder.DropTable(
            //    name: "RoleUser");

            //migrationBuilder.DropTable(
            //    name: "SupplyOrderDetails");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "SupplyOrders");

            //migrationBuilder.DropTable(
            //    name: "Client");

            //migrationBuilder.DropTable(
            //    name: "OrderStatuses");

            //migrationBuilder.DropTable(
            //    name: "Category");

            //migrationBuilder.DropTable(
            //    name: "Vendors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");
        }
    }
}
