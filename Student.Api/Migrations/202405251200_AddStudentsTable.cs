using FluentMigrator;

[Migration(202405251200)]
public class AddStudentsTable : Migration
{
    public override void Up()
    {
        Create.Table("Students")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Age").AsInt32().NotNullable()
            .WithColumn("Email").AsString(200).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Students");
    }
}
