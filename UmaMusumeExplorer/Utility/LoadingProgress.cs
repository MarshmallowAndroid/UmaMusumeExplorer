namespace UmaMusumeExplorer.Utility
{
    class LoadingProgress : IProgress<int>
    {
        private readonly Action<int> reportProgress;

        public LoadingProgress(Action<int> action)
        {
            reportProgress = action;
        }

        public void Report(int value)
        {
            reportProgress.Invoke(value);
        }
    }
}
