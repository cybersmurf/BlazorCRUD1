using BlazorAppWebAssembly.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppWebAssembly.Shared.Contracts
{
    public interface ICorderManager
    {
        Task<int> Create(c_order cOrder);
        Task<int> Delete(int Id);
        Task<int> Count(string search);
        Task<int> Update(c_order cOrder);
        Task<c_order> GetById(int Id);
        Task<List<c_order>> ListAll(int skip, int take, string orderBy, string direction, string search);
    }
}
