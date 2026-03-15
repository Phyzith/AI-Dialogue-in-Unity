using UnityEngine.UI;
using TMPro;
using UnityEngine;
using HardCodeDev.SimpleOllamaUnity;

namespace HardCodeDev.Examples
{
    public class NPC : MonoBehaviour
    {
        public string personality;
        public TMP_Text textBox;
        public TMP_InputField inputField;
        public Button speakButton;

        private string prompt;
        private Transform speechBubble;
        private bool inRange;

        void Start()
        {
            speechBubble = this.transform.Find("SpeechBubble");

            speakButton.onClick.AddListener(Speak);

            inRange = false;
        }

        private async void Speak()
        {
            if (inRange)
            {

                textBox.text = "Thinking...";

                string prompt = inputField.text;
                inputField.text = "";
                speechBubble.gameObject.SetActive(true);

                var ollama = new Ollama(new OllamaConfig(
                   modelName: "gemma3:1b",
                   systemPrompt: personality
                   ));

                var response = await ollama.SendMessage(new OllamaRequest(
                    userPrompt: prompt
                    ));


                if (response != null)
                {
                    Debug.Log(response);
                    textBox.text = response;
                }
            }
        }

        void OnTriggerEnter(Collider hit)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                //Debug.Log("In Range");

                inputField.gameObject.SetActive(true);

                inRange = true;
            }
        }

        void OnTriggerExit(Collider hit)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                //Debug.Log("Out of Range");

                speechBubble.gameObject.SetActive(false);

                inputField.gameObject.SetActive(false);

                inRange = false;
            }
        }
    }
}
