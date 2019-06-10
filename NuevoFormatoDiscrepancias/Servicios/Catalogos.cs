using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {

        enum Turnos
        {
            Primer_Turno = 1,
            Segundo_Turno = 2,
            Tercer_Turno = 3
        }

        enum Clase
        {
            T01A = 1,
            T02C = 2,
            T03C = 3,
            T04C = 4,
            T05C = 5,
            T06C = 6,
            T07C = 7,
            T08C = 8,
            T09C = 9,
            TL01A = 10,
            TL02A = 11,
            T02B = 12,
            T03B = 13,
            T04B = 14,
            T01M = 15,
            TPnnC = 16,
            TLnnA = 17,
            T01T = 18,
            T01P = 19

        }

        enum Pagos
        {
            No_Pago = 0,
            Efectivo = 1,
            Efectivo_CRE = 2,
            Excento_VSC = 27,
            Valores = 9,
            Residente = 10,
            Tarjeta_De_Credito = 12,
            Tarjeta_De_Debito = 14,
            Prepago_Tag = 15,
            Violacion = 13,
            Residente_RP1 = 71,
            Residente_RP2 = 72,
            Residente_RP3 = 73,
            Residente_RP4 = 74,
        }

    }

    public class InfoCarril
    {
        public string Carril { get; set; }
        public string TypeCarril { get; set; }
    }

    public class Linq
    {
        public string Carril { get; set; }
        public string TipoCarril { get; set; }
        public string Turno { get; set; }
        public string Pago { get; set; }
        public string Transacion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Pre { get; set; }
        public string Cajero { get; set; }
        public string Post { get; set; }

    }
}