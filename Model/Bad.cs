namespace HomeBiuld.Model
{
    public class Bad: GenaricModel
    {
        public Bad()
        {
            this.Rooms = new HashSet<Room>();
        }
        public string Color { get; set; } = "Blue";

        public int numberBody { get; set; }
         
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
