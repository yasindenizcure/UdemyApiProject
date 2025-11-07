using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TInsert(messageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            if (values == null)
            {
                return NotFound($"ID {id} numaralı misafir bulunamadı.");
            }
            _messageCategoryService.TDelete(values);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMessageCategory(int id, MessageCategory messageCategory)
        {
            var existingMessageCategory = _messageCategoryService.TGetById(id);
            if (existingMessageCategory == null)
                return NotFound();
            existingMessageCategory.MessageCategoryId = messageCategory.MessageCategoryId;
            existingMessageCategory.MessageCategoryName = messageCategory.MessageCategoryName;

            _messageCategoryService.TUpdate(existingMessageCategory);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            return Ok(values);
        }
    }
}
