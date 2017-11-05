namespace BankOfBIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedures : DbMigration
    {
        //Modified as per requirements
        public override void Up()
        {
            //Calling script to re-create the stored procedure
            this.Sql(Properties.Resources.create_next_number);
        }
        
        public override void Down()
        {
            //Calling the script to drop the procedure
            this.Sql(Properties.Resources.drop_next_number);
        }
    }
}
