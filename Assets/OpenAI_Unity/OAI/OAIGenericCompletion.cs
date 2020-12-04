using OpenAI_API;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenAI_Unity
{
    /// <summary>
    /// Allows us to communicate with the Completion engine without any presets
    /// </summary>
    public class OAIGenericCompletion : OAICompletion
    {
        [SerializeField, Tooltip("Used to send data next frame. Can be useful when testing")]
        private bool addToStoryNextFrame;

        [SerializeField, TextArea(5, 20)]
        private string _description;
        public override string Description { get => _description; set => _description = value; }

        [SerializeField]
        private string _appendToQuestion;
        public override string InjectStartText { get => _appendToQuestion; set => _appendToQuestion = value; }

        [SerializeField]
        private string _appendToResponse;
        public override string InjectRestartText { get => _appendToResponse; set => _appendToResponse = value; }

        [SerializeField]
        private string[] _stopSequences;
        public override string[] StopSequences { get => _stopSequences; set => _stopSequences = value; }

        [SerializeField]
        private int _numOutputs;
        public override int NumOutputs { get => _numOutputs; set => _numOutputs = value; }

        private void Update()
        {
            if (addToStoryNextFrame)
            {
                addToStoryNextFrame = false;
                AddToStory("");
            }
        }
    }
}