using System.Diagnostics;
using UnityEngine;

public class TextBlock : IDisplay
{
    private string text;
    private RectTransform transform;

    public TextBlock ()
    {
        this.text = string.Empty;
        this.transform = new RectTransform();

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

    public void SetTransform(RectTransform transform)
    {
        this.transform = transform;
        //this.Refresh();
    }

    public RectTransform Transform()
    {
        return this.transform;
    }

    public object GetContent()
    {
        return this.text;
    }
}