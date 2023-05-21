
public class MapNote
{
    private bool closed;
    private long timing;

    public MapNote(bool closed, long timing)
    {
        this.closed = closed;
        this.timing = timing;
    }

    public bool IsClosed()
    {
        return closed;
    }

    public long GetTiming()
    {
        return timing;
    }

    public override string ToString()
    {
        return string.Format("closed: {0}, timing: {1}", closed, timing);
    }
}
