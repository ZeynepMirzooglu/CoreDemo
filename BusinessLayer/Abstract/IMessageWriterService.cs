using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageWriterService:IGenericService<MessageWriter>
    {
        List<MessageWriter> GetInBoxByWriter(int id);
        List<MessageWriter> GetSendBoxByWriter(int id);


    }
}
