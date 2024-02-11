using API.ErrorsHandeling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace API.Controllers
{
    public class BuggyController : ApiControllerBase
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFound() // not found product
        {
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() // bad request -> Client\Front-end Send Some Thing Wrong
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("unauthorize")] // when we need to return Unauthorized
        public ActionResult GetUnanouthorizeError(int id)
        {
            return Unauthorized(new ApiResponse(401));
        }

        [HttpGet("badrequest/{id}")] // bad request -> validation error, because id is int and i send string 
        public ActionResult GetBadRequest(int id)
        {
            return Ok(new ApiResponse(400));
        }

        //[HttpGet("servererror")] // server error = exception [null reference exception]
        //public ActionResult GetServerError()
        //{
        //    var product = _storeContext.Products.Find(100);
        //    var productToReturn = product.ToString();
        //    return Ok(productToReturn);
        //}
    }
}
