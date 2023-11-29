namespace Engine.Runners.TestingProject
{
    public class FolderOrigin : AbsTestOrigin
    {
        public override TestOrigins Origin { get => TestOrigins.Folder; }
        public FolderOrigin(string path) 
        {
            this.Path = path;
        }
    }
}
