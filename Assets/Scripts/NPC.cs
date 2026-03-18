using UnityEngine.UI;
using TMPro;
using UnityEngine;
using HardCodeDev.SimpleOllamaUnity;

namespace HardCodeDev.Examples
{
    public class NPC : MonoBehaviour
    {
        // public variables
        public string personality;
        public TMP_Text textBox;
        public TMP_InputField inputField;
        public Button speakButton;

        // private variables
        private string prompt;
        private Transform speechBubble;
        private bool inRange;

        void Start()
        {
            speechBubble = this.transform.Find("SpeechBubble");
            inRange = false;

            speakButton.onClick.AddListener(Speak);
        }

        /// <summary>
        /// Manages messages between the player and the LLM. Sets the speech bubble and text box text.
        /// </summary>
        private async void Speak()
        {
            if (inRange)
            {

                textBox.text = "Thinking...";

                string prompt = inputField.text; // sets the prompt to whatever the player types
                inputField.text = "";
                speechBubble.gameObject.SetActive(true);

                var ollama = new Ollama(new OllamaConfig( // locally runs a LLM through Ollama
                   modelName: "gemma3:1b", // set to the LLM you want to use
                   systemPrompt: personality // prompts the LLM with the personality variable
                   ));

                var response = await ollama.SendMessage(new OllamaRequest( // sends your prompt to the LLM
                    userPrompt: prompt
                    ));


                if (response != null)
                {
                    Debug.Log(response);
                    textBox.text = response;
                }
            }
        }

        /// <summary>
        /// Enables the textbox when you enter the NPCs box collider
        /// </summary>
        /// <param name="hit"> The object that enters the box collider.</param>
        void OnTriggerEnter(Collider hit)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                //Debug.Log("In Range");

                inputField.gameObject.SetActive(true);
                inRange = true;
            }
        }

        /// <summary>
        /// Disables the textbox when you exit the NPCs box collider.
        /// </summary>
        /// <param name="hit"> The object that enters the box collider.</param>
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
