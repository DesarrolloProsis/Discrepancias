using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {
        public string Fecha(int i)
        {
            string Mandar = string.Empty;

            Mandar = Lista_Nuevas[i].Fecha.ToString();

            return Mandar;
        }

        public string Turno(int i)
        {
            string Mandar = string.Empty;
            var x = Lista_Nuevas[i].Turno.ToString();
            if (x == "Pre" || x == "Post")
            {
                return x;
            }
            else
            {
                Mandar = Busca_Turno(Lista_Nuevas[i].Turno.ToString());
                return Mandar;
            }
        }

        public string Transaccion(int i)
        {
            string Mandar = string.Empty;
            Mandar = Lista_Nuevas[i].Transacion.ToString();
            return Mandar;
        }
        public string Clases_Pre(int i)
        {
            string Mandar = string.Empty;
            var x = Lista_Nuevas[i].Pre.ToString();
            if (x == "Pre" || x == "Post")
            {
                return x;
            }
            else
            {
                Mandar = Buscar_Clase(Lista_Nuevas[i].Pre.ToString());
                return Mandar;
            }
        }

        public string Clases_Cajero(int i)
        {
            string Mandar = string.Empty;
            var x = Lista_Nuevas[i].Cajero.ToString();
            if (x == "Pre" || x == "Post")
            {
                return x;
            }
            else
            {
                Mandar = Buscar_Clase(Lista_Nuevas[i].Cajero.ToString());
                return Mandar;
            }
        }
        public string Clases_Post(int i)
        {
            string Mandar = string.Empty;
            var x = Lista_Nuevas[i].Post.ToString();
            if (x == "Pre" || x == "Post")
            {
                return x;
            }
            else
            {
                Mandar = Buscar_Clase(Lista_Nuevas[i].Post.ToString());
                return Mandar;
            }
        }

        public string Pago(int i)
        {
            string Mandar = string.Empty;
            var x = Lista_Nuevas[i].Pago.ToString();
            if (x == "Pre" || x == "Post")
            {
                return x;
            }
            else
            {
                Mandar = Buscar_Pago(Convert.ToInt32(Lista_Nuevas[i].Pago));
                return Mandar;
            }
         
        }
        public string Buscar_Pago(int Pago)
        {
            string Nuevo_Pago = string.Empty;

            if(Pago == (int)Pagos.No_Pago)
            {
                Nuevo_Pago = "No Pago";
            }
            else if(Pago == (int)Pagos.Efectivo)
            {
                Nuevo_Pago = "Efectivo";
            }
            else if(Pago == (int)Pagos.Efectivo_CRE)
            {
                Nuevo_Pago = "Efectivo CRE";
            }
            else if(Pago == (int)Pagos.Excento_VSC)
            {
                Nuevo_Pago = "Excento VSC";
            }
            else if(Pago == (int)Pagos.Valores)
            {
                Nuevo_Pago = "Valores";
            }
            else if(Pago == (int)Pagos.Residente)
            {
                Nuevo_Pago = "Residente";
            }
            else if(Pago == (int)Pagos.Tarjeta_De_Credito)
            {
                Nuevo_Pago = "Tarjeta de Credito";
            }
            else if(Pago == (int)Pagos.Tarjeta_De_Debito)
            {
                Nuevo_Pago = "Tarjeta de Debito";
            }
            else if(Pago == (int)Pagos.Prepago_Tag)
            {
                Nuevo_Pago = "Prepago Tag";
            }
            else if(Pago == (int)Pagos.Violacion)
            {
                Nuevo_Pago = "Violacion";
            }
            else if(Pago == (int)Pagos.Residente_RP1)
            {
                Nuevo_Pago = "Residente RP1";
            }
            else if(Pago == (int)Pagos.Residente_RP2)
            {
                Nuevo_Pago = "Residente RP2";
            }
            else if(Pago == (int)Pagos.Residente_RP3)
            {
                Nuevo_Pago = "Residente RP3";
            }
            else if(Pago == (int)Pagos.Residente_RP4)
            {
                Nuevo_Pago = "Residente RP4";
            }
            else
            {
                Nuevo_Pago = "Ups!";
            }


            return Nuevo_Pago;
        }

        public string Buscar_Clase(string Clase)
        {
            string Nueva_Clase = string.Empty;
            if (Clase == "1")
            {
                Nueva_Clase = "T01A";
            }
            else if (Clase == "2")
            {
                Nueva_Clase = "T02C";
            }
            else if (Clase == "3")
            {
                Nueva_Clase = "T03C";
            }
            else if (Clase == "4")
            {
                Nueva_Clase = "T04C";
            }
            else if (Clase == "5")
            {
                Nueva_Clase = "T05C";
            }
            else if (Clase == "6")
            {
                Nueva_Clase = "T06C";
            }
            else if (Clase == "7")
            {
                Nueva_Clase = "T07C";
            }
            else if (Clase == "8")
            {
                Nueva_Clase = "T08C";
            }
            else if (Clase == "9")
            {
                Nueva_Clase = "T09C";
            }
            else if (Clase == "10")
            {
                Nueva_Clase = "TL01A";
            }
            else if (Clase == "11")
            {
                Nueva_Clase = "TL02A";
            }
            else if (Clase == "12")
            {
                Nueva_Clase = "T02B";
            }
            else if (Clase == "13")
            {
                Nueva_Clase = "T03B";
            }
            else if (Clase == "14")
            {
                Nueva_Clase = "T04B";
            }
            else if (Clase == "15")
            {
                Nueva_Clase = "T01M";
            }
            else if (Clase == "16")
            {
                Nueva_Clase = "TPnnC";
            }
            else if (Clase == "17")
            {
                Nueva_Clase = "TLnnA";
            }
            else if (Clase == "18")
            {
                Nueva_Clase = "T01T";
            }
            else if (Clase == "19")
            {
                Nueva_Clase = "T01P";
            }
            else
            {
                Nueva_Clase = "Ups!";
            }

            return Nueva_Clase;
        }
    }
}