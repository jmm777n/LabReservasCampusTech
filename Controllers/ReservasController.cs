using LabReservasCampusTech.Models;
using LabReservasCampusTech.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LabReservasCampusTech.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservasController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public IActionResult Index()
        {
            var reservas = _reservaRepository.GetAll();
            return View(reservas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CargarLaboratorios();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            CargarLaboratorios();


            if (reserva.FechaReserva.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(Reserva.FechaReserva), "La fecha de la reserva no puede ser en el pasado.");
            }

            if (reserva.HoraFin <= reserva.HoraInicio)
            {
                ModelState.AddModelError(nameof(Reserva.HoraFin), "La hora de fin debe ser mayor que la hora de inicio.");
            }

            if (string.IsNullOrWhiteSpace(reserva.Laboratorio) || reserva.Laboratorio == "Seleccione")
            {
                ModelState.AddModelError(nameof(Reserva.Laboratorio), "Debe seleccionar un laboratorio válido.");
            }

            if (_reservaRepository.CodigoExiste(reserva.CodigoReserva))
            {
                ModelState.AddModelError(nameof(Reserva.CodigoReserva), "El código de reserva ya existe, debe ser único.");
            }

            if (!ModelState.IsValid)
            {
                return View(reserva);
            }

            _reservaRepository.Add(reserva);
            return RedirectToAction(nameof(Index));
        }

        private void CargarLaboratorios()
        {
            ViewBag.Laboratorios = new List<string>
            {
                "Seleccione",
                "Lab-01",
                "Lab-02",
                "Lab-03",
                "Lab-Redes",
                "Lab-IA"
            };
        }
    }
}
