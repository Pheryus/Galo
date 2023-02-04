using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMPro.TMP_Text text;
    PlayerTransformation player;

    private string info = "Carrots: $\nPotatoes: %";

    void Start()
    {
        player = FindObjectOfType<PlayerTransformation>();
    }

    void Update()
    {
        if (!player) return;
        text.text = info.Replace("$", player.carrots.ToString());
        text.text = text.text.Replace("%", player.potatoes.ToString());
    }
}
