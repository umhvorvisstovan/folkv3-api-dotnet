namespace Us.FolkV3.Api.Client.Mapper;

using Model;

internal abstract class PersonBaseMapper<PI, PO> : ClientMapper<PI, PO>
    where PI : Eu.Xroad.UsFolkV3.Producer.PersonSmall
    where PO : PersonSmall
{
    protected PersonBaseMapper()
    {
    }
}
