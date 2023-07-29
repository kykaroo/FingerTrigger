using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
   public List<Button> buttonList;
   public List<Image> imageList;
   public int activeButtonCount;
   public int lastDisabledButton;
   private AudioSource _buttonSoundEffect;

   protected void InitializeButtons()
   {
      _buttonSoundEffect = GameObject.Find("ButtonSoundEffect").GetComponent<AudioSource>();
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
         item.onClick.AddListener(_buttonSoundEffect.Play);
      }
   }

   private void DisableButton(int buttonNumber)
   {
      if (!buttonList[buttonNumber].enabled) return;
      buttonList[buttonNumber].enabled = false;
      imageList[buttonNumber].enabled = false;
      lastDisabledButton = buttonNumber;
      activeButtonCount--;
      Debug.Log($"DisableButton button={buttonNumber} last={lastDisabledButton}");
   }

   protected bool EnableButton(int buttonNumber)
   {
      if (buttonList[buttonNumber].enabled) return false;
      buttonList[buttonNumber].enabled = true;
      imageList[buttonNumber].enabled = true;
      activeButtonCount++;
      return true;
   }
}
