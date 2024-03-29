﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager: IAboutService
	{
		IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

        public void Add(About entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public List<About> GetAllList()
        {
            return _aboutDal.GetListAll();
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.GetListAll();
        }

        public void Update(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
