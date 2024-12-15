using proyectoGymBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoGymBlazor.Services
{
    public class ClaseService
    {
        private readonly List<Clase> _clases;

        public ClaseService()
        {
            // Datos iniciales simulados
            _clases = new List<Clase>
            {
                new Clase { ClaseID = 1, Nombre = "Yoga", Horario = DateTime.Now.AddHours(1), EntrenadorID = 1, Cupo = 20 },
                new Clase { ClaseID = 2, Nombre = "Spinning", Horario = DateTime.Now.AddHours(2), EntrenadorID = 2, Cupo = 15 }
            };
        }

        public List<Clase> GetClases() => _clases;

        public Clase GetClaseById(int id) => _clases.FirstOrDefault(c => c.ClaseID == id);

        public void AddClase(Clase clase) => _clases.Add(clase);

        public void UpdateClase(Clase clase)
        {
            var existingClase = _clases.FirstOrDefault(c => c.ClaseID == clase.ClaseID);
            if (existingClase != null)
            {
                existingClase.Nombre = clase.Nombre;
                existingClase.Horario = clase.Horario;
                existingClase.EntrenadorID = clase.EntrenadorID;
                existingClase.Cupo = clase.Cupo;
            }
        }

        public void DeleteClase(int id) => _clases.RemoveAll(c => c.ClaseID == id);
    }
}

