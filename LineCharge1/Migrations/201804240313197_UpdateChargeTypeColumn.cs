namespace LineCharge1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateChargeTypeColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Charge", name: "ChargeType_ChargeTypeID", newName: "ChargeTypeID");
            RenameIndex(table: "dbo.Charge", name: "IX_ChargeType_ChargeTypeID", newName: "IX_ChargeTypeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Charge", name: "IX_ChargeTypeID", newName: "IX_ChargeType_ChargeTypeID");
            RenameColumn(table: "dbo.Charge", name: "ChargeTypeID", newName: "ChargeType_ChargeTypeID");
        }
    }
}
