using System;
using UnityEngine;
using UnityEngine.Video;

public class InvisibleWall : MonoBehaviour
{
    [SerializeField] Material Material;
    [SerializeField] Transform Player;
    [SerializeField] Transform Wall;
    [SerializeField] VideoPlayer VideoWall;

    public void Awake()
    {
        //VideoWall.enabled = false;
        //Material.color = new Color(0, 0, 0, 0);
        Material.color = new Color(0, 0.3F, 1, 1);
    }
    public void ChangeTransparency()
    {
        float Transparency = (Player.position - Wall.position).magnitude/6.76F;
        //Debug.Log(Transparency);
        Material.color = new Color(0, 0.3F, 1, 1.3F-Transparency);
    }

    private void Update()
    {
        //ChangeTransparency();
    }
}
