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
        var targetPath = new CPath();
        int count = items.Length;
        float[] startY = new float[count];
        float[] targetY = new float[count];

        for (int i = 0; i < count; i++)
        {
            startY[i] = items[i].anchoredPosition.y;
            targetY[i] = Mathf.Round(startY[i] / itemHeight) * itemHeight;
        }

        targetPath.EasingBounceEaseOut(0.5f, 0f, 1f, (f) => {
            for (int i = 0; i < count; i++)
            {
                float currentPos = Mathf.Lerp(startY[i], targetY[i], f);
                items[i].anchoredPosition = new Vector2(0, currentPos);
            }
        });

        this.Path = targetPath;
    }
}
