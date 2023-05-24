using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
public class BaseEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PopupDisplayUI.instance.ShowOptionsPopup($"What is a correct syntax to output \"Hello World\" in C#?\n\n" +
                                                     $"1: Console.WriteLine(\"Hello World\");\n2: print(\"Hello World\");\n" +
                                                     $"3: System.out.println(\"Hello World\");\n" +
                                                     $"4: cout << \"Hello World\";",
                () =>
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => {});
                }, () =>
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                    
                }, () =>
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                    
                }, () =>
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                    
                } );
        }
    }
}
