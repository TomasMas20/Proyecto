using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTest.Logica
{
    public class UbigeoLogica
    {
        
        private static UbigeoLogica _instancia = null;

        public UbigeoLogica()
        {

        }

        public static UbigeoLogica Instancia
        {
            get {
                if (_instancia == null) {
                    _instancia = new UbigeoLogica();
                }
                return _instancia;
            }
        }



        public List<pais> Obtenerpais() {
            List<pais> lst = new List<pais>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from pais", oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new pais()
                            {
                                Idpais = dr["Idpais"].ToString(),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<pais>();
                }
            }
            return lst;
        }

        public List<Provincia> ObtenerProvincia(string _idpais)
        {
            List<Provincia> lst = new List<Provincia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from provincia where Idpais = @idpais", oConexion);
                    cmd.Parameters.AddWithValue("@idpais", _idpais);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Provincia()
                            {
                                IdProvincia = dr["IdProvincia"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Idpais = dr["Idpais"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<Provincia>();
                }
            }
            return lst;
        }

        public List<ciudad> Obtenerciudad(string _idprovincia, string _idpais)
        {
            List<ciudad> lst = new List<ciudad>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from ciudad where IdProvincia = @idprovincia and Idpais = @idpais", oConexion);
                    cmd.Parameters.AddWithValue("@idprovincia", _idprovincia);
                    cmd.Parameters.AddWithValue("@idpais", _idpais);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new ciudad()
                            {
                                Idciudad = dr["Idciudad"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdProvincia = dr["IdProvincia"].ToString(),
                                Idpais = dr["Idpais"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<ciudad>();
                }
            }
            return lst;
        }

    }
}