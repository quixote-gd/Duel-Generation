using FluentMigrator;

namespace DbMigration
{
    /// Every migration needs a unique identifier in the Migration attribute.
    /// This number is interpeted as a long, so we usually use the format of
    /// YYYYMMDDHHMM, the chances of two developers creating a migration at
    /// the same exact minute are very slim.
    [Migration(202012201938)]
    public class CreateCharacterTable : Migration
    {
        /// Up contains the migration code to go forward in time.
        public override void Up()
        {
            Create.Table("Character")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Health").AsInt64().NotNullable()
                .WithColumn("Shield").AsInt64().NotNullable()
                .WithColumn("Magic").AsInt64().NotNullable()
                .WithColumn("Attack").AsInt64().NotNullable()
                .WithColumn("IsBot").AsBoolean().WithDefaultValue(false)
                .WithColumn("Type").AsInt64().NotNullable().Identity();
        }

        /// Down() is the code that is what you would need to do,
        /// to undo the Up migration.
        public override void Down()
        {
            Delete.Table("Character");
        }
    }
}