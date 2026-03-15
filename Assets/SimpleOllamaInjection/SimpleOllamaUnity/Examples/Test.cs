using UnityEngine;
using HardCodeDev.SimpleOllamaUnity;

namespace HardCodeDev.Examples
{
    public class Test : MonoBehaviour
    {
        private async void Start()
        {
            print("The Request has Started...");
            var ollama = new Ollama(new OllamaConfig(
                modelName: "gemma3:1b",
                systemPrompt: "Your answer mustn't be more than 10 words"
                ));

            var response = await ollama.SendMessage(new OllamaRequest(
                userPrompt: "When was Github was created?"
                ));

            Debug.Log(response);
            print(response);
        }
    }
}
