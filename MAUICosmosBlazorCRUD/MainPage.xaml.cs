using MAUICosmosBlazorCRUD.Services;

namespace MAUICosmosBlazorCRUD;

public partial class MainPage : ContentPage
{
	DBCosmosService service = new DBCosmosService();
	public MainPage()
	{
		DBCosmosInit();
		InitializeComponent();
	}

	//CREAR CONEXION Y BASE DE DATOS
	public async Task DBCosmosInit()
    {
		await service.CreateDatabase();
		await service.CreateDocumentCollection();
	}
}
