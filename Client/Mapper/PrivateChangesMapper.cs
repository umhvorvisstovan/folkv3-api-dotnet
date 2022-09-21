using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Model;
using PrivateId = Us.FolkV3.Api.Model.PrivateId;

namespace Us.FolkV3.Api.Client.Mapper;

internal class PrivateChangesMapper : ChangesMapper<PrivateChanges, PrivateId>
{
    protected override Changes<PrivateId> DoMap(PrivateChanges value)
    {
        return new Changes<PrivateId>(
            DateTime.Parse(value.from),
            DateTime.Parse(value.to),
            Mapper.PrivateIds(value.ids)
        );
    }
}
