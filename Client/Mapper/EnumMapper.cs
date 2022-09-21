using Us.FolkV3.Api.Model;

namespace Us.FolkV3.Api.Client.Mapper;

internal static class EnumMapper
{

    internal static CivilStatusType CivilStatusType(string value)
    {
        switch (value)
        {
            case "BORN":
                return Model.CivilStatusType.Born;
            case "BREAKING_OFF":
                return Model.CivilStatusType.BreakingOff;
            case "DEAD":
                return Model.CivilStatusType.Dead;
            case "DIVORCED":
                return Model.CivilStatusType.Divorced;
            case "LONGEST_LIVING":
                return Model.CivilStatusType.LongestLiving;
            case "MARRIED":
                return Model.CivilStatusType.Married;
            case "PARTNER":
                return Model.CivilStatusType.Partner;
            case "SEPARATED":
                return Model.CivilStatusType.Separated;
            case "WIDOWED":
                return Model.CivilStatusType.Widow;
            default:
                throw new FolkApiException("invalid civil status type " + value);
        }
    }

    internal static CommunityPersonStatus CommunityPersonStatus(string value)
    {
        switch (value)
        {
            case "ADDED":
                return Model.CommunityPersonStatus.Added;
            case "ALREADY_EXISTS":
                return Model.CommunityPersonStatus.AlreadyExists;
            case "NOT_FOUND":
                return Model.CommunityPersonStatus.NotFound;
            case "MORE_THAN_ONE":
                return Model.CommunityPersonStatus.MoreThanOne;
            default:
                throw new FolkApiException("invalid community person status " + value);
        }
    }

    internal static Gender Gender(string value)
    {
        switch (value)
        {
            case "FEMALE":
                return Model.Gender.Female;
            case "MALE":
                return Model.Gender.Male;
            default:
                throw new FolkApiException("invalid gender " + value);
        }
    }

    internal static ResponseStatus ResponseStatus(string value)
    {
        switch (value)
        {
            case "OK":
                return Client.ResponseStatus.Ok;
            case "BAD_REQUEST":
                return Client.ResponseStatus.BadRequest;
            case "NOT_FOUND":
                return Client.ResponseStatus.NotFound;
            case "MORE_THAN_ONE":
                return Client.ResponseStatus.MoreThanOne;
            case "UNAUTHORIZED":
                return Client.ResponseStatus.Unauthorized;
            case "ERROR":
                return Client.ResponseStatus.Error;
            default:
                throw new FolkApiException("invalid response status " + value);
        }
    }

    internal static SpecialMarkType SpecialMarkType(string value)
    {
        switch (value)
        {
            case "NAME_AND_ADDRESS_PROTECTED":
                return Model.SpecialMarkType.NameAndAddressProtected;
            case "EXCLUDED_FROM_MARKETING":
                return Model.SpecialMarkType.ExcludedFromMarketing;
            case "EXCLUDED_FROM_STATISTICS_AND_RESEARCH":
                return Model.SpecialMarkType.ExcludedFromStatisticAndResearch;
            default:
                throw new FolkApiException("invalid special marks type " + value);
        }
    }
}
