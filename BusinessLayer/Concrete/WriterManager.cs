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
	public class WriterManager: IWriterService
	{
		IWriterDal _writerDal;
		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAllList()
        {
            return _writerDal.GetListAll();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterId == id);
        }

        public Writer TGetById(int id)
        {
          return  _writerDal.GetById(id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
	}
}
