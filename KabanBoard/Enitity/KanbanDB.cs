namespace KabanBoard.Enitity
{
    using Models.POCOs;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KanbanDB : DbContext
    {
        // Your context has been configured to use a 'KanbanDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KabanBoard.Enitity.KanbanDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KanbanDB' 
        // connection string in the application configuration file.
        public KanbanDB()
            : base("name=KanbanDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<boards> board { get; set; }
        public DbSet<ItemNames> itemnames { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}