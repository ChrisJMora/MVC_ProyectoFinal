
namespace MVC_ProyectoFinal.API_Service
{
    public interface IAPI_Service<T>
    {
        //método POST {T}           (create)
        public Task<bool> Post(T entity);

        //método GET                (read / index)
        public Task<List<T>?> Get();

        //método GET {id}           (read / details)
        public Task<T?> Get(int id);

        //método GET {id}           (read / details)
        public Task<T?> Get(string id);

        //método PUT {id,T}         (upload / edit)
        public Task<bool> Put(int id, T entity);

        //método DELETE {id}        (delete)
        public Task<bool> Delete(int id);

    }
}
