namespace Us.FolkV3.Api.Client.Mapper
{
    using Model;
    internal abstract class ChangesMapper<C, I> : ClientMapper<C, Changes<I>>
        where C : Eu.Xroad.UsFolkV3.Producer.ChangesBase
        where I : Id
    {
        protected ChangesMapper() { }
    }
}
