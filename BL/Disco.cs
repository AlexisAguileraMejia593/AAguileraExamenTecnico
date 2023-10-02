using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result GetAll(string titulo, string artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MixUpEntities context = new DL.MixUpEntities())
                {
                    var query = context.DiscoGetAll(titulo, artista).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var registro in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = registro.IdDisco;
                            disco.Titulo = registro.Titulo;
                            disco.Artista = registro.Artista;
                            disco.GeneroMusical = registro.GeneroMusical;
                            disco.Duracion = registro.Duracion;
                            disco.Año = registro.Año;
                            disco.Distribuidora = registro.Distribuidora;
                            disco.Ventas = registro.Ventas.Value;
                            disco.Disponibilidad = registro.Disponibilidad.Value;
                            disco.Imagen = registro.Imagen;

                            result.Objects.Add(disco);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron los registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Disco disco)
        {
                ML.Result result = new ML.Result();
                try
                {
                    //modificacion de prueba
                    using (DL.MixUpEntities context = new DL.MixUpEntities())
                    {
                        var query = context.DiscoAdd(
                                                       disco.Titulo, 
                                                       disco.Artista, 
                                                       disco.GeneroMusical, 
                                                       disco.Duracion,
                                                       disco.Año, 
                                                       disco.Distribuidora,
                                                       disco.Ventas,
                                                       disco.Disponibilidad,
                                                       disco.Imagen);
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.ErrorMessage = ex.Message;
                }
                return result;
        }
        public static ML.Result GetById(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MixUpEntities context = new DL.MixUpEntities())
                {
                    var registro = context.DiscoGetById(IdDisco).FirstOrDefault();
                    if (registro != null)
                    {

                        ML.Disco disco = new ML.Disco();
                        disco.IdDisco = registro.IdDisco;
                        disco.Titulo = registro.Titulo;
                        disco.Artista = registro.Artista;
                        disco.GeneroMusical = registro.GeneroMusical;
                        disco.Duracion = registro.Duracion;
                        disco.Año = registro.Año;
                        disco.Distribuidora = registro.Distribuidora;
                        disco.Ventas = registro.Ventas.Value;
                        disco.Disponibilidad = registro.Disponibilidad.Value;
                        disco.Imagen = registro.Imagen;
                        result.Object = disco;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MixUpEntities context = new DL.MixUpEntities())
                {
                    var query = context.DiscoUpdate(
                        disco.IdDisco,
                        disco.Titulo,
                        disco.Artista,
                        disco.GeneroMusical,
                        disco.Duracion,
                        disco.Año,
                        disco.Distribuidora,
                        disco.Ventas,
                        disco.Disponibilidad,
                        disco.Imagen
                        );
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MixUpEntities context = new DL.MixUpEntities())
                {
                    var registro = context.DiscoDelete(IdDisco);
                    if (registro >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No rows were affected by the delete operation.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}