using System;
using FluentMigrator;

namespace DbMigration.Release1
{

    [Migration(20201231545)]
    public class IterationItemRltpTable : Migration
    {

        public override void Down()
        {
            Delete.Table("IterationItemRltp");
        }

        public override void Up()
        {
            Create.Table("IterationItemRltp")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("IterationId").AsString().NotNullable()
               .WithColumn("ItemId").AsInt64().NotNullable();
        }
    }
}
