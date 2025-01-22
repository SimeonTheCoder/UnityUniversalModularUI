using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UISystem system;

    private int timer;

    public GameObject[] uiElements;
    public GameObject[] positions;

    private List<UIQuest> quests;

    public GameObject canvas;

    public void AddQuest(UIQuest quest)
    {
        quests.Add(quest);
        system.AddQuest(quest);

        VisualTextBlock currTextBlock = Instantiate(uiElements[0]).GetComponent<VisualTextBlock>();

        TextBlock questDisplay = (TextBlock) system.GetQuests().Last().Value;

        questDisplay.SetTransform(positions[0].GetComponent<RectTransform>());

        currTextBlock.RegisterDisplay(questDisplay);
        currTextBlock.transform.SetParent(canvas.transform);
    }

    public void Start()
    {
        this.quests = new();
        this.system = new();

        timer = 0;

        AddQuest(new UIQuest("Welcome", "Nigerundayo!"));
    }

    public void Update()
    {
        timer++;

        quests[0].Description = "Test: " + timer++;
        system.Update();
    }
}