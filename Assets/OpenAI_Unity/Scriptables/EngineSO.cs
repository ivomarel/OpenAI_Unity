using OpenAI_API;
using UnityEngine;

namespace OpenAI_Unity
{
    [CreateAssetMenu(fileName = "OpenAI Engine", menuName = "ScriptableObjects/OpenAI Engine", order = 1)]
    public class EngineSO : ScriptableObject
    {
        public string ApiKey;
    }
}

