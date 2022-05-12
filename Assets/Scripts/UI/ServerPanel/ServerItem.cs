using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerItem : MonoBehaviour
{
    [SerializeField]
    private UIButton btn;
    [SerializeField]
    private UILabel infoLabel;

    private int beginIndex;
    private int endIndex;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.Add(new EventDelegate(() => {
            ServerDetecPanel.Instance.updatePanel(beginIndex, endIndex);
        }));
    }

    public void initInfo(int beginIndex,int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;

        infoLabel.text = beginIndex + " - " + endIndex;
    }
}
