namespace UTAutoMouse
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTrackingPos = new System.Windows.Forms.Button();
            this.txtCursorPosX = new System.Windows.Forms.TextBox();
            this.txtCursorPosY = new System.Windows.Forms.TextBox();
            this.btnAutoClick = new System.Windows.Forms.Button();
            this.lstPositionList = new System.Windows.Forms.ListView();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTrackingPos
            // 
            this.btnTrackingPos.Location = new System.Drawing.Point(248, 30);
            this.btnTrackingPos.Name = "btnTrackingPos";
            this.btnTrackingPos.Size = new System.Drawing.Size(94, 23);
            this.btnTrackingPos.TabIndex = 0;
            this.btnTrackingPos.Text = "Tracking";
            this.btnTrackingPos.UseVisualStyleBackColor = true;
            this.btnTrackingPos.Click += new System.EventHandler(this.btnTrackingPos_Click);
            // 
            // txtCursorPosX
            // 
            this.txtCursorPosX.Location = new System.Drawing.Point(23, 32);
            this.txtCursorPosX.Name = "txtCursorPosX";
            this.txtCursorPosX.ReadOnly = true;
            this.txtCursorPosX.Size = new System.Drawing.Size(100, 21);
            this.txtCursorPosX.TabIndex = 1;
            // 
            // txtCursorPosY
            // 
            this.txtCursorPosY.Location = new System.Drawing.Point(129, 32);
            this.txtCursorPosY.Name = "txtCursorPosY";
            this.txtCursorPosY.ReadOnly = true;
            this.txtCursorPosY.Size = new System.Drawing.Size(100, 21);
            this.txtCursorPosY.TabIndex = 2;
            // 
            // btnAutoClick
            // 
            this.btnAutoClick.Location = new System.Drawing.Point(12, 365);
            this.btnAutoClick.Name = "btnAutoClick";
            this.btnAutoClick.Size = new System.Drawing.Size(68, 51);
            this.btnAutoClick.TabIndex = 3;
            this.btnAutoClick.Text = "Auto Start";
            this.btnAutoClick.UseVisualStyleBackColor = true;
            this.btnAutoClick.Click += new System.EventHandler(this.btnAutoClick_Click);
            // 
            // lstPositionList
            // 
            this.lstPositionList.HideSelection = false;
            this.lstPositionList.Location = new System.Drawing.Point(23, 89);
            this.lstPositionList.Name = "lstPositionList";
            this.lstPositionList.Size = new System.Drawing.Size(319, 164);
            this.lstPositionList.TabIndex = 4;
            this.lstPositionList.UseCompatibleStateImageBehavior = false;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(248, 60);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(94, 23);
            this.btnWrite.TabIndex = 5;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(23, 62);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(206, 21);
            this.txtTitle.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 428);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.lstPositionList);
            this.Controls.Add(this.btnAutoClick);
            this.Controls.Add(this.txtCursorPosY);
            this.Controls.Add(this.txtCursorPosX);
            this.Controls.Add(this.btnTrackingPos);
            this.Name = "MainForm";
            this.Text = "Auto Mousor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrackingPos;
        private System.Windows.Forms.TextBox txtCursorPosX;
        private System.Windows.Forms.TextBox txtCursorPosY;
        private System.Windows.Forms.Button btnAutoClick;
        private System.Windows.Forms.ListView lstPositionList;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtTitle;
    }
}

