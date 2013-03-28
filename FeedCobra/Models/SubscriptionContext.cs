using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FeedCobra.Models
{
    public class SubscriptionContext : DbContext
    {
        public SubscriptionContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
    }

    [Table("Feeds")]
    public class Feed
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public string XmlUrl { get; set; }

        public string Type { get; set; }

        public string HtmlUrl { get; set; }
    }

    [Table("Subscriptions")]
    public class Subscription
    {
        [Key]
        public string UserName { get; set; }

        public Feed Feed { get; set; }

        public string Name { get; set; }

        public ICollection<string> Tags { get; set; }
    }

    
    public class RegisterSubscriptionModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        public string Feed { get; set; }
    }
}