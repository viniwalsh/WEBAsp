using System;

namespace Domain.Model.Models
{
    public class PoderEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int HeroiId { get; set; }
        public HeroiEntity Heroi { get; set; }
    }
}
