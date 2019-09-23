using System;
using System.Linq;
using System.Runtime.Caching;
using NotificationCenter.Data;
using NotificationCenter.Data.Entities;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.BusinessLogic.Monitors
{
    public static class CertificatesMonitor
    {

        private static MemoryCache _enquiries;

        private static readonly long _notificationEventId;

        static CertificatesMonitor()
        {
            _enquiries = new MemoryCache("CertificatesMonitor");

            using (var db = new NotificationCenterContext())
            {
                _notificationEventId = db.NotificationEvents.Single(ne => ne.RaiseCriteria == NotificationRaiseCriteria.ExpiredCertificate).Id;

                var baseOffset = DateTimeOffset.Now.AddHours(24);
                var now = DateTime.UtcNow;

                foreach (var c in db.ClientCertificates.Where(c => c.ValidFrom <= now && c.ValidUntil >= now))
                {
                    _enquiries.Set(c.ClientId.ToString(), c.ValidUntil, new CacheItemPolicy()
                    {
                        AbsoluteExpiration = c.ValidUntil,
                        RemovedCallback = ReCheckCertificate
                    });
                }
            }
        }

        private static void ReCheckCertificate(CacheEntryRemovedArguments arg)
        {
            var key = int.Parse(arg.CacheItem.Key);
            var oldState = (DateTime)arg.CacheItem.Value;

            using (var db1 = new NotificationCenterContext())
            {
                var cc = db1.ClientCertificates.Single(c => c.ClientId == key);

                db1.Notifications.Add(new Notification()
                {
                    CreatedOn = DateTime.UtcNow,
                    Message = $"Certificate {cc.SetialNumber} expired.",
                    NotificationEventId = _notificationEventId,
                    ReferenceRecord = key,
                    Deleted = false,
                    Seen = false
                });

                db1.SaveChanges();               
            }
        }
    }
}
