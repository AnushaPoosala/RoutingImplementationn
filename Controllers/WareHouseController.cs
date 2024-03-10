using Microsoft.AspNetCore.Mvc;
using RoutingImplementation.Models;

namespace RoutingImplementation.Controllers
{
    [Route("WAStore")]
    public class WareHouseController : Controller
    {
        List<Product> products;

        
        public WareHouseController()
        {
            products = new List<Product> () 
            { 
                new Product() { ProductId=1,ProductName="Laptop",IsInStock=true,ProductDescription="CoreI7",StockCount=12},
                new Product() { ProductId=2,ProductName="TV",IsInStock=true,ProductDescription="32Inch",StockCount=120},
                new Product() { ProductId=3,ProductName="Fridge",IsInStock=false,ProductDescription="5Star",StockCount=1200},
                new Product() { ProductId=4,ProductName="Sofa",IsInStock=true,ProductDescription="5 seater",StockCount=12000},
            };
        }

        //[Route("WareHouse/GetJsonData")] -- Without Route on Controller name
        [Route("GetData")]  // With Route() on Controller name
        public IActionResult GetJsonData()
        {
            return Json(products);
        }

        [Route("GetJsonData/{productId}")] // For Param value to pass in Attribute routing
        public IActionResult GetJsonData(int productId)
        {
            return Json(products.Where(product=>product.ProductId==productId).FirstOrDefault());
        }

        //(You have to specify the ? post the param name)
        [Route("GetJsonWareHouseData/{isFromVendor?}")] // For Optional Param value to pass in Attribute routing 
        public JsonResult GetJsonWareHouseData(string isFromVendor="Yes")
        {
            if(isFromVendor == "Yes")
            {
                return Json(products);
            }
            else
                return Json(products.Where(product=>product.IsInStock==true));
        }

        // For adding param validation we can specify the Constraint name post the param name and put the : symbol
        //[Route("GetJsonWareHouseData/{isFromAI:AlphabetWithNumericOurOwnName}")]
        //public JsonResult GetJsonWareHouseDataAnalytic(string isFromAI = "Yes")
        //{
        //    if (isFromAI == "Yes")
        //    {
        //        return Json(products);
        //    }
        //    else
        //    {
        //        return Json(products.Where(prodcut => prodcut.IsInStock == true));
        //    }
        //}
        public IActionResult GetProdcutList()
        {
            return View(products);
        }

        [Route("~/product/{productIdValue}/info")]
        public IActionResult GetProdcutInfoByProdId(int productIdValue)
        {
            Product? product = products.Where(prod => prod.ProductId == productIdValue).FirstOrDefault();

            return View(product);
        }

        [HttpPost("~/AboutWareHouse")]
        public JsonResult GetWareHouseDetails()
        {
            return Json("It is located in AP");
        }

        [Route("~/AboutWareHouse1")]
        public JsonResult GetWareHouseDetails1()
        {
            return Json("It is located in AP");
        }
    }
}
