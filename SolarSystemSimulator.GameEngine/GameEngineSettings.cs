using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameEngineSettings
    {
        public string DisplayName { get; set; } = "Unknown Game";

        public string ContentDirectoryRoot { get; set; } = "Content";

        public View StartView { get; set; }
    }
}
