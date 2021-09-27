using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeAPI.Helper;
using ShopBridgeAPI.Model;

namespace ShopBridgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBridgeOperationController : ControllerBase
    {
        private readonly ShopBridgeHelper _helper;
        public ShopBridgeOperationController(ShopBridgeHelper helper)
        {
            _helper = helper;
        }
        [HttpPost]
        public async Task AddItems(tblShopBridge tblShopBridge)
        {
            await _helper.AddItems(tblShopBridge);

        }

        [HttpPut]
        public async Task EditItems(tblShopBridge tblShopBridge)
        {
            await _helper.EditItems(tblShopBridge);

        }
        [HttpDelete]
        public async Task DeleteItems(int id)
        {
            await _helper.DeleteItems(id);

        }
        [HttpGet]
        public async Task<tblShopBridge> ListItemsbyid(int id)
        {
            return await _helper.GetItemsbyid(id);

        }



        [HttpGet]
        [Route("GetAllItem")]
        public async Task<List<tblShopBridge>> GetAllItemDetail()
        {
            return await _helper.ListAllItemDetail();

        }
    }
}