using System;
using Microsoft.AspNetCore.Mvc;

namespace Application.ViewModels
{
    public class PoderViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int HeroiId { get; set; }
        public HeroiViewModel Heroi { get; set; }
    }
}
