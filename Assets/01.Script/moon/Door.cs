using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneIndex;
    [SerializeField] TextMeshPro text;
    private bool isPlayer;
    private void Awake()
    {
        isPlayer = false;
        text.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.enabled = true;
        isPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.enabled = false;
        isPlayer = false;
    }
    private void Update()
    {
        if (isPlayer && Keyboard.current.fKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
