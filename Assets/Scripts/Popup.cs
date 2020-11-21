using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    [SerializeField] private TextMeshPro popup3DPrefab;
    [SerializeField] private Camera cam;
    public static Popup instance;

    private void Awake()
    {
        instance = this;
    }

    private void Display3DPopup(string msg, Color col, Vector3 pos, float scale)
    {
        TextMeshPro popup = Instantiate(popup3DPrefab);
        popup.text = msg;
        popup.transform.localScale = Vector3.one * scale;
        popup.transform.position = pos;
        popup.transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        popup.color = col;

        DOTween.ToAlpha(() => popup.color, x => popup.color = x, 0f, 1f);
        popup.transform.DOLocalMoveY(popup.transform.localPosition.y + 2, 1f).OnComplete(() =>
            {
                Destroy(popup.gameObject);
            });
    }

    public static void Display3DPopup_Static(string msg, Color col, Vector3 pos, float scale)
    {
        instance.Display3DPopup(msg, col, pos, scale);
    }
}
