using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    //sound

    private bool hasReceivedPackage = false;

    public bool HasReceivedPackage {
        get { return hasReceivedPackage; }
    }

    public void ReceivePackage() {
        if (!hasReceivedPackage) {
            hasReceivedPackage = true;

            Debug.Log("Customer has received package");
            gameObject.SetActive(false);
        }
    }
}
