namespace ConsoleApp01.ValueObjects;

public class Tracker : ValueObject
{
    public Tracker()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Tracker(DateTime createdAt, DateTime updatedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public void Update() => UpdatedAt = DateTime.UtcNow;

    public static implicit operator string(Tracker tracker) =>
        $"Última atualização em {tracker.UpdatedAt:dd/MM/yyyy HH:mm:ss}";

    public override string ToString() => $"Última atualização em {UpdatedAt:dd/MM/yyyy HH:mm:ss}";
}