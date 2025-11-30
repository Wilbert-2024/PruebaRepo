using System.ComponentModel.DataAnnotations;

namespace MartinWilbert.Models
{
    public class Laboratorio
    {
        public int Id { get; set; }

       
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        public string dias_ocupado { get; set; }

        public string horas_ocupado { get; set; }



        public ICollection<ReservaLaboratorio> Reservas { get; set; }

    }
}
