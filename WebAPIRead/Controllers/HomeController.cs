using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIRead.Models;

namespace WebAPIRead.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string url = "http://localhost:8456/API/Contact";
            var restApiDataList = new ReadDataManager(new ReadRestApi()); // buradan hangisini new ile türetirsek o class aktif olacak.
            var restList = restApiDataList.ReadData(url);
            
            string xmlUrl = @"C:\Users\nmeti\source\repos\WebAPIExample\WebAPIRead\DataFolder\exampleData.xml";
            var xmlDataList = new ReadDataManager(new ReadXml());
            var xmlList = xmlDataList.ReadData(xmlUrl);

            string excelUrl = @"C:\Users\nmeti\source\repos\WebAPIExample\WebAPIRead\DataFolder\excel.xlsx";
            var excelDataList = new ReadDataManager(new ReadExcel());
            var excelList = excelDataList.ReadData(excelUrl);

            return View(restList);
        }
    }
}