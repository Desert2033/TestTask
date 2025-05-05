public interface ISaveLoadService : IService
{
    void ClearReaders();
    void ClearWriters();
    PlayerProgress LoadProgress();
    void NotifyAllReaders();
    void RegisterProgressReader(ISavedProgressReader reader);
    void RegisterProgressWriter(ISavedProgressWriter writer);
    void SaveProgress();
}