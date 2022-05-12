using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{

    private static LoginMgr instance = new LoginMgr();
    public static LoginMgr Instance => instance;

    private RegisterData registerData;

    public RegisterData RefisterData => registerData;

    private ServerInfo serverInfo;
    public ServerInfo ServerInfo => serverInfo;

    private LoginMgr()
    {
        loginData = XmlDataMgr.Instance.LoadData(typeof(LoginData), "LoginData") as LoginData;
        registerData = XmlDataMgr.Instance.LoadData(typeof(RegisterData), "RegisterData") as RegisterData;

        serverInfo = XmlDataMgr.Instance.LoadData(typeof(ServerInfo), "ServerInfo") as ServerInfo;
    }

    private LoginData loginData;

    public LoginData LoginData => loginData;

    public void saveLoginData()
    {
        XmlDataMgr.Instance.SaveData(loginData, "LoginData");
    }

    public void SaveRegisterData()
    {
        XmlDataMgr.Instance.SaveData(registerData, "RegisterData");
    }

    public bool isSuccess(string userName,string password)
    {
        if (registerData.registerInfo.ContainsKey(userName)) return false;
        registerData.registerInfo.Add(userName, password);
        SaveRegisterData();
        return true;
    }

    public void clearLoginData()
    {
        loginData.LastserverID = 0;
    }
    public bool checkInfo(string userName,string password)
    {
        if(registerData.registerInfo.ContainsKey(userName))
        {
            if (registerData.registerInfo[userName] == password) return true;
        }
        return false;
    }
}
