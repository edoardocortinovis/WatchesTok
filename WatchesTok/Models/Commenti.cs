using System.ComponentModel.DataAnnotations;

namespace WatchesTok.Models
{
    public class Commenti
    {
        [Key]
        public int CommentiID { get; set; }

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UtenteId { get; set; }
        public Utente Utente { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
