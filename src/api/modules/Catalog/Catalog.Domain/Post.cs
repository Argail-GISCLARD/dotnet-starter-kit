using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Post : AuditableEntity, IAggregateRoot
{
    public string? Content { get; private set; } = string.Empty;
    public string? Title { get; private set; } = string.Empty;
    public string? Author { get; private set; } = string.Empty;
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    public Guid? JacXsonId { get; private set; }
    public virtual JacXson JacXson { get; private set; } = null!;
    private Post() { }

    private Post(Guid id, string? content, string? title, string? author, Guid? jacXsonId)
    {
        Id = id;
        CreatedOn = DateTime.UtcNow;
        Content = content;
        Title = title;
        Author = author;
        JacXsonId = jacXsonId;
        QueueDomainEvent(new PostCreated { Post = this });
    }

    public static Post Create(string? content, string? title, string? author, Guid? jacXson)
    {
        return new Post(Guid.NewGuid(), content, title, author, jacXson);
    }

    public Post Update(string? content, string? title, string? author, Guid? jacXson)
    {
        bool isUpdated = false;
        
        if (content != null && Content != content)
        {
            Content = content;
            isUpdated = true;
        }

        if (title != null && Title != title)
        {
            Title = title;
            isUpdated = true;
        }

        if (author != null && Author != author)
        {
            Author = author;
            isUpdated = true;
        }

        if (jacXson != null && JacXsonId != jacXson)
        {
            JacXsonId = jacXson;
            isUpdated = true;
        }

        if (isUpdated)
        {
            UpdatedOn = DateTime.UtcNow;
            QueueDomainEvent(new PostUpdated { Post = this });
        }

        return this;
    }
}
