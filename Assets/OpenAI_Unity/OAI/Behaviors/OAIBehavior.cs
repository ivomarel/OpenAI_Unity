using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenAI_Unity
{
    [RequireComponent(typeof(OAICharacter))]
    public abstract class OAIBehavior : MonoBehaviour
    {
        public abstract string GetAsText();
    }

}
