using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualTextBlock : MonoBehaviour
{
    public TextBlock display;

    public TextMeshProUGUI text;

    public void Start()
    {
        //this.display = new();
    }

    public void Update()
    {
        text.text = (string) display.GetContent();

        float x = display.Transform().x;
        float y = display.Transform().y;

        this.gameObject.transform.position = new Vector3
        (
            x, y, this.gameObject.transform.position.z
        );
    }
}