using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int Review { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}
