using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevoFormatoDiscrepancias.Models
{
    public class InfoGeneral
    {
        public List<SelectListItem> Plazas { get; set; }
        public string PlazasId { get; set; }

        public List<SelectListItem> Carriles { get; set; }   
        public List<filas> FilasDeTabla { get; set; }
        public string CarrilesId { get; set; }
    }
    public class TablaTCarrilesTTurnos
    {
        public  List<filas> FilasDeTabla { get; set; }
        public object Info { get; set; }

    }
    public class TablaDetalles
    {
        public List<Detalles> Mini_Tabla {get; set;}
    }

    public class Detalles
    {
        public string Fecha { get; set; }
        public string Transacion { get; set; }
        public string  Turno { get; set; }
        public string Pre { get; set; }
        public string Cajero { get; set; }
        public string Post { get; set; }
        public string Pago { get; set; }

    }

    public class filas
    {
        public int Id { get; set; }
        public string Plaza { get; set; }
        public string Fecha { get; set; }
        public string Carril { get; set; }
        public string Turno { get; set; }
        public string Discrepancias_Pre { get; set; }
        public string Discrepancias_Post { get; set; }
        public string Eficiencia_Pre { get; set; }
        public string Eficiencia_Post { get; set; }
        public string Eficiencia_Dia_Pre { get; set; }
        public string Eficiencia_Dia_Post { get; set; }
        public string Cruces { get; set; }
        public string TipoTabla { get; set; }

    }

    public class Graficas
    {
        //PRE Turno 22:00-05:59
        public int[,] Datos_Graficos_Pre_1 { get; set; }
        //PRE Turno 06:00-13:59
        public int[,] Datos_Graficos_Pre_2 { get; set; } 
        //PRE Turno 14:00-21:59
        public int[,] Datos_Graficos_Pre_3 { get; set; }

        //POST Turno 22:00-05:59
        public int[,] Datos_Graficos_Post_1 { get; set; }
        //POST Turno 06:00-13:59
        public int[,] Datos_Graficos_Post_2 { get; set; }
        //POST Turno 14:00-21:59
        public int[,] Datos_Graficos_Post_3 { get; set; }
        //PRE todos los turnos
        public int[,] Datos_Totales_Pre { get; set; }
        //POST todos los turnos
        public int[,] Datos_Totales_Post { get; set; }
        public List<string> Carriles { get; set; }
        public string Datos { get; set; }
    }
    public class Requisitos
    {
     
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Plaza { get; set; }
        public string Carril { get; set; }
        public string Turno { get; set; }
        public string Nom_Plaza { get; set; }
        public bool Discres_Validas { get; set; }
        public List<string> Frutas { get; set; }
        public IEnumerable<SelectListItem> Lista_de_Frutas { get; set; }
        public List<string> Carriles_Select { get; set; }
        //Modelo Para el Rango de Fechas

        public DateTime Fecha1_Rango { get; set; }
        public DateTime Fecha2_Rango { get; set; }
        public string PlazaRango { get; set; }
        public string CarrilRango { get; set; }
        public string TurnoRango { get; set; }
        public List<string> FrutasRango { get; set; }
        public IEnumerable<SelectListItem> Lista_de_Frutas_Rango { get; set; }
    }
    public class Usuarios
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
  
 
}