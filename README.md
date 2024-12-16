## Telegram API介紹<br />

因應LINE宣布將於2025年3月31日結束LINE Notify服務，故因此需改用收費的Line Message API(但有免費方案供測試)，其實這個功能就是Line Bot。<br />

## Telegram API建置工具<br />
* https://webhook.site/ 可以暫時免費取得webhook網址，可以用來取得UserID或GroupID<br />
* https://account.line.biz/login Line開發管理後台(可以創建Line Bot和取得Token)<br />
* visual studio 2022<br />
* 安裝 NuGet套件<br />
>1. Line.Messaging(1.4.5)<br />
>2. LineBotSDK(2.13.39)<br />
>3. Newtonsoft.Json(13.0.3)<br />
>4. System.Net.Http(4.3.4)<br />
>5. System.Text.Encodeings.Web(9.0.0)<br />
>6. System.Text.RegularExpressions(4.3.1)<br />

## Telegram API步驟<br />
1. 創建一個New Channel(選擇Messaging API)<br />
2. 創建內容根據需求填寫(如只是測試可亂填)<br />
3. 進入創建完成的Channel後 可以去 Messaging API settings頁籤<br />
4. 往下找到Channel access token後按下按鈕後，即可獲得access token<br />
5. 接著進到webhook.site 取得Your unique URL<br />
6. 將URL貼上至Webhook settings並按下Verify並開啟下方Use webhook即可<br />
7. 接著把機器人拉進群組，隨便打字or任何動作都會觸發webhook，在到webhook.site(右上方可以選擇show intro)就可以看到請求內容如下(其中groupId和userId是重點需要打在範例程式中)<br />
