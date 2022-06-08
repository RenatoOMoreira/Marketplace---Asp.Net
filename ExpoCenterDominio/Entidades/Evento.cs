﻿namespace ExpoCenterDominio.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public decimal Preco { get; set; }
        public List<Participante> Participantes { get; set; }
    }
}