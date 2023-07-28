using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
   public List<Button> buttonList;
   public List<Image> imageList;
   public int activeButtonCount;

   protected void InitializeButtons()
   {
      for (var i = 0; i < 20; i++)
      {
         buttonList.Add(GameObject.Find($"Button {i + 1}").GetComponent<Button>());
         imageList.Add(GameObject.Find($"Button {i + 1}").GetComponent<Image>());
         DisableButton(i);
         activeButtonCount = 0;
      }

      for (var i = 0; i < buttonList.Count; i++)
      {
         var item = buttonList[i];
         var i1 = i;
         item.onClick.AddListener(() => DisableButton(i1));
      }
   }

   private void DisableButton(int buttonNumber)
   {
      if (!buttonList[buttonNumber].enabled) return;
      buttonList[buttonNumber].enabled = false;
      imageList[buttonNumber].enabled = false;
      activeButtonCount--;
   }

   protected void EnableButton(int buttonNumber)
   {
      if (buttonList[buttonNumber].enabled != false) return;
      buttonList[buttonNumber].enabled = true;
      imageList[buttonNumber].enabled = true;
      activeButtonCount++;
   }
}
