using PSTodos.Infrastructure.Repository.EF;
using System.Data.Entity.Migrations;

namespace PSTodos.Infrastructure.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PSTodosContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PSTodosContext context)
        {
            base.Seed(context);
        }
    }
}
