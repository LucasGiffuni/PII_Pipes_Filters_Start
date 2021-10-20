using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel
{
    public class CognitiveApi
    {


        public bool returnResult(string path)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(path);
            return FoundFace(cog);
        }
        static bool FoundFace(CognitiveFace cog)
        {
            if (cog.FaceFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
