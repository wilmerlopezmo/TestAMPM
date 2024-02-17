using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAMPM
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Z.EntityFramework.Extensions.LicenseManager.AddLicense("152;101-DELTAFOX", "312F1FF-D0A2201-24FD713-3BA24C5-B79F");
                //// si argumentos no contiene [-s] entonces ejecutar el splash 
                //// -s = Significa No mostrar FrmSplash
                //if (!args.Contains("-s"))
                //{
                //    FrmSplash frSplash = new FrmSplash();
                //    frSplash.ShowDialog();
                //}

                DialogResult rpta = DialogResult.No;

                FrmLogin frEntrar = new FrmLogin();
                rpta = frEntrar.ShowDialog();

                if (rpta == DialogResult.Yes)
                {
                    Application.Run(new MDI());
                }
            }
            catch (Exception ex)
            {
                var errMain = ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

                Funciones.MensajeError(errMain);
            }
        }
    }
}
