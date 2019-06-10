using NuevoFormatoDiscrepancias.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {
        public List<filas> Datos_Tabla_2(List<string> Todos_Carriles, List<string> Carriles, DateTime Fecha, string Turno, string Plaza)
        {
            string Fecha_List = Fecha.ToString("dd/MM/yyyy");            
            int _Turno = Convert.ToInt32(Turno);
            DataTable dt = new DataTable();
            List<string> Prueba = Busca_Carriles(Plaza);
            ListaCarrilesExclusivos = Busca_Carriles_Exclusivos(Plaza);



            dt = Llena_Table(Carriles, Fecha, Turno, Plaza);

            try
            {
                Lista = (from DataRow item in dt.Rows
                         select new Linq
                         {
                             Carril = Convert.ToString(item["VOIE"]),
                             TipoCarril = Convert.ToString(item["ID_VOIE"]),
                             Turno = Convert.ToString(item["SHIFT_NUMBER"]),
                             Pago = Convert.ToString(item["ID_PAIEMENT"]),
                             Transacion = Convert.ToString(item["EVENT_NUMBER"]),
                             Fecha = Convert.ToString(item["DATE_DEBUT_POSTE"]),
                             Hora = Convert.ToString(item["DATE_TRANSACTION"]),
                             Pre = Convert.ToString(item["ID_CLASSE"]),
                             Cajero = Convert.ToString(item["TAB_ID_CLASSE"]),
                             Post = Convert.ToString(item["ACD_CLASS"]),

                         }).ToList();

                var Carriles_Linq = Lista.GroupBy(x => x.Carril)
                                    .Select(g => g.Key)
                                    .ToList();

                var noExisten = Carriles_Linq.Except(Carriles).ToList();
                for (int i = 0; i < Prueba.Count; i++)
                {
                    filas newfila = new filas();
                    newfila.Id = i;
                    newfila.Carril = Prueba[i].ToString();
                    newfila.Fecha = Fecha_List;
                    newfila.Turno = Busca_Turno(Turno);
                    newfila.Discrepancias_Pre = Discrepancias_Pre(Prueba, i, _Turno);
                    newfila.Eficiencia_Pre = Eficiencia_Pre(Prueba, i, _Turno);
                    newfila.Eficiencia_Dia_Pre = "-";
                    newfila.Discrepancias_Post = Discrepancias_Post(Prueba, i, _Turno);
                    newfila.Eficiencia_Post = Eficiencia_Post(Prueba, i, _Turno);
                    newfila.Eficiencia_Dia_Post = "-";
                    newfila.Cruces = Cruces(Prueba, i, _Turno);
                    Lista_Completa.Add(newfila);
                    
                    
                }
            }
            catch (Exception ex)
            {

            }

            return Lista_Completa;
        }
    }
}