using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBiuld.Model
{
    public class Room:GenaricModel
    {
    
        public float size { get; set; } = 25.5f;

        public float price { get; set; } = 100.10f;
  
        public virtual Tv Tv { get; set; }
          
        public virtual  Bad  Bad { get; set; }
    }
}
