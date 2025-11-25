using LabReservasCampusTech.Models;

namespace LabReservasCampusTech.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private static readonly List<Reserva> _reservas = new();

        public IEnumerable<Reserva> GetAll()
        {
            return _reservas.OrderBy(r => r.FechaReserva).ThenBy(r => r.HoraInicio);
        }

        public void Add(Reserva reserva)
        {
            _reservas.Add(reserva);
        }

        public bool CodigoExiste(string codigo)
        {
            return _reservas.Any(r => r.CodigoReserva.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
