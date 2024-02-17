using System;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SIGE.Entidades.Conexion
{
    public class Conexion
    {
        public static string Cn(string stringName = "CnxBDSistema")
        {
            try
            {
                ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[$"TestAMPM.Properties.Settings.{stringName}"];
                if (setting == null)
                {
                    return string.Empty;
                }

                SqlConnectionStringBuilder strBuilderSEG = new SqlConnectionStringBuilder(setting.ConnectionString);
                SqlConnectionStringBuilder strBuilderSIS = new SqlConnectionStringBuilder();
                
                strBuilderSIS.DataSource = strBuilderSEG.DataSource;
                strBuilderSIS.InitialCatalog = strBuilderSEG.InitialCatalog;
                strBuilderSIS.PersistSecurityInfo = strBuilderSEG.PersistSecurityInfo;
                strBuilderSIS.UserID =strBuilderSEG.UserID;
                strBuilderSIS.Password =strBuilderSEG.Password;

                //var t = Crypting.DesEncrypt("Qconf44\"");
                strBuilderSIS.Pooling = true;
                strBuilderSIS.ApplicationName = "TestAMPM";
                string cnxStr = strBuilderSIS.ConnectionString;
                //var t = Crypting.DesEncrypt("Qconf44\"");

                return cnxStr;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
                return string.Empty;
            }
        }


        public static string CnxEntidades()
        {
            string CnxEDMSeguridad = "";
            try
            {
                // Generar conexion Sql Servedr
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.ConnectionString = Cn();
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.ApplicationName = Application.ProductName;

                // Generar conexion Entity Framework
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                entityBuilder.Provider = "System.Data.SqlClient";
                entityBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
                entityBuilder.Metadata = "res://*/ModelAMPM.csdl|res://*/ModelAMPM.ssdl|res://*/ModelAMPM.msl";

                CnxEDMSeguridad = entityBuilder.ConnectionString;
            }
            catch
            {
                CnxEDMSeguridad = "";
            }

            return CnxEDMSeguridad;
        }

    }
}
