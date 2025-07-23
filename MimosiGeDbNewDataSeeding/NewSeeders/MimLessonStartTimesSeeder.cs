//using System;
//using System.Collections.Generic;
//using DatabaseToolsShared;
//using MimosiGeDb.Models;
//using MimosiGeDbDataSeeding;
//using MimosiGeDbDataSeeding.Models;

//namespace MimosiGeDbNewDataSeeding.NewSeeders;

//public sealed class MimLessonStartTimesSeeder : MimDataSeeder<LessonStartTime, LessonStartTimeSeederModel>
//{
//    // ReSharper disable once ConvertToPrimaryConstructor
//    public MimLessonStartTimesSeeder(string dataSeedFolder, IMimDataSeederRepository repo) : base(dataSeedFolder, repo,
//        ESeedDataType.OnlyRules, [nameof(LessonStartTime.LstId)])
//    {
//    }

//    public override List<LessonStartTime> CreateListByRules()
//    {
//        List<LessonStartTime> records = [];

//        var lastLessonStartTime = DateTime.MinValue.AddHours(21);
//        for (var i = DateTime.MinValue.AddHours(8); i <= lastLessonStartTime; i = i.AddMinutes(30))
//            records.Add(new LessonStartTime { LstTime = i });
//        return records;
//    }
//}