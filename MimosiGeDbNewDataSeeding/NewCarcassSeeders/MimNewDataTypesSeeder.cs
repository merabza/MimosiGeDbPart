using System.Collections.Generic;
using BackendCarcass.Database.Factories;
using BackendCarcass.Database.Models;
using BackendCarcass.DataSeeding;
using CarcassDataSeeding;
using CarcassDb.Factories;
using CarcassDb.Models;
using DatabaseToolsShared;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewDataTypesSeeder : MimDataTypesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataTypesSeeder(string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo) : base(carcassRepo, dataSeedFolder, repo, ESeedDataType.OnlyRules)
    {
    }

    public override List<DataType> CreateListByRules()
    {
        var mn = base.CreateListByRules();

        var newDataTypes = new[]
        {
            //AcademicYear
            DataTypeFactory.Create("აკადემიური წლები", "აკადემიური წელი", "აკადემიური წლის",
                DataSeederRepo.GetTableName<AcademicYear>(), nameof(AcademicYear.AyId), null,
                nameof(AcademicYear.AcademicYearName), null, null, null,
                GetDateOnlyCell(nameof(AcademicYear.StartDate), "სასწავლო წლის დასაწყისი"),
                GetDateOnlyCell(nameof(AcademicYear.FinishDate), "სასწავლო წლის დასასრული")),

            //BankAccounts
            DataTypeFactory.Create("ბანკის ანგარიშები", "ბანკის ანგარიში", "ბანკის ანგარიშის",
                DataSeederRepo.GetTableName<BankAccount>(), nameof(BankAccount.BaId), null,
                nameof(BankAccount.BankCode), null, nameof(BankAccount.BankName), null,
                GetDateOnlyCell(nameof(BankAccount.AccountNumber), "ანგარიშის ნომერი"),
                GetDateOnlyCell(nameof(BankAccount.DesperateDebt), "უიმედო ვალი")),

            //Courses
            DataTypeFactory.Create("საგნები", "საგანი", "საგნის", DataSeederRepo.GetTableName<Course>(),
                nameof(Course.CrsId), null, nameof(Course.CourseName), null, null, null),

            //CrmAnswerType
            DataTypeFactory.Create("მომხმარებლების პასუხების ტიპები", "მომხმარებლების პასუხის ტიპი",
                "მომხმარებლების პასუხის ტიპი", DataSeederRepo.GetTableName<CrmAnswerType>(),
                nameof(CrmAnswerType.CatId), null, nameof(CrmAnswerType.CatKey), null,
                nameof(CrmAnswerType.AnswerTypeName), null),

            //CrmCallType
            DataTypeFactory.Create("მომხმარებლებთან ზარების ტიპები", "მომხმარებლებთან ზარის ტიპი",
                "მომხმარებლებთან ზარის ტიპის", DataSeederRepo.GetTableName<CrmCallType>(), nameof(CrmCallType.CctId),
                null, nameof(CrmCallType.CallTypeName), null, null, null),

            //ErrorLogTexts
            DataTypeFactory.Create("შეცდომების ლოგების ტექსტები", "შეცდომის ლოგის ტექსტი", "შეცდომის ლოგის ტექსტის",
                DataSeederRepo.GetTableName<ErrorLogText>(), nameof(ErrorLogText.EltId), null,
                nameof(ErrorLogText.Text), null, null, null),

            //GeoMonths
            DataTypeFactory.Create("თვეები", "თვე", "თვის", DataSeederRepo.GetTableName<GeoMonth>(),
                nameof(GeoMonth.GmnId), null, nameof(GeoMonth.GmnName), null, nameof(GeoMonth.GmnDative), null),

            //Groups
            DataTypeFactory.Create("ჯგუფები", "ჯგუფი", "ჯგუფის", DataSeederRepo.GetTableName<Group>(),
                nameof(Group.GrpId), null, nameof(Group.GroupCode), null, null, null,
                GetMdComboCell(nameof(Group.CourseId), "საგანი", DataSeederRepo.GetTableName<Course>()),
                GetMdComboCell(nameof(Group.GroupSizeId), "ჯგუფის ზომა", DataSeederRepo.GetTableName<GroupSize>()),
                GetMdComboCell(nameof(Group.StudentStatusId), "მოსწავლის სტატუსი",
                    DataSeederRepo.GetTableName<StudentStatus>()),
                GetDateOnlyCell(nameof(Group.VoidDate), "ჯგუფის გაუქმების თარიღი")),

            //GroupSizes
            DataTypeFactory.Create("ჯგუფების ზომები", "ჯგუფის ზომა", "ჯგუფის ზომის",
                DataSeederRepo.GetTableName<GroupSize>(), nameof(GroupSize.GrsId), null, nameof(GroupSize.GrsSize),
                null, nameof(GroupSize.GrsName), null)
        };

        mn.AddRange(newDataTypes);

        return mn;
    }
}
