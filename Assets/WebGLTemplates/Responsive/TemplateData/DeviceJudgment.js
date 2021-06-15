'use strict';
const getDeviceJudgment = () => {
    var WhatSystem = navigator.userAgent
    var DeviceType = ['Android', 'iPhone', 'iPad', 'Windows', 'Macintosh']
    var MobileType = null
    DeviceType.find(item => {
        if (WhatSystem.indexOf(item) != -1){
            switch (item){
                case 'Android':
                    MobileType = 'Mobile'
                    break
                case 'iPhone':
                    MobileType = 'Mobile'
                    break
                case 'iPad':
                    MobileType = 'Mobile'
                    break
                case 'Windows':
                    MobileType = 'Desktop'
                    break
                case 'Macintosh':
                    MobileType = 'Desktop'
                    break
                default:
                    MobileType = 'UnKnows'
            }
        }
    })
    gameInstance.SendMessage("Root", "FromHtml_str", `"${MobileType}"`)
}