**Line Message 發送訊息範例**<br />

1. 創建一個New Channel(選擇Messaging API)<br />
2. 創建內容根據需求填寫(如只是測試可亂填)<br />
3. 進入創建完成的Channel後 可以去 Messaging API settings頁籤<br />
4. 往下找到Channel access token後按下按鈕後，即可獲得access token<br />
5. 接著進到webhook.site 取得Your unique URL<br />
6. 將URL貼上至Webhook settings並按下Verify並開啟下方Use webhook即可<br />
7. 接著把機器人拉進群組，隨便打字or任何動作都會觸發webhook，在到webhook.site(右上方可以選擇show intro)就可以看到請求內容如下(其中==groupId和userId== 是重點需要打在下面範例程式中)<br />
