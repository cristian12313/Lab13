using ClassLibrary1;
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary3
{
    internal class EmpleoDA
    {
        private readonly DB_RRHHEntities db;
        public EmpleoDA()
        {
            db = new DB_RRHHEntities();
        }
        public int Registrar(EmpleoBE objEmpleoBE)
        {
            var objEmpleo = new empleo1{ 
                nombre=objEmpleoBE.nombre,
                salario_minimo = objEmpleoBE.salario_minimo,
                salario_maximo = objEmpleoBE.salario_maximo

            };
            db.empleo1.Add(objEmpleo);
            db.SaveChanges();

            return objEmpleo.codigo;
        }
        public List<EmpleoBE> ListarEmpleosNombre(string nombre)
        {
            var query = from emp in db.empleo1
                        where emp.nombre.Contains(nombre)
                        select new EmpleoBE
                        {
                            codigo = emp.codigo,
                            nombre = emp.nombre,
                            salario_minimo = emp.salario_minimo,
                            salario_maximo = emp.salario_maximo
                        };
            return query.ToList();
        }
        public List<EmpleoBE> ListarEmpleosRangoSalario(decimal salario_minimo, decimal salario_maximo)
        {
            var query = from emp in db.empleo1
                        where emp.salario_minimo>= salario_minimo && emp.salario_maximo<=salario_maximo
                        select new EmpleoBE
                        {
                            codigo = emp.codigo,
                            nombre = emp.nombre,
                            salario_minimo = emp.salario_minimo,
                            salario_maximo = emp.salario_maximo
                        };
            return query.ToList();
        }
        public bool Actualizar(EmpleoBE objempleoBE)
        {
            var objEmpleo = (from emp in db.empleo1
                            where emp.codigo.Equals(objempleoBE.codigo)
                            select emp).SingleOrDefault();
            objEmpleo.salario_minimo = objempleoBE.salario_minimo;
            objEmpleo.salario_maximo = objempleoBE.salario_maximo;
            objEmpleo.nombre = objempleoBE.nombre;
            db.SaveChanges();

            return true;
        }
        public bool Eliminar(int codigo)
        {
            var objEmpleo = (from emp in db.empleo1
                             where emp.codigo.Equals(codigo)
                             select emp).SingleOrDefault();
    
            db.SaveChanges();

            return true;
        }
        public EmpleoBE BuscarCodigo(int codigo)
        {
            var objEmpleoBE = (from emp in db.empleo1
                             where emp.codigo.Equals(codigo)
                             select new EmpleoBE
                             {
                                 codigo=emp.codigo,
                                 nombre=emp.nombre,
                                 salario_minimo=emp.salario_minimo,
                                 salario_maximo=emp.salario_maximo
                             }).SingleOrDefault();

            return objEmpleoBE;

        }
    }
}
