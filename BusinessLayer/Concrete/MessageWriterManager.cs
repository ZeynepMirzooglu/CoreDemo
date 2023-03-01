using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageWriterManager: IMessageWriterService
    {
        IMessageWriterDal _messageWriterDal;

        public MessageWriterManager(IMessageWriterDal messageWriterDal)
        {
            _messageWriterDal = messageWriterDal;
        }
        public void Add(MessageWriter entity)
        {
            _messageWriterDal.Insert(entity);
        }

        public void Delete(MessageWriter entity)
        {
            _messageWriterDal.Delete(entity);
        }

        public List<MessageWriter> GetAllList()
        {
            return _messageWriterDal.GetListAll();
        }

        public List<MessageWriter> GetInBoxByWriter(int id)
        {
            return _messageWriterDal.GetListWithMessageWriterByWriter(id);
        }

        public MessageWriter TGetById(int id)
        {
            return _messageWriterDal.GetById(id);
        }

        public void Update(MessageWriter entity)
        {
            _messageWriterDal.Update(entity);
        }
    }
}
