using Blog.Core.Contexts.AccountContext.Entities;
using Blog.Core.Contexts.SharedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.Entities
{
    public class Post : Entity
    {
        public Post(string title, string description, DateTime registerDate, bool edit, Guid ownerID)
        {
            Title = title;
            Description = description;
            RegisterDate = registerDate;
            Edit = edit;
            OwnerID = ownerID;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public bool Edit { get; set; }
        public Guid OwnerID { get; private set; }
    }
}
