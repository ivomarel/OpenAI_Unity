using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenAI_Unity
{
    public class OAIEngine : MonoBehaviour
    {
        public static OAIEngine Instance;

        public OpenAIAPI Api;

        public EngineSO EngineSO;

        private void Awake()
        {
            Instance = this;

            if (!EngineSO)
            {
                Debug.LogError("No EngineSO set. To create a new EngineSO, go to Assets>Create>ScriptableObjects>Open AI Engine");
                return;
            }

            if (string.IsNullOrEmpty(EngineSO.ApiKey))
            {
                Debug.LogError("Your ApiKey was not set. You can get your ApiKey from https://beta.openai.com/docs/developer-quickstart/your-api-keys");
                return;
            }
            Api = new OpenAIAPI(new APIAuthentication(EngineSO.ApiKey)); // specify manually
            
        }

    }
}