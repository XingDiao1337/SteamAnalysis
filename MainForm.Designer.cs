namespace SteamAnalysisAvalonia
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParseKey = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearWorkshop = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkKeepAccounts = new System.Windows.Forms.CheckBox();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.grpCs2 = new System.Windows.Forms.GroupBox();
            this.lblMemberSince = new System.Windows.Forms.Label();
            this.labelMemberSince = new System.Windows.Forms.Label();
            this.lblPrivacy = new System.Windows.Forms.Label();
            this.labelPrivacy = new System.Windows.Forms.Label();
            this.lblPlaytime = new System.Windows.Forms.Label();
            this.labelPlaytime = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.labelWins = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCooldown = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTrade = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVac = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSteamId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnRepo = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.lblWatermark = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBasic.SuspendLayout();
            this.grpCs2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParseKey);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "账号解析";
            // 
            // btnParseKey
            // 
            this.btnParseKey.Location = new System.Drawing.Point(6, 60);
            this.btnParseKey.Name = "btnParseKey";
            this.btnParseKey.Size = new System.Drawing.Size(248, 38);
            this.btnParseKey.TabIndex = 1;
            this.btnParseKey.Text = "一键解析卡密";
            this.btnParseKey.UseVisualStyleBackColor = true;
            this.btnParseKey.Click += new System.EventHandler(this.btnParseKey_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(6, 31);
            this.txtKey.Name = "txtKey";
            this.txtKey.PlaceholderText = "请输入卡密...";
            this.txtKey.Size = new System.Drawing.Size(248, 23);
            this.txtKey.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkKeepAccounts);
            this.groupBox2.Controls.Add(this.btnClearWorkshop);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "快捷操作";
            // 
            // btnClearWorkshop
            // 
            this.btnClearWorkshop.Location = new System.Drawing.Point(6, 85);
            this.btnClearWorkshop.Name = "btnClearWorkshop";
            this.btnClearWorkshop.Size = new System.Drawing.Size(248, 38);
            this.btnClearWorkshop.TabIndex = 3;
            this.btnClearWorkshop.Text = "清除创意工坊订阅";
            this.btnClearWorkshop.UseVisualStyleBackColor = true;
            this.btnClearWorkshop.Click += new System.EventHandler(this.btnClearWorkshop_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(6, 30);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(248, 38);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "一键登录到 Steam";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkKeepAccounts
            // 
            this.chkKeepAccounts.AutoSize = true;
            this.chkKeepAccounts.Location = new System.Drawing.Point(10, 135);
            this.chkKeepAccounts.Name = "chkKeepAccounts";
            this.chkKeepAccounts.Size = new System.Drawing.Size(240, 21);
            this.chkKeepAccounts.TabIndex = 4;
            this.chkKeepAccounts.Text = "保留其他账号数据免密 (需写注册表)";
            this.chkKeepAccounts.UseVisualStyleBackColor = true;
            this.chkKeepAccounts.Checked = true;
            // 
            // grpBasic
            this.grpBasic.Controls.Add(this.lblVac);
            this.grpBasic.Controls.Add(this.label4);
            this.grpBasic.Controls.Add(this.lblTrade);
            this.grpBasic.Controls.Add(this.label5);
            this.grpBasic.Controls.Add(this.lblLimit);
            this.grpBasic.Controls.Add(this.label7);
            this.grpBasic.Controls.Add(this.lblPrivacy);
            this.grpBasic.Controls.Add(this.labelPrivacy);
            this.grpBasic.Controls.Add(this.lblMemberSince);
            this.grpBasic.Controls.Add(this.labelMemberSince);
            this.grpBasic.Controls.Add(this.lblSteamId);
            this.grpBasic.Controls.Add(this.label2);
            this.grpBasic.Controls.Add(this.lblUserName);
            this.grpBasic.Controls.Add(this.label1);
            this.grpBasic.Controls.Add(this.picAvatar);
            this.grpBasic.Location = new System.Drawing.Point(287, 12);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(395, 235);
            this.grpBasic.TabIndex = 2;
            this.grpBasic.TabStop = false;
            this.grpBasic.Text = "Steam 基础档案";

            // grpCs2
            this.grpCs2.Controls.Add(this.lblCooldown);
            this.grpCs2.Controls.Add(this.label8);
            this.grpCs2.Controls.Add(this.lblWins);
            this.grpCs2.Controls.Add(this.labelWins);
            this.grpCs2.Controls.Add(this.lblScore);
            this.grpCs2.Controls.Add(this.label10);
            this.grpCs2.Controls.Add(this.lblLevel);
            this.grpCs2.Controls.Add(this.labelLevel);
            this.grpCs2.Controls.Add(this.lblPlaytime);
            this.grpCs2.Controls.Add(this.labelPlaytime);
            this.grpCs2.Controls.Add(this.lblStatus);
            this.grpCs2.Controls.Add(this.label3);
            this.grpCs2.Location = new System.Drawing.Point(287, 255);
            this.grpCs2.Name = "grpCs2";
            this.grpCs2.Size = new System.Drawing.Size(395, 200);
            this.grpCs2.TabIndex = 3;
            this.grpCs2.TabStop = false;
            this.grpCs2.Text = "CS2 游戏数据";

            // Basic Group Labels
            this.label1.Location = new System.Drawing.Point(145, 31);
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.Text = "用户名：";
            this.lblUserName.Location = new System.Drawing.Point(230, 31);
            this.lblUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Text = "--";
            this.lblUserName.AutoSize = true;

            this.label2.Location = new System.Drawing.Point(145, 59);
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.Text = "SteamID：";
            this.lblSteamId.Location = new System.Drawing.Point(230, 59);
            this.lblSteamId.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSteamId.Text = "--";
            this.lblSteamId.AutoSize = true;

            this.labelMemberSince.Location = new System.Drawing.Point(145, 87);
            this.labelMemberSince.Size = new System.Drawing.Size(68, 17);
            this.labelMemberSince.Text = "注册时间：";
            this.lblMemberSince.Location = new System.Drawing.Point(230, 87);
            this.lblMemberSince.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemberSince.Text = "--";
            this.lblMemberSince.AutoSize = true;

            this.labelPrivacy.Location = new System.Drawing.Point(145, 115);
            this.labelPrivacy.Size = new System.Drawing.Size(68, 17);
            this.labelPrivacy.Text = "隐私状态：";
            this.lblPrivacy.Location = new System.Drawing.Point(230, 115);
            this.lblPrivacy.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrivacy.Text = "--";
            this.lblPrivacy.AutoSize = true;

            this.label7.Location = new System.Drawing.Point(145, 143);
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.Text = "社区限制：";
            this.lblLimit.Location = new System.Drawing.Point(230, 143);
            this.lblLimit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLimit.Text = "--";
            this.lblLimit.AutoSize = true;

            this.label5.Location = new System.Drawing.Point(145, 171);
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.Text = "交易封禁：";
            this.lblTrade.Location = new System.Drawing.Point(230, 171);
            this.lblTrade.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrade.Text = "--";
            this.lblTrade.AutoSize = true;

            this.label4.Location = new System.Drawing.Point(145, 199);
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.Text = "VAC封禁：";
            this.lblVac.Location = new System.Drawing.Point(230, 199);
            this.lblVac.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVac.Text = "--";
            this.lblVac.AutoSize = true;

            this.picAvatar.Location = new System.Drawing.Point(23, 31);
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // CS2 Group Labels
            this.label3.Location = new System.Drawing.Point(23, 31);
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.Text = "当前状态：";
            this.lblStatus.Location = new System.Drawing.Point(110, 31);
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Text = "--";
            this.lblStatus.AutoSize = true;

            this.labelPlaytime.Location = new System.Drawing.Point(23, 59);
            this.labelPlaytime.Size = new System.Drawing.Size(80, 17);
            this.labelPlaytime.Text = "CS2 时长：";
            this.lblPlaytime.Location = new System.Drawing.Point(110, 59);
            this.lblPlaytime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlaytime.Text = "--";
            this.lblPlaytime.AutoSize = true;

            this.labelLevel.Location = new System.Drawing.Point(23, 87);
            this.labelLevel.Size = new System.Drawing.Size(80, 17);
            this.labelLevel.Text = "游戏内等级：";
            this.lblLevel.Location = new System.Drawing.Point(110, 87);
            this.lblLevel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLevel.Text = "--";
            this.lblLevel.AutoSize = true;

            this.label10.Location = new System.Drawing.Point(23, 115);
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.Text = "优先分数：";
            this.lblScore.Location = new System.Drawing.Point(110, 115);
            this.lblScore.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScore.Text = "--";
            this.lblScore.AutoSize = true;

            this.labelWins.Location = new System.Drawing.Point(23, 143);
            this.labelWins.Size = new System.Drawing.Size(80, 17);
            this.labelWins.Text = "竞技胜场：";
            this.lblWins.Location = new System.Drawing.Point(110, 143);
            this.lblWins.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWins.Text = "--";
            this.lblWins.AutoSize = true;

            this.label8.Location = new System.Drawing.Point(23, 171);
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.Text = "竞技冷却：";
            this.lblCooldown.Location = new System.Drawing.Point(110, 171);
            this.lblCooldown.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCooldown.Text = "--";
            this.lblCooldown.AutoSize = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 296);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(32, 17);
            this.statusLabel.Text = "就绪";
            
            // picLogo
            this.picLogo.Location = new System.Drawing.Point(20, 315);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            try { this.picLogo.Image = System.Drawing.Image.FromFile(@"D:\Google\SteamAnalysisAvalonia\Assets\icon.png"); } catch { }

            // btnRepo
            this.btnRepo.Location = new System.Drawing.Point(120, 315);
            this.btnRepo.Name = "btnRepo";
            this.btnRepo.Size = new System.Drawing.Size(140, 38);
            this.btnRepo.TabIndex = 5;
            this.btnRepo.Text = "开源仓库";
            this.btnRepo.UseVisualStyleBackColor = true;
            this.btnRepo.Click += new System.EventHandler(this.btnRepo_Click);

            // btnCard
            this.btnCard.Location = new System.Drawing.Point(120, 365);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(140, 38);
            this.btnCard.TabIndex = 6;
            this.btnCard.Text = "获取卡密";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);

            // lblWatermark
            this.lblWatermark.AutoSize = true;
            this.lblWatermark.Location = new System.Drawing.Point(30, 420);
            this.lblWatermark.Name = "lblWatermark";
            this.lblWatermark.Size = new System.Drawing.Size(200, 17);
            this.lblWatermark.TabIndex = 7;
            this.lblWatermark.Text = "作者：小司大王喵(QQ935939605)";
            this.lblWatermark.ForeColor = System.Drawing.Color.Gray;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 490);
            this.Controls.Add(this.lblWatermark);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnRepo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpCs2);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamAnalysis Native";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpBasic.ResumeLayout(false);
            this.grpBasic.PerformLayout();
            this.grpCs2.ResumeLayout(false);
            this.grpCs2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnParseKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearWorkshop;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkKeepAccounts;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.GroupBox grpCs2;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSteamId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMemberSince;
        private System.Windows.Forms.Label labelMemberSince;
        private System.Windows.Forms.Label lblPrivacy;
        private System.Windows.Forms.Label labelPrivacy;
        private System.Windows.Forms.Label lblPlaytime;
        private System.Windows.Forms.Label labelPlaytime;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label labelWins;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCooldown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnRepo;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Label lblWatermark;
    }
}
