using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queries
{
    public static class AlumnoQBLL
    {

        //QBLL Query Bussiness Logic Layer
        public static List<Alumno> GetAlumnos()
        {
            Entities db = new Entities(); //Instancia del Contexto

            /*List<Alumno> alumnos = db.Alumnoes.ToList();
            List<Alumno> resultado = new List<Alumno>();
            foreach (Alumno a in alumnos)
            {
                if (a.sexo =="M")
                {
                    resultado.Add(a);

                }
            }
            return resultado;*/

            //return db.Alumnoes.Where(x => x.sexo == "M").ToList();


            return db.Alumnoes.ToList();//SQL-> SELECT * FROM db Alumno
            //los metodos del EntityFrameword se denomina Linq, y la evaluacion de condicion lambda

        }


        public static List<Alumno> GetAlumnos(string criterio)
        {
            //startsWith que empiece pro el criterio
            //contais que contenga el criterio
            //Tolower cambia todos los apellidos a minusculas
            Entities db = new Entities();
            return db.Alumnoes.Where(x=> x.apellidos.Contains(criterio)).ToList();
        }


       public static Alumno GetAlumno(int id)
        {
            Entities db= new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.idalumno == id);
        }


        public static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }





    }
}
