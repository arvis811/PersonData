namespace Persons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Person");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Person", newName: "People");
        }
    }
}
