public interface ISavedProgressWriter : ISavedProgressReader
{
    void UpdateProgress(PlayerProgress progress);
}
