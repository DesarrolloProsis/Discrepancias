using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {


        public object Llena_Graficas(int id)
        {
            string Carril = Lista_Completa[id].Carril.ToString();
            Lista_Detalles_Pre = Lista.Where(x => x.Carril == Carril && x.Pre != x.Cajero).OrderBy(x => x.Hora).ToList();
            Lista_Detalles_Post = Lista.Where(x => x.Carril == Carril && x.Post != x.Cajero).OrderBy(x => x.Hora).ToList();
            Lista_Turno1_Pre = Lista.Where(x => x.Carril == Carril && x.Pre != x.Cajero && x.Turno == "1").ToList();
            Lista_Turno1_Post = Lista.Where(x => x.Carril == Carril && x.Post != x.Cajero && x.Turno == "1").ToList();
            Lista_Turno2_Pre = Lista.Where(x => x.Carril == Carril && x.Pre != x.Cajero && x.Turno == "2").ToList();
            Lista_Turno2_Post = Lista.Where(x => x.Carril == Carril && x.Post != x.Cajero && x.Turno == "2").ToList();
            Lista_Turno3_Pre = Lista.Where(x => x.Carril == Carril && x.Pre != x.Cajero && x.Turno == "3").ToList();
            Lista_Turno3_Post = Lista.Where(x => x.Carril == Carril && x.Post != x.Cajero && x.Turno == "3").ToList();

            int[] Graficas_Pre = Total_Pre();
            int[] Graficas_Post = Total_Post();
            int[] Grafica_Turno1_Pre = Turno_1_Pre();
            int[] Grafica_Turno1_Post = Turno_1_Post();
            int[] Grafica_Turno2_Pre = Turno_2_Pre();
            int[] Grafica_Turno2_Post = Turno_2_Post();
            int[] Grafica_Turno3_Pre = Turno_3_Pre();
            int[] Grafica_Turno3_Post = Turno_3_Post();

            string[] Clase_Turno_1 = Clases_Mini(Grafica_Turno1_Pre, Grafica_Turno1_Post);
            int[] Grafica_Mini_1_Pre = Mini_Array(Clase_Turno_1, Grafica_Turno1_Pre);
            int[] Grafica_Mini_1_Post = Mini_Array(Clase_Turno_1, Grafica_Turno1_Post);
            
            string[] Clase_Turno_2 = Clases_Mini(Grafica_Turno2_Pre, Grafica_Turno2_Post);
            int[] Grafica_Mini_2_Pre = Mini_Array(Clase_Turno_2, Grafica_Turno2_Pre);
            int[] Grafica_Mini_2_Post = Mini_Array(Clase_Turno_2, Grafica_Turno2_Post);
            
            string[] Clase_Turno_3 = Clases_Mini(Grafica_Turno3_Pre, Grafica_Turno3_Post);
            int[] Grafica_Mini_3_Pre = Mini_Array(Clase_Turno_3, Grafica_Turno3_Pre);
            int[] Grafica_Mini_3_Post = Mini_Array(Clase_Turno_3, Grafica_Turno3_Post);
            



            object NewObject = new { Graficas_Post, Graficas_Pre, Clase_Turno_1, Grafica_Mini_1_Pre, Grafica_Mini_1_Post, Clase_Turno_2, Grafica_Mini_2_Pre, Grafica_Mini_2_Post, Clase_Turno_3, Grafica_Mini_3_Pre, Grafica_Mini_3_Post };

            return NewObject;

        }


        public int[] Turno_1_Pre()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno1_Pre.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Pre[i].Pre) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Turno_1_Post()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno1_Post.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno1_Post[i].Post) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Turno_2_Pre()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno2_Pre.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Pre[i].Pre) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Turno_2_Post()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno2_Post.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno2_Post[i].Post) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Turno_3_Pre()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno3_Pre.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Pre[i].Pre) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Turno_3_Post()
        {
            int[] Array = new int[19];
            for (int i = 0; i < Lista_Turno3_Post.Count; i++)
            {
                if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T01A)
                {
                    Array[0] = Array[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T02C)
                {
                    Array[1] = Array[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T03C)
                {
                    Array[2] = Array[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[3] = Array[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T05C)
                {
                    Array[4] = Array[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T06C)
                {
                    Array[5] = Array[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T07C)
                {
                    Array[6] = Array[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T08C)
                {
                    Array[7] = Array[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T09C)
                {
                    Array[8] = Array[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.TL01A)
                {
                    Array[9] = Array[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.TL02A)
                {
                    Array[10] = Array[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T02B)
                {
                    Array[11] = Array[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T03B)
                {
                    Array[12] = Array[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T04B)
                {
                    Array[13] = Array[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T01M)
                {
                    Array[14] = Array[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.TPnnC)
                {
                    Array[15] = Array[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.TLnnA)
                {
                    Array[16] = Array[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T01T)
                {
                    Array[17] = Array[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Turno3_Post[i].Post) == (int)Clase.T01P)
                {
                    Array[18] = Array[18] + 1;
                }
                else
                {

                }

            }

            return Array;
        }
        public int[] Total_Pre()
        {
            int[] Grafica_Pre = new int[19];
            for (int i = 0; i < Lista_Detalles_Pre.Count; i++)
            {
                if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T01A)
                {
                    Grafica_Pre[0] = Grafica_Pre[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T02C)
                {
                    Grafica_Pre[1] = Grafica_Pre[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T03C)
                {
                    Grafica_Pre[2] = Grafica_Pre[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Grafica_Pre[3] = Grafica_Pre[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T05C)
                {
                    Grafica_Pre[4] = Grafica_Pre[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T06C)
                {
                    Grafica_Pre[5] = Grafica_Pre[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T07C)
                {
                    Grafica_Pre[6] = Grafica_Pre[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T08C)
                {
                    Grafica_Pre[7] = Grafica_Pre[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T09C)
                {
                    Grafica_Pre[8] = Grafica_Pre[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.TL01A)
                {
                    Grafica_Pre[9] = Grafica_Pre[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.TL02A)
                {
                    Grafica_Pre[10] = Grafica_Pre[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T02B)
                {
                    Grafica_Pre[11] = Grafica_Pre[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T03B)
                {
                    Grafica_Pre[12] = Grafica_Pre[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T04B)
                {
                    Grafica_Pre[13] = Grafica_Pre[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T01M)
                {
                    Grafica_Pre[14] = Grafica_Pre[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.TPnnC)
                {
                    Grafica_Pre[15] = Grafica_Pre[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.TLnnA)
                {
                    Grafica_Pre[16] = Grafica_Pre[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T01T)
                {
                    Grafica_Pre[17] = Grafica_Pre[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Pre[i].Pre) == (int)Clase.T01P)
                {
                    Grafica_Pre[18] = Grafica_Pre[18] + 1;
                }
                else
                {

                }
            }

            return Grafica_Pre;
        }
        public int[] Total_Post()
        {
            int[] Grafica_Post = new int[19];


            for (int i = 0; i < Lista_Detalles_Post.Count; i++)
            {
                if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T01A)
                {
                    Grafica_Post[0] = Grafica_Post[0] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T02C)
                {
                    Grafica_Post[1] = Grafica_Post[1] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T03C)
                {
                    Grafica_Post[2] = Grafica_Post[2] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T04B)
                {
                    Grafica_Post[3] = Grafica_Post[3] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T05C)
                {
                    Grafica_Post[4] = Grafica_Post[4] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T06C)
                {
                    Grafica_Post[5] = Grafica_Post[5] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T07C)
                {
                    Grafica_Post[6] = Grafica_Post[6] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T08C)
                {
                    Grafica_Post[7] = Grafica_Post[7] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T09C)
                {
                    Grafica_Post[8] = Grafica_Post[8] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.TL01A)
                {
                    Grafica_Post[9] = Grafica_Post[9] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.TL02A)
                {
                    Grafica_Post[10] = Grafica_Post[10] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T02B)
                {
                    Grafica_Post[11] = Grafica_Post[11] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T03B)
                {
                    Grafica_Post[12] = Grafica_Post[12] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T04B)
                {
                    Grafica_Post[13] = Grafica_Post[13] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T01M)
                {
                    Grafica_Post[14] = Grafica_Post[14] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.TPnnC)
                {
                    Grafica_Post[15] = Grafica_Post[15] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.TLnnA)
                {
                    Grafica_Post[16] = Grafica_Post[16] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T01T)
                {
                    Grafica_Post[17] = Grafica_Post[17] + 1;
                }
                else if (Convert.ToInt32(Lista_Detalles_Post[i].Post) == (int)Clase.T01P)
                {
                    Grafica_Post[18] = Grafica_Post[18] + 1;
                }
                else
                {

                }
            }
            return Grafica_Post;
        }

        public string[] Clases_Mini(int[] Grafica_Pre, int[] Grafica_Post)
        {
            int Tamaño_array = 0;
            int e = 0;
            int y = 0;
            for (int i = 0; i < 19; i++)
            {
                if (Grafica_Pre[i] != 0)
                    Tamaño_array += 1;
                else if (Grafica_Post[i] != 0)
                    Tamaño_array += 1;

            }
            string[] Clases = new string[Tamaño_array];

            for (int i = 0; i < 19; i++)
            {


                if (Grafica_Pre[i] != 0 || Grafica_Post[i] != 0)
                {
                        y = i + 1;
                                    
                        if (y == (int)Clase.T01A)
                            Clases[e] = "T01A";
                        else if (y == (int)Clase.T02C)
                            Clases[e] = "T02C";
                        else if (y == (int)Clase.T03C)
                            Clases[e] = "T03C";
                        else if (y == (int)Clase.T04C)
                            Clases[e] = "T04C";
                        else if (y == (int)Clase.T05C)
                            Clases[e] = "T05C";
                        else if (y == (int)Clase.T06C)
                            Clases[e] = "T06C";
                        else if (y == (int)Clase.T07C)
                            Clases[e] = "T07C";
                        else if (y == (int)Clase.T08C)
                            Clases[e] = "T08C";
                        else if (y == (int)Clase.T09C)
                            Clases[e] = "T09C";
                        else if (y == (int)Clase.TL01A)
                            Clases[e] = "TL01A";
                        else if (y == (int)Clase.TL02A)
                            Clases[e] = "TL02A";
                        else if (y == (int)Clase.T02B)
                            Clases[e] = "T02B";
                        else if (y == (int)Clase.T03B)
                            Clases[e] = "T03B";
                        else if (y == (int)Clase.T04B)
                            Clases[e] = "T04B";
                        else if (y == (int)Clase.T01M)
                            Clases[e] = "T01M";
                        else if (y == (int)Clase.TPnnC)
                            Clases[e] = "TPnnC";
                        else if (y == (int)Clase.TLnnA)
                            Clases[e] = "TLnnA";
                        else if (y == (int)Clase.T01T)
                            Clases[e] = "T01T";
                        else if (y == (int)Clase.T01P)
                            Clases[e] = "T01P";

                    y = 0;
                    e++;

                }
        
            }

            return Clases;

        }

        public int[] Mini_Array(string [] Clase, int [] Lista)
        {
            int[] array = new int[Clase.Count()];
            List<int> List = new List<int>();

            for(int i = 0; i < Clase.Count(); i++)
            {
                if (Clase[i].ToString() == "T01A")
                    List.Add(0);
                else if (Clase[i].ToString() == "T02C")
                    List.Add(1);
                else if (Clase[i].ToString() == "T03C")
                    List.Add(2);
                else if (Clase[i].ToString() == "T04C")
                    List.Add(3);
                else if (Clase[i].ToString() == "T05C")
                    List.Add(4);
                else if (Clase[i].ToString() == "T06C")
                    List.Add(5);
                else if (Clase[i].ToString() == "T07C")
                    List.Add(6);
                else if (Clase[i].ToString() == "T08C")
                    List.Add(7);
                else if (Clase[i].ToString() == "T09C")
                    List.Add(8);
                else if (Clase[i].ToString() == "TL01A")
                    List.Add(9);
                else if (Clase[i].ToString() == "TL02A")
                    List.Add(10);
                else if (Clase[i].ToString() == "T02B")
                    List.Add(11);
                else if (Clase[i].ToString() == "T03B")
                    List.Add(12);
                else if (Clase[i].ToString() == "T04B")
                    List.Add(13);
                else if (Clase[i].ToString() == "T01M")
                    List.Add(14);
                else if (Clase[i].ToString() == "TPnnC")
                    List.Add(15);
                else if (Clase[i].ToString() == "TLnnA")
                    List.Add(16);
                else if (Clase[i].ToString() == "T01T")
                    List.Add(17);
                else if (Clase[i].ToString() == "T01P")
                    List.Add(19);
            }

            for(int i = 0; i < List.Count(); i++)
            {
                array[i] = Convert.ToInt32(Lista[List[i]]);
            }

            return array;

        }


    }
}