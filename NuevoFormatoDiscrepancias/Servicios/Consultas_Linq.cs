using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {

        public string Eficiencia_Dia_Pre(List<string> Carriles, int i, int Turno)
        {
            string Mandar = string.Empty;

            if (Turno == 3)
            {
                List<string> Efiencias = new List<string>();
                List<string> EficienciaDia = new List<string>();
                double suma = 0;
                Efiencias.Add(Eficiencia_Pre(Carriles, i, 1));
                Efiencias.Add(Eficiencia_Pre(Carriles, i, 2));
                Efiencias.Add(Eficiencia_Pre(Carriles, i, 3));
                int turnos = 3;
                foreach (string indi in Efiencias)
                {
                    if (indi != "cerrado" && indi != "-" && indi != "Ups!")
                    {
                        EficienciaDia.Add(indi);
                    }
                }
                if (EficienciaDia.Count == 0)
                {
                    return "-";
                }
                for (int j = 0; j < EficienciaDia.Count; j++)
                {
                    suma = suma + Convert.ToDouble(EficienciaDia[j]);
                }
                suma = Math.Round(suma / EficienciaDia.Count(), 2);
                
                return suma.ToString();
            }
            else
            {
                return Mandar = "-";
            }
        }
        public string Eficiencia_Dia_Post(List<string> Carriles, int i, int Turno)
        {
            string Mandar = string.Empty;

            if (Turno == 3)
            {
                List<string> Efiencias = new List<string>();
                List<string> EficienciaDia = new List<string>();
                double suma = 0;
                Efiencias.Add(Eficiencia_Post(Carriles, i, 1));
                Efiencias.Add(Eficiencia_Post(Carriles, i, 2));
                Efiencias.Add(Eficiencia_Post(Carriles, i, 3));
                foreach(string indi in Efiencias)
                {
                    if (indi != "cerrado" && indi != "-" && indi != "Ups!")
                    {
                        EficienciaDia.Add(indi);
                    }
                }
                if (EficienciaDia.Count == 0)
                {
                    return "-";
                }
                for (int j = 0; j < EficienciaDia.Count; j++)
                {
                    suma = suma + Convert.ToDouble(EficienciaDia[j]);
                }
                suma = Math.Round(suma / EficienciaDia.Count(),2);
                return suma.ToString();
            }
            else
            {
                return Mandar = "-";
            }
        }
        public string Discrepancias_Post(List<string> Carriles, int i, int turno)
        {
            string Mandar = string.Empty;            
            int Exclusivos = Lista.Where(x => x.Carril == Carriles[i] && x.Post == "0" && x.Turno == Convert.ToString(turno)).Count();
            int Discrepancias = Lista.Where(x => x.Carril == Carriles[i] && x.Post != x.Cajero && x.Turno == Convert.ToString(turno)).Count();

            if (Discrepancias >= 0)
            {
                return Mandar = Convert.ToString(Discrepancias);
            }
            else if (Discrepancias == 0)
            {
                return Mandar = Convert.ToString(Discrepancias);
            }
            else
            {
                return Mandar = "Ops!";
            }

        }
        public string Eficiencia_Post(List<string> Carriles, int i, int turno)
        {
            string Mandar = string.Empty;
            int Crucez = Lista.Where(x => x.Carril == Carriles[i] && x.Turno == Convert.ToString(turno)).Count();
            int Discrepancias = Lista.Where(x => x.Carril == Carriles[i] && x.Post != x.Cajero && x.Turno == Convert.ToString(turno)).Count();


            if (Crucez > 0 && Discrepancias == 0)
            {
                return Mandar = "100";
            }
            else if (Crucez == 0 && Discrepancias == 0)
            {
                return Mandar = "cerrado";
            }
            else if (Crucez > 0 && Discrepancias > 0)
            {
                return Mandar = Convert.ToString(Math.Round((100 * (1 - (Convert.ToDouble(Discrepancias) / Convert.ToDouble(Crucez)))), 2));
            }
            else
            {
                return Mandar = "Ups!";
            }

        }
        public string Discrepancias_Pre(List<string> Carriles, int i,int turno)
        {
            string Mandar = string.Empty;
            //int Exclusivos = Lista.Where(x => x.Carril == Carriles[i] && x.TipoCarril == "2" && x.Turno == Convert.ToString(turno)).Count();
            var Exclusivo = ListaCarrilesExclusivos.Where(x => x.Carril == Carriles[i]).ToList();            

            int Discrepancias = Lista.Where(x => x.Carril == Carriles[i] && x.Pre != x.Cajero && x.Turno == Convert.ToString(turno)).Count();

            if (BuscaExclusivos(Exclusivo))
            {
                return Mandar = "Exclusivo";
            }
            else if (Discrepancias > 0)
            {
                return Mandar = Convert.ToString(Discrepancias);
            }
            else if (Discrepancias == 0)
            {
                return Mandar = Convert.ToString(Discrepancias);
            }
            else
            {
                return Mandar = "Ups!";
            }

        }
        public string Eficiencia_Pre(List<string> Carriles, int i, int turno)
        {
            string Mandar = string.Empty;
            int Crucez = Lista.Where(x => x.Carril == Carriles[i] && x.Turno == Convert.ToString(turno)).Count();
            int Exclusivos = Lista.Where(x => x.Carril == Carriles[i] && x.Pre == "0" && x.Turno == Convert.ToString(turno)).Count();
            int Discrepancias = Lista.Where(x => x.Carril == Carriles[i] && x.Pre != x.Cajero && x.Turno == Convert.ToString(turno)).Count();

            if (Exclusivos > 0)
            {
                return Mandar = "-";
            }
            else if (Crucez > 0 && Discrepancias == 0)
            {
                return Mandar = "100";
            }
            else if (Crucez == 0 && Discrepancias == 0)
            {
                return Mandar = "cerrado";
            }
            else if (Crucez > 0 && Discrepancias > 0)
            {
                return Mandar = Convert.ToString(Math.Round((100 * (1 - (Convert.ToDouble(Discrepancias) / Convert.ToDouble(Crucez)))), 2));
            }
            else
            {
                return Mandar = "Ups!";
            }

        }
        public string Cruces(List<string> Carriles, int i, int turno)
        {
            string Mandar = Convert.ToString(Lista.Where(x => x.Carril == Carriles[i] && x.Turno == Convert.ToString(turno)).Count()); ;

            return Mandar;
        }
        public string Busca_Turno(string Turno)
        {
            string Nuevo_Turno = string.Empty;
            if (Turno == "1")
            {
                Nuevo_Turno = "22:00-05:59";
            }
            else if (Turno == "2")
            {
                Nuevo_Turno = "06:00-13:59";
            }
            else if (Turno == "3")
            {
                Nuevo_Turno = "14:00-23:59";
            }

            return Nuevo_Turno;
        }
        public bool BuscaExclusivos(List<InfoCarril> Lista)
        {

            if(Lista.Count > 0)
            {
                if (Lista[0].TypeCarril == "2")
                    return true;
                else
                    return false;
            }

            return false;
        }
       
     
        
    }
}