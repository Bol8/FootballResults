using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using Repository.Context; 


namespace Domain.Manage
{
    public class gLeague
    {
        public List<Liga> list { get; }
        private FootbalEntities db;
        

        public gLeague()
        {
            db = new FootbalEntities();
            this.list = db.Ligas.ToList();
        }
        
    }
}
