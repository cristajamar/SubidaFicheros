using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SubidaFicheros.Utils
{
    public class GestionarFicheros
    {
        //HttpServerUtilityBase se utiliza para conseguir la información completa del server donde queremos subir el fichero
        public static String GuardarFicheroDisco(HttpPostedFileBase fichero, HttpServerUtilityBase server)
        {
            //Para no coger el FileName original y que no pueda coincidir con otros, le damos el nombre del ID.
            var id = Guid.NewGuid();
            //Sacamos la firma horaria
            //var n = DateTime.Now.Ticks;
            String nombre = null;
            if (fichero != null && fichero.ContentLength > 0)
            {
                //ContentType nos da el tipo de fichero codificado
                //Utilizamos el FileName para guardar la extension y evitar posibles errores
                
                var ext = fichero.FileName.Substring(fichero.FileName.LastIndexOf(".") + 1);
                nombre = $"{id}.{ext}";

                //Guarda el fichero en el servidor, el MapPath nos da la ruta relativa donde ira el fichero, concatenando con el nombre del fichero 
                fichero.SaveAs(server.MapPath("/fichero") + "/" + nombre);
            }

            return nombre;
        }


        //Vamos a meter el contenido del fichero en la base de datos, se evita de este modo el llenado del el FS local,
        //el borrado de ficheros....

        //Cogemos el fichero y lo tenemos que convertir en un Arraydevice, lo que se codifica en un disco duro es un Arraydevice
        //Devolvemos un arraydevice que en un principio su valos es NULL
        public static byte[] ToBinario(HttpPostedFileBase fichero)
        {
            //Devolvemos un arraydevice que en un principio su valos es NULL
            byte[] data = null;

            //Comprobamos que el fichero tiene datos
            if (fichero != null && fichero.ContentLength > 0)
            {
                //Para cargar ficheros siempre lo hacemos con STREAM
                //InputStream es el flujo de datos del fichero
                using (var stream=fichero.InputStream)
                {
                    var ms = stream as MemoryStream; 
                    if (ms == null)
                    {
                        ms=new MemoryStream();
                        stream.CopyTo(ms); //Lo guardamos en un Stream
                    }

                    data = ms.ToArray();
                }
            }

            return data;
        }
    }
}
