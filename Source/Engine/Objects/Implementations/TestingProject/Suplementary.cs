using Engine.Objects.Definitions.Abstracts.TestingProject;
using System.Text.Json;

namespace Engine.Objects.Implementations
{
    public partial class DotSIDEImplementation
    {
        public static List<DotSIDEImplementation> LoadFromDirectory(string testsPath) 
        {
            List<DotSIDEImplementation> SideFiles = null;
            if(!Directory.Exists(testsPath)) return SideFiles;
            var files = Directory.EnumerateFiles(testsPath).ToList();
            if (files == null || files.Count < 1) return SideFiles;
            SideFiles = new List<DotSIDEImplementation>();
            foreach (var file in files)
            {
                var readedFile = LoadFromFile(file);
                if (readedFile == null) continue;
                SideFiles.Add(readedFile);
            }
            return SideFiles; 
        }
        public static DotSIDEImplementation LoadFromFile(string testsFilePath) 
        {
            DotSIDEImplementation test = null;
            if (!File.Exists(testsFilePath)) return test;
            if (String.IsNullOrEmpty(testsFilePath)) return test;
            try
            {
                string readedFile = File.ReadAllText(testsFilePath);
                if (String.IsNullOrEmpty(readedFile)) 
                { 
                    return test; 
                }
                else 
                {
                    test = JsonSerializer.Deserialize<DotSIDEImplementation>(
                        json: readedFile,
                        new JsonSerializerOptions()
                        {
                            AllowTrailingCommas = true,
                            PropertyNameCaseInsensitive = true,
                            ReadCommentHandling = JsonCommentHandling.Skip
                        }
                    );
                }
            }
            catch { }
            return test;
        }
    }
}
