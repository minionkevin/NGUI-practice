using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPanel : BasePanel<RegisterPanel>
{
    [SerializeField]
    private UIInput nameInput;
    [SerializeField]
    private UIInput passwordInput;
    [SerializeField]
    private UIButton cancelBtn;
    [SerializeField]
    private UIButton submitBtn;
    public override void init()
    {
        hide();
        cancelBtn.onClick.Add(new EventDelegate(() => {
            hide();
            LoginPanel.Instance.show();
        }));

        submitBtn.onClick.Add(new EventDelegate(() =>{
        //check password length
        if(passwordInput.value.Length<6)
        {
            TipPanel.Instance.show();
            TipPanel.Instance.changeInfo("Password length has to be greater than 5");
            return;
        }

        //make sure its a different username
        if(LoginMgr.Instance.isSuccess(nameInput.value,passwordInput.value))
        {
            hide();
            LoginPanel.Instance.show();
            LoginPanel.Instance.setInfo(nameInput.value, passwordInput.value);

            //reset
            LoginMgr.Instance.clearLoginData();
        }
        else
        {
            TipPanel.Instance.show();
            TipPanel.Instance.changeInfo("YOU ARE TOO LATE FOR THAT NAME");
        }
        }));

    }

    public override void show()
    {
        base.show();
        nameInput.value = "";
        passwordInput.value = "";
    }
}
