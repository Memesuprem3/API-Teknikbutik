using API_Teknikbutik.Services;
using API_Teknikbutiken_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Teknikbutik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ITeknikButik<Product> _teknikbutik;

        public ProductController(ITeknikButik<Product> teknikbutik)
        {
            _teknikbutik = teknikbutik;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _teknikbutik.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await _teknikbutik.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateNewProduct(Product newPro)
        {
            try
            {
                if (newPro == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _teknikbutik.Add(newPro);
                return CreatedAtAction(nameof(GetAllProduct),
                    new {id = createdProduct.ProductId},createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
               var productToDelete = await _teknikbutik.GetSingel(id);
                if(productToDelete == null)
                {
                    return NotFound($"Prodcut with ID {id} Not found to for deleting");
                }
                return await _teknikbutik.Delete(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data in the database");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product pro)
        {
            try
            {
                if(id != pro.ProductId)
                {
                    return BadRequest($"Product ID does not match");
                }
              var productToUpdate =  await _teknikbutik.GetSingel(id);
                if(productToUpdate == null)
                {
                    return NotFound($"Product with ID {id} not found to update");
                }
                return await _teknikbutik.Update(pro);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data in the database");
            }
        }   
    }
}
