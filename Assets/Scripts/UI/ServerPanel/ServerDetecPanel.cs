using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerDetecPanel : BasePanel<ServerDetecPanel>
{
    [SerializeField]
    private Transform leftSv;
    [SerializeField]
    private Transform rightSv;
    [SerializeField]
    private UILabel nameLabel;
    [SerializeField]
    private UISprite stateSpr;
    [SerializeField]
    private UILabel currServerLab;

    private List<GameObject> itemList = new List<GameObject>();
    public override void init()
    {
        hide();
        ServerInfo info = LoginMgr.Instance.ServerInfo;
        int num = info.serverDic.Count / 5 + 1;
        for(int i = 0; i < num;i++)
        {
            int beginIndex = 5 * i + 1;
            int endIndex = 5 * (i + 1);
            if (beginIndex > info.serverDic.Count) break;
            if (endIndex > info.serverDic.Count) endIndex = info.serverDic.Count;

            GameObject item = Instantiate(Resources.Load<GameObject>("UI/serverBtn"));
            item.transform.SetParent(leftSv, false);
            item.transform.localPosition = new Vector3(-320, 88, 0) + new Vector3(0, i * (-72),0);

            ServerItem serverItem = item.GetComponent<ServerItem>();
            serverItem.initInfo(beginIndex, endIndex);
        }
    }

    public void updatePanel(int beginIndex, int endIndex)
    {
        currServerLab.text = "Server "+ beginIndex + " - " + endIndex;

        for(int i = 0; i < itemList.Count;i++)
        {
            Destroy(itemList[i]);
        }
        itemList.Clear();

        Server currInfo;
        for(int i = beginIndex;i<=endIndex;i++)
        {
            currInfo = LoginMgr.Instance.ServerInfo.serverDic[i];

            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/serverCBtn"));
            serverItem.transform.SetParent(rightSv, false);
            serverItem.transform.localPosition = new Vector3(-86, 44, 0) + new Vector3((i-1)%5%2*309, (i - 1) % 5 / 2*-81,0);
            ServerChoose chooseItem = serverItem.GetComponent<ServerChoose>();
            chooseItem.initInfo(currInfo);
            itemList.Add(serverItem);
        }
    }


    public override void show()
    {
        base.show();
        if(LoginMgr.Instance.LoginData.LastserverID == 0)
        {
            nameLabel.text = "none";
            stateSpr.gameObject.SetActive(false);
        }
        else
        {
            Server info = LoginMgr.Instance.ServerInfo.serverDic[LoginMgr.Instance.LoginData.LastserverID];
            nameLabel.text = info.id + " " + info.name;
            stateSpr.gameObject.SetActive(true);
            switch (info.state)
            {
                case 0:
                    stateSpr.gameObject.SetActive(false);
                    break;
                case 1:
                    stateSpr.spriteName = "ui_DL_weihu_01";
                    break;
                case 2:
                    stateSpr.spriteName = "ui_DL_liuchang_01";
                    break;
                case 3:
                    stateSpr.spriteName = "ui_DL_fanhua_01";
                    break;
                case 4:
                    stateSpr.spriteName = "ui_DL_huobao_01";
                    break;
            }
        }

        //right sv btns
        //check max index
        updatePanel(1, 5 > LoginMgr.Instance.ServerInfo.serverDic.Count ? LoginMgr.Instance.ServerInfo.serverDic.Count : 5);
    }
}
