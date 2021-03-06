# MAUICosmosBlazorCRUD

Aplicación con MAUI Blazor conectada a los servicios de Azure con base de datos de Azure CosmosDB (SQL).

![](/images/EstadosApp.png)

## Dependencias
```bash
Microsoft.Azure.Cosmos 3.25.0
```

## Extras
1.- Crear Base de datos Azure Cosmos DB.

2.- Crear carpeta de Environments en la aplicación, nivel raiz.

3.- Crear clase DBCosmosEnv dentro de la carpeta de Environments, ya que se implementa en el servicio de DBCosmosService.

4.- Consultar las claves de la base de datos de CosmosDB y plasmarlas en la clase de DBCosmosEnv.

```c

using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICosmosBlazorCRUD.Environments
{
    public static class DBCosmosEnv
        {
            public static readonly string URI = "https://user/example.azure.com:443/";
            public static readonly string PrimaryKey = "ADD-PRIMARY-KEY-FROM-KEYS-PASTE-HERE";
            public static CosmosClient cosmosClient;
            public static string databaseName = "-DATABASE-NAME";
            public static string containerId = "-COLLECTION-NAME-";
            public static Container container;
            public static Database database;
        }
}
```


#### Creditos
[Jose Ignacio Vaqueiro Gonzalez](https://github.com/jignaciovg)

- Video: [Demo](https://www.youtube.com/watch?v=fu0Wyx53SB0)