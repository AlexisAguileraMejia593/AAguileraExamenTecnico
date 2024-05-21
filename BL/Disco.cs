using System;
using System.Collections.Generic;
using System.Linq;

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
                    var query = context.DiscosGetAll(titulo, artista).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Disco disco = new ML.Disco
                            {
                                IdDisco = registro.DiscosID,
                                Titulo = registro.Titulo,
                                Artista = registro.Artista,
                                GeneroMusical = registro.GeneroMusical,
                                Duracion = registro.Duracion.Value,
                                Año = registro.Año.Value,
                                Distribuidora = registro.Distribuidora,
                                Imagen = registro.Imagen
                            };

                            // Maneja 'Ventas' y 'Disponible' de manera especial
                            decimal ventas;
                            if (decimal.TryParse(registro.Ventas.TrimStart('$'), out ventas))
                            {
                                disco.Ventas = ventas;
                            }
                            else
                            {
                                // Maneja el error aquí, por ejemplo, asignando un valor predeterminado o registrando un mensaje de error
                                disco.Ventas = 0; // valor predeterminado
                            }

                            disco.Disponibilidad = registro.Disponible == "SI";

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
                    var query = context.DiscosAdd(
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
                    var registro = context.DiscosGetById(IdDisco).FirstOrDefault();
                    if (registro != null)
                    {

                        ML.Disco disco = new ML.Disco
                        {
                            IdDisco = registro.DiscosID,
                            Titulo = registro.Titulo,
                            Artista = registro.Artista,
                            GeneroMusical = registro.GeneroMusical,
                            Duracion = registro.Duracion.Value,
                            Año = registro.Año.Value,
                            Distribuidora = registro.Distribuidora,
                            Imagen = registro.Imagen
                        };

                        // Maneja 'Ventas' y 'Disponible' de manera especial
                        decimal ventas;
                        if (decimal.TryParse(registro.Ventas.TrimStart('$'), out ventas))
                        {
                            disco.Ventas = ventas;
                        }
                        else
                        {
                            // Maneja el error aquí, por ejemplo, asignando un valor predeterminado o registrando un mensaje de error
                            disco.Ventas = 0; // valor predeterminado
                        }

                        disco.Disponibilidad = registro.Disponible == "SI";

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
                    var query = context.DiscosUpdate(
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
                    var registro = context.DiscosDelete(IdDisco);
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