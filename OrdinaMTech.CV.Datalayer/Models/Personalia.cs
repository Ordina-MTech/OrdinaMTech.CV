namespace OrdinaMTech.Cv.Data.Models
{
    public class Personalia
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Woonplaats { get; set; }
        public byte[] Foto { get; set; }
        public string Hobbies { get; set; }
    }
}