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
        Task SaveAsync(Estados estados, bool isNew);
        Task UpdateAsync(Estados estados, string partitionKey);
        Task DeleteAsync(string id, string partitionKey);
    }
}
