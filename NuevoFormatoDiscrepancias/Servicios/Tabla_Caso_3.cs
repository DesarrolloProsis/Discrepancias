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
        
        public List<filas> Datos_Tabla_3(List<string> Todos_Carriles, List<string> Carriles, DateTime Fecha, string Turno, string Plaza)
        {
            string Fecha_List = Fecha.ToString("dd/MM/yyyy");
            dt = Llena_Table(Carriles, Fecha, "1", Plaza);
            dt.Merge(Llena_Table(Carriles, Fecha, "2", Plaza));
            dt.Merge(Llena_Table(Carriles, Fecha, "3", Plaza));
            List<string> Prueba = Busca_Carriles(Plaza);
            ListaCarrilesExclusivos = Busca_Carriles_Exclusivos(Plaza);


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
                int id = 0;

                for (int i = 0; i < Carriles.Count; i++)
                {
                    for (int _Turno = 1; _Turno < 4; _Turno++)
                    {
                        filas newfila = new filas();
                        newfila.Id = id;
                        newfila.Carril = Carriles[i].ToString();
                        newfila.Fecha = Fecha_List;
                        newfila.Turno = Busca_Turno(Convert.ToString(_Turno));
                        newfila.Discrepancias_Pre = Discrepancias_Pre(Carriles, i, _Turno);
                        newfila.Eficiencia_Pre = Eficiencia_Pre(Carriles, i, _Turno);
                        newfila.Eficiencia_Dia_Pre = Eficiencia_Dia_Pre(Carriles, i, _Turno);
                        newfila.Discrepancias_Post = Discrepancias_Post(Carriles, i, _Turno);
                        newfila.Eficiencia_Post = Eficiencia_Post(Carriles, i, _Turno);
                        newfila.Eficiencia_Dia_Post = Eficiencia_Dia_Post(Carriles, i, _Turno);
                        newfila.Cruces = Cruces(Carriles, i, _Turno);
                        Lista_Completa.Add(newfila);
                        id++;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            dt.Clear();
            return Lista_Completa;
        }

    }
}