using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AlumnoBLL
    {
        //TBLL Transactional Bussiness Logic Layer
        //Capa de la logica del negocio
        public static void Create(Alumno a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Alumno Get(int? id)
        {
            Entities db = new Entities();
            return db.Alumnoes.Find(id);
        }

        public static void Update(Alumno alumno)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Alumno alumno = db.Alumnoes.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }

            }

           
        }


        public static List<Alumno> List()
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

        private static List<Alumno> GetAlumnos(string criterio)
        {
            //startsWith que empiece pro el criterio
            //contais que contenga el criterio
            //Tolower cambia todos los apellidos a minusculas
            Entities db = new Entities();
            return db.Alumnoes.Where(x => x.apellidos.Contains(criterio)).ToList();
        }

        private static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }

    }
}
