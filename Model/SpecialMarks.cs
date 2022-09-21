using System.Collections;

namespace Us.FolkV3.Api.Model;

public class SpecialMarks : IEnumerable<SpecialMarkType>
{
    private ISet<SpecialMarkType> Types { get; }
    public bool IsEmpty { get { return Types.Count == 0; } }
    public bool IsNameAndAddressProtected { get { return Types.Contains(SpecialMarkType.NameAndAddressProtected); } }
    public bool IsExcludedFromMarketing { get { return Types.Contains(SpecialMarkType.ExcludedFromMarketing); } }
    public bool IsExcludedFromStatisticAndResearch { get { return Types.Contains(SpecialMarkType.ExcludedFromStatisticAndResearch); } }

    public SpecialMarks(ISet<SpecialMarkType> types)
    {
        Types = new HashSet<SpecialMarkType>(types);
    }

    public IList<SpecialMarkType> ToList()
    {
        return new List<SpecialMarkType>(Types).AsReadOnly();
    }

    public IEnumerator<SpecialMarkType> GetEnumerator()
    {
        return Types.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}
