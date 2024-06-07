using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using AthenaEDU.Models;

namespace AthenaEDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IMongoCollection<LessonData> _filesCollection;

        public FilesController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AthenaEDU_DB");
            _filesCollection = database.GetCollection<LessonData>("Files");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromBody] LessonData fileModel)
        {
            try
            {
                await _filesCollection.InsertOneAsync(fileModel);
                return Ok();
            }
            catch (Exception ex)
            {
                // Обработка ошибки при сохранении файла в MongoDB
                return StatusCode(500, $"Произошла ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}