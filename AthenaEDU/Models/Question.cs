using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> AnswerOptions { get; set; }
        public Question() { }
        public Question(string text, string correctAnswer, List<string> answerOptions)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            AnswerOptions = answerOptions;
        }
    }
}
