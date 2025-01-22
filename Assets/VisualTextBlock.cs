using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections.Generic;
using System.Text;

public class VisualTextBlock : MonoBehaviour
{
    public List<IDisplay> displays;

    public TextMeshProUGUI text;

    public VisualTextBlock()
    {
        this.displays = new();
    }

    public void Start()
    {
        //this.displays = new();
    }

    public void RegisterDisplay(IDisplay display)
    {
        this.displays.Add(display);
    }

    public void Update()
    {
        if (displays.Count > 0)
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = displays[0].Transform().anchoredPosition;

        StringBuilder sb = new();

        foreach (IDisplay display in displays)
        {
            sb.Append((string) display.GetContent());
            sb.Append("\n");
        }

        this.text.text = sb.ToString();
    }
}