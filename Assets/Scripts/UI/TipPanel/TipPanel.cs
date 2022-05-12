using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPanel : BasePanel<TipPanel>
{
    [SerializeField]
    private UIButton submitBtn;
    [SerializeField]
    private UILabel labInfo;

    public override void init()
    {
        hide();
        submitBtn.onClick.Add(new EventDelegate(() =>{
            hide();
        }));
    }

    public void changeInfo(string info)
    {
        labInfo.text = info;
    }
}
