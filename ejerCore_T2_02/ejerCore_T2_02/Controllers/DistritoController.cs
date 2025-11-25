using ejerCore_T2_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ejerCore_T2_02.Controllers
{
    public class DistritoController : Controller
    {
        private readonly IConfiguration _config;

        public DistritoController(IConfiguration config)
        {
            _config = config;
        }

        // Metodo para obtener el listado de distritos desde la base de datos
        public IEnumerable<Distrito> ListadoDistrito()
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

        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() => ListadoDistrito()));
        }
    }
}
