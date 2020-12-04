using OpenAI_API;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace OpenAI_Unity
{
    /// <summary>
    /// Used for objects that communicate with OpenAI Completion
    /// Abstract itself, for a Generic and fully customizable Completion object use OAIGenericCompletion
    /// </summary>
    public abstract class OAICompletion : MonoBehaviour
    {
        public abstract string Description
        {
            get; set;
        }

        public abstract string InjectStartText
        {
            get; set;
        }

        public abstract string InjectRestartText
        {
            get; set;
        }

        public abstract string[] StopSequences
        {
            get; set;
        }

        public EngineEnum engine;

        public enum EngineEnum
        {
            Ada,
            Babbage,
            Curie,
            Davinci
        }

        public enum LogLevel
        {
            None,
            Responses,
            ResponsesAndMemory
        }

        public LogLevel logLevel;

        public int Max_tokens = 16;
        [Range(0, 1)]
        public double Temperature = 0.1;
        [Range(0, 1)]
        public double Top_p = 1;
        public abstract int NumOutputs {get;set;}
        [Range(0, 1)]
        public double PresencePenalty = 1;
        [Range(0, 1)]
        public double FrequencyPenalty = 1;
        public int LogProbs = 1;

        public StringEvent QuestionReceivedEvent;
        public ChoicesEvent ResponseReceivedEvent;

        /// <summary>
        /// This can be disabled when using multiple responses, since they should not be manually added to the entire memory
        /// </summary>
        [HideInInspector]
        public bool autoAddResponseToMemory = true;

        private StringBuilder memory;

        private void Start()
        {
            memory = GetDefaultInformation();
        }


        public void Brainwash(bool resetToDefault = true)
        {
            memory = resetToDefault ? GetDefaultInformation() : new StringBuilder();
        }

        /// <summary>
        /// D
        /// </summary>
        /// <returns></returns>
        protected virtual StringBuilder GetDefaultInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Description);

            foreach (OAIBehavior behavior in GetComponents<OAIBehavior>())
            {
                string behaviorText = behavior.GetAsText();
                sb.Append(behaviorText);
                sb.Append(" ");
            }            

            return sb;
        }

        public async void AddToStory(string value)
        {
            QuestionReceivedEvent?.Invoke(value);

            //Character should remember what they said before, since every time we send a request it requires the full 'story' to OpenAI
            memory.Append(value).Append(InjectStartText);

            if (logLevel == LogLevel.ResponsesAndMemory)
            {
                Debug.Log(memory);
            }

            if (!OAIEngine.Instance)
            {
                Debug.LogError("No OAIEngine object found in scene. Make sure there's a GameObject with an OAIEngine Component in your scene");
                return;
            }    

            //We allow the engine to change per request (= per character and per statement)
            OAIEngine.Instance.Api.UsingEngine = GetEngine(engine);

            if (NumOutputs < 1)
            {
                Debug.LogWarning($"NumOutputs was set to {NumOutputs}. You should have at least 1 output!");
                NumOutputs = 1;
            } else if (autoAddResponseToMemory && NumOutputs > 1)
            {
                Debug.Log("Multiple or no outputs are requested while autoAddResponseToMemory is still true. You should set this to false and manually call 'AddResponseToMemory' after selecting your prefered response.");
            }  

            var c = new CompletionRequest(memory.ToString(), Max_tokens, Temperature, Top_p, NumOutputs, PresencePenalty, FrequencyPenalty, LogProbs, StopSequences);
            var results = await OAIEngine.Instance.Api.Completions.CreateCompletionsAsync(c);

            ResponseReceivedEvent?.Invoke(results.Completions);

            //We make it easy by auto-adding responses to the memory
            if (autoAddResponseToMemory)
            {
                var r = results.Completions[0].Text;
                AddResponseToMemory(r);
                if (logLevel == LogLevel.Responses || logLevel == LogLevel.ResponsesAndMemory)
                {
                    Debug.Log(r);
                }                
            }
        }

        public void AddResponseToMemory (string value)
        {
            memory.Append(value).Append(InjectRestartText);            
        }

        private Engine GetEngine(EngineEnum e)
        {
            switch (e)
            {
                case EngineEnum.Ada:
                    return Engine.Ada;
                case EngineEnum.Babbage:
                    return Engine.Babbage;
                case EngineEnum.Curie:
                    return Engine.Curie;
                case EngineEnum.Davinci:
                    return Engine.Davinci;
            }
            return Engine.Default;
        }

    }

}