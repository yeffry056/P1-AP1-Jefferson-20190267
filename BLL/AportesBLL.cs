using Microsoft.EntityFrameworkCore;
using P1_AP1_Jefferson_20190267.DAL;
using P1_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Jefferson_20190267.BLL
{
    public class AportesBLL
    {
        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes aportes;

            try
            {
                aportes = contexto.Aportes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aportes;
        }
        public static bool Guardar(Aportes aportes)
        {
            Contexto contexto = new Contexto();
            if (!Existe(aportes.AporteId))
                return Insertar(aportes);
            else
                return Modificar(aportes);
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Aportes.Any(e => e.AporteId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }
        public static bool Insertar(Aportes aportes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.Aportes.Add(aportes) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Aportes aportes)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(aportes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var aportes = contexto.Aportes.Find(id);
                if(aportes != null)
                {
                    contexto.Aportes.Remove(aportes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
