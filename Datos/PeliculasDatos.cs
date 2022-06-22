using MoviesDex.Datos;
using MoviesDex.Models;
using System.Data;
using System.Data.SqlClient;

namespace MoviesDex.Datos
{
    public class PeliculasDatos
    {

        public List<ModelPelicula> Listar()
        {
            var listaPeliculas = new List<ModelPelicula>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadena()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("ListarPeliculas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaPeliculas.Add(new ModelPelicula()
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            titulo = dr["Titulo"].ToString(),
                            director = dr["Director"].ToString(),
                            categoria = dr["Categoria"].ToString(),
                            calificacion = Convert.ToInt32(dr["Calificacion"]),
                            fechaEstreno = Convert.ToDateTime(dr["FechaEstreno"])
                        });
                    }
                }

            }

            return listaPeliculas;
        }


        public ModelPelicula Obtener(int id)
        {
            var oPelicula = new ModelPelicula();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadena()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPelicula.id = Convert.ToInt32(dr["ID"]);
                        oPelicula.titulo = dr["Titulo"].ToString();
                        oPelicula.director = dr["Director"].ToString();
                        oPelicula.categoria = dr["Categoria"].ToString();
                        oPelicula.calificacion = Convert.ToInt32(dr["Calificacion"]);
                        oPelicula.fechaEstreno = Convert.ToDateTime(dr["FechaEstreno"]);
                    }
                }
            }
            return oPelicula;

        }

        public List<ModelPelicula> FiltrarPorTitulo(string cadena)
        {
            var listaPeliculas = new List<ModelPelicula>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadena()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("FiltrarPorTitulo", conexion);
                cmd.Parameters.AddWithValue("Cadena", cadena);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaPeliculas.Add(new ModelPelicula()
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            titulo = dr["Titulo"].ToString(),
                            director = dr["Director"].ToString(),
                            categoria = dr["Categoria"].ToString(),
                            calificacion = Convert.ToInt32(dr["Calificacion"]),
                            fechaEstreno = Convert.ToDateTime(dr["FechaEstreno"])
                        });
                    }
                }
            }
            return listaPeliculas;

        }



        public bool Editar(ModelPelicula oPelicula)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", oPelicula.id);
                    cmd.Parameters.AddWithValue("Titulo", oPelicula.titulo);
                    cmd.Parameters.AddWithValue("Director", oPelicula.director);
                    cmd.Parameters.AddWithValue("Categoria", oPelicula.categoria);
                    cmd.Parameters.AddWithValue("Calificacion", oPelicula.calificacion);
                    cmd.Parameters.AddWithValue("FechaEstreno", oPelicula.fechaEstreno);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                String error = e.Message;

                respuesta = false;
            }

            return respuesta;
        }

        public bool Agregar(ModelPelicula oPelicula)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("AgregarPelicula", conexion);
                    cmd.Parameters.AddWithValue("Titulo", oPelicula.titulo);
                    cmd.Parameters.AddWithValue("Director", oPelicula.director);
                    cmd.Parameters.AddWithValue("Categoria", oPelicula.categoria);
                    cmd.Parameters.AddWithValue("Calificacion", oPelicula.calificacion);
                    cmd.Parameters.AddWithValue("FechaEstreno", oPelicula.fechaEstreno);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string Error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                String error = e.Message;

                respuesta = false;
            }

            return respuesta;
        }


    }
}
