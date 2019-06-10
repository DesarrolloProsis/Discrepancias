using NuevoFormatoDiscrepancias.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NuevoFormatoDiscrepancias.Servicios
{
    public partial class Querys
    {
        public static List<Linq> Lista = new List<Linq>();
        public static List<filas> Lista_Completa = new List<filas>();
        public static List<InfoCarril> ListaCarrilesExclusivos = new List<InfoCarril>();
        public static DataTable dt = new DataTable();
        public DataTable Llena_Table(List<string> Carriles, DateTime Fecha, string Turno, string Plaza)
        {

            string conexion = ConfigurationManager.ConnectionStrings[Plaza].ConnectionString;
            OracleConnection connection = new OracleConnection(conexion);            
            DataTable dt = new DataTable();
            string _Fecha = Fecha.AddDays(-1).ToString("yyyyMMdd");
            string Fecha_ = Fecha.ToString("yyyyMMdd");
            string _Turno = string.Empty;
            string Turno_ = string.Empty;

            using (OracleCommand cmd = new OracleCommand("", connection))
            {
                try
                {
                    if(Convert.ToInt32(Turno) == (int)Turnos.Primer_Turno)
                    {
                        
                        _Turno = "220000";
                        Turno_ = "055900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,EVENT_NUMBER,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 1 AND " + 
                                          "DATE_DEBUT_POSTE BETWEEN TO_DATE('"+_Fecha+_Turno+"', 'YYYYMMDDHH24MISS') AND TO_DATE('"+Fecha_+Turno_+ "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";

                    }
                    else if(Convert.ToInt32(Turno) == (int)Turnos.Segundo_Turno)
                    {
                        _Turno = "060000";
                        Turno_ = "135900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,EVENT_NUMBER,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 2 AND " +
                                           "DATE_DEBUT_POSTE BETWEEN TO_DATE('" + Fecha_ + _Turno + "', 'YYYYMMDDHH24MISS') AND TO_DATE('" + Fecha_ + Turno_ + "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";
                    }
                    else if(Convert.ToInt32(Turno) == (int)Turnos.Tercer_Turno)
                    {

                        _Turno = "140000";
                        Turno_ = "215900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,EVENT_NUMBER,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 3 AND " +
                                          "DATE_DEBUT_POSTE BETWEEN TO_DATE('" + Fecha_ + _Turno + "', 'YYYYMMDDHH24MISS') AND TO_DATE('" + Fecha_ + Turno_ + "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";
                    }

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);

                }
                catch(Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }

            }


            return (dt);
        }

        public DataTable Llena_Table_Rango(List<string> Carriles, DateTime Fecha1, DateTime Fecha2,  string Turno, string Plaza)
        {

            string conexion = ConfigurationManager.ConnectionStrings[Plaza].ConnectionString;
            OracleConnection connection = new OracleConnection(conexion);
            DataTable dt = new DataTable();
            string _Fecha = Fecha1.AddDays(-1).ToString("yyyyMMdd");
            string Fecha_ = Fecha1.ToString("yyyyMMdd");            
            string Fecha2_ = Fecha2.ToString("yyyyMMdd");
            string _Turno = string.Empty;
            string Turno_ = string.Empty;

            using (OracleCommand cmd = new OracleCommand("", connection))
            {
                try
                {
                    if (Convert.ToInt32(Turno) == (int)Turnos.Primer_Turno)
                    {

                        _Turno = "220000";
                        Turno_ = "055900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,NUMERO_TRANSACTION,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 1 AND " +
                                          "DATE_DEBUT_POSTE BETWEEN TO_DATE('" + _Fecha + _Turno + "', 'YYYYMMDDHH24MISS') AND TO_DATE('" + Fecha2_ + Turno_ + "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";

                    }
                    else if (Convert.ToInt32(Turno) == (int)Turnos.Segundo_Turno)
                    {
                        _Turno = "060000";
                        Turno_ = "135900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,NUMERO_TRANSACTION,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 2 AND " +
                                           "DATE_DEBUT_POSTE BETWEEN TO_DATE('" + Fecha_ + _Turno + "', 'YYYYMMDDHH24MISS') AND TO_DATE('" + Fecha2_ + Turno_ + "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";
                    }
                    else if (Convert.ToInt32(Turno) == (int)Turnos.Tercer_Turno)
                    {

                        _Turno = "140000";
                        Turno_ = "215900";

                        cmd.CommandText = "SELECT VOIE, ID_VOIE, SHIFT_NUMBER,ID_PAIEMENT,NUMERO_TRANSACTION,TO_CHAR(DATE_TRANSACTION, 'dd/MM/yyyy HH24:MM:SS')DATE_TRANSACTION, TO_CHAR(DATE_DEBUT_POSTE, 'dd/MM/yyyy HH24:MM:SS')DATE_DEBUT_POSTE,ID_CLASSE, TAB_ID_CLASSE,ACD_CLASS FROM TRANSACTION WHERE SHIFT_NUMBER = 3 AND " +
                                          "DATE_DEBUT_POSTE BETWEEN TO_DATE('" + Fecha_ + _Turno + "', 'YYYYMMDDHH24MISS') AND TO_DATE('" + Fecha2_ + Turno_ + "','YYYYMMDDHH24MISS') AND ACD_CLASS >= 1";
                    }

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }

            }


            return (dt);
        }

        public List<string> Busca_Carriles(string Plaza)
        {
            List<string> Lista = new List<string>();
            string conexion = ConfigurationManager.ConnectionStrings[Plaza].ConnectionString;
            OracleConnection connection = new OracleConnection(conexion);            
            DataTable dt = new DataTable();


            using (OracleCommand cmd = new OracleCommand("", connection))
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = "SELECT VOIE FROM VOIE_PHYSIQUE ORDER BY VOIE ASC";
                    cmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);

                    foreach(DataRow indi in dt.Rows)
                    {
                        Lista.Add(indi["VOIE"].ToString());
                    }

                }
                catch(Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }

            return Lista;

        }
        public List<InfoCarril> Busca_Carriles_Exclusivos(string Plaza)
        {
            List<InfoCarril> Lista = new List<InfoCarril>();
            string conexion = ConfigurationManager.ConnectionStrings[Plaza].ConnectionString;
            OracleConnection connection = new OracleConnection(conexion);
            DataTable dt = new DataTable();


            using (OracleCommand cmd = new OracleCommand("", connection))
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = "SELECT VOIE,ID_VOIE FROM VOIE_PHYSIQUE ORDER BY VOIE ASC";
                    cmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow indi in dt.Rows)
                    {
                        Lista.Add(new InfoCarril
                        {
                            Carril = indi["VOIE"].ToString(),
                            TypeCarril = indi["ID_VOIE"].ToString(),

                        });
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }

            return Lista;

        }



    }

}