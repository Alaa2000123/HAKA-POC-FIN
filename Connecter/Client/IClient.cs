using Connecter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClient<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByID(int Id);
        public Task<Response> Insert(T objDto);
        public Task<Response> Update(T objDto);
        public Task<T> Delete(T objDto);
    }
}
