using System.Diagnostics;

public class TextBlock : IDisplay
{
    private string text;
    private UITransform transform;

    public TextBlock ()
    {
        this.text = string.Empty;
        this.transform = new(0f, 0f);

        this.Refresh();
    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateContent(string message)
    {
        this.text = message;
    }

    public void Refresh()
    {
        
    }

    public void SetTransform(UITransform transform)
    {
        this.transform = transform;
        //this.Refresh();
    }

    public UITransform Transform()
    {
        return this.transform;
    }

    public object GetContent()
    {
        return this.text;
    }
}