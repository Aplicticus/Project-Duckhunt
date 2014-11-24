using System;

namespace XNA_MainProject
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (StateSwitcher game = new StateSwitcher())
            {
                game.Run();
            }
            
        }
    }
#endif
}

