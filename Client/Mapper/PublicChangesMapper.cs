using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Model;
using PublicId = Us.FolkV3.Api.Model.PublicId;

namespace Us.FolkV3.Api.Client.Mapper;

internal class PublicChangesMapper : ChangesMapper<PublicChanges, PublicId>
{
    protected override Changes<PublicId> DoMap(PublicChanges value)
    {
        return new Changes<PublicId>(
            DateTime.Parse(value.from),
            DateTime.Parse(value.to),
            Mapper.PublicIds(value.ids)
        );
    }
}
