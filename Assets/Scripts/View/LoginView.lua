---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by DELL.
--- DateTime: 2020/12/22 12:10
---

local LoginView = {}

local login_panel = nil
local login_username = nil
local login_password = nil
local login_btn_login = nil
local login_btn_signup = nil

function LoginView.hide()
    UIManager.hidePanel('login_panel')
end

function LoginView.show(panel)
    login_panel = panel
    LoginView.init()
    login_panel:SetActive(true)
end

function LoginView.init()
    login_username = login_panel.transform:Find('input_username'):GetComponent("InputField")
    login_password = login_panel.transform:Find('input_password'):GetComponent("InputField")
    login_btn_login = login_panel.transform:Find('btn_login'):GetComponent("Button")
    login_btn_signup = login_panel.transform:Find('btn_signup'):GetComponent("Button")

    login_btn_login.onClick:AddListener(function()
        LoginController.loginClick(login_username.text, login_password.text,function()
            LoginView.hide()
            UIManager.showPanel('home_panel')
        end)
    end)

    login_btn_signup.onClick:AddListener(function()
        LoginView.hide()
        UIManager.showPanel('signup_panel')
    end)
end

return LoginView