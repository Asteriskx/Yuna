namespace Yuna
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.SearchButton = new System.Windows.Forms.Button();
			this.Artwork = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SearchBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SearchResult = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SearchNum = new System.Windows.Forms.NumericUpDown();
			this.InfoGroup = new System.Windows.Forms.GroupBox();
			this.TrialButton = new System.Windows.Forms.Button();
			this.ListGroup = new System.Windows.Forms.GroupBox();
			this.ResultView = new System.Windows.Forms.ListView();
			this.ArtworkGroup = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.Artwork)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchNum)).BeginInit();
			this.InfoGroup.SuspendLayout();
			this.ListGroup.SuspendLayout();
			this.ArtworkGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// SearchButton
			// 
			this.SearchButton.BackColor = System.Drawing.Color.Black;
			this.SearchButton.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.SearchButton.ForeColor = System.Drawing.Color.White;
			this.SearchButton.Location = new System.Drawing.Point(841, 86);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(148, 33);
			this.SearchButton.TabIndex = 0;
			this.SearchButton.Text = "情報取得するやで";
			this.SearchButton.UseVisualStyleBackColor = false;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// Artwork
			// 
			this.Artwork.BackColor = System.Drawing.Color.Black;
			this.Artwork.Location = new System.Drawing.Point(16, 22);
			this.Artwork.Name = "Artwork";
			this.Artwork.Size = new System.Drawing.Size(290, 290);
			this.Artwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Artwork.TabIndex = 2;
			this.Artwork.TabStop = false;
			this.Artwork.Click += new System.EventHandler(this.Artwork_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "検索名称：";
			// 
			// SearchBox
			// 
			this.SearchBox.BackColor = System.Drawing.Color.Black;
			this.SearchBox.ForeColor = System.Drawing.Color.White;
			this.SearchBox.Location = new System.Drawing.Point(95, 26);
			this.SearchBox.Name = "SearchBox";
			this.SearchBox.Size = new System.Drawing.Size(542, 25);
			this.SearchBox.TabIndex = 4;
			this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "検索結果：";
			// 
			// SearchResult
			// 
			this.SearchResult.AutoSize = true;
			this.SearchResult.Location = new System.Drawing.Point(92, 86);
			this.SearchResult.Name = "SearchResult";
			this.SearchResult.Size = new System.Drawing.Size(152, 18);
			this.SearchResult.TabIndex = 6;
			this.SearchResult.Text = "検索結果が設定されるで。";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "検索数：";
			// 
			// SearchNum
			// 
			this.SearchNum.BackColor = System.Drawing.Color.Black;
			this.SearchNum.ForeColor = System.Drawing.Color.White;
			this.SearchNum.Location = new System.Drawing.Point(95, 56);
			this.SearchNum.Name = "SearchNum";
			this.SearchNum.Size = new System.Drawing.Size(120, 25);
			this.SearchNum.TabIndex = 8;
			this.SearchNum.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// InfoGroup
			// 
			this.InfoGroup.Controls.Add(this.TrialButton);
			this.InfoGroup.Controls.Add(this.label1);
			this.InfoGroup.Controls.Add(this.SearchNum);
			this.InfoGroup.Controls.Add(this.SearchBox);
			this.InfoGroup.Controls.Add(this.SearchButton);
			this.InfoGroup.Controls.Add(this.label3);
			this.InfoGroup.Controls.Add(this.label2);
			this.InfoGroup.Controls.Add(this.SearchResult);
			this.InfoGroup.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.InfoGroup.ForeColor = System.Drawing.Color.White;
			this.InfoGroup.Location = new System.Drawing.Point(12, 358);
			this.InfoGroup.Name = "InfoGroup";
			this.InfoGroup.Size = new System.Drawing.Size(995, 127);
			this.InfoGroup.TabIndex = 9;
			this.InfoGroup.TabStop = false;
			this.InfoGroup.Text = "Information";
			// 
			// TrialButton
			// 
			this.TrialButton.BackColor = System.Drawing.Color.Black;
			this.TrialButton.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TrialButton.ForeColor = System.Drawing.Color.White;
			this.TrialButton.Location = new System.Drawing.Point(689, 86);
			this.TrialButton.Name = "TrialButton";
			this.TrialButton.Size = new System.Drawing.Size(148, 33);
			this.TrialButton.TabIndex = 9;
			this.TrialButton.Text = "試聴するやで";
			this.TrialButton.UseVisualStyleBackColor = false;
			this.TrialButton.Click += new System.EventHandler(this.TrialButton_Click);
			// 
			// ListGroup
			// 
			this.ListGroup.Controls.Add(this.ResultView);
			this.ListGroup.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ListGroup.ForeColor = System.Drawing.Color.White;
			this.ListGroup.Location = new System.Drawing.Point(12, 12);
			this.ListGroup.Name = "ListGroup";
			this.ListGroup.Size = new System.Drawing.Size(653, 330);
			this.ListGroup.TabIndex = 10;
			this.ListGroup.TabStop = false;
			this.ListGroup.Text = "取得情報";
			// 
			// ResultView
			// 
			this.ResultView.BackColor = System.Drawing.Color.Black;
			this.ResultView.ForeColor = System.Drawing.Color.White;
			this.ResultView.Location = new System.Drawing.Point(13, 22);
			this.ResultView.Name = "ResultView";
			this.ResultView.Size = new System.Drawing.Size(625, 290);
			this.ResultView.TabIndex = 0;
			this.ResultView.UseCompatibleStateImageBehavior = false;
			this.ResultView.SelectedIndexChanged += new System.EventHandler(this.ResultView_SelectedIndexChanged);
			// 
			// ArtworkGroup
			// 
			this.ArtworkGroup.Controls.Add(this.Artwork);
			this.ArtworkGroup.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ArtworkGroup.ForeColor = System.Drawing.Color.White;
			this.ArtworkGroup.Location = new System.Drawing.Point(685, 12);
			this.ArtworkGroup.Name = "ArtworkGroup";
			this.ArtworkGroup.Size = new System.Drawing.Size(322, 330);
			this.ArtworkGroup.TabIndex = 11;
			this.ArtworkGroup.TabStop = false;
			this.ArtworkGroup.Text = "アートワーク";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1024, 506);
			this.Controls.Add(this.ArtworkGroup);
			this.Controls.Add(this.ListGroup);
			this.Controls.Add(this.InfoGroup);
			this.Name = "FormMain";
			this.Text = "Yuna - iTunes Search API Test";
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.Artwork)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchNum)).EndInit();
			this.InfoGroup.ResumeLayout(false);
			this.InfoGroup.PerformLayout();
			this.ListGroup.ResumeLayout(false);
			this.ArtworkGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.PictureBox Artwork;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SearchBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label SearchResult;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown SearchNum;
		private System.Windows.Forms.GroupBox InfoGroup;
		private System.Windows.Forms.GroupBox ListGroup;
		private System.Windows.Forms.GroupBox ArtworkGroup;
		private System.Windows.Forms.ListView ResultView;
		private System.Windows.Forms.Button TrialButton;
	}
}

