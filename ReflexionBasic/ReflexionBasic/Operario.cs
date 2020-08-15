using System;
namespace ReflexionBasic
{
    public class Operario : Empleado
    {
        private int baseHora = 580;
        private double premio = 0.1;

        public Operario(string nombre, int legajo) : base(nombre, legajo)
        {
        }

       public Operario() { }

        public override double CalcularSalario(int horas)
        {
            return (baseHora * horas) * premio ;
        }
    }
}
