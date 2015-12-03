using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubidaFicheros.Controllers;
using SubidaFicheros.Models;

namespace TesTMvc
{
    public abstract class BasePruebas
    {
        protected HomeController Controller;
        protected FicherosEntities1 db;

        protected BasePruebas()
        {
            db=new FicherosEntities1();
            Controller=new HomeController();
        }
    }
}
