using NuevoFormatoDiscrepancias.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using NuevoFormatoDiscrepancias.Servicios;
using static NuevoFormatoDiscrepancias.Servicios.Querys;
using System.Web.Routing;
using System.IO;

namespace NuevoFormatoDiscrepancias.Controllers
{
    public class HomeController : Controller
    {
        public static Requisitos formato = new Requisitos();
        public static List<filas> graficas = new List<filas>();
        public static List<filas> Lista_Datos = new List<filas>();
        public static List<string> Todos_Carriles = new List<string>();
        public static int f, p, Id_Grafica;
        public static bool Usuario = false;

        public ActionResult Index()
        {

            if (p == 1)
            {
                ViewBag.ValidaPlaza = "Este campo es obligatorio";
                p = 0;
            }
            if (f == 1)
            {
                ViewBag.ValidaFecha = "Este campo es obligatorio";
                f = 0;
            }
            formato.Turno = "";
            formato.Plaza = "";
            formato.Fecha_Inicio = Convert.ToDateTime("01/01/0001");
            formato.Carril = "";
            formato.Discres_Validas = false;
            formato.Carriles_Select = new List<string>();
            Requisitos Model = new Requisitos();
            Model.Fecha_Inicio = DateTime.Now;
            Model.Fecha_Fin = DateTime.Now;
            Model.Fecha1_Rango = DateTime.Now;
            Model.Fecha2_Rango = DateTime.Now;
            return View(Model);
        }
        public ActionResult IndexSecundario()
        {
            formato.Turno = "";
            formato.Plaza = "";
            formato.Fecha_Inicio = Convert.ToDateTime("01/01/0001");
            formato.Fecha_Fin = Convert.ToDateTime("01/01/0001");
            formato.Carril = "";
            formato.Discres_Validas = false;
            formato.Carriles_Select = new List<string>();

            return View();
        }
        public ActionResult IndexGraficas()
        {
            if (p == 1)
            {
                ViewBag.ValidaPlaza = "Este campo es obligatorio";
                p = 0;
            }
            if (f == 1)
            {
                ViewBag.ValidaFecha = "Este campo es obligatorio";
                f = 0;
            }
            formato.Turno = "";
            formato.Plaza = "";
            formato.Fecha_Inicio = Convert.ToDateTime("01/01/0001");
            formato.Fecha_Fin = Convert.ToDateTime("01/01/0001");
            formato.Discres_Validas = false;
            formato.Carriles_Select = new List<string>();
            return View();
        }
        public JsonResult GetPlazas()
        {
            var plazas = new List<SelectListItem>()
                {
                new SelectListItem()
                               {
                    Text = "Seleccione una Plaza",
                    Value = "00"
                },
                 new SelectListItem()
                {
                    Text = "Laboratorio",
                    Value = "OracleCN"
                },
                new SelectListItem()
                {
                    Text = "ALPUYECA",
                    Value = "P101"
                },
                new SelectListItem()
                {
                    Text = "PASO MORELOS",
                    Value = "P102"
                },
                new SelectListItem()
                {
                    Text = "PALO BLANCO",
                    Value = "P103"
                },
                new SelectListItem()
                {
                    Text = "LA VENTA",
                    Value = "P104"
                },
                new SelectListItem()
                {
                    Text = "XOCHITEPEC",
                    Value = "P105"
                },
                new SelectListItem()
                {
                    Text = "AEROPUERTO",
                    Value = "P106"
                },
                    new SelectListItem()
                {
                    Text = "EMILIANO ZAPATA",
                    Value = "P107"
                },
                new SelectListItem()
                {
                    Text = "TLALPAN",
                    Value = "P108"
                },
                    new SelectListItem()
                {
                    Text = "TRES MARIAS",
                    Value = "P169"
                },
                new SelectListItem()
                {
                    Text = "FRANCISCO VELASCO",
                    Value = "P184"
                },


            };
            return Json(plazas, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCarriles(string Plaza)
        {

            if (Plaza != null && Plaza != "")
            {
                List<SelectListItem> carrl = new List<SelectListItem>();
                if (Plaza == "00")
                {
                   
                    return Json(carrl, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    try
                    {

            
                    string conexion = ConfigurationManager.ConnectionStrings[Plaza].ConnectionString;
                    OracleConnection connection = new OracleConnection(conexion);
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string Query = "select voie  from VOIE_PHYSIQUE ORDER BY voie ASC";

                    OracleCommand cmd = new OracleCommand(Query, connection);
                    cmd.ExecuteNonQuery();


                    DataTable dt = new DataTable();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        carrl.Add(new SelectListItem
                        {
                            Text = dt.Rows[i][0].ToString(),
                            Value = dt.Rows[i][0].ToString()

                        });

                    }
                    connection.Close();

                    return Json(carrl, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception info)
                    {
                        string path = @"C:\LogDiscrepancias";
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        string logFile = $@"{path}\log.txt";
                        string error = $"{DateTime.Now:dd/MM/yyyy hh:mm:ss}: Line: {Convert.ToInt32(info.StackTrace.Substring(info.StackTrace.LastIndexOf(" ") + 1))} {info.Message}";
                        if (System.IO.File.Exists(logFile))
                        {
                            using (StreamWriter sw = System.IO.File.AppendText(logFile))
                            {
                                sw.WriteLine(error);
                            }
                            //System.IO.File.AppendText(error);
                        }
                        else
                        {
                            System.IO.File.WriteAllText(logFile, error);
                        }
                    }
                }
            }

            return View();
        }
        public ActionResult SetSelect()
        {
            return Json(new { id = 1, value = "test" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTurnos()
        {
            var turno = new List<SelectListItem>()
                {
                new SelectListItem()
                {
                    Text = "Seleccione un Turno",
                    Value = "00",
                },
                new SelectListItem()
                {
                    Text = "22:00-06:00",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "06:00-14:00",
                    Value = "2"
                },
                new SelectListItem()
                {
                    Text = "14:00-22:00",
                    Value = "3"
                },
                };

            return Json(turno, JsonRequestBehavior.AllowGet);
        }
   
      
        public JsonResult Graficas()
        {
            Querys Data = new Querys();
            //Object Grafica_Data = new object();
            object Grafica_Data = Data.Llena_Graficas(Id_Grafica);

            return Json(Grafica_Data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Inicial()
        {          
            return View("Login");
        }

        public ActionResult Login(Usuarios model)
        {
            if (model.Usuario == "Admin" && model.Contraseña == "CAPUFE")
            {
                Usuario = true;
                Requisitos Model = new Requisitos();
                Model.Fecha_Inicio = DateTime.Now;
                Model.Fecha_Fin = DateTime.Now;
                Model.Fecha1_Rango = DateTime.Now;
                Model.Fecha2_Rango = DateTime.Now;
                return View("Index",Model);
            }
            else
            {
                Response.Write("<script>alert('" + "El usuario o la contraseña no coinciden" + "');</script>");
                return View("Login");
            }
        }


        [HttpGet]
        public ActionResult Detalles(int id)
        {

            if (Lista_Completa.Count != 0 && Lista_Completa.Count != 0)
            {
                Querys Data = new Querys();
                TablaDetalles model = new TablaDetalles();
                model.Mini_Tabla = Data.Llenar_Detalles(id);
                Id_Grafica = id;

                return View("Mini_Tabla", model);
            }
            else
            {
                Response.Write("<script>alert('" + "En construccion" + "');</script>");
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult CreacionDeTabla(Requisitos Model)
        {
            if (Usuario == true)
            {

                Lista.Clear();
                Lista_Completa.Clear();
                ListaCarrilesExclusivos.Clear();

                string IdPlaza = Model.Plaza; //connection string de la plaza
                List<string> Carriles = new List<string>();
                string NomPlaza = formato.Nom_Plaza;
                string Carril = string.Empty;
                string Turno = string.Empty;
                if (Model.Frutas == null)
                   Carril = "";
                else
                   Carriles = Model.Frutas;

                if (Model.Turno == "00")
                    Turno = "";
                else
                    Turno = Model.Turno;


                DateTime Fecha = Model.Fecha_Inicio; //fecha que introdujo el usuario   
                //List<string> Carriles = Carril.Split(new char[] { ',' }).ToList();
                TablaTCarrilesTTurnos model = new TablaTCarrilesTTurnos();
                
                if (IdPlaza == "00" || Fecha == Convert.ToDateTime("01/01/0001"))
                {
                    if (IdPlaza == "")
                    {
                        p = 1;
                    }
                    if (Fecha == Convert.ToDateTime("01/01/0001"))
                    {
                        f = 1;
                    }
                    return RedirectToAction("Index");
                }
                else
                {

                    Querys data = new Querys();
                    //Un carril o muchos y un Turno
                    if (Carriles.Count > 0 && Turno != "")
                    {
                        model.FilasDeTabla = data.Datos_Tabla_1(Todos_Carriles, Carriles, Fecha, Turno, IdPlaza);

                    }
                    //Todos Carriles y un Turno
                    else if (Carril == "" && Turno != "")
                    {
                        model.FilasDeTabla = data.Datos_Tabla_2(Todos_Carriles, Carriles, Fecha, Turno, IdPlaza);
                    }
                    //un carril o muchos y todos los turnos
                    else if (Carriles.Count > 0 && Turno == "")
                    {
                        model.FilasDeTabla = data.Datos_Tabla_3(Todos_Carriles, Carriles, Fecha, Turno, IdPlaza);
                    }
                    //todos los carriles y todos los turnos
                    else if (Carril == "" && Turno == "")
                    {
                        model.FilasDeTabla = data.Datos_Tabla_4(Todos_Carriles, Carriles, Fecha, Turno, IdPlaza);
                    }

                    Lista_Datos = Lista_Completa;


                }

                foreach (var item in model.FilasDeTabla)
                {
                    item.TipoTabla = "SinRango";
                }

                //return View("CreacionDeTabla",model);
                return View("CreacionDeTabla", model);
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult CreacionTabla2(Requisitos Model)
        {
            if (Usuario == true)
            {
                int Id = 0;
                Lista.Clear();
                Lista_Completa.Clear();
                string IdPlaza = Model.PlazaRango; //connection string de la plaza
                string NomPlaza = formato.Nom_Plaza;
                DateTime datetime2 =  Model.Fecha2_Rango;
                List<string> prueba = Model.FrutasRango;
                DateTime datetime1 = Model.Fecha1_Rango; //fecha que introdujo el usuario 
                if (IdPlaza == "00" || datetime1 == Convert.ToDateTime("01/01/0001") || datetime2 == Convert.ToDateTime("01/01/0001"))
                {
                    if (IdPlaza == "")
                        p = 1;
                    if (datetime1 == Convert.ToDateTime("01/01/0001"))
                        f = 1;
                    return RedirectToAction("Index");
                }
                else
                {
                    string date1stringformat1 = datetime1.ToString("dd/MM/yyyy");
                    string date2stringformat1 = datetime2.ToString("dd/MM/yyyy");

                    ViewBag.Validar = "";
                    ViewBag.ValidaPlaza = "";
                    ViewBag.ValidaFecha = "";
                    ViewBag.Fecha = date1stringformat1;
                    ViewBag.Fecha2 = date2stringformat1;
                    ViewBag.Plaza = formato.Plaza;

                    string IdCarril = formato.Carril;
                    string Turno = Model.TurnoRango;
                    bool Discres_Validas = formato.Discres_Validas;
                    string conexion = ConfigurationManager.ConnectionStrings[IdPlaza].ConnectionString;
                    OracleConnection connection = new OracleConnection(conexion);
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    List<string> lista = new List<string>();
                    string date1stringformat2 = datetime1.ToString("yyyyMMdd");
                    string date2stringformat2 = datetime2.ToString("yyyyMMdd");
                    string datebefore = (datetime1.AddDays(-1)).ToString("yyyyMMdd");
                    Table table = new Table();
                    List<string> Lista_Carriles = new List<string>();
                    string sql = "select count(*)  from VOIE_PHYSIQUE ORDER BY voie ASC"; //
                    string sql2 = "select voie  from VOIE_PHYSIQUE ORDER BY voie ASC";
                    List<string> Carriles_Seleccionados = new List<string>();
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    OracleCommand cmd2 = new OracleCommand(sql2, connection);
                    OracleDataReader carriles = cmd2.ExecuteReader();
                    while (carriles.Read())
                    {
                        lista.Add(carriles.GetString(0));
                    }
                    if(prueba == null)
                    {

                        List<string> btn = new List<string>();

                        foreach (var item in lista) {
                            btn.Add(item);
                                }

                        prueba = btn;


                    }

                    string todos = "4";
                    if (Turno == "" || Turno == null)
                    {
                        Turno = todos;
                    }
                    if (Model.CarrilRango == "" || Model.CarrilRango == null)
                    {
                        IdCarril = todos;
                    }
                    TablaTCarrilesTTurnos model = new TablaTCarrilesTTurnos();
                    int FilaActual; //variable para saber que fila se esta llenando, su límite es FilasTotal
                    int FilasTotal; //variable para saber el total de filas que se llenaran
                    int CeldaActual; //variable para saber la celda que se llena dentro de una fila
                    int ContadorLista = 0; //variable que sirve como contador de la lista de carriles
                    int Contador_Carril = 0; //variable que sirve de contador para saber cuando cambiar de carril
                    string turnoinicio = ""; //variable para indicar el inicio de un turno
                    int Contador_Turno = 1; //variable para imprimer turnos correspondientes
                    string turnoFin = ""; //variable para indicar el fin de un turno
                    double a = 0, b = 0, c = 0, d = 3;
                    TimeSpan timeSpan = datetime2 - datetime1;
                    int dias = timeSpan.Days;
                    List<DateTime> Fechas = new List<DateTime>();
                    for (int i = 0; i <= dias; i++)
                    {
                        Fechas.Add(datetime1.AddDays(i));
                    }
                    TableRow nuevFila = new TableRow();
                    TableCell nuevaCelda = new TableCell();
                    bool Decide = false;

                  
                        if (lista.Count == prueba.Count)
                        {
                            Decide = true;
                        }
                        else
                        {
                            Decide = false;
                        }
                   

                    //Todos los turnos y todos los carriles 2
                    //if (Turno == todos && IdCarril == todos)
                    if (Turno == "00" && Decide == true)
                    {

                        FilasTotal = lista.Count * 6 * (dias + 1);
                        for (FilaActual = 0; FilaActual < FilasTotal; FilaActual++)
                        {
                            nuevFila = new TableRow();
                            for (CeldaActual = 0; CeldaActual < 9; CeldaActual++)
                            {
                                nuevaCelda = new TableCell();
                                if (CeldaActual == 0)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                        nuevaCelda.Text = "PRE";
                                    else
                                        nuevaCelda.Text = "POST";
                                }
                                else if (CeldaActual == 1)
                                    nuevaCelda.Text = NomPlaza;
                                else if (CeldaActual == 2)
                                    nuevaCelda.Text = date1stringformat1;
                                else if (CeldaActual == 3)
                                    nuevaCelda.Text = lista[ContadorLista];
                                else if (CeldaActual == 4)
                                {
                                    if (Contador_Turno == 1)
                                    {
                                        nuevaCelda.Text = "Turno 22:00 - 05:59";
                                        turnoinicio = "220000";
                                        turnoFin = "055959";
                                    }
                                    else if (Contador_Turno == 2)
                                    {
                                        nuevaCelda.Text = "Turno 06:00 - 13:59";
                                        turnoinicio = "060000";
                                        turnoFin = "135959";
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = "Turno 14:00 - 21:59";
                                        turnoinicio = "140000";
                                        turnoFin = "215959";
                                    }
                                }
                                else if (CeldaActual == 5)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                        nuevaCelda.Text = DiscrePre(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                    else
                                        nuevaCelda.Text = DiscrePost(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                }
                                else if (CeldaActual == 6)
                                    nuevaCelda.Text = Cruces(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                else if (CeldaActual == 7)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPre(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                        if (nuevaCelda.Text != "cerrado")
                                        {
                                            if (Contador_Carril == 0)
                                                a = Convert.ToDouble(nuevaCelda.Text);
                                            else if (Contador_Carril == 1)
                                                b = Convert.ToDouble(nuevaCelda.Text);
                                            else
                                                c = Convert.ToDouble(nuevaCelda.Text);
                                        }
                                        else
                                        {
                                            d--;
                                            if (Contador_Carril == 0)
                                                a = 0;
                                            else if (Contador_Carril == 1)
                                                b = 0;
                                            else
                                                c = 0;
                                        }
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPost(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                        if (nuevaCelda.Text != "cerrado")
                                        {
                                            if (Contador_Carril == 3)
                                                a = Convert.ToDouble(nuevaCelda.Text);
                                            else if (Contador_Carril == 4)
                                                b = Convert.ToDouble(nuevaCelda.Text);
                                            else
                                                c = Convert.ToDouble(nuevaCelda.Text);
                                        }
                                        else
                                        {
                                            d--;
                                            if (Contador_Carril == 3)
                                                a = 0;
                                            else if (Contador_Carril == 4)
                                                b = 0;
                                            else
                                                c = 0;
                                        }
                                    }
                                }
                                else if (CeldaActual == 8)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 3 || Contador_Carril == 4)
                                        nuevaCelda.Text = "-";
                                    else
                                    {
                                        if (d == 0)
                                            nuevaCelda.Text = "Carriles Cerrados";
                                        else
                                            nuevaCelda.Text = Math.Round(((a + b + c) / d), 3).ToString();
                                    }
                                }
                                nuevFila.Cells.Add(nuevaCelda).ToString();
                            }
                            Contador_Carril++;
                            if (Contador_Carril == 6)
                            {
                                ContadorLista++;
                                Contador_Carril = 0;
                            }
                            if (ContadorLista == lista.Count)
                            {
                                ContadorLista = 0;
                                datetime1 = datetime1.AddDays(1);
                                for (int i = 0; i < Fechas.Count; i++)
                                {
                                    if (datetime1 == Fechas[i] && datetime1 != Fechas[Fechas.Count - 1].AddDays(1))
                                    {
                                        date1stringformat1 = Fechas[i].ToString("dd/MM/yyyy");
                                        date1stringformat2 = Fechas[i].ToString("yyyyMMdd");
                                        date2stringformat2 = Fechas[i - 1].ToString("yyyyMMdd");
                                        datebefore = Fechas[i - 1].ToString("yyyyMMdd");
                                    }
                                }

                            }
                            if (Contador_Carril == 3 || Contador_Carril == 0)
                                d = 3;
                            Contador_Turno++;
                            if (Contador_Turno == 4)
                                Contador_Turno = 1;
                            table.Rows.Add(nuevFila).ToString();
                        }
                        ViewBag.FechaVista = date1stringformat1;
                        ViewBag.FechaVista2 = date2stringformat1;
                        List<filas> filasss = new List<filas>();
                        List<string> guaca = new List<string>();

                        int t = 0;
                        int w = 3;
                        int l = 0;
                        for (int i = 0; i < table.Rows.Count / 2; i++)
                        {




                            filas newfila = new filas();
                            newfila.Id = Id;
                            newfila.Carril = table.Rows[t].Cells[3].Text;
                            newfila.Fecha = table.Rows[t].Cells[2].Text;
                            newfila.Turno = table.Rows[t].Cells[4].Text.Substring(5, 14).Replace(" ", "");
                            newfila.Discrepancias_Pre = table.Rows[t].Cells[5].Text;
                            newfila.Eficiencia_Pre = table.Rows[t].Cells[7].Text;
                            newfila.Eficiencia_Dia_Pre = table.Rows[t].Cells[8].Text;
                            newfila.Discrepancias_Post = table.Rows[w].Cells[5].Text;
                            newfila.Eficiencia_Post = table.Rows[w].Cells[7].Text;
                            newfila.Eficiencia_Dia_Post = table.Rows[w].Cells[8].Text;
                            newfila.Cruces = table.Rows[t].Cells[6].Text;
                            filasss.Add(newfila);
                            Id += 1;
                            t++;
                            w++;
                            l++;

                            if (l == 3)
                            {
                                t = t + 3;
                                w = w + 3;
                                l = 0;
                            }
                        }

                        //for (int i = 0; i < table.Rows.Count; i++)
                        //{
                        //    filas newfila = new filas();
                        //    //newfila.Pre_Post = table.Rows[i].Cells[0].Text;
                        //    //newfila.Plaza = table.Rows[i].Cells[1].Text;
                        //    //newfila.Fecha = table.Rows[i].Cells[2].Text;
                        //    //newfila.Carril = table.Rows[i].Cells[3].Text;
                        //    //newfila.Turno = table.Rows[i].Cells[4].Text;
                        //    //newfila.Discrepancias = table.Rows[i].Cells[5].Text;
                        //    //newfila.Cruces = table.Rows[i].Cells[6].Text;
                        //    //newfila.Eficiencia = table.Rows[i].Cells[7].Text;
                        //    //newfila.Eficiencia_Dia = table.Rows[i].Cells[8].Text;
                        //    //filasss.Add(newfila);
                        //}
                        graficas = filasss;
                        model.FilasDeTabla = filasss;
                        formato.Carril = "";

                    }



                    //Un solo turno y todos los carriles 2

                    //else if (Turno != todos && IdCarril == todos)
                    else if (Turno != "00" && Decide == true)
                    {
                        string formatohora;
                        if (Turno == "1")
                        {
                            turnoinicio = "220000";
                            turnoFin = "055959";
                            formatohora = "22:00 - 06:00";
                        }
                        else if (Turno == "2")
                        {
                            turnoinicio = "060000";
                            turnoFin = "135959";
                            formatohora = "06:00-13:59";
                        }
                        else if (Turno == "3")
                        {
                            turnoinicio = "140000";
                            turnoFin = "215959";
                            formatohora = "14:00 - 22:00";
                        }
                        else
                        {
                            turnoinicio = "";
                            turnoFin = "";
                            formatohora = "";
                        }
                        FilasTotal = lista.Count * 2 * (dias + 1);
                        for (FilaActual = 0; FilaActual < FilasTotal; FilaActual++)
                        {
                            nuevFila = new TableRow();
                            for (CeldaActual = 0; CeldaActual < 8; CeldaActual++)
                            {
                                nuevaCelda = new TableCell();
                                if (CeldaActual == 0)
                                {
                                    if (Contador_Carril == 0)
                                        nuevaCelda.Text = "PRE";
                                    else
                                        nuevaCelda.Text = "POST";
                                }
                                else if (CeldaActual == 1)
                                    nuevaCelda.Text = NomPlaza;
                                else if (CeldaActual == 2)
                                    nuevaCelda.Text = date1stringformat1;
                                else if (CeldaActual == 3)
                                    nuevaCelda.Text = lista[ContadorLista];
                                else if (CeldaActual == 4)
                                {
                                    nuevaCelda.Text = formatohora;
                                }
                                else if (CeldaActual == 5)
                                {
                                    if (Contador_Carril == 0)
                                        nuevaCelda.Text = DiscrePre(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                    else
                                        nuevaCelda.Text = DiscrePost(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                }
                                else if (CeldaActual == 6)
                                    nuevaCelda.Text = Cruces(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                else if (CeldaActual == 7)
                                {
                                    if (Contador_Carril == 0)
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPre(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPost(turnoinicio, turnoFin, lista[ContadorLista], date1stringformat2, datebefore, connection);
                                    }
                                }
                                nuevFila.Cells.Add(nuevaCelda).ToString();
                            }
                            Contador_Carril++;
                            if (Contador_Carril == 2)
                            {
                                ContadorLista++;
                                Contador_Carril = 0;
                            }
                            if (ContadorLista == lista.Count)
                            {
                                ContadorLista = 0;
                                datetime1 = datetime1.AddDays(1);
                                for (int i = 0; i < Fechas.Count; i++)
                                {
                                    if (datetime1 == Fechas[i] && datetime1 != Fechas[Fechas.Count - 1].AddDays(1))
                                    {
                                        date1stringformat1 = Fechas[i].ToString("dd/MM/yyyy");
                                        date1stringformat2 = Fechas[i].ToString("yyyyMMdd");
                                        date2stringformat2 = Fechas[i - 1].ToString("yyyyMMdd");
                                        datebefore = Fechas[i - 1].ToString("yyyyMMdd");
                                    }
                                }

                            }
                            if (Contador_Carril == 3 || Contador_Carril == 0)
                            {
                                d = 3;
                            }
                            Contador_Turno++;
                            if (Contador_Turno == 4)
                            {
                                Contador_Turno = 1;
                            }
                            table.Rows.Add(nuevFila).ToString();
                        }
                        ViewBag.FechaVista = date1stringformat1;
                        ViewBag.FechaVista2 = date2stringformat1;
                        List<filas> filasss = new List<filas>();
                        List<string> Conta = new List<string>();

                        int k = 0;
                        int e = 1;
                        int t = 0;
                        for (int i = 0; i < table.Rows.Count / 2; i++)
                        {


                            Conta.Add(table.Rows[i].Cells[3].Text);
                            Conta.Add(table.Rows[i].Cells[2].Text);
                            Conta.Add(table.Rows[i].Cells[0].Text);
                            filas newfila = new filas();
                            newfila.Id = Id;
                            newfila.Carril = table.Rows[k].Cells[3].Text;
                            newfila.Fecha = table.Rows[k].Cells[2].Text;
                            newfila.Turno = table.Rows[k].Cells[4].Text.Replace(" ", "");
                            newfila.Discrepancias_Pre = table.Rows[k].Cells[5].Text;
                            newfila.Eficiencia_Pre = table.Rows[k].Cells[7].Text;
                            newfila.Eficiencia_Dia_Pre = "-";
                            newfila.Discrepancias_Post = table.Rows[e].Cells[5].Text;
                            newfila.Eficiencia_Post = table.Rows[e].Cells[7].Text;
                            newfila.Eficiencia_Dia_Post = "-";
                            newfila.Cruces = table.Rows[k].Cells[6].Text;
                            filasss.Add(newfila);
                            Id += 1;
                            k = k + 2;
                            e = e + 2;

                        }

                        //for (int i = 0; i < table.Rows.Count; i++)
                        //{
                        //    filas newfila = new filas();
                        //    //newfila.Pre_Post = table.Rows[i].Cells[0].Text;
                        //    //newfila.Plaza = table.Rows[i].Cells[1].Text;
                        //    //newfila.Fecha = table.Rows[i].Cells[2].Text;
                        //    //newfila.Carril = table.Rows[i].Cells[3].Text;
                        //    //newfila.Turno = table.Rows[i].Cells[4].Text;
                        //    //newfila.Discrepancias = table.Rows[i].Cells[5].Text;
                        //    //newfila.Cruces = table.Rows[i].Cells[6].Text;
                        //    //newfila.Eficiencia = table.Rows[i].Cells[7].Text;
                        //    //newfila.Eficiencia_Dia = "";
                        //    //filasss.Add(newfila);
                        //}

                        graficas = filasss;
                        model.FilasDeTabla = filasss;
                        formato.Carril = "";
                    }


                    //Todos los turnos pero solo algunos carriles
                    else if (Turno == "00" && Decide == false)
                    {
                        int x = prueba.Count - 1;
                        int z = 0;
                        int y = 0;
                        FilasTotal = 6 * (dias + 1) * prueba.Count;
                        for (FilaActual = 0; FilaActual < FilasTotal; FilaActual++)
                        {
                            nuevFila = new TableRow();
                            for (CeldaActual = 0; CeldaActual < 9; CeldaActual++)
                            {
                                nuevaCelda = new TableCell();
                                if (CeldaActual == 0)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                    {
                                        nuevaCelda.Text = "PRE";
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = "POST";
                                    }
                                }
                                else if (CeldaActual == 1)
                                    nuevaCelda.Text = NomPlaza;
                                else if (CeldaActual == 2)
                                    nuevaCelda.Text = date1stringformat1;
                                else if (CeldaActual == 3)
                                    //-----------------
                                    nuevaCelda.Text = prueba[ContadorLista];
                                else if (CeldaActual == 4)
                                {
                                    if (Contador_Turno == 1)
                                    {
                                        nuevaCelda.Text = "Turno 22:00 - 05:59";
                                        turnoinicio = "220000";
                                        turnoFin = "055959";
                                    }
                                    else if (Contador_Turno == 2)
                                    {
                                        nuevaCelda.Text = "Turno 06:00 - 13:59";
                                        turnoinicio = "060000";
                                        turnoFin = "135959";
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = "Turno 14:00 - 21:59";
                                        turnoinicio = "140000";
                                        turnoFin = "215959";
                                    }
                                }
                                else if (CeldaActual == 5)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                        nuevaCelda.Text = DiscrePre(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                    else
                                        nuevaCelda.Text = DiscrePost(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                }
                                else if (CeldaActual == 6)
                                    nuevaCelda.Text = Cruces(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                else if (CeldaActual == 7)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 2)
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPre(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                        if (nuevaCelda.Text != "cerrado")
                                        {
                                            if (Contador_Carril == 0)
                                                a = Convert.ToDouble(nuevaCelda.Text);
                                            else if (Contador_Carril == 1)
                                                b = Convert.ToDouble(nuevaCelda.Text);
                                            else
                                                c = Convert.ToDouble(nuevaCelda.Text);
                                        }
                                        else
                                        {
                                            d--;
                                            if (Contador_Carril == 0)
                                                a = 0;
                                            else if (Contador_Carril == 1)
                                                b = 0;
                                            else
                                                c = 0;
                                        }
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPost(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                        if (nuevaCelda.Text != "cerrado")
                                        {
                                            if (Contador_Carril == 3)
                                                a = Convert.ToDouble(nuevaCelda.Text);
                                            else if (Contador_Carril == 4)
                                                b = Convert.ToDouble(nuevaCelda.Text);
                                            else
                                                c = Convert.ToDouble(nuevaCelda.Text);
                                        }
                                        else
                                        {
                                            d--;
                                            if (Contador_Carril == 3)
                                                a = 0;
                                            else if (Contador_Carril == 4)
                                                b = 0;
                                            else
                                                c = 0;
                                        }
                                    }
                                }
                                else if (CeldaActual == 8)
                                {
                                    if (Contador_Carril == 0 || Contador_Carril == 1 || Contador_Carril == 3 || Contador_Carril == 4)
                                        nuevaCelda.Text = "-";
                                    else
                                    {
                                        if (d == 0)
                                            nuevaCelda.Text = "Carriles Cerrados";
                                        else
                                            nuevaCelda.Text = Math.Round(((a + b + c) / d), 3).ToString();
                                    }
                                }
                                nuevFila.Cells.Add(nuevaCelda).ToString();
                            }

                            Contador_Carril++;
                            z++;
                            y++;

                            if (z == 6)
                            {
                                if (ContadorLista < x)
                                {
                                    ContadorLista++;
                                    z = 0;
                                    Contador_Carril = 0;
                                }



                                ////    datetime1 = datetime1.AddDays(1);


                                ////for (int i = 0; i < Fechas.Count; i++)
                                ////{
                                ////    if (datetime1 == Fechas[i] && datetime1 != Fechas[Fechas.Count - 1].AddDays(1))
                                ////    {
                                ////        date1stringformat1 = Fechas[i].ToString("dd/MM/yyyy");
                                ////        date1stringformat2 = Fechas[i].ToString("yyyyMMdd");
                                ////        date2stringformat2 = Fechas[i - 1].ToString("yyyyMMdd");
                                ////        datebefore = Fechas[i - 1].ToString("yyyyMMdd");
                                ////    }
                                ////}
                                ////Contador_Carril = 0;

                            }
                            if (y == prueba.Count * 6)
                            {

                                datetime1 = datetime1.AddDays(1);


                                for (int i = 0; i < Fechas.Count; i++)
                                {
                                    if (datetime1 == Fechas[i] && datetime1 != Fechas[Fechas.Count - 1].AddDays(1))
                                    {
                                        date1stringformat1 = Fechas[i].ToString("dd/MM/yyyy");
                                        date1stringformat2 = Fechas[i].ToString("yyyyMMdd");
                                        date2stringformat2 = Fechas[i - 1].ToString("yyyyMMdd");
                                        datebefore = Fechas[i - 1].ToString("yyyyMMdd");
                                    }
                                }

                                ContadorLista = 0;
                                Contador_Carril = 0;
                                z = 0;
                                y = 0;


                            }


                            if (Contador_Carril == 3 || Contador_Carril == 0)
                                d = 3;
                            Contador_Turno++;
                            if (Contador_Turno == 4)
                                Contador_Turno = 1;
                            table.Rows.Add(nuevFila).ToString();

                        }
                        ViewBag.FechaVista = date1stringformat1;
                        ViewBag.FechaVista2 = date2stringformat1;



                        int r = 0;
                        int s = 3;
                        int t = 0;

                        List<filas> filasss = new List<filas>();

                        for (int i = 0; i < table.Rows.Count / 2; i++)
                        {


                            filas newfila = new filas();
                            newfila.Id = Id;
                            newfila.Carril = table.Rows[r].Cells[3].Text;
                            newfila.Fecha = table.Rows[r].Cells[2].Text;
                            newfila.Turno = table.Rows[r].Cells[4].Text.Substring(5, 14).Replace(" ", "");
                            newfila.Discrepancias_Pre = table.Rows[r].Cells[5].Text;
                            newfila.Eficiencia_Pre = table.Rows[r].Cells[7].Text;
                            newfila.Eficiencia_Dia_Pre = table.Rows[r].Cells[8].Text;
                            newfila.Discrepancias_Post = table.Rows[s].Cells[5].Text;
                            newfila.Eficiencia_Post = table.Rows[s].Cells[7].Text;
                            newfila.Eficiencia_Dia_Post = table.Rows[s].Cells[8].Text;
                            newfila.Cruces = table.Rows[r].Cells[6].Text;
                            filasss.Add(newfila);
                            Id += 1;
                            r++;
                            s++;
                            t++;

                            if (t == 3)
                            {
                                r = r + 3;
                                s = s + 3;
                                t = 0;
                            }

                        }


                        graficas = filasss;
                        formato.Carril = "";
                        model.FilasDeTabla = filasss;
                    }

                    //--------------------------------------------------
                    else if (Turno != "00" && Decide == false)
                    {
                        int z = 0;
                        int y = 0;
                        int x = prueba.Count - 1;
                        string formatohora;
                        if (Turno == "1")
                        {
                            turnoinicio = "220000";
                            turnoFin = "055959";
                            formatohora = "22:00 - 06:00";
                        }
                        else if (Turno == "2")
                        {
                            turnoinicio = "060000";
                            turnoFin = "135959";
                            formatohora = "06:00-13:59";
                        }
                        else if (Turno == "3")
                        {
                            turnoinicio = "140000";
                            turnoFin = "215959";
                            formatohora = "14:00 - 22:00";
                        }
                        else
                        {
                            turnoinicio = "";
                            turnoFin = "";
                            formatohora = "";
                        }
                        FilasTotal = 2 * (dias + 1) * prueba.Count;
                        for (FilaActual = 0; FilaActual < FilasTotal; FilaActual++)
                        {
                            nuevFila = new TableRow();
                            for (CeldaActual = 0; CeldaActual < 8; CeldaActual++)
                            {
                                nuevaCelda = new TableCell();
                                if (CeldaActual == 0)
                                {
                                    if (Contador_Carril == 0)
                                        nuevaCelda.Text = "PRE";
                                    else
                                        nuevaCelda.Text = "POST";
                                }
                                else if (CeldaActual == 1)
                                    nuevaCelda.Text = NomPlaza;
                                else if (CeldaActual == 2)
                                    nuevaCelda.Text = date1stringformat1;
                                else if (CeldaActual == 3)
                                    nuevaCelda.Text = prueba[ContadorLista];
                                else if (CeldaActual == 4)
                                {
                                    nuevaCelda.Text = formatohora;
                                }
                                else if (CeldaActual == 5)
                                {
                                    if (Contador_Carril == 0)
                                        nuevaCelda.Text = DiscrePre(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                    else
                                        nuevaCelda.Text = DiscrePost(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                }
                                else if (CeldaActual == 6)
                                    nuevaCelda.Text = Cruces(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                else if (CeldaActual == 7)
                                {
                                    if (Contador_Carril == 0)
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPre(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                    }
                                    else
                                    {
                                        nuevaCelda.Text = DiscrepanciasConsultaPost(turnoinicio, turnoFin, prueba[ContadorLista], date1stringformat2, datebefore, connection);
                                    }
                                }
                                nuevFila.Cells.Add(nuevaCelda).ToString();
                            }
                            Contador_Carril++;
                            z++;
                            y++;

                            if (z == 2)
                            {
                                if (ContadorLista < x)
                                {
                                    ContadorLista++;
                                    Contador_Carril = 0;
                                    z = 0;
                                }
                            }
                            if (y == prueba.Count * 2)
                            {
                                datetime1 = datetime1.AddDays(1);
                                for (int i = 0; i < Fechas.Count; i++)
                                {
                                    if (datetime1 == Fechas[i] && datetime1 != Fechas[Fechas.Count - 1].AddDays(1))
                                    {
                                        date1stringformat1 = Fechas[i].ToString("dd/MM/yyyy");
                                        date1stringformat2 = Fechas[i].ToString("yyyyMMdd");
                                        date2stringformat2 = Fechas[i - 1].ToString("yyyyMMdd");
                                        datebefore = Fechas[i - 1].ToString("yyyyMMdd");
                                    }
                                }
                                Contador_Carril = 0;
                                ContadorLista = 0;
                                z = 0;
                                y = 0;
                            }
                            if (Contador_Carril == 3 || Contador_Carril == 0)
                            {
                                d = 3;
                            }
                            Contador_Turno++;
                            if (Contador_Turno == 4)
                            {
                                Contador_Turno = 1;
                            }
                            table.Rows.Add(nuevFila).ToString();
                        }
                        ViewBag.FechaVista = date1stringformat1;
                        ViewBag.FechaVista2 = date2stringformat1;

                        int q = 0;
                        int w = 1;
                        List<filas> filasss = new List<filas>();
                        List<string> aqui = new List<string>();
                        for (int i = 0; i < table.Rows.Count / 2; i++)
                        {


                            aqui.Add(table.Rows[i].Cells[2].Text);
                            filas newfila = new filas();
                            newfila.Id = Id;
                            newfila.Carril = table.Rows[q].Cells[3].Text;
                            newfila.Fecha = table.Rows[q].Cells[2].Text;
                            newfila.Turno = table.Rows[i].Cells[4].Text.Replace(" ", "");
                            newfila.Discrepancias_Pre = table.Rows[q].Cells[5].Text;
                            newfila.Eficiencia_Pre = table.Rows[q].Cells[7].Text;
                            newfila.Eficiencia_Dia_Pre = "-";
                            newfila.Discrepancias_Post = table.Rows[w].Cells[5].Text;
                            newfila.Eficiencia_Post = table.Rows[w].Cells[7].Text;
                            newfila.Eficiencia_Dia_Post = "-";
                            newfila.Cruces = table.Rows[q].Cells[6].Text;
                            filasss.Add(newfila);
                            Id += 1;
                            q += 2;
                            w += 2;


                        }

                        graficas = filasss;
                        model.FilasDeTabla = filasss;
                        formato.Carril = "";
                    }


                    foreach (var item in model.FilasDeTabla)
                    {
                        item.TipoTabla = "RangoFecha";
                    }

                    return View("CreacionDeTabla", model);
                }

            }
            else
            {
                return View("Login");
            }
        }


        //Método para sacar efectividad pre
        public string DiscrepanciasConsultaPre(string turnoinicio, string turnoFin, string carril, string date, string date2, OracleConnection connection)
        {
            string shiftnumber;
            string todoscruces;
            string discrepancias;
            string comparar;
            int discrenovalidas = 0;
            if (turnoinicio == "220000")
            {
                shiftnumber = "1";

                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1 AND ID_VOIE <> '2'";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";
            }
            else
            {
                if (turnoinicio == "060000")
                {
                    shiftnumber = "2";
                }
                else
                {
                    shiftnumber = "3";
                }
                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1 AND ID_VOIE <> '2'";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";
            }
            var cmd = new OracleCommand(todoscruces, connection);
            var cmd2 = new OracleCommand(discrepancias, connection);
            double rescruces = Convert.ToDouble(cmd.ExecuteScalar());
            double resdiscre = Convert.ToDouble(cmd2.ExecuteScalar());
            var cmd3 = new OracleCommand(comparar, connection);
            cmd3.ExecuteNonQuery();
            var da = new OracleDataAdapter(cmd3);
            var dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    if (dt.Rows[i][1].ToString() == "12")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "12")
                {
                    if (dt.Rows[i][1].ToString() == "2")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "3")
                {
                    if (dt.Rows[i][1].ToString() == "13")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "13")
                {
                    if (dt.Rows[i][1].ToString() == "3")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "4")
                {
                    if (dt.Rows[i][1].ToString() == "14")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "14")
                {
                    if (dt.Rows[i][1].ToString() == "4")
                    {
                        discrenovalidas++;
                    }
                }
            }

            if (rescruces == 0)
            {
                return "cerrado";
            }
            else if (rescruces.ToString() == "0" && resdiscre.ToString() == "0")
            {
                return "100";
            }
            else
            {
                if (formato.Discres_Validas == true)
                {
                    resdiscre = resdiscre - discrenovalidas;
                }

                return Convert.ToString(Math.Round(100 * (1 - (resdiscre / rescruces)), 2));
            }
        }
        //Método para sacar efectividad post
        public string DiscrepanciasConsultaPost(string turnoinicio, string turnoFin, string carril, string date, string date2, OracleConnection connection)
        {
            string shiftnumber;
            string todoscruces;
            string discrepancias;
            string comparar;
            int discrenovalidas = 0;
            if (turnoinicio == "220000")
            {
                shiftnumber = "1";

                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";
            }
            else
            {
                if (turnoinicio == "060000")
                {
                    shiftnumber = "2";
                }
                else
                {
                    shiftnumber = "3";
                }
                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";
            }
            var cmd = new OracleCommand(todoscruces, connection);
            var cmd2 = new OracleCommand(discrepancias, connection);
            double rescruces = Convert.ToDouble(cmd.ExecuteScalar());
            double resdiscre = Convert.ToDouble(cmd2.ExecuteScalar());
            var cmd3 = new OracleCommand(comparar, connection);
            cmd3.ExecuteNonQuery();
            var da = new OracleDataAdapter(cmd3);
            var dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    if (dt.Rows[i][1].ToString() == "12")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "12")
                {
                    if (dt.Rows[i][1].ToString() == "2")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "3")
                {
                    if (dt.Rows[i][1].ToString() == "13")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "13")
                {
                    if (dt.Rows[i][1].ToString() == "3")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "4")
                {
                    if (dt.Rows[i][1].ToString() == "14")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "14")
                {
                    if (dt.Rows[i][1].ToString() == "4")
                    {
                        discrenovalidas++;
                    }
                }
            }

            if (rescruces == 0)
            {
                return "cerrado";
            }
            else if (rescruces.ToString() == "0" && resdiscre.ToString() == "0")
            {
                return "100";
            }
            else
            {
                if (formato.Discres_Validas == true)
                {
                    resdiscre = resdiscre - discrenovalidas;
                }
                return Convert.ToString(Math.Round(100 * (1 - (resdiscre / rescruces)), 2));
            }
        }
        //Método para sacar discrepancias pre
        public string DiscrePre(string turnoinicio, string turnoFin, string carril, string date, string date2, OracleConnection connection)
        {
            string shiftnumber;
            string discrepancias;
            string comparar;
            int discrenovalidas = 0;
            if (turnoinicio == "220000")
            {
                shiftnumber = "1";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE  AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";
            }
            else
            {
                if (turnoinicio == "060000")
                {
                    shiftnumber = "2";
                }
                else
                {
                    shiftnumber = "3";
                }

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_PRE_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ID_CLASSE AND ID_VOIE <> '2'";


            }
            var cmd2 = new OracleCommand(discrepancias, connection);
            double resdiscre = Convert.ToDouble(cmd2.ExecuteScalar());
            var cmd3 = new OracleCommand(comparar, connection);
            cmd3.ExecuteNonQuery();
            var da = new OracleDataAdapter(cmd3);
            var dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    if (dt.Rows[i][1].ToString() == "12")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "12")
                {
                    if (dt.Rows[i][1].ToString() == "2")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "3")
                {
                    if (dt.Rows[i][1].ToString() == "13")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "13")
                {
                    if (dt.Rows[i][1].ToString() == "3")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "4")
                {
                    if (dt.Rows[i][1].ToString() == "14")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "14")
                {
                    if (dt.Rows[i][1].ToString() == "4")
                    {
                        discrenovalidas++;
                    }
                }
            }
            if (formato.Discres_Validas == true)
            {
                resdiscre = resdiscre - discrenovalidas;
            }
            return resdiscre.ToString();
        }
        //Método para sacar discrepancias post
        public string DiscrePost(string turnoinicio, string turnoFin, string carril, string date, string date2, OracleConnection connection)
        {
            string shiftnumber;
            string discrepancias;
            string comparar;
            int discrenovalidas = 0;
            if (turnoinicio == "220000")
            {
                shiftnumber = "1";

                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";
            }
            else
            {
                if (turnoinicio == "060000")
                {
                    shiftnumber = "2";
                }
                else
                {
                    shiftnumber = "3";
                }
                discrepancias = "SELECT COUNT(ACD_CLASS) AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";

                comparar = "SELECT tab_id_classe,acd_class AS DISCREPANCIAS_POST_T1 FROM TRANSACTION " +
                                    "where VOIE = '" + carril + "' " +
                                    "AND SHIFT_NUMBER = " + shiftnumber +

                                    " AND ACD_CLASS >= 1 " +
                                    "AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS') AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS') " +
                                    "AND TAB_ID_CLASSE<> ACD_CLASS AND ID_VOIE <> '2'";
            }

            var cmd2 = new OracleCommand(discrepancias, connection);

            double resdiscre = Convert.ToDouble(cmd2.ExecuteScalar());
            var cmd3 = new OracleCommand(comparar, connection);
            cmd3.ExecuteNonQuery();
            var da = new OracleDataAdapter(cmd3);
            var dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    if (dt.Rows[i][1].ToString() == "12")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "12")
                {
                    if (dt.Rows[i][1].ToString() == "2")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "3")
                {
                    if (dt.Rows[i][1].ToString() == "13")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "13")
                {
                    if (dt.Rows[i][1].ToString() == "3")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "4")
                {
                    if (dt.Rows[i][1].ToString() == "14")
                    {
                        discrenovalidas++;
                    }
                }
                else if (dt.Rows[i][0].ToString() == "14")
                {
                    if (dt.Rows[i][1].ToString() == "4")
                    {
                        discrenovalidas++;
                    }
                }
            }
            if (formato.Discres_Validas == true)
            {
                resdiscre = resdiscre - discrenovalidas;
            }
            return resdiscre.ToString();
        }
        //Método para sacar cruces
        public string Cruces(string turnoinicio, string turnoFin, string carril, string date, string date2, OracleConnection connection)
        {
            string todoscruces;
            string shiftnumber;
            if (turnoinicio == "220000")
            {
                shiftnumber = "1";

                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date2 + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1 ";
            }
            else
            {
                if (turnoinicio == "060000")
                {
                    shiftnumber = "2";
                }
                else
                {
                    shiftnumber = "3";
                }
                todoscruces = "SELECT COUNT(ACD_CLASS) AS TRANSACCIONES FROM TRANSACTION" +
                                " where VOIE ='" + carril + "' " +
                                                " AND SHIFT_NUMBER = " + shiftnumber +
                                                " AND DATE_DEBUT_POSTE BETWEEN TO_DATE('" + date + turnoinicio + "','YYYYMMDDHH24MISS')" +
                                                " AND TO_DATE('" + date + turnoFin + "','YYYYMMDDHH24MISS')" +
                                                " AND ACD_CLASS >= 1";
            }
            var cmd = new OracleCommand(todoscruces, connection);
            double rescruces = Convert.ToDouble(cmd.ExecuteScalar());
            return rescruces.ToString();
        }


        public string NombrePlazaCS(string name)
        {
            if (name == "OracleCN")
                return "Prueba";

            else if (name == "P101")
                return "Local";

            else if (name == "P102")
                return "Alpuyeca";

            else if (name == "P103")
                return "Paso Morelos";

            else if (name == "P104")
                return "Palo Blanco";

            else if (name == "P105")
                return "La Venta";

            else if (name == "P106")
                return "Xochitepec";

            else if (name == "P107")
                return "Aeropuerto";

            else if (name == "P108")
                return "Emiliano Zapata";

            else if (name == "P109")
                return "Tlalpan";

            else if (name == "P189")
                return "Tres Marías";

            else if (name == "P186")
                return "Cerro Gordo";

            else if (name == "P190")
                return "Libramiento";

            else if (name == "P191")
                return "Querétaro";

            else if (name == "P192")
                return "Villagrán";

            else if (name == "P193")
                return "Salamanca";
            else if (name == "P194")
                return "Palmillas";
            else
                return "S/N";
        }
    }
}