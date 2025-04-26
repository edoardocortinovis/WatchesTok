using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchesTok.Models
{
    public class Orologio
    {
        [Key]
        public int OrologioID { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modello { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }  // Nome completo o commerciale dell'orologio

        [StringLength(1000)]
        public string Descrizione { get; set; }

        public decimal? Prezzo { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }  // Sportivo, Dress, Diving, ecc.

        [StringLength(255)]
        public string ImmagineURL { get; set; }

        public int? AnnoProduzione { get; set; }  // Anno di produzione dell'orologio

        public DateTime DataCreazione { get; set; } = DateTime.Now;

        // Proprietà di navigazione per post correlati
        public virtual ICollection<Post> Posts { get; set; }

        // Metodo helper per ottenere il nome completo dell'orologio
        [NotMapped]
        public string NomeCompleto => $"{Marca} {Modello}";
    }
}