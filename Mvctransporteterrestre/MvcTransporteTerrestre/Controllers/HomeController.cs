using Mvctransporteterrestre.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Mvctransporteterrestre.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string idTiquete, string origen, string destino, string fecha, string precio, string cantidad, string subtotal, String boton)
        {

            if (idTiquete is null)
            {
                return View(idTiquete);
            }

            else
            {
                Tiquetes tiquetesv = new Tiquetes();
                tiquetesv.IdTiquete = idTiquete;
                tiquetesv.Origen = origen;
                tiquetesv.Destino = destino;
                tiquetesv.Fecha = fecha;
                tiquetesv.Precio = Convert.ToDecimal(precio);
                tiquetesv.Cantidad = Convert.ToInt64(cantidad);
                tiquetesv.Subtotal = Convert.ToDecimal(subtotal);
                tiquetesv.Subtotal = tiquetesv.Cantidad * tiquetesv.Precio;


                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE3TVQ9\\SQLEXPRESS;Initial Catalog=TransporteTerrestre;Integrated Security=True;");
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@IdTiquete", SqlDbType.NVarChar).Value = idTiquete;
                com.Parameters.Add("@Origen", SqlDbType.NVarChar).Value = origen;
                com.Parameters.Add("@Destino", SqlDbType.NVarChar).Value = destino;
                com.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Parse(fecha);
                com.Parameters.Add("@Cantidad", SqlDbType.Int).Value = int.Parse(cantidad);
                com.Parameters.Add("@Precio", SqlDbType.Decimal).Value = decimal.Parse(precio);
                com.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = tiquetesv.Subtotal;
                com.CommandText = "spInsertarCompraTiquetes";
                com.ExecuteNonQuery();

                return View(tiquetesv);
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }

    }
}