using API.ModelBinders;
using DomainModel.Responses;
using Entities.DAOs;
using Entities.DTOs.CRUD;
using Entities.RequestFeatures;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IApplicationServices;
using System.Text.Json;

namespace API.Presentation.Controllers
{
    [Route("api/phong-ban")]
    [ApiController]
    public class PhongBanController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllPhongBan([FromQuery] PhongBanParameters phongBanParameters)
        {
            var (departments, metaData) = await _service.PhongBanService.GetAllPhongBan(phongBanParameters, trackChanges: false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metaData);

            var response = new ResponseBase<IEnumerable<PhongBanDTO>>
            {
                Data = departments,
                Message = ResponseMessage.GetDeparmentSuccess,
            };

            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "DeparmetById")]
        public async Task<IActionResult> GetPhongBan(Guid id)
        {
            var department = await _service.PhongBanService.GetPhongBan(id, trackChanges: false);

            var response = new ResponseBase<PhongBanDTO>
            {
                Data = department,
                Message = ResponseMessage.GetDeparmentSuccess,
            };

            return Ok(response);
        }

        [HttpGet("collection/({ids})", Name = "ClassCollection")]
        public async Task<IActionResult> GetPhongBanCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var departments = await _service.PhongBanService.GetByIdsAsync(ids, trackChanges: false);

            var response = new ResponseBase<IEnumerable<PhongBanDTO?>>
            {
                Data = departments,
                Message = ResponseMessage.GetDeparmentsSuccess,
            };

            return Ok(response);
        }

       

        [HttpPost]
        public async Task<IActionResult> CreatePhongBan([FromBody] PhongBanForCreationDTO phongBanForCreationDTO)
        {
            if (phongBanForCreationDTO is null)
                return BadRequest("PhongBanForCreationDTO object is null");

            var createPhongBan = await _service.PhongBanService.CreatePhongBan(phongBanForCreationDTO);

            return CreatedAtRoute("DeparmetById", new { id = createPhongBan.Idpb }, createPhongBan);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePhongBan(Guid id, [FromBody] PhongBanForUpdateDTO phongBanForUpdateDTO)
        {
            if (phongBanForUpdateDTO is null)
                return BadRequest("PhongBanForCreationDTO object is null");

            await _service.PhongBanService.UpdatePhongBan(id, phongBanForUpdateDTO, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClass(Guid id)
        {
            await _service.PhongBanService.DeletePhongBan(id, trackChanges: true);
            return NoContent();
        }
    }
}
