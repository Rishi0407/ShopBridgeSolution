using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridgeAPI.Model;

namespace ShopBridgeAPI.Helper
{
    public class ShopBridgeHelper
    {
        private readonly ShopBridgeContext _dbContext;
        public ShopBridgeHelper(ShopBridgeContext context)
        {
            _dbContext = context;
        }

        public async Task AddItems(tblShopBridge tblShopBridge)
        {
            await AddItemDetails(tblShopBridge, _dbContext);
        }

        public async Task EditItems(tblShopBridge tblShopBridge)
        {
            await EditItemDetails(tblShopBridge, _dbContext);
        }

        public async Task DeleteItems(int id)
        {
            await DeleteItemDetails(id, _dbContext);
        }

        public async Task<List<tblShopBridge>> ListAllItemDetail()
        {
            return await ListAllItemDetails(_dbContext);
        }

            public async Task<tblShopBridge> GetItemsbyid(int id)
        {
            return await ListItemDetailsbyid(id, _dbContext);
        }

        private async Task AddItemDetails(tblShopBridge tblShopBridge, ShopBridgeContext context)
        {
            await Task.Run(() => context.tblShopBridge.Add(tblShopBridge));
            context.SaveChanges();
        }

        private async Task EditItemDetails(tblShopBridge tblShopBridge, ShopBridgeContext context)
        {

            await Task.Run(() => context.tblShopBridge.Update(tblShopBridge));
            context.SaveChanges();
        }

        private async Task DeleteItemDetails(int id, ShopBridgeContext context)
        {

            tblShopBridge tblShopBridgedel = context.tblShopBridge.Find(id);
            await Task.Run(() => context.tblShopBridge.Remove(tblShopBridgedel));
            context.SaveChanges();


        }

        private async Task<tblShopBridge> ListItemDetailsbyid(int id, ShopBridgeContext context)
        {

            // await Task.Run(() => context.tblShopBridge.se(tblShopBridge));
            tblShopBridge objtblshopbridge = new tblShopBridge();
            
                var result = await Task.Run(() => context.tblShopBridge.AsEnumerable().Where(x=>x.ID==id)
            .Select(x => x)
            .ToList());
                foreach (var obj in result)
                {
                    objtblshopbridge.ID = obj.ID;
                    objtblshopbridge.ProductName = obj.ProductName;
                    objtblshopbridge.Description = obj.Description;
                    objtblshopbridge.Price = obj.Price;
                }
                return objtblshopbridge;
            


        }

        private async Task<List<tblShopBridge>> ListAllItemDetails(ShopBridgeContext context)
        {

            // await Task.Run(() => context.tblShopBridge.se(tblShopBridge));
            List<tblShopBridge> listtblShopBridge = new List<tblShopBridge>();
            
                var result = await Task.Run(() => context.tblShopBridge.ToList());
                foreach (var obj in result)
                {
                tblShopBridge objtblshopbridge = new tblShopBridge();
                    objtblshopbridge.ID = obj.ID;
                    objtblshopbridge.ProductName = obj.ProductName;
                    objtblshopbridge.Description = obj.Description;
                    objtblshopbridge.Price = obj.Price;
                    listtblShopBridge.Add(objtblshopbridge);
                }
                return listtblShopBridge;
            


        }
    }
}
