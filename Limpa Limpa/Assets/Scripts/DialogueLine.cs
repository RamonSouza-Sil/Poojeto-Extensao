using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;

    [TextArea(3, 6)]
    public string text;
}
