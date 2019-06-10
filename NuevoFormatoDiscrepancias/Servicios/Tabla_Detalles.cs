using NuevoFormatoDiscrepancias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {
        public List<Linq> Lista_Detalles_Pre = new List<Linq>();
        public List<Linq> Lista_Detalles_Post = new List<Linq>();
        public List<Linq> Lista_Turno1_Pre = new List<Linq>();
        public List<Linq> Lista_Turno1_Post = new List<Linq>();
        public List<Linq> Lista_Turno2_Pre = new List<Linq>();
        public List<Linq> Lista_Turno2_Post = new List<Linq>();
        public List<Linq> Lista_Turno3_Pre = new List<Linq>();
        public List<Linq> Lista_Turno3_Post = new List<Linq>();
        public List<Detalles> Lista_Nuevas = new List<Detalles>();

        public List<Detalles> Llenar_Detalles(int id)
        {

            List<Detalles> Lista_Final = new List<Detalles>();
            string Carril = Lista_Completa[id].Carril.ToString();
            Lista_Detalles_Pre = Lista.Where(x => x.Carril == Carril && x.Pre != x.Cajero).OrderBy(x => x.Hora).ToList();
            Lista_Detalles_Post = Lista.Where(x => x.Carril == Carril && x.Post != x.Cajero).OrderBy(x => x.Hora).ToList();

            Lista_Nuevas.Add(new Detalles
            {
                Fecha = "Pre",
                Turno = "Pre",
                Transacion = "Pre",
                Pre = "Pre",
                Cajero = "Pre",
                Post = "Pre",
                Pago = "Pre",
            });


            for (int i = 0; i < Lista_Detalles_Pre.Count; i++)
            {

                Lista_Nuevas.Add(new Detalles
                {
                    Fecha = Lista_Detalles_Pre[i].Hora,
                    Turno = Lista_Detalles_Pre[i].Turno,
                    Transacion = Lista_Detalles_Pre[i].Transacion,
                    Pre = Lista_Detalles_Pre[i].Pre,
                    Cajero = Lista_Detalles_Pre[i].Cajero,
                    Post = Lista_Detalles_Pre[i].Post,
                    Pago = Lista_Detalles_Pre[i].Pago

                });

            }
            Lista_Nuevas.Add(new Detalles
            {
                Fecha = "Post",
                Turno = "Post",
                Transacion = "Post",
                Pre = "Post",
                Cajero = "Post",
                Post = "Post",
                Pago = "Post",
            });

            for (int i = 0; i < Lista_Detalles_Post.Count; i++)
            {

                Lista_Nuevas.Add(new Detalles
                {
                    Fecha = Lista_Detalles_Post[i].Hora,
                    Turno = Lista_Detalles_Post[i].Turno,
                    Transacion = Lista_Detalles_Post[i].Transacion,
                    Pre = Lista_Detalles_Post[i].Pre,
                    Cajero = Lista_Detalles_Post[i].Cajero,
                    Post = Lista_Detalles_Post[i].Post,
                    Pago = Lista_Detalles_Post[i].Pago

                });

            }


            for (int i = 0; i < Lista_Nuevas.Count; i++)
            {
                Detalles newDetalle = new Detalles();
                newDetalle.Fecha = Fecha(i);
                newDetalle.Transacion = Transaccion(i);
                newDetalle.Turno = Turno(i);
                newDetalle.Pre = Clases_Pre(i);
                newDetalle.Cajero = Clases_Cajero(i);
                newDetalle.Post = Clases_Post(i);
                newDetalle.Pago = Pago(i);
                Lista_Final.Add(newDetalle);

            }

            return Lista_Final;
        }
       
    }
}