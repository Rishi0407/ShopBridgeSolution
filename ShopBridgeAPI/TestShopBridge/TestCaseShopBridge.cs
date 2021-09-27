using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridgeAPI.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestShopBridge
{
    [TestClass]
   public class TestCaseShopBridge
    {
        [TestMethod]
        public void TestGetlistItem()
        {

            var mockshops = new List<tblShopBridge>();
            mockshops.Add(new tblShopBridge
            { ID= 1, ProductName= "XYZ", Description = "medicine", Price = 100 });
            mockshops.Add(new tblShopBridge
            { ID = 2, ProductName = "abc", Description = "grocery", Price = 200 });

            var employeeRepositoryMock = TestInitializer.MockShopBridgeRepository;
            employeeRepositoryMock.Setup
                  (x => x.GetItemsbyid(mockshops[0].ID));

            var response = TestInitializer.TestHttpClient.GetAsync("api/ShopBridgeOperation").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<tblShopBridge>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockshops[0].ProductName, responseData[0].ProductName);
        }

        public void TestAddItem()
        {
            object data = new
            {
                ID = 10,
                ProductName = "article",
                Description = "test",
                Price = 300
            };
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = TestInitializer.TestHttpClient.PostAsync("api/ShopBridgeOperation", byteContent).Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<tblShopBridge>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(data, responseData[0].ProductName);
        }
    }
}
