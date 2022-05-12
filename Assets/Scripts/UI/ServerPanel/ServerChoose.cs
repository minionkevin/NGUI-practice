using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerChoose : MonoBehaviour
{
    [SerializeField]
    private UIButton btn;
    [SerializeField]
    private UILabel nameLabel;
    [SerializeField]
    private UISprite isNewSprite;
    [SerializeField]
    private UISprite stateSprite;

    private Server nowInfo;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.Add(new EventDelegate(() => {
            LoginMgr.Instance.LoginData.LastserverID = nowInfo.id;

            ServerDetecPanel.Instance.hide();
            ServerPanel.Instance.show();
        }));
    }

    public void initInfo(Server info)
    {
        nowInfo = info;

        nameLabel.text = info.id + " " + info.name;
        isNewSprite.gameObject.SetActive(info.isNew);
        stateSprite.gameObject.SetActive(true);
        switch (info.state)
        {
            case 0:
                stateSprite.gameObject.SetActive(false);
                break;
            case 1:
                stateSprite.spriteName = "ui_DL_weihu_01";
                break;
            case 2:
                stateSprite.spriteName = "ui_DL_liuchang_01";
                break;
            case 3:
                stateSprite.spriteName = "ui_DL_fanhua_01";
                break;
            case 4:
                stateSprite.spriteName = "ui_DL_huobao_01";
                break;
        }
    }
}
