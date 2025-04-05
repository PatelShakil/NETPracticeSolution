namespace EventDelegateLoggerWebApp.Utils
{
    public class Events
    {
        public delegate void Load(string pageName);
        public event Load OnLoad;

        public void EventLoad(string pageName)
        {
            if (OnLoad != null)
            {
                OnLoad(pageName);
                Console.WriteLine(pageName + " Visited");
            }
            else
            {
                throw new Exception("Event not implemented yet");
            }
        }

    }
}
