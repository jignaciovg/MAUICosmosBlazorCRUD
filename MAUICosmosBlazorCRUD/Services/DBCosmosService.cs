using MAUICosmosBlazorCRUD.Environments;
using MAUICosmosBlazorCRUD.Interfaces;
using MAUICosmosBlazorCRUD.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICosmosBlazorCRUD.Services
{
    public class DBCosmosService : IDBCosmosAzure
    {
        public DBCosmosService()
        {
            try
            {
                DBCosmosEnv.cosmosClient = new Microsoft.Azure.Cosmos.CosmosClient(DBCosmosEnv.URI, DBCosmosEnv.PrimaryKey);
            }
            catch (CosmosException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task CreateDatabase()
        {
            try
            {
                DBCosmosEnv.database = await DBCosmosEnv.cosmosClient.CreateDatabaseIfNotExistsAsync(DBCosmosEnv.databaseName);
            }
            catch (CosmosException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateDocumentCollection()
        {
            try
            {
                DBCosmosEnv.container = await(DBCosmosEnv.database.CreateContainerIfNotExistsAsync(DBCosmosEnv.containerId, "/partitionKey"));
            }
            catch (CosmosException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(string id, string partitionKey)
        {
            try
            {
                ItemResponse<Estados> itemResponse = await DBCosmosEnv.container.DeleteItemAsync<Estados>(id, new PartitionKey(partitionKey));
                return true;
            }
            catch (CosmosException ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Estados>> GetAsync()
        {
            List<Estados> estados = new List<Estados>();
            try
            {
                var sqlQuery = "SELECT * FROM c WHERE c.partitionKey='Mexico'";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

                FeedIterator<Estados> queryResult = DBCosmosEnv.container.GetItemQueryIterator<Estados>(queryDefinition);

                while (queryResult.HasMoreResults)
                {
                    FeedResponse<Estados> currentResult = await queryResult.ReadNextAsync();
                    foreach (var item in currentResult)
                    {
                        estados.Add(item);
                    }
                }
            }
            catch (CosmosException ex)
            {
                throw new Exception(ex.Message);
            }
            return estados;
        }

        public async Task<List<Estados>> GetByIdAsync(string id)
        {
            List<Estados> estados = new List<Estados>();
            try
            {
                var sqlQuery = $"SELECT * FROM c WHERE c.partitionKey='Mexico' AND c.id='{id}'";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

                FeedIterator<Estados> queryResult = DBCosmosEnv.container.GetItemQueryIterator<Estados>(queryDefinition);

                while (queryResult.HasMoreResults)
                {
                    FeedResponse<Estados> currentResult = await queryResult.ReadNextAsync();
                    foreach (var item in currentResult)
                    {
                        estados.Add(item);
                    }
                }
            }
            catch (CosmosException ex)
            {
                throw new Exception(ex.Message);
            }
            return estados;
        }

        public async Task<bool> SaveAsync(Estados estados, bool isNew)
        {
            try
            {
                if (isNew)
                {
                    ItemResponse<Estados> itemResponse = await DBCosmosEnv.container.CreateItemAsync<Estados>(estados,
                        new PartitionKey(estados.PartitionKey));
                    return true;
                }
                else
                {
                    ItemResponse<Estados> itemResponse = await DBCosmosEnv.container.ReadItemAsync<Estados>(
                        estados.Id, new PartitionKey(estados.PartitionKey));

                    itemResponse = await DBCosmosEnv.container.ReplaceItemAsync<Estados>
                        (estados, estados.Id, new PartitionKey(estados.PartitionKey));
                    return true;
                }
            }
            catch (CosmosException ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Estados estados, string partitionKey)
        {
            try
            {
                //ACTUALIZA TODO EL ITEM
                await DBCosmosEnv.container.ReplaceItemAsync<Estados>(estados, estados.Id, new PartitionKey(partitionKey));
                return true;

            }
            catch (CosmosException ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
