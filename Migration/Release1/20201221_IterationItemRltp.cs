using System;
using FluentMigrator;

namespace DbMigration.Release1
{

    [Migration(202012211513)]
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
               .WithColumn("ItemId").AsString().NotNullable()
               .WithColumn("IterationId").AsInt64().NotNullable();
        }
    }
}
