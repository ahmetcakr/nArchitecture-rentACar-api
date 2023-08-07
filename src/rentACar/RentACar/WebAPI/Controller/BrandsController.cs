using Application.Features.Brands.Commands.Create;
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
        
}
