using System;
using System.Collections.Generic;
using CarcassDataSeeding;
using CarcassDb.Models;
using CarcassMasterDataDom;
using CarcassMasterDataDom.CellModels;
using DatabaseToolsShared;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using MimosiGeDbMasterDataDom;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SystemToolsShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewDataTypesSeeder : MimDataTypesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataTypesSeeder(string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo) : base(carcassRepo, dataSeedFolder, repo, ESeedDataType.OnlyRules)
    {
    }

    protected override bool SetParentDataTypes()
    {
        var tempData = DataSeederTempData.Instance;

        var dtdtdt = new Tuple<int, int, int>[]
        {
            new(tempData.GetIntIdByKey<DataType>(EMimosiGeDataTypeKeys.InflectionTypeToCrudType.ToDtKey()),
                tempData.GetIntIdByKey<DataType>(EMimosiGeDataTypeKeys.InflectionType.ToDtKey()),
                tempData.GetIntIdByKey<DataType>(ECarcassDataTypeKeys.CrudRightType.ToDtKey())),
            new(tempData.GetIntIdByKey<DataType>(EMimosiGeDataTypeKeys.DerivationTypeToCrudType.ToDtKey()),
                tempData.GetIntIdByKey<DataType>(EMimosiGeDataTypeKeys.DerivationType.ToDtKey()),
                tempData.GetIntIdByKey<DataType>(ECarcassDataTypeKeys.CrudRightType.ToDtKey()))
        };

        return CarcassRepo.SetManyToManyJoinParentChildDataTypes(dtdtdt) && base.SetParentDataTypes();
    }

    protected override bool RemoveRedundantDataTypes()
    {
        string[] toRemoveTableNames = ["verbPersonMarkerCombinationFormulaDetails"];
        return CarcassRepo.RemoveRedundantDataTypesByTableNames(toRemoveTableNames) && base.RemoveRedundantDataTypes();
    }

    protected override List<DataType> CreateListByRules()
    {
        var mn = base.CreateListByRules();

        var classifierDKey = EMimosiGeDataTypeKeys.Classifier.ToDtKey();
        var actantGrammarCaseDKey = EMimosiGeDataTypeKeys.ActantGrammarCase.ToDtKey();
        var actantGroupDKey = EMimosiGeDataTypeKeys.ActantGroup.ToDtKey();
        var actantPositionDKey = EMimosiGeDataTypeKeys.ActantPosition.ToDtKey();
        var actantTypeDKey = EMimosiGeDataTypeKeys.ActantType.ToDtKey();
        var grammarCaseDKey = EMimosiGeDataTypeKeys.GrammarCase.ToDtKey();

        //IssueKind.DKey
        var issueKindDKey = EMimosiGeDataTypeKeys.IssueKind.ToDtKey();

        //IssuePriority.DKey
        var issuePriorityDKey = EMimosiGeDataTypeKeys.IssuePriority.ToDtKey();

        //IssueStatus.DKey
        var issueStatusDKey = EMimosiGeDataTypeKeys.IssueStatus.ToDtKey();

        //NounNumber.DKey
        var nounNumberDKey = EMimosiGeDataTypeKeys.NounNumber.ToDtKey();

        //NounParadigm.DKey
        var nounParadigmDKey = EMimosiGeDataTypeKeys.NounParadigm.ToDtKey();

        //RecordStatus.DKey
        var recordStatusDKey = EMimosiGeDataTypeKeys.RecordStatus.ToDtKey();

        //VerbNumber.DKey
        var verbNumberDKey = EMimosiGeDataTypeKeys.VerbNumber.ToDtKey();

        //VerbParadigm.DKey
        var verbParadigmDKey = EMimosiGeDataTypeKeys.VerbParadigm.ToDtKey();

        //VerbPerson.DKey
        var verbPersonDKey = EMimosiGeDataTypeKeys.VerbPerson.ToDtKey();

        //VerbPluralityType.DKey
        var verbPluralityTypeDKey = EMimosiGeDataTypeKeys.VerbPluralityType.ToDtKey();

        //VerbSeries.DKey
        var verbSeriesDKey = EMimosiGeDataTypeKeys.VerbSeries.ToDtKey();

        //VerbTransition.DKey
        var verbTransitionDKey = EMimosiGeDataTypeKeys.VerbTransition.ToDtKey();

        //Pronoun.DKey
        var pronounDKey = EMimosiGeDataTypeKeys.Pronoun.ToDtKey();

        //VerbRowFilter.DKey
        var verbRowFilterDKey = EMimosiGeDataTypeKeys.VerbRowFilter.ToDtKey();

        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var newDataTypes = new DataType[]
        {
            new()
            {
                DtKey = classifierDKey,
                DtName = "კლასიფიკატორები",
                DtNameNominative = "კლასიფიკატორი",
                DtNameGenitive = "კლასიფიკატორის",
                DtTable = DataSeederRepo.GetTableName<Classifier>(),
                DtIdFieldName = nameof(Classifier.ClfId).UnCapitalize(),
                DtKeyFieldName = nameof(Classifier.ClfKey).UnCapitalize(),
                DtNameFieldName = nameof(Classifier.ClfName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(classifierDKey), serializerSettings)
            },

            //Inflection

            new()
            {
                DtKey = EMimosiGeDataTypeKeys.ActantCombinationDetail.ToDtKey(),
                DtName = "აქტანტების კომბინაციების დეტალები",
                DtNameNominative = "აქტანტის კომბინაციის დეტალი",
                DtNameGenitive = "აქტანტის კომბინაციის დეტალის",
                DtTable = DataSeederRepo.GetTableName<ActantCombinationDetail>(),
                DtIdFieldName = nameof(ActantCombinationDetail.AcdId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateActantCombinationDetailsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = actantGrammarCaseDKey,
                DtName = "აქტანტების ბრუნვები",
                DtNameNominative = "აქტანტის ბრუნვა",
                DtNameGenitive = "აქტანტის ბრუნვის",
                DtTable = DataSeederRepo.GetTableName<ActantGrammarCase>(),
                DtIdFieldName = nameof(ActantGrammarCase.AgcId).UnCapitalize(),
                DtKeyFieldName = nameof(ActantGrammarCase.AgcKey).UnCapitalize(),
                DtNameFieldName = nameof(ActantGrammarCase.AgcName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(actantGrammarCaseDKey),
                        serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.ActantGrammarCaseByActantType.ToDtKey(),
                DtName = "აქტანტების ბრუნვები აქტანტების ტიპების მიხედვით",
                DtNameNominative = "აქტანტის ბრუნვა აქტანტის ტიპის მიხედვით",
                DtNameGenitive = "აქტანტების ბრუნვის აქტანტების ტიპის მიხედვით",
                DtTable = DataSeederRepo.GetTableName<ActantGrammarCaseByActantType>(),
                DtIdFieldName = nameof(ActantGrammarCaseByActantType.AgcatId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateActantGrammarCasesByActantTypesGridModel(),
                        serializerSettings)
            },
            new()
            {
                DtKey = actantGroupDKey,
                DtName = "აქტანტების ჯგუფები",
                DtNameNominative = "აქტანტების ჯგუფი",
                DtNameGenitive = "აქტანტების ჯგუფების",
                DtTable = DataSeederRepo.GetTableName<ActantGroup>(),
                DtIdFieldName = nameof(ActantGroup.AgrId).UnCapitalize(),
                DtKeyFieldName = nameof(ActantGroup.AgrKey).UnCapitalize(),
                DtNameFieldName = nameof(ActantGroup.AgrName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(actantGroupDKey), serializerSettings)
            },
            new()
            {
                DtKey = actantPositionDKey,
                DtName = "აქტანტების პოზიციები",
                DtNameNominative = "აქტანტის პოზიცია",
                DtNameGenitive = "აქტანტის პოზიციის",
                DtTable = DataSeederRepo.GetTableName<ActantPosition>(),
                DtIdFieldName = nameof(ActantPosition.ApnId).UnCapitalize(),
                DtKeyFieldName = nameof(ActantPosition.ApnKey).UnCapitalize(),
                DtNameFieldName = nameof(ActantPosition.ApnName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(actantPositionDKey), serializerSettings)
            },
            new()
            {
                DtKey = actantTypeDKey,
                DtName = "აქტანტების ტიპები",
                DtNameNominative = "აქტანტის ტიპი",
                DtNameGenitive = "აქტანტის ტიპის",
                DtTable = DataSeederRepo.GetTableName<ActantType>(),
                DtIdFieldName = nameof(ActantType.AttId).UnCapitalize(),
                DtKeyFieldName = nameof(ActantType.AttKey).UnCapitalize(),
                DtNameFieldName = nameof(ActantType.AttName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(actantTypeDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.ActantTypeByVerbType.ToDtKey(),
                DtName = "აქტანტების ტიპები ზმნის ტიპების მიხედვით",
                DtNameNominative = "აქტანტის ტიპი ზმნის ტიპის მიხედვით",
                DtNameGenitive = "აქტანტის ტიპის ზმნის ტიპის მიხედვით",
                DtTable = DataSeederRepo.GetTableName<ActantTypeByVerbType>(),
                DtIdFieldName = nameof(ActantTypeByVerbType.AtvtId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateActantTypesByVerbTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.AfterDominantPersonMarker.ToDtKey(),
                DtName = "პირის ნიშნების დომინანტების გათვალისწინებით",
                DtNameNominative = "პირის ნიშანი დომინანტების გათვალისწინებით",
                DtNameGenitive = "დომინანტების გათვალისწინებით პირის ნიშნის",
                DtTable = DataSeederRepo.GetTableName<AfterDominantPersonMarker>(),
                DtIdFieldName = nameof(AfterDominantPersonMarker.AdpmId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateAfterDominantPersonMarkersGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.DerivationType.ToDtKey(),
                DtName = "დერივაციის ტიპები",
                DtNameNominative = "დერივაციის ტიპი",
                DtNameGenitive = "დერივაციის ტიპის",
                DtTable = DataSeederRepo.GetTableName<DerivationType>(),
                DtIdFieldName = nameof(DerivationType.DrtId).UnCapitalize(),
                DtKeyFieldName = nameof(DerivationType.DrtKey).UnCapitalize(),
                DtNameFieldName = nameof(DerivationType.DrtName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateDerivationTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.DerivationTypeToCrudType.ToDtKey(),
                DtName = "დერივაციის ცვლილებაზე უფლებები",
                DtNameNominative = "დერივაციის ცვლილებაზე უფლება",
                DtNameGenitive = "დერივაციის ცვლილებაზე უფლების",
                DtTable = "derivationTypesToCrudTypes"
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.DominantActant.ToDtKey(),
                DtName = "დომინანტი აქტანტები",
                DtNameNominative = "დომინანტი აქტანტი",
                DtNameGenitive = "დომინანტი აქტანტის",
                DtTable = DataSeederRepo.GetTableName<DominantActant>(),
                DtIdFieldName = nameof(DominantActant.DmaId).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateDominantActantsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = grammarCaseDKey,
                DtName = "სახელის ბრუნვები",
                DtNameNominative = "სახელის ბრუნვა",
                DtNameGenitive = "სახელის ბრუნვის",
                DtTable = DataSeederRepo.GetTableName<GrammarCase>(),
                DtIdFieldName = nameof(GrammarCase.GrcId).UnCapitalize(),
                DtKeyFieldName = nameof(GrammarCase.GrcKey).UnCapitalize(),
                DtNameFieldName = nameof(GrammarCase.GrcName).UnCapitalize(),
                //DtGridRulesJson =
                //    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(grammarCaseDKey), serializerSettings)
                DtGridRulesJson = JsonConvert.SerializeObject(CreateGrammarCaseGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = issueKindDKey,
                DtName = "მოსაგვარებელი საკითხების ტიპები",
                DtNameNominative = "მოსაგვარებელი საკითხის ტიპი",
                DtNameGenitive = "მოსაგვარებელი საკითხის ტიპის",
                DtTable = DataSeederRepo.GetTableName<IssueKind>(),
                DtIdFieldName = nameof(IssueKind.IskId).UnCapitalize(),
                DtKeyFieldName = nameof(IssueKind.IskKey).UnCapitalize(),
                DtNameFieldName = nameof(IssueKind.IskName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(issueKindDKey), serializerSettings)
            },
            new()
            {
                DtKey = issuePriorityDKey,
                DtName = "მოსაგვარებელი საკითხების პრიორიტეტები",
                DtNameNominative = "მოსაგვარებელი საკითხის პრიორიტეტი",
                DtNameGenitive = "მოსაგვარებელი საკითხის პრიორიტეტის",
                DtTable = DataSeederRepo.GetTableName<IssuePriority>(),
                DtIdFieldName = nameof(IssuePriority.IspId).UnCapitalize(),
                DtKeyFieldName = nameof(IssuePriority.IspKey).UnCapitalize(),
                DtNameFieldName = nameof(IssuePriority.IspName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(issuePriorityDKey), serializerSettings)
            },
            new()
            {
                DtKey = issueStatusDKey,
                DtName = "მოსაგვარებელი საკითხების სტატუსები",
                DtNameNominative = "მოსაგვარებელი საკითხის სტატუსი",
                DtNameGenitive = "მოსაგვარებელი საკითხის სტატუსის",
                DtTable = DataSeederRepo.GetTableName<IssueStatus>(),
                DtIdFieldName = nameof(IssueStatus.IstId).UnCapitalize(),
                DtKeyFieldName = nameof(IssueStatus.IstKey).UnCapitalize(),
                DtNameFieldName = nameof(IssueStatus.IstName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(issueStatusDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.MorphemeGroup.ToDtKey(),
                DtName = "მორფემების ჯგუფები",
                DtNameNominative = "მორფემის ჯგუფი",
                DtNameGenitive = "მორფემის ჯგუფის",
                DtTable = DataSeederRepo.GetTableName<MorphemeGroup>(),
                DtIdFieldName = nameof(MorphemeGroup.MogId).UnCapitalize(),
                DtNameFieldName = nameof(MorphemeGroup.MogName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateMorphemeGroupsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.Morpheme.ToDtKey(),
                DtName = "მორფემები",
                DtNameNominative = "მორფემა",
                DtNameGenitive = "მორფემის",
                DtTable = DataSeederRepo.GetTableName<Morpheme>(),
                DtIdFieldName = nameof(Morpheme.MrpId).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateMorphemesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = nounNumberDKey,
                DtName = "სახელის რიცხვები",
                DtNameNominative = "სახელის რიცხვი",
                DtNameGenitive = "სახელის რიცხვის",
                DtTable = DataSeederRepo.GetTableName<NounNumber>(),
                DtIdFieldName = nameof(NounNumber.NnnId).UnCapitalize(),
                DtKeyFieldName = nameof(NounNumber.NnnKey).UnCapitalize(),
                DtNameFieldName = nameof(NounNumber.NnnName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(nounNumberDKey), serializerSettings)
            },
            new()
            {
                DtKey = nounParadigmDKey,
                DtName = "სახელის პარადიგმები",
                DtNameNominative = "სახელის პარადიგმა",
                DtNameGenitive = "სახელის პარადიგმის",
                DtTable = DataSeederRepo.GetTableName<NounParadigm>(),
                DtIdFieldName = nameof(NounParadigm.NpnId).UnCapitalize(),
                DtKeyFieldName = nameof(NounParadigm.NpnKey).UnCapitalize(),
                DtNameFieldName = nameof(NounParadigm.NpnName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(nounParadigmDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PhoneticsChange.ToDtKey(),
                DtName = "ფონეტიკური ცვლილებები",
                DtNameNominative = "ფონეტიკური ცვლილება",
                DtNameGenitive = "ფონეტიკური ცვლილების",
                DtTable = DataSeederRepo.GetTableName<PhoneticsChange>(),
                DtIdFieldName = nameof(PhoneticsChange.PhcId).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreatePhoneticsChangesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PhoneticsOptionDetail.ToDtKey(),
                DtName = "ფონეტიკური ვარიანტების დეტალები",
                DtNameNominative = "ფონეტიკური ვარიანტის დეტალი",
                DtNameGenitive = "ფონეტიკური ვარიანტის დეტალის",
                DtTable = DataSeederRepo.GetTableName<PhoneticsOptionDetail>(),
                DtIdFieldName = nameof(PhoneticsOptionDetail.PhodId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreatePhoneticsOptionDetailsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PhoneticsOption.ToDtKey(),
                DtName = "ფონეტიკური ვარიანტები",
                DtNameNominative = "ფონეტიკური ვარიანტი",
                DtNameGenitive = "ფონეტიკური ვარიანტის",
                DtTable = DataSeederRepo.GetTableName<PhoneticsOption>(),
                DtIdFieldName = nameof(PhoneticsOption.PhoId).UnCapitalize(),
                DtNameFieldName = nameof(PhoneticsOption.PhoName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreatePhoneticsOptionsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PhoneticsType.ToDtKey(),
                DtName = "ფონეტიკური ტიპები",
                DtNameNominative = "ფონეტიკური ტიპი",
                DtNameGenitive = "ფონეტიკური ტიპის",
                DtTable = DataSeederRepo.GetTableName<PhoneticsType>(),
                DtIdFieldName = nameof(PhoneticsType.PhtId).UnCapitalize(),
                DtNameFieldName = nameof(PhoneticsType.PhtName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreatePhoneticsTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PhoneticsTypeProhibition.ToDtKey(),
                DtName = "ფონეტიკური ტიპების შეზღუდვები",
                DtNameNominative = "ფონეტიკური ტიპის შეზღუდვა",
                DtNameGenitive = "ფონეტიკური ტიპის შეზღუდვის",
                DtTable = DataSeederRepo.GetTableName<PhoneticsTypeProhibition>(),
                DtIdFieldName = nameof(PhoneticsTypeProhibition.PhtpId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreatePhoneticsTypeProhibitionsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PluralityChangeByVerbType.ToDtKey(),
                DtName = "მრავლობითობების ცვლილებების ზმნის ტიპის მიხედვით",
                DtNameNominative = "მრავლობითობის ცვლილება ზმნის ტიპის მიხედვით",
                DtNameGenitive = "ზმნის ტიპის მიხედვით მრავლობითობის ცვლილების",
                DtTable = DataSeederRepo.GetTableName<PluralityChangeByVerbType>(),
                DtIdFieldName = nameof(PluralityChangeByVerbType.PcvtId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreatePluralityChangesByVerbTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = recordStatusDKey,
                DtName = "ჩანაწერების სტატუსები",
                DtNameNominative = "ჩანაწერის სტატუსი",
                DtNameGenitive = "ჩანაწერის სტატუსის",
                DtTable = DataSeederRepo.GetTableName<RecordStatus>(),
                DtIdFieldName = nameof(RecordStatus.RstId).UnCapitalize(),
                DtKeyFieldName = nameof(RecordStatus.RstKey).UnCapitalize(),
                DtNameFieldName = nameof(RecordStatus.RstName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(recordStatusDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbPersonMarkerParadigmChange.ToDtKey(),
                DtName = "ზმნის ცალი პირის ნიშნების პარადიგმების ცვლილებები",
                DtNameNominative = "ზმნის ცალი პირის ნიშნის პარადიგმის ცვლილება",
                DtNameGenitive = "ზმნის ცალი პირის ნიშნის პარადიგმის ცვლილების",
                DtTable = DataSeederRepo.GetTableName<VerbPersonMarkerParadigmChange>(),
                DtIdFieldName = nameof(VerbPersonMarkerParadigmChange.VpmpcId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateVerbPersonMarkerParadigmChangesGridModel(),
                        serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbPluralityTypeChange.ToDtKey(),
                DtName = "ზმნის მრავლობითობის ტიპების ცვლილებები",
                DtNameNominative = "ზმნის მრავლობითობის ტიპის ცვლილება",
                DtNameGenitive = "ზმნის მრავლობითობის ტიპის ცვლილების",
                DtTable = DataSeederRepo.GetTableName<VerbPluralityTypeChange>(),
                DtIdFieldName = nameof(VerbPluralityTypeChange.VptcId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateVerbPluralityTypeChangesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.ForRecountVerbPersonMarker.ToDtKey(),
                DtName = "პირის ნიშნების კომბინაციების ფორმულების დასათვლელი შუალედური ცხრილი",
                DtNameNominative = "პირის ნიშნების კომბინაციების ფორმულების დასათვლელი შუალედური ცხრილი",
                DtNameGenitive = "პირის ნიშნების კომბინაციების ფორმულების დასათვლელი შუალედური ცხრილი",
                DtTable = DataSeederRepo.GetTableName<ForRecountVerbPersonMarker>(),
                DtIdFieldName = nameof(ForRecountVerbPersonMarker.FrvpmId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateForRecountVerbPersonMarkersGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = verbNumberDKey,
                DtName = "ზმნის რიცხვები",
                DtNameNominative = "ზმნის რიცხვი",
                DtNameGenitive = "ზმნის რიცხვის",
                DtTable = DataSeederRepo.GetTableName<VerbNumber>(),
                DtIdFieldName = nameof(VerbNumber.VnmId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbNumber.VnmKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbNumber.VnmName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(verbNumberDKey), serializerSettings)
            },
            new()
            {
                DtKey = verbParadigmDKey,
                DtName = "ზმნის პარადიგმები",
                DtNameNominative = "ზმნის პარადიგმა",
                DtNameGenitive = "ზმნის პარადიგმის",
                DtTable = DataSeederRepo.GetTableName<VerbParadigm>(),
                DtIdFieldName = nameof(VerbParadigm.VpnId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbParadigm.VpnKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbParadigm.VpnName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(verbParadigmDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbPersonMarkerParadigm.ToDtKey(),
                DtName = "ზმნის პირის ნიშნების პარადიგმები",
                DtNameNominative = "ზმნის პირის ნიშნების პარადიგმა",
                DtNameGenitive = "ზმნის პირის ნიშნების პარადიგმის",
                DtTable = DataSeederRepo.GetTableName<VerbPersonMarkerParadigm>(),
                DtIdFieldName = nameof(VerbPersonMarkerParadigm.VpmpnId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbPersonMarkerParadigm.VpmpnKey).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateVerbPersonMarkerParadigmsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = verbPersonDKey,
                DtName = "ზმნის პირები",
                DtNameNominative = "ზმნის პირი",
                DtNameGenitive = "ზმნის პირის",
                DtTable = DataSeederRepo.GetTableName<VerbPerson>(),
                DtIdFieldName = nameof(VerbPerson.VprId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbPerson.VprKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbPerson.VprName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(verbPersonDKey), serializerSettings)
            },
            new()
            {
                DtKey = verbPluralityTypeDKey,
                DtName = "ზმნის მრავლობითობის ტიპები",
                DtNameNominative = "ზმნის მრავლობითობის ტიპი",
                DtNameGenitive = "ზმნის მრავლობითობის ტიპის",
                DtTable = DataSeederRepo.GetTableName<VerbPluralityType>(),
                DtIdFieldName = nameof(VerbPluralityType.VptId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbPluralityType.VptKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbPluralityType.VptName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(verbPluralityTypeDKey),
                        serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbRow.ToDtKey(),
                DtName = "მწკრივები",
                DtNameNominative = "მწკრივი",
                DtNameGenitive = "მწკრივის",
                DtTable = DataSeederRepo.GetTableName<VerbRow>(),
                DtIdFieldName = nameof(VerbRow.VrwId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbRow.VrwKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbRow.VrwName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateVerbRowsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = verbSeriesDKey,
                DtName = "სერიების ნომრები",
                DtNameNominative = "სერიის ნომერი",
                DtNameGenitive = "სერიის ნომრის",
                DtTable = DataSeederRepo.GetTableName<VerbSeries>(),
                DtIdFieldName = nameof(VerbSeries.VsrId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbSeries.VsrKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbSeries.VsrName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(verbSeriesDKey), serializerSettings)
            },
            new()
            {
                DtKey = verbTransitionDKey,
                DtName = "ზმნის გარდამავლობა",
                DtNameNominative = "ზმნის გარდამავლობა",
                DtNameGenitive = "ზმნის გარდამავლობის",
                DtTable = DataSeederRepo.GetTableName<VerbTransition>(),
                DtIdFieldName = nameof(VerbTransition.VtrId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbTransition.VtrKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbTransition.VtrName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameGridModel(verbTransitionDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbType.ToDtKey(),
                DtName = "ზმნის ტიპები",
                DtNameNominative = "ზმნის ტიპი",
                DtNameGenitive = "ზმნის ტიპის",
                DtTable = DataSeederRepo.GetTableName<VerbType>(),
                DtIdFieldName = nameof(VerbType.VtpId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbType.VtpKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbType.VtpName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateVerbTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.MorphemeRange.ToDtKey(),
                DtName = "მორფემების რანგები",
                DtNameNominative = "მორფემის რანგი",
                DtNameGenitive = "მორფემის რანგის",
                DtTable = DataSeederRepo.GetTableName<MorphemeRange>(),
                DtIdFieldName = nameof(MorphemeRange.MrId).UnCapitalize(),
                DtKeyFieldName = nameof(MorphemeRange.MrKey).UnCapitalize(),
                DtNameFieldName = nameof(MorphemeRange.MrName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateMorphemeRangesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbPersonMarkerCombination.ToDtKey(),
                DtName = "პირის ნიშნების კომბინაციები",
                DtNameNominative = "პირის ნიშნების კომბინაცია",
                DtNameGenitive = "პირის ნიშნების კომბინაციის",
                DtTable = DataSeederRepo.GetTableName<VerbPersonMarkerCombination>(),
                DtIdFieldName = nameof(VerbPersonMarkerCombination.VpmcId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateVerbPersonMarkerCombinationsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbPersonMarkerCombinationFormulaDetail.ToDtKey(),
                DtName = "პირის ნიშნების კომბინაციების ფორმულების დეტალები",
                DtNameNominative = "პირის ნიშნების კომბინაციების ფორმულის დეტალი",
                DtNameGenitive = "პირის ნიშნების კომბინაციების ფორმულის დეტალის",
                DtTable = DataSeederRepo.GetTableName<VerbPersonMarkerCombinationFormulaDetail>(),
                DtIdFieldName = nameof(VerbPersonMarkerCombinationFormulaDetail.VpmcfdId).UnCapitalize()
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PersonVariabilityType.ToDtKey(),
                DtName = "პირცვალებადობის ტიპები",
                DtNameNominative = "პირცვალებადობის ტიპი",
                DtNameGenitive = "პირცვალებადობის ტიპის",
                DtTable = DataSeederRepo.GetTableName<PersonVariabilityType>(),
                DtIdFieldName = nameof(PersonVariabilityType.PvtId).UnCapitalize(),
                DtKeyFieldName = nameof(PersonVariabilityType.PvtKey).UnCapitalize(),
                DtNameFieldName = nameof(PersonVariabilityType.PvtName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreatePersonVariabilityTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.PersonVariabilityDetail.ToDtKey(),
                DtName = "პირცვალებადობის ტიპების დეტალები",
                DtNameNominative = "პირცვალებადობის ტიპის დეტალი",
                DtNameGenitive = "პირცვალებადობის ტიპის დეტალის",
                DtTable = DataSeederRepo.GetTableName<PersonVariabilityDetail>(),
                DtIdFieldName = nameof(PersonVariabilityDetail.PvdId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreatePersonVariabilityDetailsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = pronounDKey,
                DtName = "ნაცვალსახელები",
                DtNameNominative = "ნაცვალსახელი",
                DtNameGenitive = "ნაცვალსახელის",
                DtTable = DataSeederRepo.GetTableName<Pronoun>(),
                DtIdFieldName = nameof(Pronoun.PrnId).UnCapitalize(),
                DtKeyFieldName = nameof(Pronoun.PrnKey).UnCapitalize(),
                DtNameFieldName = nameof(Pronoun.PrnName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(pronounDKey), serializerSettings)
            },
            new()
            {
                DtKey = verbRowFilterDKey,
                DtName = "მწკრივების ფილტრების სახელები",
                DtNameNominative = "მწკრივების ფილტრის სახელი",
                DtNameGenitive = "მწკრივების ფილტრის სახელის",
                DtTable = DataSeederRepo.GetTableName<VerbRowFilter>(),
                DtIdFieldName = nameof(VerbRowFilter.VrfId).UnCapitalize(),
                DtKeyFieldName = nameof(VerbRowFilter.VrfKey).UnCapitalize(),
                DtNameFieldName = nameof(VerbRowFilter.VrfName).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(GetKeyNameSortIdGridModel(verbRowFilterDKey), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.VerbRowFilterDetail.ToDtKey(),
                DtName = "მწკრივების ფილტრების დეტალები",
                DtNameNominative = "მწკრივების ფილტრის დეტალი",
                DtNameGenitive = "მწკრივების ფილტრის დეტალის",
                DtTable = DataSeederRepo.GetTableName<VerbRowFilterDetail>(),
                DtIdFieldName = nameof(VerbRowFilterDetail.VrfdId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateVerbRowFilterDetailsGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.MorphemeRangeByInflectionBlock.ToDtKey(),
                DtName = "მორფემების რანგები ფლექსიის ბლოკების მიხედვით",
                DtNameNominative = "მორფემების რანგი ფლექსიის ბლოკების მიხედვით",
                DtNameGenitive = "ფლექსიის ბლოკების მიხედვით მორფემების რანგის",
                DtTable = DataSeederRepo.GetTableName<MorphemeRangeByInflectionBlock>(),
                DtIdFieldName = nameof(MorphemeRangeByInflectionBlock.MrbibId).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateMorphemeRangesByInflectionBlocksGridModel(),
                    serializerSettings)
            },
            //სახელის ფლექსია

            //GeoModel
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.InflectionBlock.ToDtKey(),
                DtName = "ფლექსიის ბლოკები",
                DtNameNominative = "ფლექსიის ბლოკი",
                DtNameGenitive = "ფლექსიის ბლოკის",
                DtTable = DataSeederRepo.GetTableName<InflectionBlock>(),
                DtIdFieldName = nameof(InflectionBlock.InbId).UnCapitalize(),
                DtKeyFieldName = nameof(InflectionBlock.InbKey).UnCapitalize(),
                DtNameFieldName = nameof(InflectionBlock.InbName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateInflectionBlocksGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.DerivationFormula.ToDtKey(),
                DtName = "დერივაციის ფორმულები",
                DtNameNominative = "დერივაციის ფორმულა",
                DtNameGenitive = "დერივაციის ფორმულის",
                DtTable = DataSeederRepo.GetTableName<DerivationFormula>(),
                DtIdFieldName = nameof(DerivationFormula.DfId).UnCapitalize()
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.InflectionType.ToDtKey(),
                DtName = "ფლექსიის ტიპები",
                DtNameNominative = "ფლექსიის ტიპი",
                DtNameGenitive = "ფლექსიის ტიპის",
                DtTable = DataSeederRepo.GetTableName<InflectionType>(),
                DtIdFieldName = nameof(InflectionType.IftId).UnCapitalize(),
                DtKeyFieldName = nameof(InflectionType.IftKey).UnCapitalize(),
                DtNameFieldName = nameof(InflectionType.IftName).UnCapitalize(),
                DtGridRulesJson = JsonConvert.SerializeObject(CreateInflectionTypesGridModel(), serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.InflectionTypeToCrudType.ToDtKey(),
                DtName = "ფლექსიის ცვლილებაზე უფლებები",
                DtNameNominative = "ფლექსიის ცვლილებაზე უფლება",
                DtNameGenitive = "ფლექსიის ცვლილებაზე უფლების",
                DtTable = "inflectionTypesToCrudTypes"
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.MorphemeRangeByDerivationType.ToDtKey(),
                DtName = "მორფემების რანგები დერივაციის ტიპების მიხედვით",
                DtNameNominative = "მორფემის რანგი დერივაციის ტიპების მიხედვით",
                DtNameGenitive = "დერივაციის ტიპების მიხედვით მორფემის რანგის",
                DtTable = DataSeederRepo.GetTableName<MorphemeRangeByDerivationType>(),
                DtIdFieldName = nameof(MorphemeRangeByDerivationType.MrbdtId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateMorphemeRangesByDerivationTypesGridModel(),
                        serializerSettings)
            },
            new()
            {
                DtKey = EMimosiGeDataTypeKeys.MorphPhoneticsOccasion.ToDtKey(),
                DtName = "მორფემების ფონეტიკური შესაძლებლობები",
                DtNameNominative = "მორფემის ფონეტიკური შესაძლებლობა",
                DtNameGenitive = "მორფემის ფონეტიკური შესაძლებლობის",
                DtTable = DataSeederRepo.GetTableName<MorphPhoneticsOccasion>(),
                DtIdFieldName = nameof(MorphPhoneticsOccasion.MpoId).UnCapitalize(),
                DtGridRulesJson =
                    JsonConvert.SerializeObject(CreateMorphPhoneticsOccasionsGridModel(), serializerSettings)
            }
        };

        mn.AddRange(newDataTypes);

        return mn;
    }

    private static GridModel CreateGrammarCaseGridModel()
    {
        var gridModel = GetKeyNameSortIdGridModel(EMimosiGeDataTypeKeys.GrammarCase.ToDtKey());
        var cells = new[]
        {
            GetCheckBoxCell(nameof(GrammarCase.GrcAllowOMorpheme).UnCapitalize(),
                "დასაშვებია სხვათა სიტყვის ნაწილაკის დართვა")
        };
        gridModel.Cells.AddRange(cells);
        return gridModel;
    }

    private GridModel CreateInflectionTypesGridModel()
    {
        var gridModel = GetKeyNameGridModel(EMimosiGeDataTypeKeys.InflectionType.ToDtKey());
        gridModel.Cells.Add(GetMorphemeGroupColumnModel());
        gridModel.Cells.Add(GetTextBoxCell(nameof(InflectionType.IftFileName).UnCapitalize(), "ფერის სახელი"));
        return gridModel;
    }

    private GridModel CreateInflectionBlocksGridModel()
    {
        var gridModel = GetKeyNameGridModel(EMimosiGeDataTypeKeys.InflectionBlock.ToDtKey());
        gridModel.Cells.Add(GetMdComboCell(nameof(InflectionBlock.InflectionTypeId).UnCapitalize(), "ფლექსიის ტიპი",
            DataSeederRepo.GetTableName<InflectionType>()));
        gridModel.Cells.Add(GetCheckBoxCell(nameof(InflectionBlock.InbContainsNecessaryBase).UnCapitalize(),
            "შეიცავს აუცილებელ ფუძეს"));
        return gridModel;
    }

    private static GridModel CreateMorphPhoneticsOccasionsGridModel()
    {
        var gridModel = new GridModel();
        var cells = new[]
        {
            GetAutoNumberColumn(nameof(MorphPhoneticsOccasion.MpoId).UnCapitalize()), GetMorphemeCellModel(),
            GetMdComboCell(nameof(MorphPhoneticsOccasion.MpoPhoneticsChangeId).UnCapitalize(),
                "ფონეტიკური ცვლილება", "phoneticsChangesQuery")
        };
        gridModel.Cells = [.. cells];
        return gridModel;
    }

    private GridModel CreateMorphemeRangesByDerivationTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(MorphemeRangeByDerivationType.MrbdtId).UnCapitalize()),
            GetMdComboCell(nameof(MorphemeRangeByDerivationType.DerivationTypeId).UnCapitalize(), "დერივაციის ტიპი",
                DataSeederRepo.GetTableName<DerivationType>()),
            GetMorphemeRangeColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateMorphemeRangesByInflectionBlocksGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(MorphemeRangeByInflectionBlock.MrbibId).UnCapitalize()),
            GetMdComboCell(nameof(MorphemeRangeByInflectionBlock.InflectionBlockId).UnCapitalize(),
                "ფლექსიის ბლოკი", DataSeederRepo.GetTableName<InflectionBlock>()),
            GetMorphemeRangeColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreatePersonVariabilityDetailsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PersonVariabilityDetail.PvdId).UnCapitalize()),
            GetMdComboCell(nameof(PersonVariabilityDetail.PersonVariabilityTypeId).UnCapitalize(),
                "პირცვალებადობის ტიპი", DataSeederRepo.GetTableName<PersonVariabilityType>()),
            GetVerbNumberColumnModel(), GetVerbPersonColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private static GridModel CreatePersonVariabilityTypesGridModel()
    {
        var gridModel = GetKeyNameSortIdGridModel(EMimosiGeDataTypeKeys.PersonVariabilityType.ToDtKey());
        gridModel.Cells.Add(GetCheckBoxCell(nameof(PersonVariabilityType.PvtHasPronoun).UnCapitalize(),
            "აქვს ნაცვალსახელი"));
        return gridModel;
    }

    private GridModel CreateVerbRowFilterDetailsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbRowFilterDetail.VrfdId).UnCapitalize()),
            GetMdComboCell(nameof(VerbRowFilterDetail.VerbRowFilterId).UnCapitalize(), "მწკრივების ფილტრი",
                DataSeederRepo.GetTableName<VerbRowFilter>()),
            GetMdComboCell(nameof(VerbRowFilterDetail.VerbRowId).UnCapitalize(), "მწკრივი",
                DataSeederRepo.GetTableName<VerbRow>())
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateActantCombinationDetailsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(ActantCombinationDetail.AcdId).UnCapitalize()),
            GetActantCombinationIdColumnModel(), GetActantPositionColumnModel(), GetVerbNumberColumnModel(),
            GetVerbPersonColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private static GridModel CreateForRecountVerbPersonMarkersGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(ForRecountVerbPersonMarker.FrvpmId).UnCapitalize()),
            GetIntegerCell(nameof(ForRecountVerbPersonMarker.VerbPersonMarkerCombinationId).UnCapitalize(),
                "პირების კომბინაციის #"),
            GetMdComboCell(nameof(ForRecountVerbPersonMarker.DominantActantId).UnCapitalize(), "დომინანტი აქტანტი",
                "dominantActantsQuery"),
            GetMorphemeCellModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbPluralityTypeChangesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbPluralityTypeChange.VptcId).UnCapitalize()),
            GetPluralityTypeStartColumnModel(),
            GetIntegerCell(nameof(VerbPluralityTypeChange.PluralityTypeDominantId).UnCapitalize(), "დომინანტის #"),
            GetActantGroupColumnModel(), GetVerbNumberColumnModel(), GetVerbPersonColumnModel(),
            GetActantTypeColumnModel(), GetPluralityTypeEndColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbPersonMarkerParadigmChangesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbPersonMarkerParadigmChange.VpmpcId).UnCapitalize()),
            GetActantGroupColumnModel(),
            GetMdComboCell(nameof(VerbPersonMarkerParadigmChange.VerbPersonMarkerParadigmIdStart).UnCapitalize(),
                "პირის ნიშნის პარადიგმა საწყისი", DataSeederRepo.GetTableName<VerbPersonMarkerParadigm>()),
            GetMdComboCell(nameof(VerbPersonMarkerParadigmChange.VerbPersonMarkerParadigmIdEnd).UnCapitalize(),
                "პირის ნიშნის პარადიგმა საბოლოო", DataSeederRepo.GetTableName<VerbPersonMarkerParadigm>())
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreatePluralityChangesByVerbTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PluralityChangeByVerbType.PcvtId).UnCapitalize()),
            GetPluralityTypeStartColumnModel(), GetVerbTypeColumnModel(), GetVerbSeriesColumnModel(),
            GetPluralityTypeEndColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateAfterDominantPersonMarkersGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(AfterDominantPersonMarker.AdpmId).UnCapitalize()), GetVerbTypeColumnModel(),
            GetVerbSeriesColumnModel(), GetActantCombinationIdColumnModel(),
            GetMdComboCell(nameof(AfterDominantPersonMarker.DominantActantId).UnCapitalize(), "დომინანტი აქტანტი",
                "dominantActantsQuery"),
            GetActantGroupColumnModel(), GetVerbPersonColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateDominantActantsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(DominantActant.DmaId).UnCapitalize()), GetActantGroupColumnModel(),
            GetVerbPersonColumnModel(), GetActantTypeColumnModel(), GetSortIdCell()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateActantTypesByVerbTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(ActantTypeByVerbType.AtvtId).UnCapitalize()), GetVerbTypeColumnModel(),
            GetActantPositionColumnModel(), GetActantTypeColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateActantGrammarCasesByActantTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(ActantGrammarCaseByActantType.AgcatId).UnCapitalize()),
            GetActantTypeColumnModel(), GetVerbSeriesColumnModel(),
            GetMdComboCell(nameof(ActantGrammarCaseByActantType.ActantGrammarCaseId).UnCapitalize(),
                "აქტანტის ბრუნვა", DataSeederRepo.GetTableName<ActantGrammarCase>()),
            GetActantGroupColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbPersonMarkerCombinationsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbPersonMarkerCombination.VpmcId).UnCapitalize()),
            GetMdComboCell(nameof(VerbPersonMarkerCombination.VerbPluralityTypeId).UnCapitalize(), "მრავლობითობა",
                DataSeederRepo.GetTableName<VerbPluralityType>()),
            GetMdComboCell(nameof(VerbPersonMarkerCombination.VerbPersonMarkerParadigmId).UnCapitalize(),
                "პირის ნიშნის პარადიგმა", DataSeederRepo.GetTableName<VerbPersonMarkerParadigm>()),
            GetMdComboCell(nameof(VerbPersonMarkerCombination.VerbTypeId).UnCapitalize(), "ზმნის ტიპი",
                DataSeederRepo.GetTableName<VerbType>()),
            GetMdComboCell(nameof(VerbPersonMarkerCombination.VerbSeriesId).UnCapitalize(), "სერია",
                DataSeederRepo.GetTableName<VerbSeries>())
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateMorphemeRangesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(MorphemeRange.MrId).UnCapitalize()),
            GetKeyColumn(nameof(MorphemeRange.MrKey).UnCapitalize()), GetMorphemeGroupColumnModel(),
            //SortID
            GetIntegerCell(nameof(MorphemeRange.MrPosition).UnCapitalize(), "პოზიცია"),
            GetNameColumn(nameof(MorphemeRange.MrName).UnCapitalize()),
            GetIntegerCell(nameof(MorphemeRange.MrBaseNom).UnCapitalize(), "ფუძის ნომერი", true, true),
            GetCheckBoxCell(nameof(MorphemeRange.MrBaseRequired).UnCapitalize(), "აუცილებელი ფუძე"),
            GetCheckBoxCell(nameof(MorphemeRange.MrSelectable).UnCapitalize(), "თავისუფალი"),
            GetCheckBoxCell(nameof(MorphemeRange.MrInflectionSelectable).UnCapitalize(), "თავისუფალი ფლექსიაში")
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateMorphemesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(Morpheme.MrpId).UnCapitalize()), GetMorphemeRangeColumnModel(),
            //SortID
            GetIntegerCell(nameof(Morpheme.MrpNom).UnCapitalize(), "ნომერი"),
            GetTextBoxCell(nameof(Morpheme.MrpMorpheme).UnCapitalize(), "მორფემა"), GetPhoneticsTypeComboColumn(true)
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private static GridModel CreateMorphemeGroupsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(MorphemeGroup.MogId).UnCapitalize()),
            GetNameColumn(nameof(MorphemeGroup.MogName).UnCapitalize()),
            GetCheckBoxCell(nameof(MorphemeGroup.MogAutoPhonetics).UnCapitalize(), "ავტოფონეტიკა")
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateDerivationTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(DerivationType.DrtId).UnCapitalize()),
            GetNameColumn(nameof(DerivationType.DrtName).UnCapitalize()), GetMorphemeGroupColumnModel(),
            GetCheckBoxCell(nameof(DerivationType.DrtAutomatic).UnCapitalize(), "ავტომატური"),
            GetTextBoxCell(nameof(DerivationType.DrtFolderName).UnCapitalize(), "ფოლდერი")
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private static GridModel CreatePhoneticsTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PhoneticsType.PhtId).UnCapitalize()),
            GetNameColumn(nameof(PhoneticsType.PhtName).UnCapitalize()),
            GetComboCellWithRowSource(nameof(PhoneticsType.PhtLastLetter).UnCapitalize(), "ბოლო ბგერა",
                "0;თანხმოვანი;1;ხმოვანი;2;სულერთია"),
            GetIntegerCell(nameof(PhoneticsType.PhtDistance).UnCapitalize(), "დისტანცია", false, true),
            GetTextBoxCell(nameof(PhoneticsType.PhtNote).UnCapitalize(), "შენიშვნა", true),
            GetComboCellWithRowSource(nameof(PhoneticsType.PhtSlab).UnCapitalize(), "ხმოვნები",
                "0;მინიმუმ;1;ზუსტად;2;მაქსიმუმ"),
            GetIntegerCell(nameof(PhoneticsType.PhtSlabCount).UnCapitalize(), "მარცვლების რაოდენობა")
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private static GridModel CreatePhoneticsOptionsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PhoneticsOption.PhoId).UnCapitalize()),
            GetNameColumn(nameof(PhoneticsOption.PhoName).UnCapitalize())
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreatePhoneticsChangesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PhoneticsChange.PhcId).UnCapitalize()), GetPhoneticsTypeComboColumn(false),
            //SortID by phoneticsTypeByOptionSequentialNumber
            GetIntegerCell(nameof(PhoneticsChange.PhoneticsTypeByOptionSequentialNumber).UnCapitalize(),
                "რიგითი ნომერი"),
            GetPhoneticsOptionComboColumn(true)
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreatePhoneticsTypeProhibitionsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PhoneticsTypeProhibition.PhtpId).UnCapitalize()),
            GetPhoneticsTypeComboColumn(false),
            //SortID by PhtpProhOrd
            GetIntegerCell(nameof(PhoneticsTypeProhibition.PhtpProhOrd).UnCapitalize(), "რიგითი ნომერი", false, true),
            GetComboCellWithRowSource(nameof(PhoneticsTypeProhibition.PhtpProhId).UnCapitalize(), "შეზღუდვის ტიპი",
                "0;იყოს;1;იყოს ერთ-ერთი;2;არ იყოს", true),
            GetComboCellWithRowSource(nameof(PhoneticsTypeProhibition.PhtpOrient).UnCapitalize(), "ორიენტაცია",
                "0;ბოლოდან;1;თავიდან", true),
            GetIntegerCell(nameof(PhoneticsTypeProhibition.PhtpStart).UnCapitalize(), "საწყისი ნომერი", false, true),
            GetIntegerCell(nameof(PhoneticsTypeProhibition.PhtpCount).UnCapitalize(), "რაოდენობა", false, true),
            GetComboCellWithRowSource(nameof(PhoneticsTypeProhibition.PhtpObject).UnCapitalize(), "ობიექტის ტიპი",
                "0;ბგერა;1;ხმოვანი;2;თანხმოვანი", true),
            GetTextBoxCell(nameof(PhoneticsTypeProhibition.PhtpNew).UnCapitalize(), "სიმბოლოები", true)
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreatePhoneticsOptionDetailsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(PhoneticsOptionDetail.PhodId).UnCapitalize()),
            GetPhoneticsOptionComboColumn(false),
            //SortID by PhodActOrd
            GetIntegerCell(nameof(PhoneticsOptionDetail.PhodActOrd).UnCapitalize(), "რიგითი ნომერი", false, true),
            GetComboCellWithRowSource(nameof(PhoneticsOptionDetail.PhodActId).UnCapitalize(), "მოქმედების ტიპი",
                "0;იკარგება/ჩაენაცვლება;1;ჩნდება", true),
            GetComboCellWithRowSource(nameof(PhoneticsOptionDetail.PhodOrient).UnCapitalize(), "ორიენტაცია",
                "0;ბოლოდან;1;თავიდან", true),
            GetIntegerCell(nameof(PhoneticsOptionDetail.PhodStart).UnCapitalize(), "საწყისი ნომერი", false, true),
            GetIntegerCell(nameof(PhoneticsOptionDetail.PhodCount).UnCapitalize(), "რაოდენობა", false, true),
            GetComboCellWithRowSource(nameof(PhoneticsOptionDetail.PhodObject).UnCapitalize(), "ობიექტის ტიპი",
                "0;ბგერა;1;ხმოვანი;2;თანხმოვანი", true),
            GetTextBoxCell(nameof(PhoneticsOptionDetail.PhodNew).UnCapitalize(), "ახალი სიმბოლოები", true)
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbTypesGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbType.VtpId).UnCapitalize()),
            GetKeyColumn(nameof(VerbType.VtpKey).UnCapitalize()),
            GetNameColumn(nameof(VerbType.VtpName).UnCapitalize()),
            //sortId
            GetSortIdCell(), GetIntegerCell(nameof(VerbType.VtpVerbPersonsCount).UnCapitalize(), "პირების რაოდენობა"),
            GetMdComboCell(nameof(VerbType.VerbTransitionId).UnCapitalize(), "გარდამავლობა",
                DataSeederRepo.GetTableName<VerbTransition>())
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbRowsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbRow.VrwId).UnCapitalize()),
            GetKeyColumn(nameof(VerbRow.VrwKey).UnCapitalize()), GetNameColumn(nameof(VerbRow.VrwName).UnCapitalize()),
            //sortId
            GetSortIdCell(), GetVerbSeriesColumnModel()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private GridModel CreateVerbPersonMarkerParadigmsGridModel()
    {
        var gridModel = new GridModel();
        var columns = new[]
        {
            GetAutoNumberColumn(nameof(VerbPersonMarkerParadigm.VpmpnId).UnCapitalize()),
            GetKeyColumn(nameof(VerbPersonMarkerParadigm.VpmpnKey).UnCapitalize()), GetActantGroupColumnModel()
            //sortId
            //GetSortIdCell()
        };
        gridModel.Cells = [.. columns];
        return gridModel;
    }

    private Cell GetMorphemeGroupColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს morphemeGroupId
        return GetMdComboCell(nameof(MorphemeRange.MorphemeGroupId).UnCapitalize(), "მორფემების ჯგუფი",
            DataSeederRepo.GetTableName<MorphemeGroup>());
    }

    private static Cell GetActantCombinationIdColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს actantCombinationId
        return GetIntegerCell(nameof(ActantCombinationDetail.ActantCombinationId).UnCapitalize(),
            "პირების კომბინაციის #");
    }

    private Cell GetVerbPersonColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს verbPersonId
        return GetMdComboCell(nameof(ActantCombinationDetail.VerbPersonId).UnCapitalize(), "ზმნის პირი",
            DataSeederRepo.GetTableName<VerbPerson>());
    }

    private Cell GetVerbTypeColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს verbTypeId
        return GetMdComboCell(nameof(ActantTypeByVerbType.VerbTypeId).UnCapitalize(), "ზმნის ტიპი",
            DataSeederRepo.GetTableName<VerbType>());
    }

    private Cell GetActantPositionColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს actantPositionId
        return GetMdComboCell(nameof(ActantCombinationDetail.ActantPositionId).UnCapitalize(), "აქტანტის პოზიცია",
            DataSeederRepo.GetTableName<ActantPosition>());
    }

    private static Cell GetMorphemeCellModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს morphemeId
        return GetMdComboCell(nameof(DerivationFormulaDetail.MorphemeId).UnCapitalize(), "მორფემა", "morphemesQuery");
    }

    private Cell GetVerbNumberColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს verbNumberId
        return GetMdComboCell(nameof(ActantCombinationDetail.VerbNumberId).UnCapitalize(), "რიცხვი",
            DataSeederRepo.GetTableName<VerbNumber>());
    }

    private Cell GetActantTypeColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს actantTypeId
        return GetMdComboCell(nameof(ActantGrammarCaseByActantType.ActantTypeId).UnCapitalize(), "აქტანტის ტიპი",
            DataSeederRepo.GetTableName<ActantType>());
    }

    private Cell GetPluralityTypeStartColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს pluralityTypeIdStart
        return GetPluralityTypeColumnModel(nameof(PluralityChangeByVerbType.PluralityTypeIdStart).UnCapitalize(),
            "მრავლობითობა საწყისი");
    }

    private Cell GetPluralityTypeEndColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს pluralityTypeIdEnd
        return GetPluralityTypeColumnModel(nameof(PluralityChangeByVerbType.PluralityTypeIdEnd).UnCapitalize(),
            "მრავლობითობა საბოლოო");
    }

    private Cell GetPluralityTypeColumnModel(string fieldName, string caption)
    {
        return GetMdComboCell(fieldName, caption, DataSeederRepo.GetTableName<VerbPluralityType>());
    }

    private Cell GetActantGroupColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს actantGroupId
        return GetMdComboCell(nameof(ActantGrammarCaseByActantType.ActantGroupId).UnCapitalize(), "აქტანტების ჯგუფი",
            DataSeederRepo.GetTableName<ActantGroup>());
    }

    private Cell GetMorphemeRangeColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს morphemeRangeId
        return GetMdComboCell(nameof(Morpheme.MorphemeRangeId).UnCapitalize(), "რანგი",
            DataSeederRepo.GetTableName<MorphemeRange>());
    }

    private Cell GetVerbSeriesColumnModel()
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს verbSeriesId
        return GetMdComboCell(nameof(ActantGrammarCaseByActantType.VerbSeriesId).UnCapitalize(), "სერია",
            DataSeederRepo.GetTableName<VerbSeries>());
    }

    private Cell GetPhoneticsTypeComboColumn(bool allowNull)
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს phoneticsTypeId
        return GetMdComboCell(nameof(Morpheme.PhoneticsTypeId).UnCapitalize(), "ფონეტიკური ტიპი",
            DataSeederRepo.GetTableName<PhoneticsType>(), allowNull);
    }

    private Cell GetPhoneticsOptionComboColumn(bool allowNull)
    {
        //ითვლება რომ ყველა ცხრილში ერთიდაიგივე სახელი ექნება ამ ველს phoneticsOptionId
        return GetMdComboCell(nameof(PhoneticsChange.PhoneticsOptionId).UnCapitalize(), "ფონეტიკური ვარიანტი",
            DataSeederRepo.GetTableName<PhoneticsOption>(), allowNull);
    }
}