using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        Uri BaseAddress = new Uri("https://localhost:7289/api");
        private readonly HttpClient _client;
        public ProductController()
        {
            _client= new HttpClient();
            _client.BaseAddress = BaseAddress;
        }
        public IActionResult Index()
        {
            List<Product> productlist=new List<Product>();
            
            HttpResponseMessage respo = _client.GetAsync(_client.BaseAddress + "/Product/GetAllc/GetAll").Result;
            if (respo.IsSuccessStatusCode)
            {
                String data = respo.Content.ReadAsStringAsync().Result;
                productlist= JsonConvert.DeserializeObject<List<Product>>(data);


            }
            return View(productlist);
        }
        public IActionResult DetailsVM()
        {
            List<ProductViewModel> productlist=new List<ProductViewModel>();

            HttpResponseMessage respo = _client.GetAsync(_client.BaseAddress + "/Product/GetAllc/GetAll").Result;
            if (respo.IsSuccessStatusCode)
            {
                String data = respo.Content.ReadAsStringAsync().Result;
                productlist = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);


            }
            return View(productlist);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            String data=JsonConvert.SerializeObject(model);
            StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage respose = _client.PostAsync(_client.BaseAddress+ "/Product/CreateProduct", content).Result;
            if(respose.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit()
        {

            Product product = new Product();

            HttpResponseMessage respo = _client.GetAsync(_client.BaseAddress + "/Product/GetAllc/GetAll").Result;
            if (respo.IsSuccessStatusCode)
            {
                String data = respo.Content.ReadAsStringAsync().Result;
                 product = JsonConvert.DeserializeObject<Product>(data);


            }
            return View("Create",product);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            String data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage respose = _client.PostAsync(_client.BaseAddress + "/Product/CreateProduct", content).Result;
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create",model);
        }
    }
}
