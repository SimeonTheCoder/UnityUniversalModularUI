public interface IDisplay
{
    void Refresh();

    UITransform Transform();

    void SetTransform (UITransform transform);

    void UpdateContent (string message);

    object GetContent();

    void Destroy();
}