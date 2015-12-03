using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SubidaFicheros.Utils
{
    public class AzureStorageUtils
    {
        private CloudStorageAccount _cuenta;
        private String _contenedor;

        public AzureStorageUtils(String cuenta, String clave, String contenedor = null)
        {
            StorageCredentials cred=new StorageCredentials(cuenta,clave);
            _cuenta=new CloudStorageAccount(cred,true);
            _contenedor = contenedor;


        }

        //Comprobamos si existe el contedor.Le damos la opción al usuario de crear el contenedor/carpeta
        private void ComprobarContenedor(String contenedor = null)
        {
            if (contenedor != null)
            {
                _contenedor = contenedor;
            }

            var cliente = _cuenta.CreateCloudBlobClient();
            var cont = cliente.GetContainerReference(_contenedor);
            cont.CreateIfNotExists();
        }

        public void SubirFichero(Stream fichero, String nombre, String contenedor = null)
        {
            ComprobarContenedor(contenedor);

            var client = _cuenta.CreateCloudBlobClient();
            //Recupera el contenedor
            var cont = client.GetContainerReference(_contenedor);
            var blob = cont.GetBlockBlobReference(nombre);
            blob.UploadFromStream(fichero);
            fichero.Close();
        }

        public byte[] RecuperarFichero(String nombre, String contenedor)
        {
            ComprobarContenedor(contenedor);
            var client = _cuenta.CreateCloudBlobClient();
            //Recupera el contenedor
            var cont = client.GetContainerReference(_contenedor);
            var blob = cont.GetBlockBlobReference(nombre);

            blob.FetchAttributes();
            var lon = blob.Properties.Length;
            var dest = new byte[lon];
            blob.DownloadToByteArray(dest, 0);
            return dest;

        }
    }
}
