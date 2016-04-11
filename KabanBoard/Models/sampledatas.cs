using KabanBoard.Enitity;
using KabanBoard.Models.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KabanBoard.Models
{
    public class sampledatas:System.Data.Entity.DropCreateDatabaseIfModelChanges<KanbanDB>
    {
        protected override void Seed(KanbanDB context)
        {
            var board = new List<boards>
            {
                new boards() { Title = "First" }
            };
            board.ForEach(bo => context.board.Add(bo));
            context.SaveChanges();

            var items = new List<ItemNames>
            {
                new ItemNames() { ItemNameTitle = "check" }
            };
            board.ForEach(bo => context.board.Add(bo));
            context.SaveChanges();

        }
    }
}