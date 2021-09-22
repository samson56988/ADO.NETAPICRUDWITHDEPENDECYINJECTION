using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADONETCRUDAPI2.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ADONETCRUDAPI2.Controllers.UI
{
    public class CustomerUIController : Controller
    {
        // GET: CustomerUI
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Customer> customer = new List<Customer>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:3040/api/Customer"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);

                }
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:3040/api/Customer",content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        customer = JsonConvert.DeserializeObject<Customer>(apiResponse);

                    }
                }
                return View(customer);
            }

            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult>Edit(int id)
        {
            Customer customer = new  Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:3040/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);

                }
            }
            return View(customer);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult>Edit(Customer customer)
        {
            

            if(ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("http://localhost:3040/api/Customer/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        customer = JsonConvert.DeserializeObject<Customer>(apiResponse);

                    }
                }
            }
            return View(customer); 
        }
        
        
        public async System.Threading.Tasks.Task<ActionResult>Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.DeleteAsync("http://localhost:3040/api/Customer/" +id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                
                }
            }

            return RedirectToAction("Index");
        }


    }
}