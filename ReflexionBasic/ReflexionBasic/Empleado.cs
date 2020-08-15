using System;
namespace ReflexionBasic
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public int Legajo { get; set; }

        public Empleado(string nombre, int legajo)
        {
            this.Nombre = nombre;
            this.Legajo = legajo;
        }

        public Empleado() { }

        public abstract double CalcularSalario(int horas);
    }
}
