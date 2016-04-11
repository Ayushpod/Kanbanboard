using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace KabanBoard.Models.POCOs

{
    public class boards
    {
        [Key]
        public int boardID { get; set; }
        [Required]
        public string Title { get; set; }

        public string columnss { get; set; }

        public virtual ICollection<ItemNames> Items { get; set; }
        
    }
}

