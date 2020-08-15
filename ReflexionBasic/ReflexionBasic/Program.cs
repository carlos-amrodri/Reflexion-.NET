using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflexionBasic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Obtener el ensamblado
            Assembly miEnsamblado = typeof(MainClass).Assembly;
            Console.WriteLine("Datos full de mi ensamblado");
            Console.WriteLine(miEnsamblado.FullName);

            //Accedo a sus metadatos
            AssemblyName nombre = miEnsamblado.GetName();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nLos datos de mi ensamblado");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nEl nombre de mi ensamblado es: {0}", nombre.Name);
            Console.WriteLine("\nLa versión de mi ensamblado es: {0}.{1}", nombre.Version.Major, nombre.Version.Minor);
            //Obtenemos el path
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEl path de mi ensamblado es:");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(miEnsamblado.CodeBase);

            //Módulos
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("\nModulos ---------");
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Module ensambladoModulo = miEnsamblado.GetType().Module;
            //Console.WriteLine("El módulo de mi ensamblado es:" + ensambladoModulo);

            //List<Empleado> empleados = new List<Empleado>();
            //Operario ope1 = new Operario("Pedro", 124);
            //Operario ope2 = new Operario("Alberto", 125);
            //Administrativo admi1 = new Administrativo("Lucia", 567);
            //Administrativo admi2 = new Administrativo("Paula", 568);
            //empleados.Add(ope1);
            //empleados.Add(ope2);
            //empleados.Add(admi1);
            //empleados.Add(admi2);
            //foreach (Empleado empl in empleados)
            //{
            //    Module modEmpl = empl.GetType().Module;
            //    Console.WriteLine("El empleado {0}, se encuentra en el módulo {1}", empl.Nombre, modEmpl);
            //}

            //Type
            Type[] misTipos = miEnsamblado.GetTypes();
            Console.WriteLine("\nListado de tipos (Clases) *******");
            foreach (Type tipo in misTipos)
            {
                Console.WriteLine(tipo.GetTypeInfo());
            }
            Console.WriteLine("\nListado de tipos  Abstractas(Clases) *******");
            foreach (Type tipo in misTipos)
            {
                if (tipo.IsAbstract)
                {
                    Console.WriteLine(tipo.GetTypeInfo());
                }
                
            }

            var objDinamico = miEnsamblado.CreateInstance("ReflexionBasic.Operario");
            Console.WriteLine("El objeto generado es:" + objDinamico.GetType().Name);
            Console.WriteLine("\nLas propiedades de mi objeto son:");
            PropertyInfo[] propiedades = objDinamico.GetType().GetProperties();
            foreach (PropertyInfo prop in propiedades)
            {
                Console.WriteLine("La propiedad: " + prop.Name);
                Console.WriteLine("El tipo es:" + prop.PropertyType);
            }
            Console.WriteLine("\nLos métodos de mi objeto son:");
            MethodInfo[] mismetodos = objDinamico.GetType().GetMethods();
            foreach (MethodInfo met in mismetodos)
            {
                Console.WriteLine("El método es:" + met.Name);
            }

            var metDinamic = objDinamico.GetType().GetMethod("CalcularSalario");
            var salario = metDinamic.Invoke(objDinamico, new object[] { 45 });
            Console.WriteLine("\nEl salrio de nuestro empleado es ${0}", salario);

        }

    }


}
