using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CreateBrandCommand createBrandCommand)
    {
        CreatedBrandResponse createdBrandResponse = await Mediator.Send(createBrandCommand);
        return Ok(createdBrandResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new () { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> getListBrandResponse = await Mediator.Send(getListBrandQuery);
        return Ok(getListBrandResponse); 
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
        GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse updatedBrandResponse = await Mediator.Send(updateBrandCommand);
        
        return Ok(updatedBrandResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new() { Id = id };
        DeletedBrandResponse deletedBrandResponse = await Mediator.Send(deleteBrandCommand);

        return Ok(deletedBrandResponse);
    }
}
