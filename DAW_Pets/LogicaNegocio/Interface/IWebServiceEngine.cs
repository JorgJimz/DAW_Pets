using DAW_Pets.Models.Helpers;
using System.Threading.Tasks;

namespace DAW_Pets.LogicaNegocio.Interface
{
    public interface IWebServiceEngine
    {
        Task<WS_Response<T>> GetAll_Service<T>(string url);
        Task<WS_Response<T>> GetById_Service<T>(string url, string id);
        Task<WS_Response<T>> Post_Service<T>(string url, T entity);
        Task<WS_Response<T>> Put_Service<T>(string url, T entity, string Id);
    }
}
