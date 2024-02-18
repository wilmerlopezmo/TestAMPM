using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Entidades.Utilidades
{
    public static class Funciones
    {
        public static byte[] ImageToBytes(System.Drawing.Image img)
        {
            string sTemp = System.IO.Path.GetTempFileName();
            System.IO.FileStream fs = new FileStream(sTemp, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;
            //
            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        public static System.Drawing.Image BytesToImage(byte[] bytes)
        {
            if (bytes == null) return null;

            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            System.Drawing.Bitmap bm = null;
            try
            {
                bm = new System.Drawing.Bitmap(ms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bm;
        }

        public static string Deco(string PassWord)
        {
            string Deco = "", s = "", sChar = "";
            int c1, c2;


            for (int i = 1; i <= PassWord.Length; i++)
            {
                s = s + Convert.ToChar(i);
            }

            for (int i = 0; i <= s.Length - 1; i++)
            {
                sChar = PassWord.Substring(i, 1);
                c1 = Encoding.ASCII.GetBytes(sChar)[0];

                sChar = s.Substring(i, 1);
                c2 = Encoding.ASCII.GetBytes(sChar)[0];
                Deco = Deco + Convert.ToChar(c2 ^ c1);
            }

            return Deco;
        }
        public static string GetMessageExceptions(Exception ex)
        {
            string result;

            if (ex != null)
            {
                result = ex.Message;

                if (ex.InnerException != null)
                    result += (!ex.Message.Substring(ex.Message.Length - 1, 1).Equals(".") ? "." : "") + " " +
                              GetMessageExceptions(ex.InnerException);
            }
            else
                result = "";

            return result;
        }

        public static void MensajeError(string MsgError)
        {
            MessageBox.Show(MsgError, "AM / PM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MensajeInformacion(string MsgInformation)
        {
            MessageBox.Show(MsgInformation, "AM / PM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool IsNumeric(string valor)
        {
            int i = 0;
            string s = valor;
            bool result = int.TryParse(s, out i); //i now = 108
            return result;
        }

        public static bool IsDecimal(string valor)
        {
            decimal i = 0;
            string s = valor;
            bool result = decimal.TryParse(s, out i); //i now = 108
            return result;
        }

        public static string ConvierteFecha(string Mes)
        {
            string MesAux;
            switch (Mes)
            {
                case "01":
                    MesAux = "ENERO";
                    break;
                case "02":
                    MesAux = "FEBRERO";
                    break;
                case "03":
                    MesAux = "MARZO";
                    break;
                case "04":
                    MesAux = "ABRIL";
                    break;
                case "05":
                    MesAux = "MAYO";
                    break;
                case "06":
                    MesAux = "JUNIO";
                    break;
                case "07":
                    MesAux = "JULIO";
                    break;
                case "08":
                    MesAux = "AGOSTO";
                    break;
                case "09":
                    MesAux = "SEPTIEMBRE";
                    break;
                case "10":
                    MesAux = "OCTUBRE";
                    break;
                case "11":
                    MesAux = "NOVIEMBRE";
                    break;
                case "12":
                    MesAux = "DICIEMBRE";
                    break;
                default:
                    MesAux = "MES NO DEFINIDO";
                    break;
            }
            return MesAux;
        }

        public static string ConvertirFecha(string Fecha)
        {
            string Anno = Fecha.Substring(6, 4);
            string Mes = Fecha.Substring(3, 2);
            string Dia = Fecha.Substring(0, 2);
            return Anno + "-" + Mes + "-" + Dia;

        }

        public static string Right(string value, int length)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }
    }
}
