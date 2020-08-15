using System;
namespace ReflexionBasic
{
    public class Administrativo : Empleado
    {
        private int baseHora = 500;

        public Administrativo(string nombre, int legajo):base(nombre,legajo)
        {
        }
        public Administrativo() { }

        public override double CalcularSalario(int horas)
        {
            return baseHora * horas;
        }
    }
}
