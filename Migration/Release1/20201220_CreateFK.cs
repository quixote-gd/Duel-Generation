using FluentMigrator;

namespace DbMigration
{
    /// Every migration needs a unique identifier in the Migration attribute.
    /// This number is interpeted as a long, so we usually use the format of
    /// YYYYMMDDHHMM, the chances of two developers creating a migration at
    /// the same exact minute are very slim.
    [Migration(202012202020)]
    public class CreateFK : Migration
    {
        /// Up contains the migration code to go forward in time.
        public override void Up()
        {

            Create.ForeignKey("fkCharacterType")
                .FromTable("Character")
                .ForeignColumn("Type")
                .ToTable("CharacterTypeTable")
                .PrimaryColumn("Id");

            Create.ForeignKey("fkItemType")
               .FromTable("Item")
               .ForeignColumn("Type")
               .ToTable("ItemTypeTable")
               .PrimaryColumn("Id");

        }

        /// Down() is the code that is what you would need to do,
        /// to undo the Up migration.
        public override void Down()
        {
            Delete.ForeignKey("fkCharacterType").OnTable("Character");
            Delete.ForeignKey("fkItemType").OnTable("Item");
        }
    }
}