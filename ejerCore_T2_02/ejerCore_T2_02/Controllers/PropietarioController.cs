using Microsoft.AspNetCore.Mvc;
using ejerCore_T2_02.Models;
using System.Data;
using Microsoft.Data.SqlClient;
namespace ejerCore_T2_02.Controllers
{
    public class PropietarioController : Controller
    {
        // definimos la propiedad de tipo IConfig para la conexion
        private readonly IConfiguration _config;

        public PropietarioController(IConfiguration config)
        {
            // Se asigna a la propiead la cadena de conexion
            _config = config;
        }

        // Agregue aqui los metodos de acceso a datos...
        IEnumerable<Propietario> Listado()
        {
            List<Propietario> temporal = new List<Propietario>();   

            using (SqlConnection cn = new SqlConnection(_config .GetConnectionString ("Infracciones")))
            {
                cn.Open ();
                SqlCommand cmd = new SqlCommand("usp_ListarPropietario", cn);
                SqlDataReader dr = cmd.ExecuteReader ();
                while (dr.Read())
                {
                    temporal.Add(new Propietario()
                    {
                        Cod_Propietario = dr.GetString(0),
                        Nom_Propietario = dr.GetString(1),
                        Ape_Propietario = dr.GetString(2),
                        Dir_Propietario = dr.GetString(3),
                        DNI_Propietario = dr.GetString(4),
                        Cod_Distrito = dr.GetString(5)
                    });
                }
                //Cerramos el dr
                dr.Close ();
            }
            return temporal;


        }

        // Listado de Distritos para combo box
        public IEnumerable<Distrito> cboDistritos()
        {
            List<Distrito> temporal = new List<Distrito>();

            using (SqlConnection cn = new SqlConnection(_config.GetConnectionString("Infracciones")))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_ListarDistrito", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Distrito()
                    {
                        Cod_distrito = dr.GetString(0),
                        Nom_distrito = dr.GetString(1)
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        String mergePropietario(Propietario obj)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_config.GetConnectionString("Infracciones")))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_MergePropietario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cod_Propietario", obj.Cod_Propietario);
                    cmd.Parameters.AddWithValue("@Nom_Propietario", obj.Nom_Propietario);
                    cmd.Parameters.AddWithValue("@Ape_Propietario", obj.Ape_Propietario);
                    cmd.Parameters.AddWithValue("@Dir_Propietario", obj.Dir_Propietario);
                    cmd.Parameters.AddWithValue("@DNI_Propietario", obj.DNI_Propietario);
                    cmd.Parameters.AddWithValue("@Cod_Distrito", obj.Cod_Distrito);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {i} propietario.";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
                finally
                { 
                    cn.Close();
                }
            }
            return mensaje;
        }

        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(()=> Listado()));
        }
    }
}
