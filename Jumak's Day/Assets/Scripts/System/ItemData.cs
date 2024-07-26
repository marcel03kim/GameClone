[System.Serializable]
public class ItemData
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }

    public ItemData(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
