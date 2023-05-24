using System.ComponentModel.DataAnnotations.Schema;

namespace OrderData.Models
{
    public class Order
    {
        [Column("ord_id")]
        public int Id { get; set; }
        [Column("ord_datetime")]
        public DateTime Date { get; set; }
        [Column("ord_an")]
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }

    }
}
