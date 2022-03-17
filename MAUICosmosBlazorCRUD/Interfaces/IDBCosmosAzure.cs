using MAUICosmosBlazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICosmosBlazorCRUD.Interfaces
{
    public interface IDBCosmosAzure
    {
        Task CreateDatabase();
        Task CreateDocumentCollection();
        Task<List<Estados>> GetAsync();
        Task<List<Estados>> GetByIdAsync(string id);
        Task<bool> SaveAsync(Estados estados, bool isNew);
        Task<bool> UpdateAsync(Estados estados, string partitionKey);
        Task<bool> DeleteAsync(string id, string partitionKey);
    }
}
