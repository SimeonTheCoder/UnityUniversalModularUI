using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UISystem system;

    private VisualTextBlock popUpBlock;

    private int timer;

    public GameObject[] uiElements;
    public GameObject[] positions;

    private List<UIQuest> quests;

    public GameObject canvas;

    public UIManager()
    {
        this.quests = new();
        this.system = new();
    }

    public void AddQuest(UIQuest quest)
    {
        quests.Add(quest);
        system.AddQuest(quest);

        VisualTextBlock currTextBlock = Instantiate(uiElements[0]).GetComponent<VisualTextBlock>();

        TextBlock questDisplay = (TextBlock) system.GetQuests().Last().Value;

        questDisplay.SetTransform(positions[0].GetComponent<RectTransform>());
        questDisplay.Duration = 5;

        currTextBlock.RegisterDisplay(questDisplay);
        currTextBlock.transform.SetParent(canvas.transform);
    }

    public void SetPopUp (PopUp popUp)
    {
        popUpBlock.gameObject.SetActive(true);
        system.UpdatePopUp(popUp);
        Debug.Log(popUp.Duration);
    }

    public void Start()
    {
        timer = 0;

        this.popUpBlock = Instantiate(uiElements[1]).GetComponent<VisualTextBlock>();
        this.popUpBlock.RegisterDisplay(system.popUpTextBlock);

        this.popUpBlock.display.SetTransform(positions[1].GetComponent<RectTransform>());
        this.popUpBlock.display.ResumeTime();

        this.popUpBlock.transform.SetParent(canvas.transform);

        AddQuest(new UIQuest("Welcome", "Nigerundayo!"));
        SetPopUp(new PopUp("NEW QUEST: Press V 10 times"));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            timer++;
        }

        quests[0].Description = "Test: " + timer;
        system.Update(Time.deltaTime);

        if (timer == 10)
        {
            SetPopUp(new PopUp("Quest complete: Press V 10 times"));
            timer++;
            ((TextBlock) system.GetQuests().Last().Value).ResumeTime();
        }
    }
}