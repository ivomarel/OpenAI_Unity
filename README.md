# Open AI in Unity

An extension of the C# .NET wrapper from OkGoDoIt as can be found on https://github.com/OkGoDoIt/OpenAI-API-dotnet. This extension is meant to make it easier to use Open AI in Unity.

*Tested with Unity 2020.1.4f1*

## Important!
This is intended as a simple showcase of OpenAI in Unity, but I am not affiliated with OpenAI in any way, nor can I guarantee any future updates/support on this project. Also, future updates can potentially break previous projects, as I am considering some structural changes to the system. If you'd like to contribute or have any questions, feel free to contact me with any questions on the OpenAI Slack.

## Examples

[![](http://img.youtube.com/vi/Va6PBIz1BxY/0.jpg)](http://www.youtube.com/watch?v=Va6PBIz1BxY "OpenAI Unity Demo")

In the Example/DemoScenes folder you can find two demo scenes with examples of how this can be used. You need Beta access to OpenAI and a custom ApiKey from https://beta.openai.com/docs/developer-quickstart/your-api-keys 
This can be copied into an EngineSO.

## Engine

To get started with your scene, you will need a GameObject with an OAIEngine script. Using the Inspector, you will have to drag in an EngineSO Scriptable Object, which contains your ApiKey.

![OAIEngine](https://i.imgur.com/OQGI5XG.png)

## OAIGenericCompletion (:OAICompletion)

This script can be added to an empty GameObject, allowing for full control when accessing OpenAI. By using the parameters in the Inspector, this provides a similar experience to the [OpenAI Playground](https://beta.openai.com/playground)

## OAICharacter (:OAICompletion)

Characters are similar to the OAIGenericCompletion, but have a few presets to make it easier to use for a character. This can be useful when you have one or more characters in your scene, as can be seen in the CharacterDemo scene.

## OAIBehavior

There are multiple Behaviors that can be attached to any GameObject with an OAICharacter component. Behaviors get picked up the OAICharacter to describe the character that's being talked to. Since they are components, characters can share some Behaviors. Currently there is only one Behavior, but more (such as the SpatialAwarenessBehavior) are scheduled to be added in the future.

### ScriptableOAIBehavior
This Behavior allows us to add basic data that describes a character, with the use of the BehaviorSO ScriptableObject. You can create your own BehaviorSO objects through Assets/Create/Scriptable Objects/OpenAI Behavior.
Below an example can be seen of an Angry Behavior, as well as a simple show of how this can be added to character.

![Angry BehaviorSO](https://i.imgur.com/MhhBGFp.png)![ScriptableOAI Behavior](https://i.imgur.com/UFrG8A3.png)


## License
[![CC-0 Public Domain](https://camo.githubusercontent.com/9e918e1e7cd28a73246cf1c8d2c9903da3e487a65931c823a2391afe4b4a0d04/68747470733a2f2f6c6963656e7365627574746f6e732e6e65742f702f7a65726f2f312e302f38387833312e706e67)](https://camo.githubusercontent.com/9e918e1e7cd28a73246cf1c8d2c9903da3e487a65931c823a2391afe4b4a0d04/68747470733a2f2f6c6963656e7365627574746f6e732e6e65742f702f7a65726f2f312e302f38387833312e706e67)

This library is licensed CC-0, in the public domain. You can use it for whatever you want, publicly or privately, without worrying about permission or licensing or whatever. It's just a wrapper around the OpenAI API, so you still need to get access to OpenAI from them directly. I am not affiliated with OpenAI and this library is not endorsed by them, I just have beta access and wanted to make a Unity library to access it more easily. Hopefully others find this useful as well. Feel free to open a PR if there's anything you want to contribute
