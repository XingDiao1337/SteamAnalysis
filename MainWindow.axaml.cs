using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using SteamEyaWinUI.Services;
using SteamEyaWinUI.Models;

using System.Linq;
using System.Xml.Linq;
namespace SteamAnalysisAvalonia
{
    public partial class MainWindow : Window
    {
        private SteamAccountData? _currentAccount;

        public MainWindow()
        {
            InitializeComponent();

            AppState.StatusReporter = (msg, severity) =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    InfoMessageText.Text = msg;
                    InfoNotification.IsVisible = true;
                    
                    // Simple hide logic
                    Task.Delay(3000).ContinueWith(_ =>
                    {
                        Dispatcher.UIThread.InvokeAsync(() => InfoNotification.IsVisible = false);
                    });
                });
            };

        }

        private async void ParseKey_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                var server = SteamLicenseClient.Servers.FirstOrDefault(s => s.Name == "路飞") ?? SteamLicenseClient.Servers[0];
                var key = KeyTextBox.Text?.Trim() ?? "";
                
                if (string.IsNullOrEmpty(key) || server == null)
                {
                    AppState.ShowStatus("卡密或服务器不能为空", InfoBarSeverity.Warning);
                    return;
                }

                AppState.ShowStatus("正在解析卡密...", InfoBarSeverity.Informational);
                
                _currentAccount = await AppState.LicenseClient.GetAccountDataAsync(key, server);
                
                UserNameTextBlock.Text = _currentAccount.User;
                SteamIdTextBlock.Text = _currentAccount.SteamId;

                AvatarImage.Source = null;

                // 清空旧数据
                CurrentStateTextBlock.Text = "查询中...";
                CurrentStateTextBlock.Foreground = Avalonia.Media.Brushes.White;
                VacBannedTextBlock.Text = "查询中...";
                VacBannedTextBlock.Foreground = Avalonia.Media.Brushes.White;
                TradeBanTextBlock.Text = "查询中...";
                TradeBanTextBlock.Foreground = Avalonia.Media.Brushes.White;
                LimitedAccountTextBlock.Text = "查询中...";
                LimitedAccountTextBlock.Foreground = Avalonia.Media.Brushes.White;
                CooldownTextBlock.Text = "查询中...";
                CooldownTextBlock.Foreground = Avalonia.Media.Brushes.White;
                CsScoreTextBlock.Text = "查询中...";
                CsScoreTextBlock.Foreground = Avalonia.Media.Brushes.White;

                // 异步获取详细状态
                _ = Task.Run(() => FetchAdditionalInfoAsync(_currentAccount.SteamId, _currentAccount.Token));

                AppState.ShowStatus("卡密解析成功", InfoBarSeverity.Success);
            }
            catch (Exception ex)
            {
                AppState.ShowStatus($"解析失败: {ex.Message}", InfoBarSeverity.Error);
            }
        }

        private async void ClearWorkshop_Click(object? sender, RoutedEventArgs e)
        {
            if (_currentAccount == null)
            {
                AppState.ShowStatus("请先解析卡密", InfoBarSeverity.Warning);
                return;
            }

            try
            {
                AppState.ShowStatus("正在清除创意工坊订阅...", InfoBarSeverity.Informational);
                await AppState.WorkshopService.ClearSubscriptionsAsync(_currentAccount.Token);
                AppState.ShowStatus("已全部取消订阅并清除本地文件", InfoBarSeverity.Success);
            }
            catch (Exception ex)
            {
                AppState.ShowStatus($"清除失败: {ex.Message}", InfoBarSeverity.Error);
            }
        }

        private async void LoginSteam_Click(object? sender, RoutedEventArgs e)
        {
            if (_currentAccount == null)
            {
                AppState.ShowStatus("请先解析卡密", InfoBarSeverity.Warning);
                return;
            }

            try
            {
                AppState.ShowStatus("正在自动登录...", InfoBarSeverity.Informational);
                
                await SteamPathCoordinator.EnsureResolvedAsync();
                
                var jwt = _currentAccount.Token;
                var validationResult = AppState.JwtTokenService.Validate(jwt);
                string steamId = validationResult.SteamId;

                var result = await Task.Run(() => AppState.LoginService.Login(_currentAccount.User, jwt));
                
                AppState.ShowStatus($"登录成功，凭证过期时间: {result.ExpiresAt:yyyy-MM-dd HH:mm}", InfoBarSeverity.Success);
            }
            catch (Exception ex)
            {
                AppState.ShowStatus($"登录失败: {ex.Message}", InfoBarSeverity.Error);
            }
        }

        private async Task FetchAdditionalInfoAsync(string steamId, string token)
        {
            try
            {
                using var client = new System.Net.Http.HttpClient();
                var xmlStr = await client.GetStringAsync($"https://steamcommunity.com/profiles/{steamId}?xml=1");
                var xml = XDocument.Parse(xmlStr);
                var profile = xml.Root;
                if (profile != null)
                {
                    var stateMessage = profile.Element("stateMessage")?.Value ?? "未知";
                    var vacBanned = profile.Element("vacBanned")?.Value == "1" ? "有封禁" : "无封禁";
                    var tradeBanState = profile.Element("tradeBanState")?.Value ?? "None";
                    var isLimitedAccount = profile.Element("isLimitedAccount")?.Value == "1" ? "受限 (无5刀)" : "正常 (已充5刀)";

                    Dispatcher.UIThread.Post(() =>
                    {
                        CurrentStateTextBlock.Text = stateMessage;
                        CurrentStateTextBlock.Foreground = stateMessage.Contains("Offline") ? Avalonia.Media.Brushes.Gray : Avalonia.Media.Brushes.LightGreen;

                        VacBannedTextBlock.Text = vacBanned;
                        VacBannedTextBlock.Foreground = vacBanned == "有封禁" ? Avalonia.Media.Brushes.Red : Avalonia.Media.Brushes.LightGreen;

                        TradeBanTextBlock.Text = tradeBanState == "None" ? "正常" : tradeBanState;
                        TradeBanTextBlock.Foreground = tradeBanState != "None" ? Avalonia.Media.Brushes.Red : Avalonia.Media.Brushes.LightGreen;

                        LimitedAccountTextBlock.Text = isLimitedAccount;
                        LimitedAccountTextBlock.Foreground = isLimitedAccount.Contains("受限") ? Avalonia.Media.Brushes.Red : Avalonia.Media.Brushes.LightGreen;
                    });

                    // 获取并设置头像
                    var avatarUrl = profile.Element("avatarFull")?.Value;
                    if (!string.IsNullOrEmpty(avatarUrl))
                    {
                        try 
                        {
                            var imgBytes = await client.GetByteArrayAsync(avatarUrl);
                            using var ms = new System.IO.MemoryStream(imgBytes);
                            var bitmap = new Avalonia.Media.Imaging.Bitmap(ms);
                            Dispatcher.UIThread.Post(() => AvatarImage.Source = bitmap);
                        } 
                        catch { }
                    }
                }
            }
            catch
            {
                Dispatcher.UIThread.Post(() =>
                {
                    CurrentStateTextBlock.Text = "获取失败";
                    VacBannedTextBlock.Text = "获取失败";
                    TradeBanTextBlock.Text = "获取失败";
                    LimitedAccountTextBlock.Text = "获取失败";
                });
            }

            try
            {
                var result = await AppState.PremierScoreService.QueryAsync(token, steamId);
                var cooldownText = FormatHelper.FormatCooldownText(result.PenaltySeconds, result.PenaltyReason, "未知");
                
                Dispatcher.UIThread.Post(() =>
                {
                    CooldownTextBlock.Text = cooldownText;
                    CooldownTextBlock.Foreground = result.HasCooldown ? Avalonia.Media.Brushes.Red : Avalonia.Media.Brushes.LightGreen;
                    
                    // 如果 GC 报告了 VAC 且之前查出来的没发现，则补充 (有时候游戏内部特有 VAC)
                    if (result.IsGcVacBanned)
                    {
                        VacBannedTextBlock.Text = "有封禁 (GC)";
                        VacBannedTextBlock.Foreground = Avalonia.Media.Brushes.Red;
                    }
                    
                    if (result.PremierRanking != null)
                    {
                        CsScoreTextBlock.Text = result.PremierRanking.RankId.ToString();
                        CsScoreTextBlock.Foreground = Avalonia.Media.Brushes.LightGreen;
                    }
                    else
                    {
                        CsScoreTextBlock.Text = "无优先分/未出分";
                        CsScoreTextBlock.Foreground = Avalonia.Media.Brushes.Gray;
                    }
                });
            }
            catch
            {
                Dispatcher.UIThread.Post(() => 
                {
                    CooldownTextBlock.Text = "获取失败";
                    CsScoreTextBlock.Text = "获取失败";
                });
            }
        }
    }
}
