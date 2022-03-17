# MAUICosmosBlazorCRUD

MAUI APP Blazor conectada a los servicios de Azure con base de datos de CosmosDB (SQL) 

## Dependencias
```bash
Microsoft.Azure.Cosmos 3.25.0
```

## Extras
- Falta crear la carpeta de Environments nivel raiz.

Crear clase DBCosmosEnv:
```c
public static class DBCosmosEnv
    {
        public static readonly string URI = "";
        public static readonly string PrimaryKey = "";
        public static CosmosClient cosmosClient;
        public static string databaseName = "";
        public static string containerId = "";
        public static Container container;
        public static Database database;
    }
```

#### Creador
[Jose Ignacio Vaqueiro Gonzalez](https://github.com/jignaciovg)