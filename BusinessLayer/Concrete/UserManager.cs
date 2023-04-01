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
    public class UserManager: IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(AppUser entity)
        {
            _userDal.Insert(entity);
        }

        public void Delete(AppUser entity)
        {
            _userDal.Delete(entity);
        }

        public List<AppUser> GetAllList()
        {
            return _userDal.GetListAll();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
