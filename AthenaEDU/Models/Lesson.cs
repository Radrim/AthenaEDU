﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Lesson
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public List<LessonData> LessonDatas { get; private set; } = new List<LessonData>();

        public Lesson() { }

        public Lesson(string name, List<LessonData> lessonData)
        {
            Name = name;
            LessonDatas = lessonData;
        }
    }
}
