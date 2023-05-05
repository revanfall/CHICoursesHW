using System.ComponentModel.DataAnnotations.Schema;

namespace OrderData.Models
{
    public class Analysis
    {
        [Column("an_id")]
        public int Id { get; set; }
        [Column("an_name")]
        public string Name { get; set; }
        [Column("an_cost")]
        public decimal Cost { get; set; }
        [Column("an_price")]
        public decimal Price { get; set; }
        [Column("an_group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}