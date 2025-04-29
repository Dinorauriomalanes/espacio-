using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller {
    [HttpGet("listar-aterrizados")]
    public IActionResult ListarAterrizados(string estatus){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.EstatusVuelo,estatus);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
}