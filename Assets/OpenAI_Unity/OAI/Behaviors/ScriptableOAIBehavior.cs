using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace OpenAI_Unity
{
    public class ScriptableOAIBehavior : OAIBehavior
    {
        public BehaviorSO[] behaviors;

        public override string GetAsText()
        {
            StringBuilder sb = new StringBuilder();
            foreach(BehaviorSO bSo in behaviors)
            {
                sb.Append(bSo.Description);
            }
            return sb.ToString();
        }
    }

}
