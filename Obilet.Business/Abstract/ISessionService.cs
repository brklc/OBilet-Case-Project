using Obilet.Core.ResponseModel;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface ISessionService
    {
        Task<SessionResponseModel> GetSession();
    }
}
