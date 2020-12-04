using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace OpenAI_Unity
{
    public class SimpleOAIBehavior : OAIBehavior
    {
        [TextArea(5,20)]
        public string Description;

        public override string GetAsText()
        {
            return Description;
        }
    }

}
