using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{
    [SerializeField]
    private bool closed;
    [SerializeField]
    private Animator drawer = null;
    [SerializeField]
    private Text OpenText;
    [SerializeField]
    private Text CloseText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleDrawer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (closed)
            {
                CloseText.gameObject.SetActive(false);
                OpenText.gameObject.SetActive(true);
            } 
            else
            {
                CloseText.gameObject.SetActive(true);
                OpenText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenText.gameObject.SetActive(false);
            CloseText.gameObject.SetActive(false);
        }
    }
    public void ToggleDrawer()
    {
        if (closed)
        {
            drawer.Play("DrawerOpen", 0, 0.0f);
            CloseText.gameObject.SetActive(true);
            OpenText.gameObject.SetActive(false);
            closed = !closed;
        } 
        else
        {
            CloseText.gameObject.SetActive(false);
            OpenText.gameObject.SetActive(true);
            drawer.Play("DrawerClose", 0, 0.0f);
            closed = !closed;
        }
    }
}
