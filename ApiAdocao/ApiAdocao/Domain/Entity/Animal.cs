﻿namespace ApiAdocao.Domain.Entity
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Especie { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int NivelFofura { get; set; }
        public int NivelCarinho { get; set; }
        public string Email { get; set; }
    }
}
