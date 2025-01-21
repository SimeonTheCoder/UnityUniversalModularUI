using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private UISystem system;

    public GameObject[] uiElements;
    public GameObject canvas;

    public void AddQuest()
    {
        UIQuest quest = new UIQuest("Welcome", "Nigerundayo!");

        system.AddQuest(quest);

        GameObject currTextBlock = Instantiate (uiElements[0]);

        TextBlock questDisplay = (TextBlock) system.GetQuests().Last().Value;

        currTextBlock.GetComponent<VisualTextBlock>().display = questDisplay;
        currTextBlock.transform.SetParent(canvas.transform);
    }

    public void Start()
    {
        this.system = new();

        AddQuest();
    }

    public void Update()
    {
        system.Update();
    }
}