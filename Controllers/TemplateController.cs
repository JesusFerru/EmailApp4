using Microsoft.AspNetCore.Mvc;

namespace EmailApp4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }



        //------------------------------------------------------------------------------------------
        // GET: Templates
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetTemplate();
            return _service.GetTemplate() != null ?
                       Ok(result) :
                        NotFound();
        }

        // GET: Templates/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniqueTemplate(int id)
        {
            /*       if (id == null || _service.GetTemplate() == null)
                   {
                       return NotFound();
                   }*/

            var emailTemplate = await _service.GetUniqueTemplate(id);

            if (id == null || emailTemplate == null)
            {
                return NotFound();
            }

            return Ok(emailTemplate);
        }

        //------------------------------------------------------------------------------------------

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmailTemplate body)
        {
            var result = await _service.PostTemplate(body);

            return Ok(result);
        }

//------------------------------------------------------------------------------------------

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmailTemplate body)
        {

            var result = await _service.PutTemplate(id, body);
            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();
        }

//---------------------------------------------------------------------------------------------

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _service.DeleteTemplate(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();

        }
    }
}
