using AtlantTest.DB.Entities;
using AtlantTest.Domain.Services.StoreKeeper;
using AtlantTest.DTO;
using AtlantTest.DTO.StoreKeeperRequests;
using Azure.Core;
using Azure.Core.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AtlantTest.Controllers
{
    public class StoreController : Controller
    {
        IStoreKeeperService storeKeeperService;
        public StoreController(IStoreKeeperService storeKeeperService)
        {
            this.storeKeeperService = storeKeeperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreKeepers()
        {
            var storeKeeperList =  await storeKeeperService.GetStoreKeepers();
            return Ok(ApiResult<IEnumerable<Storekeeper>>.Success(storeKeeperList));
            
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreKeeper(int id)
        {
            if (id > 0)
            {
                var storeKeeper = await storeKeeperService.GetStoreKeeper(id);
                return Ok(ApiResult<Storekeeper>.Success(storeKeeper));

            }
            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStoreKeeper([FromBody] CreateStoreKeeperRequest request)
        {
            if (ModelState.IsValid)
            {
                await storeKeeperService.CreateStoreKeeper(request.FIO);
                return Ok(ApiResult<string>.Success("StoreKeeper Added"));
            }
            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStoreKeeper([FromBody] UpdateStoreKeeperRequest request)
        {
            if (ModelState.IsValid)
            {
                await storeKeeperService.UpdateStoreKeeper(request.Id, request.FIO);
                return Ok(ApiResult<string>.Success("StoreKeeper Updated"));

            }

            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStoreKeeper(int id)
        {
            if (id > 0)
            {
                await storeKeeperService.DeleteStoreKeeper(id);
                return Ok(ApiResult<string>.Success("StoreKeeper Deleted"));
            }

            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        //public async Task<IActionResult> Initialize()
        //{
        //    await storeKeeperService.CreateStoreKeeper("Петров Петр Петрович");
        //    await storeKeeperService.CreateStoreKeeper("Иванов Иван Иванович");
        //    await storeKeeperService.CreateStoreKeeper("Сидоров Евгений Аркадьевич");
        //    await storeKeeperService.CreateStoreKeeper("Семенов Алексей Герундиевич");
        //    return RedirectToAction("GetStoreKeepers");
        //}
    }
}
