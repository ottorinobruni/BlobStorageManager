using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobStorageManager.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlobStorageManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileStorage> FileStorages { get; set; }
    }
}
