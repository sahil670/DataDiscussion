using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataDiscussion.Model;

namespace DataDiscussion.Data
{
    public class DataDiscussionContext : DbContext
    {
        public DataDiscussionContext (DbContextOptions<DataDiscussionContext> options)
            : base(options)
        {
        }

        public DbSet<DataDiscussion.Model.Message> Message { get; set; }
    }
}
