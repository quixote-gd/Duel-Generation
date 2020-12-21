using FluentMigrator;

namespace DbMigration
{
    /// Every migration needs a unique identifier in the Migration attribute.
    /// This number is interpeted as a long, so we usually use the format of
    /// YYYYMMDDHHMM, the chances of two developers creating a migration at
    /// the same exact minute are very slim.
    [Migration(202012201920)]
    public class CreateCharacterType: Migration
    {
        /// Up contains the migration code to go forward in time.
        public override void Up()
        {
            Create.Table("CharacterTypeTable")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Code").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsInt64().NotNullable();
        }

        /// Down() is the code that is what you would need to do,
        /// to undo the Up migration.
        public override void Down()
        {
            Delete.Table("CharacterTypeTable");
        }
    }
}