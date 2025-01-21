using System.Collections.Generic;

public class UISystem
{
    private UIQuestSystem questManager;

    public UISystem()
    {
        this.questManager = new();
    }

    public void Update()
    {
        foreach (var quest in questManager.GetQuests())
        {
            quest.Value.UpdateContent(quest.Key.ToString());
            quest.Value.Refresh();
        }
    }

    public void AddQuest (UIQuest quest)
    {
        this.questManager.AddQuest(quest);
    }

    public void RemoveQuest (UIQuest quest)
    {
        this.questManager.RemoveQuest(quest);
    }

    public Dictionary<UIQuest, IDisplay> GetQuests ()
    {
        return this.questManager.GetQuests();
    }
}