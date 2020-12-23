using System;
using FluentMigrator;

namespace DbMigration.Release1
{

    [Migration(202012211513)]
    public class IterationCharacterRltpTable : Migration
    {

        public override void Down()
        {
            Delete.Table("IterationCharacterRltp");
        }

        public override void Up()
        {
            Create.Table("IterationCharacterRltp")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("CharacterId").AsString().NotNullable()
               .WithColumn("IterationId").AsInt64().NotNullable();
        }
    }
}
