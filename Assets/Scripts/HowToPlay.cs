using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howPlay;
   public void openHowToPlay()
   {
     mainMenu.SetActive(false);
     howPlay.SetActive(true);
   }

   public void closeHowtoPlay()
   {
       howPlay.SetActive(false);
       mainMenu.SetActive(true);
   }
}
