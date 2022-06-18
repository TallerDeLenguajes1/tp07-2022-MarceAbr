using System;


int cantidadTareas;
string descripcion;

Console.WriteLine("Ingrese la cantidad de tareas a cargar: ");
cantidadTareas = int.Parse(Console.ReadLine());

List<Tarea> listaTareasRealizadas = new List<Tarea>();
List<Tarea> listaTareasPendientes = new List<Tarea>();

Random rand = new Random();
for (int i = 1; i <= cantidadTareas; i++)
{
    Console.WriteLine("Ingrese la descripcion de la tarea " + i + ":");
    descripcion = Console.ReadLine();

    listaTareasPendientes.Add(new Tarea(i, descripcion, rand.Next(10,101)));
}

Console.WriteLine("\n:::Lista Pendientes::: ");
MostrarTareas(listaTareasPendientes);

Console.WriteLine("\nEstados de la/s tareas: ");
MoverATareasRealizadas(listaTareasPendientes,listaTareasRealizadas);

Console.WriteLine("\n=====TAREAS PENDIENTES=====");
MostrarTareas(listaTareasPendientes);

Console.WriteLine("\n=====TAREAS REALIZADAS=====");
MostrarTareas(listaTareasRealizadas);

Console.WriteLine("\nHoras trabajadas: " + CantidadHorasTrabajadas(listaTareasRealizadas));

// ======================================= FUNCIONES =======================================

int CantidadHorasTrabajadas(List<Tarea> listaTareasRealizadas)
{        
    int CantidadHorasTrabajadas = 0;
    foreach (var tarea in listaTareasRealizadas)
    {   
        CantidadHorasTrabajadas += tarea.Duracion; 
    }

    return CantidadHorasTrabajadas;
}

void MostrarTareas(List<Tarea> listaTareas)
{        
    foreach (var tarea in listaTareas)
    {
        Console.WriteLine("Tarea " + tarea.TareaID);
        Console.WriteLine("Descripcion: " + tarea.Descripcion);
        Console.WriteLine("Duracion: " + tarea.Duracion);
    }
}

void MoverATareasRealizadas(List<Tarea> listaTareasPendientes, List<Tarea> listaTareasRealizadas)
{
    int realizada = 0;
    int valor = 0;

    while(valor < listaTareasPendientes.Count){

        do
        {
            Console.WriteLine("Tarea " + listaTareasPendientes[valor].TareaID);
            Console.WriteLine("Descripcion: " + listaTareasPendientes[valor].Descripcion);
            Console.WriteLine("Duracion en horas: " + listaTareasPendientes[valor].Duracion);

            Console.WriteLine("La tarea fue realizada? (1-sí / 0-no)");
            int.TryParse(Console.ReadLine(), out realizada);

        } while (realizada < 0 || realizada > 1);

        if(realizada == 1){
            listaTareasRealizadas.Add(listaTareasPendientes[valor]);
            listaTareasPendientes.RemoveAt(valor);
        } else {
            valor++;
        }
    }
}