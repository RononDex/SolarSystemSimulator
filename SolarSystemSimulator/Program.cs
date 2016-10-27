using SolarSystemSimulator.Views;
using System;

namespace SolarSystemSimulator
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameEngine.GameEngine( new GameEngine.GameEngineSettings() { StartView = new TestView() } ))
            {
                game.Run();                
            }
        }
    }
#endif
}
