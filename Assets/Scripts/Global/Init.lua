---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by DELL.
--- DateTime: 2020/12/22 16:18
---

-- Global
EventCenter = require('Scripts.Global.EventCenter')
Tips = require('Scripts.Global.Tips')
Users = { { username = 'admin', password = 'admin' }, { username = '1', password = '1' } }
UIDefine = require('Scripts.Global.UIDefine')
Resource = require('Scripts.Global.Resource')
UIManager = require('Scripts.Global.UIManager')

-- Controllers
require('Scripts.Controller.init')

-- Models
require('Scripts.Model.init')

-- Views
--require('Scripts.View.init')

Resource.load('MainUI')
UIManager.showPanel('login_panel')

print('init finish')