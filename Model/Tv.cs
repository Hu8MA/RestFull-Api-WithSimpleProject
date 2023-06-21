namespace HomeBiuld.Model
{
    public class Tv:GenaricModel
    {
        public string name_model { get; set; } = "Samsong";
        public float size { get; set; } = 14.5f;
 
        public virtual Room room { get; set; }
    }
}
