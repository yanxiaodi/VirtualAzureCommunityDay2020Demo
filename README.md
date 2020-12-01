# VirtualAzureCommunityDay2020Demo

![diagram](/diagram.png)

![sample](/sample.png)

## Fork this repo to your own repo

You can fork this repo to your repo. Currently Static Web Apps supports GitHub actions.

## Create your Cosmos DB

Download the json file here: https://github.com/MicrosoftDocs/mslearn-build-api-azure-functions/blob/master/DB_SETUP/products.json

Create a new Cosmos DB from your Azure portal. Create a new database named `tailwind` then create a container named `products`.

Import the json file to initialize the database.

## Create your Function

Create a new function from your Azure portal. Write down the key and we will use it later.

## Clone this repo

Update the `local.settings.json` file of the **TailwindTradersApi** project. If it does not exist, create one.
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "MyOptions:ConnectionString": "your connection string",
    "MyOptions:Database": "tailwind",
    "MyOptions:Container": "products"
  },
  "Host": {
    "CORS": "*"
  }
}
```
Update the `appsettings.json` file in **wwwroot** folder in the **TailwindTradersBlazorApp** folder.
```json
{
  "ProSettings": {
    "NavTheme": "dark",
    "Layout": "side",
    "ContentWidth": "Fluid",
    "FixedHeader": false,
    "FixSiderbar": true,
    "Title": "Ant Design Pro",
    "PrimaryColor": "daybreak",
    "ColorWeak": false,
    "SplitMenus": false,
    "HeaderRender": true,
    "FooterRender": true,
    "MenuRender": true,
    "MenuHeaderRender": true,
    "HeaderHeight": 48
  },
  "FunctionApiUrl": "http://localhost:7071",
  "FunctionKey": "Your function key"
}
```

## Deploy the Functions

Download the publish file of the function and import it to your VS 2019. Then publish the **TailwindTradersApi** project to your function.
You will see 4 Functions: GetProducts, CreateProduct, UpdateProduct, DeleteProduct. 
Only `GetProducts` works. You can update the others as a practise.

## Deploy the Static Web App

Create a new Static Web App. Connect to your repo.
You will see a new **azure-static-web-apps-xxx.yml** file in **/.github/workflows** folder. The GitHub action will build the project and deploy the Blazor app to Static Web App.

## Any questions please feel free to contact me. Thanks.

