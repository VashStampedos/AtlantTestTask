using AtlantTest.DB.Entities;
using AtlantTest.Domain.Services.DetailService;
using AtlantTest.Domain.Services.StoreKeeper;
using AtlantTest.DTO.StoreKeeperRequests;
using AtlantTest.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AtlantTest.DTO.DetailRequsts;

namespace AtlantTest.Controllers
{
    public class DetailsController : Controller
    {
        IDetailService detailService;
        public DetailsController(IDetailService detailService)
        {
            this.detailService = detailService;
        }
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var detailsList = await detailService.GetDetailsAsync();
            return Ok(ApiResult<IEnumerable<Detail>>.Success(detailsList));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetail(int id)
        {
            if (id > 0)
            {
                var detail = await detailService.GetDetailAsync(id);
                return Ok(ApiResult<Detail>.Success(detail));

            }
            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail([FromBody] CreateDetailRequest request)
        {
            if (ModelState.IsValid)
            {
                //решить что делать с типом для дат(оставлять стрниг или менять на datetime)
                await detailService.CreateDetailAsync(request.NomenclCode, request.DetailName, request.StorekeeperId, request.DateOfCreation.ToString(), request.DetailCount);
                return Ok(ApiResult<string>.Success("Detail Added"));
            }
            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDetail([FromBody] UpdateDetailRequest request)
        {
            if (ModelState.IsValid)
            {
                await detailService.UpdateDetailAsync(request.Id, request.NomenclCode, request.DetailName, request.StorekeeperId, request.DateOfCreation.ToString(), request.DetailCount);
                return Ok(ApiResult<string>.Success("Detail Updated"));

            }

            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDetail([FromBody] DeleteDetailRequest request)
        {
            if (ModelState.IsValid)
            {
                await detailService.DeleteDetailAsync(request.Id, request.DateOfRemoving);
                return Ok(ApiResult<string>.Success("Detail Deleted"));
            }

            return BadRequest(ApiResult<string>.Failure(HttpStatusCode.BadRequest, new List<string>() { "Invalid Request" }));
        }
        //public async Task<IActionResult> Initialize()
        //{
        //    await detailService.CreateDetailAsync("NOMEN1A", "Шестерня", 1, $"{DateTime.Now}", 10);
        //    await detailService.CreateDetailAsync("NOMEN2A", "Дверь", 2, $"{DateTime.Now}", 0);
        //    await detailService.CreateDetailAsync("NOMEN1B", "Рельса", 3, $"{DateTime.Now}", 11);
        //    await detailService.CreateDetailAsync("NOMEN3A", "Ручка", 1, $"{DateTime.Now}", 4);

        //    return RedirectToAction("Details");
        //}
    }
}
