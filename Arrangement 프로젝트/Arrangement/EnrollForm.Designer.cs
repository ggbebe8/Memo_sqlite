namespace Arrangement
{
    partial class EnrollForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollForm));
            this.dte = new System.Windows.Forms.DateTimePicker();
            this.cboMain = new System.Windows.Forms.ComboBox();
            this.cboSmall = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnDirSearch = new System.Windows.Forms.Button();
            this.btnRegiFile = new System.Windows.Forms.Button();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnDirOpen = new System.Windows.Forms.Button();
            this.labFile1 = new System.Windows.Forms.Label();
            this.labFile2 = new System.Windows.Forms.Label();
            this.labFile3 = new System.Windows.Forms.Label();
            this.txtFile3 = new System.Windows.Forms.TextBox();
            this.txtFile4 = new System.Windows.Forms.TextBox();
            this.labFile4 = new System.Windows.Forms.Label();
            this.rdoMove = new System.Windows.Forms.RadioButton();
            this.btnDel1 = new System.Windows.Forms.Button();
            this.btnDel2 = new System.Windows.Forms.Button();
            this.btnDel3 = new System.Windows.Forms.Button();
            this.btnDel4 = new System.Windows.Forms.Button();
            this.rdoCopy = new System.Windows.Forms.RadioButton();
            this.rtxtContents = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnSizeDown = new System.Windows.Forms.Button();
            this.btnSizeUp = new System.Windows.Forms.Button();
            this.btnThick = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dte
            // 
            this.dte.Location = new System.Drawing.Point(98, 3);
            this.dte.Name = "dte";
            this.dte.Size = new System.Drawing.Size(113, 21);
            this.dte.TabIndex = 2;
            this.dte.Value = new System.DateTime(2018, 3, 20, 0, 0, 0, 0);
            // 
            // cboMain
            // 
            this.cboMain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMain.BackColor = System.Drawing.Color.White;
            this.cboMain.FormattingEnabled = true;
            this.cboMain.Location = new System.Drawing.Point(285, 3);
            this.cboMain.Name = "cboMain";
            this.cboMain.Size = new System.Drawing.Size(118, 20);
            this.cboMain.TabIndex = 7;
            this.cboMain.SelectedIndexChanged += new System.EventHandler(this.cboMain_SelectedIndexChanged);
            this.cboMain.Leave += new System.EventHandler(this.cboMain_Leave);
            // 
            // cboSmall
            // 
            this.cboSmall.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSmall.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSmall.FormattingEnabled = true;
            this.cboSmall.Location = new System.Drawing.Point(464, 3);
            this.cboSmall.Name = "cboSmall";
            this.cboSmall.Size = new System.Drawing.Size(118, 20);
            this.cboSmall.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(98, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(366, 21);
            this.txtTitle.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "날짜 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "대분류 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "소분류 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "제목 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "내용 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "파일 :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(315, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(406, 93);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(87, 23);
            this.btnSaveClose.TabIndex = 19;
            this.btnSaveClose.Text = "저장 후 닫기";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(511, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(102, 3);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(391, 21);
            this.txtFile.TabIndex = 21;
            // 
            // btnDirSearch
            // 
            this.btnDirSearch.Location = new System.Drawing.Point(499, 3);
            this.btnDirSearch.Name = "btnDirSearch";
            this.btnDirSearch.Size = new System.Drawing.Size(31, 23);
            this.btnDirSearch.TabIndex = 23;
            this.btnDirSearch.Text = "...";
            this.btnDirSearch.UseVisualStyleBackColor = true;
            this.btnDirSearch.Click += new System.EventHandler(this.btnDirSearch_Click);
            // 
            // btnRegiFile
            // 
            this.btnRegiFile.Location = new System.Drawing.Point(536, 3);
            this.btnRegiFile.Name = "btnRegiFile";
            this.btnRegiFile.Size = new System.Drawing.Size(50, 23);
            this.btnRegiFile.TabIndex = 24;
            this.btnRegiFile.Text = "등록";
            this.btnRegiFile.UseVisualStyleBackColor = true;
            this.btnRegiFile.Click += new System.EventHandler(this.btnRegiFile_Click);
            // 
            // txtFile1
            // 
            this.txtFile1.Location = new System.Drawing.Point(102, 30);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.ReadOnly = true;
            this.txtFile1.Size = new System.Drawing.Size(144, 21);
            this.txtFile1.TabIndex = 25;
            this.txtFile1.Visible = false;
            this.txtFile1.DoubleClick += new System.EventHandler(this.txtFile1_DoubleClick);
            // 
            // txtFile2
            // 
            this.txtFile2.Location = new System.Drawing.Point(324, 30);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.ReadOnly = true;
            this.txtFile2.Size = new System.Drawing.Size(144, 21);
            this.txtFile2.TabIndex = 26;
            this.txtFile2.Visible = false;
            this.txtFile2.DoubleClick += new System.EventHandler(this.txtFile2_DoubleClick);
            // 
            // btnDirOpen
            // 
            this.btnDirOpen.Location = new System.Drawing.Point(499, 57);
            this.btnDirOpen.Name = "btnDirOpen";
            this.btnDirOpen.Size = new System.Drawing.Size(87, 23);
            this.btnDirOpen.TabIndex = 27;
            this.btnDirOpen.Text = "경로 열기";
            this.btnDirOpen.UseVisualStyleBackColor = true;
            this.btnDirOpen.Visible = false;
            this.btnDirOpen.Click += new System.EventHandler(this.btnDirOpen_Click);
            // 
            // labFile1
            // 
            this.labFile1.AutoSize = true;
            this.labFile1.Location = new System.Drawing.Point(53, 35);
            this.labFile1.Name = "labFile1";
            this.labFile1.Size = new System.Drawing.Size(43, 12);
            this.labFile1.TabIndex = 28;
            this.labFile1.Text = "파일1 :";
            this.labFile1.Visible = false;
            // 
            // labFile2
            // 
            this.labFile2.AutoSize = true;
            this.labFile2.Location = new System.Drawing.Point(277, 35);
            this.labFile2.Name = "labFile2";
            this.labFile2.Size = new System.Drawing.Size(43, 12);
            this.labFile2.TabIndex = 29;
            this.labFile2.Text = "파일2 :";
            this.labFile2.Visible = false;
            // 
            // labFile3
            // 
            this.labFile3.AutoSize = true;
            this.labFile3.Location = new System.Drawing.Point(53, 64);
            this.labFile3.Name = "labFile3";
            this.labFile3.Size = new System.Drawing.Size(43, 12);
            this.labFile3.TabIndex = 30;
            this.labFile3.Text = "파일3 :";
            this.labFile3.Visible = false;
            // 
            // txtFile3
            // 
            this.txtFile3.Location = new System.Drawing.Point(102, 57);
            this.txtFile3.Name = "txtFile3";
            this.txtFile3.ReadOnly = true;
            this.txtFile3.Size = new System.Drawing.Size(144, 21);
            this.txtFile3.TabIndex = 31;
            this.txtFile3.Visible = false;
            this.txtFile3.DoubleClick += new System.EventHandler(this.txtFile3_DoubleClick);
            // 
            // txtFile4
            // 
            this.txtFile4.Location = new System.Drawing.Point(324, 57);
            this.txtFile4.Name = "txtFile4";
            this.txtFile4.ReadOnly = true;
            this.txtFile4.Size = new System.Drawing.Size(144, 21);
            this.txtFile4.TabIndex = 32;
            this.txtFile4.Visible = false;
            this.txtFile4.DoubleClick += new System.EventHandler(this.txtFile4_DoubleClick);
            // 
            // labFile4
            // 
            this.labFile4.AutoSize = true;
            this.labFile4.Location = new System.Drawing.Point(277, 64);
            this.labFile4.Name = "labFile4";
            this.labFile4.Size = new System.Drawing.Size(43, 12);
            this.labFile4.TabIndex = 33;
            this.labFile4.Text = "파일4 :";
            this.labFile4.Visible = false;
            // 
            // rdoMove
            // 
            this.rdoMove.AutoSize = true;
            this.rdoMove.Checked = true;
            this.rdoMove.Location = new System.Drawing.Point(499, 32);
            this.rdoMove.Name = "rdoMove";
            this.rdoMove.Size = new System.Drawing.Size(47, 16);
            this.rdoMove.TabIndex = 34;
            this.rdoMove.TabStop = true;
            this.rdoMove.Text = "이동";
            this.rdoMove.UseVisualStyleBackColor = true;
            // 
            // btnDel1
            // 
            this.btnDel1.Location = new System.Drawing.Point(252, 30);
            this.btnDel1.Name = "btnDel1";
            this.btnDel1.Size = new System.Drawing.Size(19, 21);
            this.btnDel1.TabIndex = 35;
            this.btnDel1.Text = "X";
            this.btnDel1.UseVisualStyleBackColor = true;
            this.btnDel1.Visible = false;
            this.btnDel1.Click += new System.EventHandler(this.btnDel1_Click);
            // 
            // btnDel2
            // 
            this.btnDel2.Location = new System.Drawing.Point(474, 30);
            this.btnDel2.Name = "btnDel2";
            this.btnDel2.Size = new System.Drawing.Size(19, 21);
            this.btnDel2.TabIndex = 36;
            this.btnDel2.Text = "X";
            this.btnDel2.UseVisualStyleBackColor = true;
            this.btnDel2.Visible = false;
            this.btnDel2.Click += new System.EventHandler(this.btnDel2_Click);
            // 
            // btnDel3
            // 
            this.btnDel3.Location = new System.Drawing.Point(252, 56);
            this.btnDel3.Name = "btnDel3";
            this.btnDel3.Size = new System.Drawing.Size(19, 21);
            this.btnDel3.TabIndex = 37;
            this.btnDel3.Text = "X";
            this.btnDel3.UseVisualStyleBackColor = true;
            this.btnDel3.Visible = false;
            this.btnDel3.Click += new System.EventHandler(this.btnDel3_Click);
            // 
            // btnDel4
            // 
            this.btnDel4.Location = new System.Drawing.Point(474, 56);
            this.btnDel4.Name = "btnDel4";
            this.btnDel4.Size = new System.Drawing.Size(19, 21);
            this.btnDel4.TabIndex = 38;
            this.btnDel4.Text = "X";
            this.btnDel4.UseVisualStyleBackColor = true;
            this.btnDel4.Visible = false;
            this.btnDel4.Click += new System.EventHandler(this.btnDel4_Click);
            // 
            // rdoCopy
            // 
            this.rdoCopy.AutoSize = true;
            this.rdoCopy.Location = new System.Drawing.Point(552, 32);
            this.rdoCopy.Name = "rdoCopy";
            this.rdoCopy.Size = new System.Drawing.Size(47, 16);
            this.rdoCopy.TabIndex = 39;
            this.rdoCopy.Text = "복사";
            this.rdoCopy.UseVisualStyleBackColor = true;
            // 
            // rtxtContents
            // 
            this.rtxtContents.AcceptsTab = true;
            this.rtxtContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtContents.Location = new System.Drawing.Point(67, 94);
            this.rtxtContents.Name = "rtxtContents";
            this.rtxtContents.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtContents.Size = new System.Drawing.Size(1009, 445);
            this.rtxtContents.TabIndex = 11;
            this.rtxtContents.Text = "";
            this.rtxtContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtContents_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRed);
            this.panel1.Controls.Add(this.btnBlack);
            this.panel1.Controls.Add(this.btnBlue);
            this.panel1.Controls.Add(this.btnSizeDown);
            this.panel1.Controls.Add(this.btnSizeUp);
            this.panel1.Controls.Add(this.btnThick);
            this.panel1.Location = new System.Drawing.Point(110, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 22);
            this.panel1.TabIndex = 42;
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Font = new System.Drawing.Font("굴림", 7F);
            this.btnRed.Location = new System.Drawing.Point(174, 1);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(22, 20);
            this.btnRed.TabIndex = 47;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBlack.Font = new System.Drawing.Font("굴림", 7F);
            this.btnBlack.Location = new System.Drawing.Point(146, 1);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(22, 20);
            this.btnBlack.TabIndex = 47;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBlue.FlatAppearance.BorderSize = 0;
            this.btnBlue.Font = new System.Drawing.Font("굴림", 7F);
            this.btnBlue.Location = new System.Drawing.Point(201, 1);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(22, 20);
            this.btnBlue.TabIndex = 46;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnSizeDown
            // 
            this.btnSizeDown.Font = new System.Drawing.Font("굴림", 7F);
            this.btnSizeDown.Location = new System.Drawing.Point(90, 1);
            this.btnSizeDown.Name = "btnSizeDown";
            this.btnSizeDown.Size = new System.Drawing.Size(22, 20);
            this.btnSizeDown.TabIndex = 45;
            this.btnSizeDown.Text = "-";
            this.btnSizeDown.UseVisualStyleBackColor = true;
            this.btnSizeDown.Click += new System.EventHandler(this.btnSizeDown_Click);
            // 
            // btnSizeUp
            // 
            this.btnSizeUp.Font = new System.Drawing.Font("굴림", 7F);
            this.btnSizeUp.Location = new System.Drawing.Point(62, 1);
            this.btnSizeUp.Name = "btnSizeUp";
            this.btnSizeUp.Size = new System.Drawing.Size(22, 20);
            this.btnSizeUp.TabIndex = 44;
            this.btnSizeUp.Text = "+";
            this.btnSizeUp.UseVisualStyleBackColor = true;
            this.btnSizeUp.Click += new System.EventHandler(this.btnSizeUp_Click);
            // 
            // btnThick
            // 
            this.btnThick.Font = new System.Drawing.Font("굴림", 7F);
            this.btnThick.Location = new System.Drawing.Point(12, 1);
            this.btnThick.Name = "btnThick";
            this.btnThick.Size = new System.Drawing.Size(44, 20);
            this.btnThick.TabIndex = 43;
            this.btnThick.Text = "진하게";
            this.btnThick.UseVisualStyleBackColor = true;
            this.btnThick.Click += new System.EventHandler(this.btnThick_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "색 :";
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(525, 30);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(57, 20);
            this.cboColor.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dte);
            this.panel2.Controls.Add(this.cboColor);
            this.panel2.Controls.Add(this.cboMain);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cboSmall);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(244, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 85);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtFile);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.rdoCopy);
            this.panel3.Controls.Add(this.btnSaveClose);
            this.panel3.Controls.Add(this.btnDel4);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnDel3);
            this.panel3.Controls.Add(this.btnDirSearch);
            this.panel3.Controls.Add(this.btnDel2);
            this.panel3.Controls.Add(this.btnRegiFile);
            this.panel3.Controls.Add(this.btnDel1);
            this.panel3.Controls.Add(this.txtFile1);
            this.panel3.Controls.Add(this.rdoMove);
            this.panel3.Controls.Add(this.txtFile2);
            this.panel3.Controls.Add(this.labFile4);
            this.panel3.Controls.Add(this.btnDirOpen);
            this.panel3.Controls.Add(this.txtFile4);
            this.panel3.Controls.Add(this.labFile1);
            this.panel3.Controls.Add(this.txtFile3);
            this.panel3.Controls.Add(this.labFile2);
            this.panel3.Controls.Add(this.labFile3);
            this.panel3.Location = new System.Drawing.Point(229, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 121);
            this.panel3.TabIndex = 46;
            // 
            // EnrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 671);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rtxtContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnrollForm";
            this.Text = "EnrollForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnrollForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dte;
        private System.Windows.Forms.ComboBox cboMain;
        private System.Windows.Forms.ComboBox cboSmall;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnDirSearch;
        private System.Windows.Forms.Button btnRegiFile;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnDirOpen;
        private System.Windows.Forms.Label labFile1;
        private System.Windows.Forms.Label labFile2;
        private System.Windows.Forms.Label labFile3;
        private System.Windows.Forms.TextBox txtFile3;
        private System.Windows.Forms.TextBox txtFile4;
        private System.Windows.Forms.Label labFile4;
        private System.Windows.Forms.RadioButton rdoMove;
        private System.Windows.Forms.Button btnDel1;
        private System.Windows.Forms.Button btnDel2;
        private System.Windows.Forms.Button btnDel3;
        private System.Windows.Forms.Button btnDel4;
        private System.Windows.Forms.RadioButton rdoCopy;
        private System.Windows.Forms.RichTextBox rtxtContents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSizeDown;
        private System.Windows.Forms.Button btnSizeUp;
        private System.Windows.Forms.Button btnThick;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}