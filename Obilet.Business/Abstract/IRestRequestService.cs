using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IRestRequestService
    {
        Task<T> PostRequest<T>(object model, string methodUrl);
    }
}
