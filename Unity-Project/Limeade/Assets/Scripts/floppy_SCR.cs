using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floppy_SCR : MonoBehaviour
{

    public movement_SCR movement_;
    public counterManager_SCR counterManager_;
    public GameObject checkpointIndicator;

    private bool checkedThis = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "ObjectDetector")
        {
            if (Input.GetKeyDown(KeyCode.Z) == true && checkedThis == false)
            {
                checkedThis = true;
                movement_.mainAudio.PlayOneShot(movement_.OS);
                counterManager_.floppyCollected += 1;
                checkpointIndicator.SetActive(false);
                Destroy(this.gameObject);

            }
        }
    }
}
