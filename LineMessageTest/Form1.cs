using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LineMessageTest
{
    public partial class Form1 : Form
    {
        // 請替換成你的 Channel Access Token
        private const string ChannelAccessToken = "LINE_CHANNEL_ACCESS_TOKEN";
        // 請替換成你的目標群組 ID
        private const string GroupId = "LINE_GROUP_ID";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {

                await SendLineMessage(textBox1.Text);
                MessageBox.Show("訊息發送成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發送訊息失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task SendLineMessage(string message)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ChannelAccessToken}");

                    var payload = new
                    {
                        to = GroupId,
                        messages = new[]
                        {
                            new { type = "text", text = message }
                        }
                    };

                    var jsonContent = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("https://api.line.me/v2/bot/message/push", content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"API 呼叫失敗 (狀態碼: {response.StatusCode})\n" +
                            $"回應內容: {responseContent}\n" +
                            $"發送的內容: {jsonContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"網路請求錯誤: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"發送訊息時發生錯誤: {ex.Message}", ex);
                }
            }
        }
    }
}
