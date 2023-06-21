using System.ComponentModel.DataAnnotations;

namespace HomeBiuld.Dto
{
    public class BedDto
    {
        public int Id { get; set; }

        public string Color { get; set; } = "Blue";

        public int numberBody { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
