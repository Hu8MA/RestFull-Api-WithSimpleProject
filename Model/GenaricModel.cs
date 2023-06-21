using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBiuld.Model
{
    public class GenaricModel
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int id { get; set; }
        public DateTime AddDate { get; set; } 
        public DateTime UpdateDate { get; set; }
        
        
    }
}
