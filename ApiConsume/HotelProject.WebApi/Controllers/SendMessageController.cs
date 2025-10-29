using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public IActionResult GetSendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            if (values == null)
            {
                return NotFound($"ID {id} numaralı mesaj bulunamadı.");
            }
            _sendMessageService.TDelete(values);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSendMessage(int id, SendMessage sendMessage)
        {
            var existingSendMessage = _sendMessageService.TGetById(id);
            if (existingSendMessage == null)
                return NotFound();

            existingSendMessage.SenderName = sendMessage.SenderName;
            existingSendMessage.SenderMail = sendMessage.SenderMail;
            existingSendMessage.ReceiverMail = sendMessage.ReceiverMail;
            existingSendMessage.ReceiverName = sendMessage.ReceiverName;
            existingSendMessage.Title = sendMessage.Title;
            existingSendMessage.Content = sendMessage.Content;
            existingSendMessage.Date = sendMessage.Date;
            _sendMessageService.TUpdate(existingSendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            return Ok(values);
        }
    }
}
