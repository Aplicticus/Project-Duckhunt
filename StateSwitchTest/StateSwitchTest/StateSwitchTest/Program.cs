using System;

namespace StateSwitchTest
{
#if WINDOWS || XBOX
    static class Program
    {
        public static Game1 game;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

