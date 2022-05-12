using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerPanel : BasePanel<ServerPanel>
{
    [SerializeField]
    private UILabel infoLabel;
    [SerializeField]
    private UIButton changeBtn;
    [SerializeField]
    private UIButton submitBtn;
    [SerializeField]
    private UIButton backBtn;
    public override void init()
    {
        hide();
        changeBtn.onClick.Add(new EventDelegate(() => {
            ServerDetecPanel.Instance.show();
            hide();
        }));

        submitBtn.onClick.Add(new EventDelegate(() => {
            SceneManager.LoadScene("Game");

            LoginMgr.Instance.saveLoginData();
        }));
        backBtn.onClick.Add(new EventDelegate(() => {
            LoginPanel.Instance.show();
            hide();
        }));
    }

    public override void show()
    {
        base.show();
        int id = LoginMgr.Instance.LoginData.LastserverID;
        Server info = LoginMgr.Instance.ServerInfo.serverDic[id];
        infoLabel.text = info.name;
    }
}
