public interface IFileService : IService
{
    public void Save(SaveDataModel saveDataModel);
    public SaveDataModel Load();
    public void Delete();
}