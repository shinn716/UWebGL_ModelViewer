using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DgcDoor : MonoBehaviour
{
    public Transform target;
    public GameObject dialogOpen;
    public GameObject dialogClose;

    private bool m_open = false;
    private bool m_enable = true;

    private void Start()
    {
        dialogClose.SetActive(false);
        dialogOpen.SetActive(true);
    }

    public void OpenDoor()
    {
        // open
        if (!m_open && m_enable)
        {
            m_enable = false;
            dialogOpen.SetActive(false);
            target.DOLocalRotate(Vector3.up * 100, 1f, RotateMode.Fast).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                m_enable = true;
                dialogClose.SetActive(true);
            });
            m_open = true;
        }
        // close
        else if (m_open && m_enable)
        {
            m_enable = false;
            dialogClose.SetActive(false);
            target.DOLocalRotate(Vector3.zero, 1f, RotateMode.Fast).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                m_enable = true;
                dialogOpen.SetActive(true);
            });
            m_open = false;
        }
    }
}
