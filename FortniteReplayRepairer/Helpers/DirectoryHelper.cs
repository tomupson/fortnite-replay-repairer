using System.IO;

namespace FortniteReplayRepairer.Helpers
{
    public static class DirectoryHelper
    {
        public static DirectoryInfo GetOrCreateDirectory(string directoryPath) =>
            !Directory.Exists(directoryPath) ? Directory.CreateDirectory(directoryPath) : new DirectoryInfo(directoryPath);
    }
}