using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Data;

namespace NotificationCenter.BusinessLogic
{
    public abstract class ServiceBase : IDisposable
    {
        protected NotificationCenterContext _db;

        public ServiceBase()
        {
            _db = new NotificationCenterContext();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _db = null;
        }
    }
}
