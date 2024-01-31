using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migratioms
{
    [Migration(202401310011)]
    public class _202401310011_AddUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).WithDefaultValue("null").NotNullable()
                .WithColumn("Email").AsString(50).Nullable()
                .WithColumn("CreateAt").AsDateTime().NotNullable();

        }
        public override void Down()
        {
            Delete.Table("users");
        }

    }
}
