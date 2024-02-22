using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Player selectedPlayer { get; private set; }

    public static void SetSelectedPlayer(Player player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
        }

        selectedPlayer = player;
        player.Selected(true);
    }
}
