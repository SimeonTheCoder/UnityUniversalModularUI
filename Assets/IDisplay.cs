using UnityEngine;

public interface IDisplay
{
    void Refresh();

    RectTransform Transform();

    void SetTransform (RectTransform transform);

    void UpdateContent (string message);

    object GetContent();

    void Destroy();
}