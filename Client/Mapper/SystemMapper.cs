using Us.FolkV3.Api.Model;

namespace Us.FolkV3.Api.Client.Mapper;

internal class SystemMapper
{
    public IList<PrivateId> PrivateIds(Eu.Xroad.UsFolkV3.Producer.PrivateId[] idList)
    {
        return Mapper.PrivateIds(idList);
    }

}
