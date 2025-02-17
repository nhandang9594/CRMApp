﻿using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;
        public ProductController(IProductServiceAsync productServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await productServiceAsync.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"Region with Id = {id} is not available");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var result = await productServiceAsync.AddProductAsync(model);
            if(result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductRequestModel model)
        {
            var result = await productServiceAsync.UpdateProductAsync(model);
            if(result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productServiceAsync.DeleteProductAsync(id);
            if(result != 0)
            {
                return Ok("Product Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
