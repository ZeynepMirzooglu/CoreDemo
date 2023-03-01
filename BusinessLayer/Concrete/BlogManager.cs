using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager: IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}
		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}
        public List<Blog> GetBlogListWithCategory()
        {
           return _blogDal.GetListWithCategory();
        }
		public List<Blog> GetListWithCategoryByWriter(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}
		public List<Blog> GetListBlogById(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogId== id);
		}
        public Blog TGetById(int id)
		{
			return _blogDal.GetById(id);
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x=>x.WriterId == id);
		}

        public void Add(Blog blog)
		{
            _blogDal.Insert(blog);
        }

        public void Update(Blog blog)
        {
           _blogDal.Update(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAllList()
        {
			return _blogDal.GetListAll();
        }
    }
}
