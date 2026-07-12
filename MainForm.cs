using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteamEyaWinUI.Models;
using SteamEyaWinUI.Services;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;

namespace SteamAnalysisAvalonia
{
    public partial class MainForm : Form
    {
        private SteamAccountData? _currentAccount;
        private readonly HttpClient _httpClient;

        public MainForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            
            try 
            {
                using var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SteamAnalysisAvalonia.Assets.icon.ico");
                if (stream != null)
                {
                    this.Icon = new System.Drawing.Icon(stream);
                }
            } 
            catch { }
            
            // setup AppState StatusReporter
            AppState.StatusReporter = (msg, severity) =>
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => UpdateStatus(msg)));
                }
                else
                {
                    UpdateStatus(msg);
                }
            };
        }
        
        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }



        private void btnRepo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/XingDiao1337/SteamAnalysis",
                    UseShellExecute = true
                });
            }
            catch { }
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://xn--rssy31a.top/",
                    UseShellExecute = true
                });
            }
            catch { }
        }

        private async void btnParseKey_Click(object sender, EventArgs e)
        {
            try
            {
                var server = SteamLicenseClient.Servers.FirstOrDefault(s => s.Name == "路飞") ?? SteamLicenseClient.Servers[0];
                var key = txtKey.Text?.Trim() ?? "";

                if (string.IsNullOrEmpty(key) || server == null)
                {
                    MessageBox.Show("卡密或服务器不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnParseKey.Enabled = false;
                UpdateStatus("正在解析卡密...");

                _currentAccount = await AppState.LicenseClient.GetAccountDataAsync(key, server);

                lblUserName.Text = _currentAccount.User;
                lblSteamId.Text = _currentAccount.SteamId;

                picAvatar.Image = null;

                lblStatus.Text = "查询中...";
                lblVac.Text = "查询中...";
                lblTrade.Text = "查询中...";
                lblLimit.Text = "查询中...";
                lblCooldown.Text = "查询中...";
                lblScore.Text = "查询中...";
                lblMemberSince.Text = "查询中...";
                lblPrivacy.Text = "查询中...";
                lblPlaytime.Text = "查询中...";
                lblWins.Text = "查询中...";
                lblLevel.Text = "查询中...";
                
                ResetColors();

                _ = Task.Run(() => FetchAdditionalInfoAsync(_currentAccount.SteamId, _currentAccount.Token));

                UpdateStatus("卡密解析成功");
            }
            catch (Exception ex)
            {
                UpdateStatus($"解析失败: {ex.Message}");
                MessageBox.Show(ex.Message, "解析失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnParseKey.Enabled = true;
            }
        }
        
        private void ResetColors()
        {
            lblStatus.ForeColor = Color.Black;
            lblVac.ForeColor = Color.Black;
            lblTrade.ForeColor = Color.Black;
            lblLimit.ForeColor = Color.Black;
            lblCooldown.ForeColor = Color.Black;
            lblScore.ForeColor = Color.Black;
            lblMemberSince.ForeColor = Color.Black;
            lblPrivacy.ForeColor = Color.Black;
            lblPlaytime.ForeColor = Color.Black;
            lblWins.ForeColor = Color.Black;
            lblLevel.ForeColor = Color.Black;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (_currentAccount == null)
            {
                MessageBox.Show("请先解析卡密", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("正在自动登录...");
                btnLogin.Enabled = false;

                await SteamPathCoordinator.EnsureResolvedAsync();

                var jwt = _currentAccount.Token;
                var validationResult = AppState.JwtTokenService.Validate(jwt);
                string steamId = validationResult.SteamId;

                var result = await Task.Run(() => AppState.LoginService.Login(_currentAccount.User, jwt));

                UpdateStatus($"登录成功，凭证过期时间: {result.ExpiresAt:yyyy-MM-dd HH:mm}");
                MessageBox.Show($"登录成功！\n凭证过期时间: {result.ExpiresAt}", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus($"登录失败: {ex.Message}");
                MessageBox.Show(ex.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private async void btnClearWorkshop_Click(object sender, EventArgs e)
        {
            if (_currentAccount == null)
            {
                MessageBox.Show("请先解析卡密", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("正在清除创意工坊订阅...");
                btnClearWorkshop.Enabled = false;
                await AppState.WorkshopService.ClearSubscriptionsAsync(_currentAccount.Token);
                UpdateStatus("已全部取消订阅并清除本地文件");
                MessageBox.Show("已全部取消订阅并清除本地文件", "清除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus($"清除失败: {ex.Message}");
                MessageBox.Show(ex.Message, "清除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnClearWorkshop.Enabled = true;
            }
        }

        private async Task FetchAdditionalInfoAsync(string steamId, string token)
        {
            // 优化 XML 查询机制，加入重试和超时
            try
            {
                this.Invoke(new Action(() => UpdateStatus("正在获取 Steam 社区资料...")));
                using var handler = new System.Net.Http.HttpClientHandler { Proxy = System.Net.WebRequest.GetSystemWebProxy() };
                using var client = new System.Net.Http.HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(15);
                
                string? xmlStr = null;
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        xmlStr = await client.GetStringAsync($"https://steamcommunity.com/profiles/{steamId}?xml=1");
                        if (xmlStr != null && xmlStr.Contains("<?xml")) break;
                    }
                    catch
                    {
                        if (i == 2) throw;
                        await Task.Delay(1500);
                    }
                }

                if (string.IsNullOrEmpty(xmlStr))
                {
                    throw new Exception("XML content is empty.");
                }

                var xml = XDocument.Parse(xmlStr);
                var profile = xml.Root;
                if (profile != null)
                {
                    var stateMessage = profile.Element("stateMessage")?.Value ?? "未知";
                    var vacBanned = profile.Element("vacBanned")?.Value == "1" ? "有封禁" : "无封禁";
                    var tradeBanState = profile.Element("tradeBanState")?.Value ?? "None";
                    var isLimitedAccount = profile.Element("isLimitedAccount")?.Value == "1" ? "受限 (无5刀)" : "正常 (已充5刀)";
                    
                    var memberSince = profile.Element("memberSince")?.Value ?? "未知";
                    var privacyStateStr = profile.Element("privacyState")?.Value;
                    var privacyState = privacyStateStr == "public" ? "公开" : (privacyStateStr == "friendsonly" ? "仅好友" : "私密");

                    string cs2Hours = "未公开或未玩过";
                    var games = profile.Element("mostPlayedGames")?.Elements("mostPlayedGame");
                    if (games != null)
                    {
                        foreach (var game in games)
                        {
                            if (game.Element("gameName")?.Value == "Counter-Strike 2")
                            {
                                cs2Hours = game.Element("hoursOnRecord")?.Value ?? "未知";
                                cs2Hours += " 小时";
                                break;
                            }
                        }
                    }

                    this.Invoke(new Action(() =>
                    {
                        lblStatus.Text = stateMessage;
                        lblStatus.ForeColor = stateMessage.Contains("Offline") ? Color.Gray : Color.Green;

                        lblVac.Text = vacBanned;
                        lblVac.ForeColor = vacBanned == "有封禁" ? Color.Red : Color.Green;

                        lblTrade.Text = tradeBanState == "None" ? "正常" : tradeBanState;
                        lblTrade.ForeColor = tradeBanState != "None" ? Color.Red : Color.Green;

                        lblLimit.Text = isLimitedAccount;
                        lblLimit.ForeColor = isLimitedAccount.Contains("受限") ? Color.Red : Color.Green;

                        lblMemberSince.Text = memberSince;
                        lblPrivacy.Text = privacyState;
                        lblPrivacy.ForeColor = privacyState == "公开" ? Color.Green : Color.Gray;

                        lblPlaytime.Text = cs2Hours;
                    }));

                    var avatarUrl = profile.Element("avatarFull")?.Value;
                    if (!string.IsNullOrEmpty(avatarUrl))
                    {
                        try 
                        {
                            var imgBytes = await client.GetByteArrayAsync(avatarUrl);
                            using var ms = new MemoryStream(imgBytes);
                            var img = Image.FromStream(ms);
                            this.Invoke(new Action(() => picAvatar.Image = img));
                        } 
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = "获取失败";
                    lblVac.Text = "获取失败";
                    lblTrade.Text = "获取失败";
                    lblLimit.Text = "获取失败";
                    UpdateStatus("获取资料失败: 网络超时或受限");
                }));
            }

            try
            {
                this.Invoke(new Action(() => UpdateStatus("正在查询 CS2 游戏协调器...")));
                
                var progress = new Progress<string>(msg => 
                {
                    this.Invoke(new Action(() => UpdateStatus(msg)));
                });
                
                var result = await AppState.PremierScoreService.QueryAsync(token, steamId, progress);
                var cooldownText = FormatHelper.FormatCooldownText(result.PenaltySeconds, result.PenaltyReason, "未知");
                
                this.Invoke(new Action(() =>
                {
                    lblCooldown.Text = cooldownText;
                    lblCooldown.ForeColor = result.HasCooldown ? Color.Red : Color.Green;
                    
                    if (result.IsGcVacBanned)
                    {
                        lblVac.Text = "有封禁 (GC)";
                        lblVac.ForeColor = Color.Red;
                    }
                    
                    if (result.PremierRanking != null)
                    {
                        lblScore.Text = result.PremierRanking.RankId.ToString();
                        lblScore.ForeColor = Color.Green;
                        lblWins.Text = result.PremierRanking.Wins.ToString();
                        lblWins.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblScore.Text = "无优先分/未出分";
                        lblScore.ForeColor = Color.Gray;
                        lblWins.Text = "未知";
                    }

                    if (result.PlayerLevel != null)
                    {
                        lblLevel.Text = result.PlayerLevel.ToString();
                    }
                    else
                    {
                        lblLevel.Text = "未知";
                    }
                    
                    UpdateStatus("所有信息查询完成");
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() => 
                {
                    lblCooldown.Text = "查询超时";
                    lblScore.Text = "查询超时";
                    UpdateStatus($"游戏服务器连接失败: {ex.Message}");
                }));
            }
        }
    }
}
