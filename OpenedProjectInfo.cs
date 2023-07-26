using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2
{
    public static class OpenedProjectInfo
    {
        public static Action? StateChanged;
        public static Project? OpenedProject { get; set; }

        private static ProjectState state;
        public static ProjectState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                if (StateChanged != null)
                    StateChanged();
            }
        }
    }
}
