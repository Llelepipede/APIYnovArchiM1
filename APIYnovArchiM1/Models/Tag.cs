namespace APIYnovArchiM1.Models
{
    public class Tag
    {
        public int ID { get; set; }

        public byte[]? QrCode { get; set; }

        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}