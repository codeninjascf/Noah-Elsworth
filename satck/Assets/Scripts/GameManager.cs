using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner spawner;
    public CameraFollow view;
    public UIManager uIManager;

    private bool _gameOver;
    // Start is called before the first frame update
   private void Start()
   {
       spawner.Spawn();
   }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_gameOver)
        {
            BlockMovement.CurrentBlock.Stop();
            if (BlockMovement.GameOver)
            {
                _gameOver = true;
            }
            else
            {
                spawner.Spawn();
                view.Height = spawner.GetNewHeight();
                uIManager.Score++;
            }
        }
    }
}
