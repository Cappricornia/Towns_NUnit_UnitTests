public class TownsCollection
{
    public TownsCollection()
    {
        this.Towns = new List<string>();
    }

    public TownsCollection(string townsCommaSeparated)
    {
        this.Towns = townsCommaSeparated
        .Split(',')
        .Select(t => t.Trim())
        .Where(t => !string.IsNullOrEmpty(t))
        .ToList();
    }

    public List<string> Towns { get; set; }

    public override string ToString()
    {
        return string.Join(", ", this.Towns);
    }

    public bool Add(string townName)
    {
        if (string.IsNullOrEmpty(townName) || this.Towns.Contains(townName))
            return false;

        this.Towns.Add(townName);
        return true;
    }

    public void RemoveAt(int index)
    {
        this.Towns.RemoveAt(index);
    }

    public void Reverse()
    {
        if (this.Towns == null)
            throw new ArgumentNullException();
        if (this.Towns.Count <= 1)
            throw new InvalidOperationException();

        this.Towns.Reverse();
    }
}
