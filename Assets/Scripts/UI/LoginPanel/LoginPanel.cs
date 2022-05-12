using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : BasePanel<LoginPanel>
{
    [SerializeField]
    private UIInput nameInput;
    [SerializeField]
    private UIInput passwordInput;
    [SerializeField]
    private UIButton submitBtn;
    [SerializeField]
    private UIButton registerBtn;
    [SerializeField]
    private UIToggle saveTog;
    [SerializeField]
    private UIToggle autoTog;

    public override void init()
    {
        registerBtn.onClick.Add(new EventDelegate(() => {
            //show register panel
            RegisterPanel.Instance.show();
            //hide self
            hide();
        }));

        submitBtn.onClick.Add(new EventDelegate(() => {
            if(LoginMgr.Instance.checkInfo(nameInput.value,passwordInput.value))
            {
                //check password/username
                LoginMgr.Instance.LoginData.userName = nameInput.value;
                LoginMgr.Instance.LoginData.passWord = passwordInput.value;
                LoginMgr.Instance.LoginData.saveTog = saveTog.value;
                LoginMgr.Instance.LoginData.autoTog = autoTog.value;
                LoginMgr.Instance.saveLoginData();

                hide();
                //show server

                //check if choose server before 
                if (LoginMgr.Instance.LoginData.LastserverID == 0) ServerDetecPanel.Instance.show();
                else ServerPanel.Instance.show();
            }
            else
            {
                TipPanel.Instance.show();
                TipPanel.Instance.changeInfo("Wrong password/username");
            }
        }));

        saveTog.onChange.Add(new EventDelegate(() => {
            //save password
            if (!saveTog.value) autoTog.value = false;
        }));

        autoTog.onChange.Add(new EventDelegate(() => {
            //save data

            //can only auto login when save password
            if (!saveTog.value) saveTog.value = true;

        }));

        //saving data
        LoginData data = LoginMgr.Instance.LoginData;
        saveTog.value = data.saveTog;
        autoTog.value = data.autoTog;
        if (data.userName != null) nameInput.value = data.userName;
        if (data.saveTog) passwordInput.value = data.passWord;
        if (data.autoTog)
        {
            if (LoginMgr.Instance.checkInfo(nameInput.value, passwordInput.value))
            {
                //check if choose server before 
                if (LoginMgr.Instance.LoginData.LastserverID == 0) ServerDetecPanel.Instance.show();
                else ServerPanel.Instance.show();
                hide();
            }
            else
            {
                TipPanel.Instance.show();
                TipPanel.Instance.changeInfo("Wrong password/username");
            }
        }
    }

    public void setInfo(string username,string password)
    {
        nameInput.value = username;
        passwordInput.value = password;
    }
}
