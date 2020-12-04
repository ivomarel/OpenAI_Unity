using OpenAI_API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OpenAI_Unity
{
    [Serializable] public class StringEvent : UnityEvent<string> { }
    [Serializable] public class ChoicesEvent : UnityEvent<List<Choice>> { }

}