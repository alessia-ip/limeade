using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterManager_SCR : MonoBehaviour
{

    public movement_SCR movement_;

    public Canvas counterCanvas;

    public Text checkpointText;
    public Text floppyText;

    public int checkpointsReached = 0;
    public int floppyCollected = 0;

    public AudioSource mainAud;

    public AudioClip victory;


    public Animator camAnim;

    private void Start()
    {
        movement_.enabled = false;
        StartCoroutine(MOVE());
    }


    private void Update()
    {
        checkpointText.text = checkpointsReached + "/3 checkpoints";
        floppyText.text = floppyCollected + "/4 disks";
        if (checkpointsReached == 3 && floppyCollected == 4)
        {
            StartCoroutine(YouWin());
        }
    }

    IEnumerator YouWin(){
        yield return new WaitForSeconds(1);
        Initiate.Fade("TitleScreen", new Color(0, 0, 0), 5);
    }

    IEnumerator MOVE(){
        yield return new WaitForSeconds(12);
        movement_.enabled = true;
        camAnim.enabled = false;
    }

}
