using System.ComponentModel.DataAnnotations.Schema;

namespace OrderData.Models
{
    public class Group
    {
        [Column("gr_id")]
        public int Id { get; set; }
        [Column("gr_name")]
        public string Name { get; set; }
        [Column("gr_temp")]
        public int Temp { get; set; }
    }
}
