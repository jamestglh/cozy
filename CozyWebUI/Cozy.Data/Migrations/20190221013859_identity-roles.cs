using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class identityroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bee8341-e52b-463f-abff-c6628ebb2c27", "08144fda-6274-4da8-b359-9dcee841e11e", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2000e725-9ad2-45f9-94ff-dee719c67bad", "00d0d5a1-e961-4c97-b33b-0a8f53b09487", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2000e725-9ad2-45f9-94ff-dee719c67bad", "00d0d5a1-e961-4c97-b33b-0a8f53b09487" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8bee8341-e52b-463f-abff-c6628ebb2c27", "08144fda-6274-4da8-b359-9dcee841e11e" });
        }
    }
}
