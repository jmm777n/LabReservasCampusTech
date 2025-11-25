using LabReservasCampusTech.Models;

namespace LabReservasCampusTech.Repositories
{
    public interface IReservaRepository
    {
        IEnumerable<Reserva> GetAll();
        void Add(Reserva reserva);
        bool CodigoExiste(string codigo);
    }
}
