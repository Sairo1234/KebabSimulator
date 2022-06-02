using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWritter : MonoBehaviour
{
    private static TextWritter instance;
    private List<TextWritterSingle> textWritterSingleList;

    private void Awake()
    {
        instance = this;
        textWritterSingleList = new List<TextWritterSingle>();
    }
    public static void AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }
    private void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWritterSingleList.Add(new TextWritterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters));
    }

    private void Update()
    {
        for (int i = 0; i < textWritterSingleList.Count; i++)
        {

            bool destroyInstance = textWritterSingleList[i].Update();
            if (destroyInstance)
            {
                textWritterSingleList.RemoveAt(i);
                i--;
            }
        }

    }

    //Esto es una unica instancia de TextWritter
    public class TextWritterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        public TextWritterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            characterIndex = 0;
        }
        //Devuelve true cuando acaba
        public bool Update()
        {

            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Mostrar el siguiente caracter
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {

                    return true;
                }
            }
            return false;

        }
    }
}
