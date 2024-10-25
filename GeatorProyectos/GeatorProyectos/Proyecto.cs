using GeatorProyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Proyecto
{
    public string Nombre { get; set; }
    public EstadoProyecto Estado { get; set; }
    public int CantidadDesarrolladores { get; set; }
    public DateTime FechaInicio { get; set; }

    public Proyecto(string nombre, EstadoProyecto estado, int cantidadDesarrolladores, DateTime fechaInicio)
    {
        Nombre = nombre;
        Estado = estado;
        CantidadDesarrolladores = cantidadDesarrolladores;
        FechaInicio = fechaInicio;
    }

    public abstract double CalcularDuracionEstimada();

    public abstract void MostrarDetalles();

    esteban
}


