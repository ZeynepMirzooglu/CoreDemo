using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageWriterRepository:GenericRepository<MessageWriter>,IMessageWriterDal
    {
        public List<MessageWriter> GetListWithMessageWriterByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.MessageWriters.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}
