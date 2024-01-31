using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migratioms
{
    [Migration(202401302329)]
    public class _202401302329_AddBooksTable : Migration
    {
        public override void Up()
        {
            Create.Table("books")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Genre").AsString(50).NotNullable()
                .WithColumn("Writer").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("books");
        }

    }
}
