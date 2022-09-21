using Us.FolkV3.Api.Client;

namespace Us.FolkV3.Api.Model;

public class CommunityPerson
{
    public PersonSmall Person { get; }
    public PrivateId ExistingId { get; }
    public CommunityPersonStatus Status { get; }
    public bool IsAdded { get { return Status.Equals(CommunityPersonStatus.Added); } }
    public bool IsAlreadyExists { get { return Status.Equals(CommunityPersonStatus.AlreadyExists); } }
    public bool IsNotFound { get { return Status.Equals(CommunityPersonStatus.NotFound); } }
    public bool IsMoreThanOne { get { return Status.Equals(CommunityPersonStatus.NotFound); } }

    public CommunityPerson(PersonSmall person, PrivateId existingId, CommunityPersonStatus status)
    {
        Status = Util.RequireNonNull(status, "status");
        if (person == null && status.Equals(CommunityPersonStatus.Added))
        {
            throw new FolkApiException("person must not be null when status is " + CommunityPersonStatus.Added);
        }
        if (existingId == null && status.Equals(CommunityPersonStatus.AlreadyExists))
        {
            throw new FolkApiException("existingId must not be null when status is " + CommunityPersonStatus.AlreadyExists);
        }
        Person = Status.Equals(CommunityPersonStatus.AlreadyExists) ? null : person;
        ExistingId = existingId;
    }

}
