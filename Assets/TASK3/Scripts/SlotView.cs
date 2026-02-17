using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using System.IO;
using UnityEngine;

public class SlotView: MonoBehaviourExtBind
{
    public RectTransform[] items;
    public float itemHeight = 200f;

    [OnUpdate]
    private void OnUpdate()
    {
        float speed = Model.Get<float>("Speed", 0f);

        if (speed > 0)
        {
            foreach (var item in items)
            {
                Vector2 pos = item.anchoredPosition;
                pos.y -= speed * Time.deltaTime;

                if (pos.y <= -itemHeight * 2)
                {
                    pos.y += items.Length * itemHeight;
                }
                item.anchoredPosition = pos;
            }
        }
        Debug.Log($"Current Speed: {Model.Get<float>("Speed")}");
    }

    [Bind("AlignSlots")]
    private void AlignSlots()
    {
        Debug.Log("SlotView: started aligning to the center");

        var targetPath = new CPath();

        foreach (var item in items)
        {
            float currentY = item.anchoredPosition.y;
            float targetY = Mathf.Round(currentY / itemHeight) * itemHeight;

            targetPath.EasingBounceEaseOut(0.5f, currentY, targetY, (f) => {
                item.anchoredPosition = new Vector2(0, f);
            });
        }

        this.Path = targetPath;
    }
}
