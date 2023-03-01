using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager: INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification notification)
        {
            _notificationDal.Insert(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public List<Notification> GetAllList()
        {
            return _notificationDal.GetListAll();
        }

        public Notification TGetById(int id)
        {
           return _notificationDal.GetById(id);
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}
