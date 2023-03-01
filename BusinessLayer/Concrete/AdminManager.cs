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
    public class AdminManager: IAdminService
    {
        IAdminDal _adminDal;
        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public List<Admin> GetAllList()
        {
            return _adminDal.GetListAll();
        }

        public Admin TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
