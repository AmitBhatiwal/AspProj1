using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspProj1.Models;

namespace AspProj1.Controllers;

/***
@Author Amit Amit
@Date : 3/10/2024
**/
public class LaptopsController : Controller
{
    private readonly ILogger<LaptopsController> _logger;

    //object to handle all the operations on list of laptops
    private static Laptops laptopList ;

    public LaptopsController(ILogger<LaptopsController> logger)
    {
        _logger = logger;
    }

    //index page
    public IActionResult Index()
    {
        Laptop laptop1 = new Laptop("Dell",16,473,"Latitude 7390 2-in-1 touchScreen 13.3 FHD","i7-8650U","1.9 GHz",16,"intel xe iris",true,"https://m.media-amazon.com/images/I/61tR8YwenXL._AC_SL1073_.jpg",1);
        Laptop laptop2 = new Laptop("Apple",8,1599,"Apple 2023 MacBook Air Laptop","M2 Chip","3333 Mhz",4,"nvidia geForce",true,"https://m.media-amazon.com/images/I/81b9m+BnkrL._AC_SL1500_.jpg",2);
        Laptop laptop3 = new Laptop("HP",12,399,"Thinkpad T470s Laptop Computer 14-inch Notebook","i7-6600 ","2.6Ghz",4,"integerated",true,"https://m.media-amazon.com/images/I/61tjQhwNp6L._AC_SL1500_.jpg",3);
        Laptop laptop4 = new Laptop("HP",16,669,"5.6 HD Everyday Laptop","i7","1.2 GHz core_i3",16,"Intel UHD Graphics 605",true,"https://m.media-amazon.com/images/I/61NoJjyN6VL._AC_SL1500_.jpg",4);
        Laptop laptop5 = new Laptop("HP",16,639,"15.6 HD Touchscreen Laptop","i3-1215U","1.2 GHz core_i3",4,"Intel UHD Graphics",true,"https://m.media-amazon.com/images/I/810D75DbygL._AC_SL1500_.jpg",5);
        Laptop laptop6 = new Laptop("ASUS",4,349,"VivoBook 15 X515 Thin and Light Laptop","i3","1.1 GHz",4,"Intel UHD Graphics 605",true,"https://m.media-amazon.com/images/I/71HEF+d4UEL._AC_SL1500_.jpg",6);
        Laptop laptop7 = new Laptop("ASUS",4,346,"Chromebook CX1","Chromebook CX1","1.1 GHz celeron",4,"Intel UHD Graphics ",true,"https://m.media-amazon.com/images/I/81n65PUe4sL._AC_SL1500_.jpg",7);
        List<Laptop> allLaptops = new List<Laptop>();
        allLaptops.Add(laptop1);
        allLaptops.Add(laptop2);
        allLaptops.Add(laptop3);    
        allLaptops.Add(laptop4);
        allLaptops.Add(laptop5);
        allLaptops.Add(laptop6);
        allLaptops.Add(laptop7);
        laptopList = new Laptops();
        Console.WriteLine("Loaded laptops into view");
        laptopList.setLaptops(allLaptops);
        return View(laptopList);
    }

    //Add to cart ajax call called from index page 
    [HttpPost]
    public IActionResult AddToCart(int laptopId)
        {
            Console.WriteLine("finally i am reached here ,,,,,");
            try
            {
                if (laptopList == null)
                {
                    Console.WriteLine("laptopList is null.");
                    return StatusCode(500, "Internal server error. laptopList is null.");
                }
                // Find the laptop with the given id and add it to selectedLaptops list
                var laptop = laptopList.getAllLaptops().FirstOrDefault(l => l.id == laptopId);

                Console.WriteLine("1");
                if (laptop != null)
                {
                    Console.WriteLine("2");
                    laptopList.selectedLaptops.Add(laptop);
                    return Ok(); // Return success response
                }
                else
                {
                    Console.WriteLine("3");
                    return NotFound(); // Return not found response if laptop with given id is not found
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("4");
                return StatusCode(500, ex.Message); // Return internal server error response
            }
    }

    //cart page 
    public IActionResult Cart() {
        return View(laptopList);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
