using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningPitch
{
    public static class globals
    {
        public static Persona user = new Persona();
        public static void Flush()
        {
            user = new Persona();
        }
    }

    
}
