using UnityEngine;

namespace OpenAI_Unity
{
    [CreateAssetMenu(fileName = "OpenAI Behavior", menuName = "ScriptableObjects/OpenAI Behavior", order = 1)]
    public class BehaviorSO : ScriptableObject
    {
        [SerializeField, TextArea(5, 20)]
        public string Description;
        
    }

}