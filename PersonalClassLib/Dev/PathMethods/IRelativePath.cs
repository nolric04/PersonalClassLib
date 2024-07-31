namespace PersonalClassLib.Dev.PathMethods
{
    public interface IRelativePath
    {
        string ConvertAbsolutePath(string relativePath);
        bool IsCheminRelatif(string path);
    }
}