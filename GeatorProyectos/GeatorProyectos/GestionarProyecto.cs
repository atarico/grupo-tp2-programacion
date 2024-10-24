public class GestorProyectos
{
    private List<Proyecto> proyectos = new List<Proyecto>();
    private string archivoProyectos = "proyectos.txt";


    public void AgregarProyecto(Proyecto proyecto)
    {
        proyectos.Add(proyecto);
        Console.WriteLine("Proyecto agregado exitosamente.");
    }

    public void MostrarProyectos()
    {
        foreach (var proyecto in proyectos)
        {
            proyecto.MostrarDetalles();
        }
    }
    public void ModificarProyecto(string nombre)
    {
        Proyecto proyecto = proyectos.Find(p => p.Nombre == nombre);
        if (proyecto != null)
        {
            Console.WriteLine("Modificar Estado: ");
            Console.WriteLine("Ingrese el estado del proyecto (0- Planificacion, 1- EnDesarrollo, 2- EnPruebas, 3- Completado, 4- Cancelado): ");
            proyecto.Estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
            Console.WriteLine("Proyecto modificado.");
        }
        else
        {
            Console.WriteLine("Proyecto no encontrado.");
        }
    }

    public void EliminarProyecto(string nombre)
    {
        Proyecto proyecto = proyectos.Find(p => p.Nombre == nombre);
        if (proyecto != null)
        {
            proyectos.Remove(proyecto);
            Console.WriteLine("Proyecto eliminado.");
        }
        else
        {
            Console.WriteLine("Proyecto no encontrado.");
        }
    }
    public void GuardarCambios()
    {
        using (StreamWriter writer = new StreamWriter(archivoProyectos))
        {
            foreach (var proyecto in proyectos)
            {
                if (proyecto is ProyectoWeb web)
                {
                    writer.WriteLine($"Web,{web.Nombre},{web.Estado},{web.CantidadDesarrolladores},{web.FechaInicio},{web.Tecnologia}");
                }
                else if (proyecto is ProyectoMovil movil)
                {
                    writer.WriteLine($"Movil,{movil.Nombre},{movil.Estado},{movil.CantidadDesarrolladores},{movil.FechaInicio},{string.Join(";", movil.PlataformasObjetivo)}");
                }
            }
        }
        Console.WriteLine("Proyectos guardados.");
    }
    public void CargarProyectos()
    {
        if (File.Exists(archivoProyectos))
        {
            using (StreamReader reader = new StreamReader(archivoProyectos))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    var datos = linea.Split(',');
                    string tipo = datos[0];
                    string nombre = datos[1];
                    EstadoProyecto estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), datos[2]);
                    int cantidadDesarrolladores = int.Parse(datos[3]);
                    DateTime fechaInicio = DateTime.Parse(datos[4]);

                    if (tipo == "Web")
                    {
                        string tecnologiaPrincipal = datos[5];
                        ProyectoWeb web = new ProyectoWeb(nombre, estado, cantidadDesarrolladores, fechaInicio, tecnologiaPrincipal);
                        proyectos.Add(web);
                    }
                    else if (tipo == "Movil")
                    {
                        List<string> plataformasObjetivo = new List<string>(datos[5].Split(';'));
                        ProyectoMovil movil = new ProyectoMovil(nombre, estado, cantidadDesarrolladores, fechaInicio, plataformasObjetivo);
                        proyectos.Add(movil);
                    }
                }
            }
        }
    }
}
