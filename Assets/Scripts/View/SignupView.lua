---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by DELL.
--- DateTime: 2020/12/22 12:11
---

local SignupView = {}

local signup_panel = nil
local signup_username = nil
local signup_password01 = nil
local signup_password02 = nil
local signup_btn_signup = nil
local signup_btn_back = nil

function SignupView.hide()
    UIManager.hidePanel('signup_panel')
end 

function SignupView.show(panel)
    signup_panel = panel
    SignupView.init()
    signup_panel:SetActive(true)
end

function SignupView.init()
    signup_username = signup_panel.transform:Find('input_username'):GetComponent("InputField")
    signup_password01 = signup_panel.transform:Find('input_password01'):GetComponent("InputField")
    signup_password02 = signup_panel.transform:Find('input_password02'):GetComponent("InputField")
    signup_btn_signup = signup_panel.transform:Find('btn_signup'):GetComponent("Button")
    signup_btn_back = signup_panel.transform:Find('btn_back'):GetComponent("Button")

    signup_btn_signup.onClick:AddListener(function()
        SignupController.signupClick(signup_username.text,signup_password01.text,signup_password02.text,function()
            SignupView.hide()
            UIManager.showPanel('login_panel')
        end)
    end)

    signup_btn_back.onClick:AddListener(function()
        SignupView.hide()
        UIManager.showPanel('login_panel')
    end)
end

return SignupView