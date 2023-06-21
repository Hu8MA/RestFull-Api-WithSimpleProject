using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBiuld.Dto
{
    public class RoomDto
    {
        public int Id { get; set; } = 0;

        public float size { get; set; } = 25.5f;

        public float price { get; set; } = 100.10f;

        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
