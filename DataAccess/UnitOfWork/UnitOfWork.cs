using DataAccess.Concrete;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
           Context context = new Context();
           context.SaveChanges();
        }
    }
}
