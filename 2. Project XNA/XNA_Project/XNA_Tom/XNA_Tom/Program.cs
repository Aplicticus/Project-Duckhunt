using System;

namespace XNA_Tom
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (DreamkeeperGame game = new DreamkeeperGame())
            {
                game.Run();
            }
        }
    }
#endif
}

