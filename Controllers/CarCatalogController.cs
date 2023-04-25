using Microsoft.AspNetCore.Mvc;
using CarAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CarAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class CarCatalogController : ControllerBase
{
    private readonly CarDbContext _DBContext;
    public CarCatalogController(CarDbContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAllCars")]
    public async Task<IActionResult> GetAllCars()
    {
        var car = await this._DBContext.CarCatalogs.ToListAsync();
        return Ok(car);
    }
    [HttpGet("GetCarByDealer/{dealer}")]
    public async Task<IActionResult> GetCardByDealer(string dealer)
    {

        if (dealer == "GMC")
        {
            var car = await this._DBContext.CarCatalogs1.ToListAsync();
            Console.WriteLine(car);
            return Ok(car);
        }
        else if (dealer == "Ford")
        {
            var car = await this._DBContext.CarCatalogs2.ToListAsync();
            return Ok(car);
        }
        else if (dealer == "Chrysler")
        {
            var car = await this._DBContext.CarCatalogs3.ToListAsync();
            return Ok(car);
        }
        else return Ok(null);

    }
}
