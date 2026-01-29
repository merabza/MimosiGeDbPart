using System.Collections.Generic;
using BackendCarcass.Database.Models;
using BackendCarcass.DataSeeding;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;
using SystemTools.RepositoriesShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewMenuSeeder : MimMenuSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewMenuSeeder(string dataSeedFolder, IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(
        dataSeedFolder, repo, unitOfWork, ESeedDataType.OnlyRules)
    {
    }

    public override List<MenuItm> CreateListByRules()
    {
        var mn = base.CreateListByRules();

        var tempData = DataSeederTempData.Instance;

        MenuItm[] menuItems =
        [
            //HumansAndContracts group
            new()
            {
                MenKey = "Humans",
                MenName = "ადამიანები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("HumansAndContracts"),
                SortId = 1,
                MenLinkKey = "humans",
                MenIconName = "stream"
            },
            new()
            {
                MenKey = "StudentContracts",
                MenName = "მოსწავლეების კონტრაქტები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("HumansAndContracts"),
                SortId = 1,
                MenLinkKey = "studentContracts",
                MenIconName = "stream"
            },
            new()
            {
                MenKey = "TeacherContracts",
                MenName = "მასწავლებლების კონტრაქტები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("HumansAndContracts"),
                SortId = 1,
                MenLinkKey = "teacherContracts",
                MenIconName = "stream"
            },
            //GroupsAndLessons group
            new()
            {
                MenKey = "Groups",
                MenName = "ჯგუფები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("GroupsAndLessons"),
                SortId = 1,
                MenLinkKey = "groups",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = "Lessons",
                MenName = "გაკვეთილები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("GroupsAndLessons"),
                SortId = 1,
                MenLinkKey = "lessons",
                MenIconName = "check-circle"
            },
            //CRM group
            new()
            {
                MenKey = "CrmCalls",
                MenName = "CRM დარეკვები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("CRM"),
                SortId = 1,
                MenLinkKey = "crmCalls",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = UnitOfWork.GetTableName<CrmAnswerType>(),
                MenName = "CRM პასუხების ტიპები",
                MenValue = UnitOfWork.GetTableName<CrmAnswerType>(),
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("CRM"),
                SortId = 1,
                MenLinkKey = "mdList"
            },
            new()
            {
                MenKey = UnitOfWork.GetTableName<CrmCallType>(),
                MenName = "CRM დარეკვის ტიპები",
                MenValue = UnitOfWork.GetTableName<CrmCallType>(),
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("CRM"),
                SortId = 1,
                MenLinkKey = "mdList"
            },
            //Accounting group
            new()
            {
                MenKey = "ChargesAndPayments",
                MenName = "დარიცხვები და გადახდები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Accounting"),
                SortId = 1,
                MenLinkKey = "chargesAndPayments",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = "Deposits",
                MenName = "დეპოზიტები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Accounting"),
                SortId = 1,
                MenLinkKey = "deposits",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = "Payments",
                MenName = "გადახდები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Accounting"),
                SortId = 1,
                MenLinkKey = "payments",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = "Salary",
                MenName = "ხელფასები",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Accounting"),
                SortId = 1,
                MenLinkKey = "salary",
                MenIconName = "check-circle"
            },
            new()
            {
                MenKey = "WorkHours",
                MenName = "სამუშაო საათების შესრულება",
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Accounting"),
                SortId = 1,
                MenLinkKey = "workHours",
                MenIconName = "check-circle"
            },
            //Reports group
            new()
            {
                MenKey = UnitOfWork.GetTableName<ReportCategory>(),
                MenName = "რეპორტების ჯგუფები",
                MenValue = UnitOfWork.GetTableName<ReportCategory>(),
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Reports"),
                SortId = 0,
                MenLinkKey = "mdList"
            },
            new()
            {
                MenKey = UnitOfWork.GetTableName<Report>(),
                MenName = "რეპორტები",
                MenValue = UnitOfWork.GetTableName<Report>(),
                MenGroupId = tempData.GetIntIdByKey<MenuGroup>("Reports"),
                SortId = 0,
                MenLinkKey = "mdList"
            }
        ];
        mn.AddRange(menuItems);
        return mn;
    }
}

//რეპორტების კატეგორიები
//ID ReportCategoryName
//1	ყველა
//2	გაკვეთილების ცხრილი
//3	ჯგუფები
//4	კომენტარები
//5	გაკვეთილები
//6	ფინანსები
//7	შემოწმება

//რეპორტები
//ID Description ReportName RepFltNames
//28	დროების აცდენილი გადასვლები r28DayTimesMissDate
//13	შეცდომიანი გაკვეთილები  r13LessonsWithErrors	
//9	ოპტიმიზაციის შესაძლებლობა   r09Optimization	
//22	კვირის დღეების არასწორი ცვლილებები  r22	
//15	შავი სია    r15BlackList	
//27	მასწავლებლების აცდელინი გადასვლები r27TeacherMissDate
//29	მასწავლებლების აცდენილი ხელფასები r29TeacherMissSalary
//30	მოსწავლის სწავლის საფასურის აცდენა  r30StudentMissFees	
//31	მოსწავლის სწავლის დაწყება და დამთავრება ერთიდაიგივე თარიღზე r31StudSameStartEndDate
//32	მასწავლებლის ჯგუფში მუშაობის დაწყება და დამთავრება ერთიდაიგივე თარიღზე  r32TeachSameStartEndDate	
//33	დღეების განაწილება დაწყებული და დამთავრებული ერთიდაიგივე თარიღზე r33DTPSameStartEndDate
//26	მოსწავლეების აცდელინი გადასვლები r26StudMissDate
//20	მოსწავლეები დარეგისტრირებული ერთ საგანზე რამდენჯერმე r20StudentDoubleCources EndDate
//5	მასწავლებლების ცხრილი   r05TeachersAgenda EndDate
//6	ოთახების გადაფარვა  r06RoomOver EndDate
//7	დატვირთვა დღეებისა და საათების მიხედვით r07UsedDayTimes EndDate
//8	შეუვსებელი ჯგუფები  r08LessSizeGroups EndDate
//4	მოსწავლეების ცხრილი r04StudentsAgenda EndDate
//3	ოთახების ცხრილი r03RoomsAgenda EndDate
//21	მასწავლებლები დარეგისტრირებული ერთ ჯგუფში რამდენჯერმე r21TeacherDoubleGroups  EndDate
//35	მასწავლებლების დროის ხაზების გადაფარვა  r35TeacherLineOver EndDate
//24	ჯგუფების ოპტიმიზაციის შესაძლებლობა r24GroupsOptimization   EndDate
//18	მასწავლებლების დროების გადაფარვა r18TeacherOver  EndDate
//23	ჯგუფების ზომების ანალიზი r23GroupSizesAnalize    EndDate
//17	ზედიზედ გაცდენები   r17MissingsInRow EndDate
//19	მოსწავლეების დროების გადაფარვა r19StudentOver  EndDate
//1	დღის კომენტარები 1 თვისთვის r01Comments EndDate,TeacherID
//2	თვის შემაჯამებელი კომენტარები r02SummaryComments  EndDate,TeacherID
//10	ჯგუფები r10Groups   EndDate,TeacherID,CourceID,StudentID
//11	გასაუქმებელი გაკვეთილები    r11WrongStatuseLessons StartDate, EndDate
//12	არასწორად გაუქმებული გაკვეთილები r12LessonsWithWrongVoidStatus   StartDate,EndDate
//14	გაცდენები r14Missings StartDate,EndDate
//34	გაუქმებები და ჩანაცვლებები r34TeacherMissAndSubstitutes    StartDate,EndDate
//36	სამუშაო დროის აღრიცხვის ფორმა   r36 StartDate, EndDate
//25	მასწავლებლების გამომუშავებული ხელფასი ჯგუფების მიხედვით r25TecherSalaryByGroups StartDate,EndDate,TeacherID

//რეპორტები კატეგორიების მიხედვით
//ID ReportCategoryID    ReportID
//23	გაკვეთილები r11WrongStatuseLessons
//25	გაკვეთილები r12LessonsWithWrongVoidStatus
//27	გაკვეთილები r13LessonsWithErrors
//28	გაკვეთილები r14Missings
//33	გაკვეთილები r17MissingsInRow
//43	გაკვეთილები r22
//6	გაკვეთილების ცხრილი r03RoomsAgenda
//7	გაკვეთილების ცხრილი r04StudentsAgenda
//8	გაკვეთილების ცხრილი r05TeachersAgenda
//9	გაკვეთილების ცხრილი r06RoomOver
//12	გაკვეთილების ცხრილი r07UsedDayTimes
//36	გაკვეთილების ცხრილი r18TeacherOver
//37	გაკვეთილების ცხრილი r19StudentOver
//40	გაკვეთილების ცხრილი r20StudentDoubleCources
//41	გაკვეთილების ცხრილი r21TeacherDoubleGroups
//20	კომენტარები r01Comments
//21	კომენტარები r02SummaryComments
//31	ფინანსები r15BlackList
//64	ფინანსები r25TecherSalaryByGroups
//1	ყველა r01Comments
//2	ყველა r02SummaryComments
//3	ყველა r03RoomsAgenda
//4	ყველა r04StudentsAgenda
//5	ყველა r05TeachersAgenda
//10	ყველა r06RoomOver
//11	ყველა r07UsedDayTimes
//14	ყველა r08LessSizeGroups
//16	ყველა r09Optimization
//19	ყველა r10Groups
//22	ყველა r11WrongStatuseLessons
//65	ყველა r12LessonsWithWrongVoidStatus
//26	ყველა r13LessonsWithErrors
//29	ყველა r14Missings
//30	ყველა r15BlackList
//32	ყველა r17MissingsInRow
//34	ყველა r18TeacherOver
//35	ყველა r19StudentOver
//38	ყველა r20StudentDoubleCources
//39	ყველა r21TeacherDoubleGroups
//42	ყველა r22
//44	ყველა r23GroupSizesAnalize
//46	ყველა r24GroupsOptimization
//67	ყველა r25TecherSalaryByGroups
//68	ყველა r26StudMissDate
//70	ყველა r27TeacherMissDate
//73	ყველა r28DayTimesMissDate
//75	ყველა r29TeacherMissSalary
//77	ყველა r30StudentMissFees
//79	ყველა r31StudSameStartEndDate
//81	ყველა r32TeachSameStartEndDate
//83	ყველა r33DTPSameStartEndDate
//86	ყველა r34TeacherMissAndSubstitutes
//87	ყველა r35TeacherLineOver
//89	ყველა r36
//54	შემოწმება r06RoomOver
//55	შემოწმება r07UsedDayTimes
//60	შემოწმება r08LessSizeGroups
//61	შემოწმება r09Optimization
//48	შემოწმება r11WrongStatuseLessons
//49	შემოწმება r12LessonsWithWrongVoidStatus
//50	შემოწმება r13LessonsWithErrors
//51	შემოწმება r14Missings
//52	შემოწმება r17MissingsInRow
//56	შემოწმება r18TeacherOver
//57	შემოწმება r19StudentOver
//58	შემოწმება r20StudentDoubleCources
//59	შემოწმება r21TeacherDoubleGroups
//53	შემოწმება r22
//62	შემოწმება r23GroupSizesAnalize
//63	შემოწმება r24GroupsOptimization
//69	შემოწმება r26StudMissDate
//71	შემოწმება r27TeacherMissDate
//74	შემოწმება r28DayTimesMissDate
//76	შემოწმება r29TeacherMissSalary
//78	შემოწმება r30StudentMissFees
//80	შემოწმება r31StudSameStartEndDate
//82	შემოწმება r32TeachSameStartEndDate
//84	შემოწმება r33DTPSameStartEndDate
//85	შემოწმება r34TeacherMissAndSubstitutes
//88	შემოწმება r35TeacherLineOver
//15	ჯგუფები r08LessSizeGroups
//17	ჯგუფები r09Optimization
//18	ჯგუფები r10Groups
//45	ჯგუფები r23GroupSizesAnalize
//47	ჯგუფები r24GroupsOptimization
