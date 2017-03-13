namespace Data.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SwanDbEntities : DbContext
    {
        public SwanDbEntities()
            : base("name=SwanDbEntities")
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}