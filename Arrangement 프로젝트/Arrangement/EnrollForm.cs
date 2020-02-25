using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Security.AccessControl;

namespace Arrangement
{
    public partial class EnrollForm : Form
    {
        #region 전역변수

        public string rMainCombText = "";

        public string rSmallCombText = "";

        int mSeq;   //저장할 때 Seq번호

        string mDate;   //예전 파일 날짜 -- 날짜 변경 시 파일을 옮기기 위함

        bool mIsNew = false; //신규 수정 여부 

        List<string> mFilePathList = new List<string>();

        List<string> mOldFileList = new List<string>();

        DataTable dtCombo;


        #endregion 전역변수_End

        #region 생성자
        /// <summary>
        /// 신규
        /// </summary>
        /// <param name="p_Main"></param>
        /// <param name="p_Small"></param>
        public EnrollForm(DataTable p_dtCombo, int p_Seq)
        {
            InitializeComponent();

            dte.Value = DateTime.Now;

            mSeq = p_Seq;

            mIsNew = true;

            dtCombo = p_dtCombo;

            fnComboInit();

            cboColor.SelectedItem = "흰색";

            fnInitOpt();

        }


        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="p_Main"></param>
        /// <param name="p_Small"></param>
        /// <param name="p_dicSelected"></param>
        public EnrollForm(DataTable p_dtCombo, Dictionary<string,string> p_dicSelected)
        {
            InitializeComponent();

            //seq을 전역변수에 저장
            mSeq = Convert.ToInt32(p_dicSelected["Seq"]);

            //예전 날짜 저장
            mDate = p_dicSelected["날짜"];

            //콤보박스 아이템 받아오기
            dtCombo = p_dtCombo;

            //이동,복사 체크유무
            fnInitOpt();

            //신규 수정 여부 
            mIsNew = false;

            //파일을 나누어 담기    //mOldFileList 에 기존의 첨부파일들이 저장
            fnDividerFileName(p_dicSelected["FileDetail"]);

            //콤보바인딩
            fnComboInit();

            //파일컨트롤 초기화
            fnFileInit();

            //그 밖에 컨트롤 바인딩
            fnSelectedInit(p_dicSelected);
        }
        #endregion 생성자_End




        #region 함수

        private void fnInitOpt()
        {
            string strSQL = @"SELECT isCopy FROM InitOpt";
            
            SQLiteConnection conn = new SQLiteConnection(@"Data Source = .\Contents.db");
            conn.Open();
            SQLiteDataAdapter Ap = new SQLiteDataAdapter(strSQL, conn);
            DataTable dtOpt = new DataTable();

            Ap.Fill(dtOpt);

            if (dtOpt.Rows[0]["isCopy"].ToString().ToUpper().Equals("Y"))
            {
                rdoCopy.Checked = true;
            }
            else
            {
                rdoCopy.Checked = false;
            }

            Ap.Dispose();
            conn.Dispose();
        }

        /// <summary>
        /// 빈 디렉토리 삭제
        /// </summary>
        /// <param name="p_Path"></param>
        private void fnEmptyDirDel(string p_Path)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(p_Path);
            if (DirInfo.GetFiles().Length < 1)
                DirInfo.Delete();
        }

        /// <summary>
        /// 쿼리로 들어온 파일리스트를 전역변수에 저장(mOldFileList)
        /// </summary>
        /// <param name="p_LongName"></param>
        private void fnDividerFileName(string p_LongName)
        {
            string[] Temp;
            mOldFileList.Clear();

            if (p_LongName != "")
            {
                Temp = p_LongName.Split('§');

                foreach (string a in Temp)
                {
                    if (a != "")
                        mOldFileList.Add(a);

                }
            }
            else
            {
                return;
            }
            

        }

        /// <summary>
        /// 수정 시, 컨트롤 초기화
        /// </summary>
        /// <param name="p_dicSelected"></param>
        private void fnSelectedInit(Dictionary<string, string> p_dicSelected)
        {
            dte.Value = Convert.ToDateTime(p_dicSelected["날짜"].Substring(0, 4) + "." + p_dicSelected["날짜"].Substring(4, 2) + "." + p_dicSelected["날짜"].Substring(6, 2));
            cboMain.SelectedIndex = cboMain.FindStringExact(p_dicSelected["대분류"]);
            cboSmall.SelectedIndex = cboSmall.FindStringExact(p_dicSelected["소분류"]);
            cboColor.SelectedIndex = cboColor.FindStringExact(p_dicSelected["Color"] == "" ? "흰색" : p_dicSelected["Color"]);
            txtTitle.Text = p_dicSelected["제목"].Replace("♤", "'");
            //rtxtContents.Text = p_dicSelected["내용"].Replace("♤", "'");
            if (p_dicSelected["Contents_Rtf"] != "")
            {
                rtxtContents.Rtf = p_dicSelected["Contents_Rtf"].Replace("♤", "'");
            }
            else
            {
                rtxtContents.Text = p_dicSelected["내용"].Replace("♤", "'");
            }
        }

        /// <summary>
        /// 파일 컨트롤 초기화
        /// </summary>
        private void fnFileInit()
        {
            txtFile1.Visible = false;
            labFile1.Visible = false;
            btnDel1.Visible = false;
            txtFile2.Visible = false;
            labFile2.Visible = false;
            btnDel2.Visible = false;
            txtFile3.Visible = false;
            labFile3.Visible = false;
            btnDel3.Visible = false;
            txtFile4.Visible = false;
            labFile4.Visible = false;
            btnDel4.Visible = false;

            bool isFile1 = false;
            bool isFile2 = false;
            bool isFile3 = false;
            bool isFile4 = false;

            if (mOldFileList.Count > 0 && mOldFileList.Count < 5)
            {
                btnDirOpen.Visible = true;

                foreach (string fileName in mOldFileList)
                {
                    if (!isFile1)
                    {
                        txtFile1.Text = fileName;
                        txtFile1.Visible = true;
                        labFile1.Visible = true;
                        btnDel1.Visible = true;
                        isFile1 = true;
                    }
                    else if (!isFile2)
                    {
                        txtFile2.Text = fileName;
                        txtFile2.Visible = true;
                        labFile2.Visible = true;
                        btnDel2.Visible = true;
                        isFile2 = true;

                    }
                    else if (!isFile3)
                    {
                        txtFile3.Text = fileName;
                        txtFile3.Visible = true;
                        labFile3.Visible = true;
                        btnDel3.Visible = true;
                        isFile3 = true;
                    }
                    else if (!isFile4)
                    {
                        txtFile4.Text = fileName;
                        txtFile4.Visible = true;
                        labFile4.Visible = true;
                        btnDel4.Visible = true;
                        isFile4 = true;
                    }
                }
            }
            else if (mOldFileList.Count > 4)
            {
                MessageBox.Show("파일 갯수 오류");
            }
            else
            {
                btnDirOpen.Visible = false;
            }
        }


        /// <summary>
        /// 콤보 초기화
        /// </summary>
        /// <param name="p_Main"></param>
        /// <param name="p_Small"></param>
        private void fnComboInit()
        {
            cboMain.Items.Clear();
            cboSmall.Items.Clear();

            cboMain.Items.Add("<전체>");

            cboColor.Items.Add("흰색");
            cboColor.Items.Add("회색");
            cboColor.Items.Add("하늘");
            cboColor.Items.Add("노랑");
            cboColor.Items.Add("빨강");

            //콤보박스 바인딩
            foreach (DataRow dr in dtCombo.Rows)
            {

                if (!cboMain.Items.Contains(dr["대분류"].ToString()))
                {
                    cboMain.Items.Add(dr["대분류"].ToString());
                }

            }


        }


        /// <summary>
        /// 디비 저장  
        /// </summary>
        /// <param name="p_Seq"></param>
        /// <returns></returns>
        private bool fnSave(int p_Seq)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("제목에 내용이 없습니다.");
                return false;
            }

            if (txtFile.Text != "")
            {
                if (MessageBox.Show("파일을 등록하지 않았는데, 그대로 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }


            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\Contents.db");
            SQLiteCommand sqlcmd;
            string strSQL = "";
            string strFileQuery = "";
            string strCboMain = cboMain.Text.Equals("<전체>") ? "" : cboMain.Text;

            if (strCboMain.Replace(" ","").Equals(""))
            {
                MessageBox.Show("대분류의 내용이 없습니다.");
                return false;
            }

            conn.Open();

            //날짜를 바꿨을 경우 파일 경로도 다시 재조정

            if (mOldFileList.Count > 0)
            {

                foreach (string oldFile in mOldFileList)
                {
                    if (!File.Exists(@".\FileList\" + mDate + @"\" + oldFile))
                    {
                        MessageBox.Show("경로에 파일( '" + oldFile + "' )이 없음.");
                    }


                    else if (!File.Exists(@".\FileList\" + dte.Value.ToString("yyyyMMdd") + @"\" + Path.GetFileName(oldFile)))
                    {
                        if (fnFileCopyMove(@".\FileList\" + mDate + @"\" + oldFile, false))
                        {
                            strFileQuery += oldFile + "§";
                        }
                        fnEmptyDirDel(@".\FileList\" + mDate);
                    }

                    else
                    {
                        strFileQuery += oldFile + "§";
                    }
                }
            }


            //추가한 파일 이동
            if (mFilePathList.Count > 0)
            {
                for (int i = 0; i < mFilePathList.Count; i++)
                {

                    if (fnFileCopyMove(mFilePathList[i], rdoCopy.Checked))
                    {
                        strFileQuery += Path.GetFileName(mFilePathList[i]) + "§";
                    }
                }
            }



            if (mIsNew)
            {
                strSQL = @"INSERT INTO ASList ( Seq, Date, MainCate, SmallCate, Title, Contents, File, Contents_Rtf, Color )
                            VALUES ( '" + mSeq + @"'
                                    ,'" + dte.Value.ToString("yyyyMMdd") + @"'
                                    ,'" + strCboMain + @"'
                                    ,'" + cboSmall.Text + @"'
                                    ,'" + txtTitle.Text.Replace("'","♤") + @"'
                                    ,'" + rtxtContents.Text.Replace("'", "♤") + @"'
                                    ,'" + strFileQuery + @"'
                                    ,'" + rtxtContents.Rtf.Replace("'", "♤") + @"'
                                    ,'" + (cboColor.Text == "흰색" ? "" : cboColor.Text) + "')";
            }
            else
            {
                strSQL = @"UPDATE ASList 
                              SET Date = '" + dte.Value.ToString("yyyyMMdd") + @"', 
                                  MainCate = '" + strCboMain + @"',
                                  SmallCate = '" + cboSmall.Text + @"',
                                  Title = '" + txtTitle.Text.Replace("'", "♤") + @"',
                                  Contents = '" + rtxtContents.Text.Replace("'", "♤") + @"',
                                  File = '" + strFileQuery + @"',
                                  Contents_Rtf = '" + rtxtContents.Rtf.Replace("'", "♤") + @"',
                                  Color = '" + (cboColor.Text == "흰색" ? "" : cboColor.Text) + @"'
                            WHERE Seq = " + mSeq;
            }

            sqlcmd = new SQLiteCommand(strSQL, conn);
            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();
                conn.Dispose();
                mFilePathList.Clear();

                //재조회
                fnDividerFileName(strFileQuery);
                fnFileInit();
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                sqlcmd.Dispose();
                conn.Dispose();
                return false;
            }


        }

        /// <summary>
        /// 파일 선택하기
        /// </summary>
        private void fnFileSelector()
        {

            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.ShowDialog();
            if (Ofd.FileName.Length > 0)
            {
                txtFile.Text = Ofd.FileName;
            }
        }

        /// <summary>
        /// 파일 복사하기
        /// </summary>
        private bool fnFileCopyMove(string p_SourceFile, bool p_isCopy)
        {

            string strTargetDirPath = @".\FileList\" + dte.Value.ToString("yyyyMMdd");
            string strSourcePath = p_SourceFile;
            string strFileName = Path.GetFileName(p_SourceFile);

            if (!Directory.Exists(strTargetDirPath))
            {
                Directory.CreateDirectory(strTargetDirPath);
            }

            if (p_isCopy)
            {
                File.Copy(strSourcePath, strTargetDirPath + @"\" + strFileName,true);
                return true;
            }

            else
            {
                try
                {
                    //권한주기
                    DirectorySecurity dSecurity = Directory.GetAccessControl(strSourcePath);
                    dSecurity.AddAccessRule(new FileSystemAccessRule(System.Environment.UserDomainName + "\\" + System.Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                    Directory.SetAccessControl(strSourcePath, dSecurity);

                    File.Delete(strTargetDirPath + @"\" + strFileName);
                    File.Move(strSourcePath, strTargetDirPath + @"\" + strFileName);
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("파일 이동 삭제에 대한 권한이 없습니다.");
                    mOldFileList.Remove(strFileName + "§");
                    return false;
                }
            }

        }

        private void fntxtFileFill()
        {

            string strTargetDirPath = @".\FileList\" + dte.Value.ToString("yyyyMMdd");
            string strSourcePath = txtFile.Text;
            string strFileName = Path.GetFileName(txtFile.Text);
            string strMessage = string.Format("{0} 파일이 이미 저장되어 있습니다. 바꾸시겠습니까?", strFileName);

            if(!File.Exists(strSourcePath))
            {
                MessageBox.Show("파일을 찾을 수 없습니다.");
                return;
            }

            if (File.Exists(strTargetDirPath + @"\" + strFileName))
            {
                if (MessageBox.Show(strMessage, "알림", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    txtFile.Text = "";
                    return;
                }
                else
                {
                    mOldFileList.Remove(strFileName);
                }
            }

            if (!txtFile1.Visible || Path.GetFileName(txtFile1.Text).Equals(strFileName))
            {
                txtFile1.Text = strFileName;
                txtFile1.Visible = true;
                labFile1.Visible = true;
                btnDel1.Visible = true;
            }
            else if (!txtFile2.Visible || Path.GetFileName(txtFile2.Text).Equals(strFileName))
            {
                txtFile2.Text = strFileName;
                txtFile2.Visible = true;
                labFile2.Visible = true;
                btnDel1.Visible = true;

            }
            else if (!txtFile3.Visible || Path.GetFileName(txtFile3.Text).Equals(strFileName))
            {
                txtFile3.Text = strFileName;
                txtFile3.Visible = true;
                labFile3.Visible = true;
                btnDel1.Visible = true;
            }
            else if (!txtFile4.Visible || Path.GetFileName(txtFile4.Text).Equals(strFileName))
            {
                txtFile4.Text = strFileName;
                txtFile4.Visible = true;
                labFile4.Visible = true;
                btnDel1.Visible = true;
            }
            else
            {
                MessageBox.Show("4개 이상은 첨부되지 않습니다.");
                return;
            }

            mFilePathList.Add(strSourcePath);
            txtFile.Text = "";
        }

        /// <summary>
        /// 파일 지우기 버튼
        /// </summary>
        /// <param name="p_TextBox"></param>
        /// <param name="p_Label"></param>
        /// <param name="p_Button"></param>
        private void fnDelButton(TextBox p_TextBox, Label p_Label, Button p_Button)
        {
            if (MessageBox.Show("정말 삭제 하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (mOldFileList.Contains(p_TextBox.Text))
            {
                mOldFileList.Remove(p_TextBox.Text);

                p_TextBox.Visible = false;
                p_Label.Visible = false;
                p_Button.Visible = false;

                string strFilePath = @".\FileList\" + mDate + @"\";

                if(Directory.Exists(strFilePath))
                {
                    //권한주기
                    DirectorySecurity dSecurity = Directory.GetAccessControl(strFilePath);
                    dSecurity.AddAccessRule(new FileSystemAccessRule(System.Environment.UserDomainName + "\\" + System.Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                    Directory.SetAccessControl(strFilePath, dSecurity);

                    if(File.Exists(strFilePath + p_TextBox.Text))
                    {
                        File.Delete(strFilePath + p_TextBox.Text);
                        fnEmptyDirDel(strFilePath);
                    }
                }
                
            }
            else if (mFilePathList.Count > 0)
            {
                for (int i = 0; i < mFilePathList.Count; i++)
                {
                    if (Path.GetFileName(mFilePathList[i]).Equals(p_TextBox.Text))
                    {
                        mFilePathList.RemoveAt(i);
                        p_TextBox.Visible = false;
                        p_Label.Visible = false;
                        p_Button.Visible = false;
                        
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("파일 이름이나 경로가 맞지않습니다.");
            }

            if(!txtFile1.Visible && !txtFile2.Visible && !txtFile3.Visible && !txtFile4.Visible)
            {
                btnDirOpen.Visible = false;
            }
        }

        private void fnFontChange(int p_size, bool p_boldOpt)
        {
            int intSelectStart = rtxtContents.SelectionStart;
            int intSelectLength = rtxtContents.SelectionLength;
            int intSelectEnd = intSelectStart + intSelectLength;
            for (int x = intSelectStart; x < intSelectEnd; ++x)
            {
                rtxtContents.Select(x, 1);
                
                //굵기변경
                if(p_boldOpt)
                    rtxtContents.SelectionFont = new Font(rtxtContents.SelectionFont.FontFamily, rtxtContents.SelectionFont.Size, rtxtContents.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold);

                else
                    rtxtContents.SelectionFont = new Font(rtxtContents.SelectionFont.FontFamily, rtxtContents.SelectionFont.Size + p_size, rtxtContents.SelectionFont.Bold ? FontStyle.Bold : FontStyle.Regular);
            }

            rtxtContents.Select(intSelectStart, intSelectLength);
        }

        /// <summary>
        /// 파일경로열기.
        /// </summary>
        /// <param name="p_FileName"></param>
        private void fnProcessOpen(string p_FileName)
        {
            try
            {
                System.Diagnostics.Process.Start(@".\Filelist\" + dte.Value.ToString("yyyyMMdd") + @"\" + p_FileName);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("해당 파일의 폴더가 존재하는지 확인바랍니다.");
            }
        }

        #endregion 함수_End

        #region 이벤트 연결
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fnSave(mSeq))
            {
                MessageBox.Show("저장되었습니다.");
                mDate = dte.Value.ToString("yyyyMMdd");
                mIsNew = false;
            }



        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (fnSave(mSeq))
            {
                MessageBox.Show("저장되었습니다.");
                this.Close();
            }

            else
            {
            }

            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDirSearch_Click(object sender, EventArgs e)
        {
            fnFileSelector();
        }

        private void btnRegiFile_Click(object sender, EventArgs e)
        {
            fntxtFileFill();
            //fnFileRegistor();
        }


        private void btnDirOpen_Click(object sender, EventArgs e)
        {
            fnProcessOpen("");
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            fnDelButton(txtFile1, labFile1, btnDel1);
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            fnDelButton(txtFile2, labFile2, btnDel2);
        }

        private void btnDel3_Click(object sender, EventArgs e)
        {
            fnDelButton(txtFile3, labFile3, btnDel3);
        }

        private void btnDel4_Click(object sender, EventArgs e)
        {
            fnDelButton(txtFile4, labFile4, btnDel4);
        }

        private void EnrollForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source = .\Contents.db");
            conn.Open();
            string strSQL = "";
            string strCopy = rdoCopy.Checked ? "Y" : "N";

            strSQL = @"UPDATE InitOpt
                          SET isCopy = '" + strCopy + @"'";
            SQLiteCommand sqlcmd = new SQLiteCommand(strSQL, conn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            conn.Dispose();

            rMainCombText = cboMain.Text;
            rSmallCombText = cboSmall.Text;
        }

        private void btnThick_Click(object sender, EventArgs e)
        {
            fnFontChange(0, true);
        }

        private void btnSizeUp_Click(object sender, EventArgs e)
        {
            fnFontChange(+1,false);
        }

        private void btnSizeDown_Click(object sender, EventArgs e)
        {
            fnFontChange(-1,false);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            rtxtContents.SelectionColor = Color.Black;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            rtxtContents.SelectionColor = Color.Red;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            rtxtContents.SelectionColor = Color.Blue;
        }

        private void rtxtContents_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Alt && e.Shift && e.KeyCode == Keys.Q)
                {
                    fnFontChange(0, true);
                }

                else if (e.Alt && e.Shift && e.KeyCode == Keys.E)
                {
                    fnFontChange(+1, false);
                }

                else if (e.Alt && e.Shift && e.KeyCode == Keys.R)
                {
                    fnFontChange(-1, false);
                }
            }
            catch
            {}
        }
        
        private void cboMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSmall.Items.Clear();
            
            if (cboMain.Text.Equals("<전체>"))
            {
                foreach (DataRow dr in dtCombo.Rows)
                {
                    if (!cboSmall.Items.Contains(dr["소분류"].ToString()))
                    {
                        cboSmall.Items.Add(dr["소분류"].ToString());
                    }
                }
            }


            foreach (DataRow dr in dtCombo.Rows)
            {
                if (dr["대분류"].ToString().Equals(cboMain.Text) && !cboSmall.Items.Contains(dr["소분류"].ToString()))
                {
                    cboSmall.Items.Add(dr["소분류"].ToString());
                }
            }
        }


        private void cboMain_Leave(object sender, EventArgs e)
        {
            cboSmall.Items.Clear();

            if (cboMain.Text.Equals("<전체>"))
            {
                foreach (DataRow dr in dtCombo.Rows)
                {
                    if (!cboSmall.Items.Contains(dr["소분류"].ToString()))
                    {
                        cboSmall.Items.Add(dr["소분류"].ToString());
                    }
                }
            }


            foreach (DataRow dr in dtCombo.Rows)
            {
                if (dr["대분류"].ToString().Equals(cboMain.Text) && !cboSmall.Items.Contains(dr["소분류"].ToString()))
                {
                    cboSmall.Items.Add(dr["소분류"].ToString());
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData)) // 위에서 처리 안했으면
            {
                // 여기에 처리코드를 넣는다.
                if (keyData.Equals(Keys.F5))
                {
                    if (fnSave(mSeq))
                    {
                        MessageBox.Show("저장되었습니다.");
                        this.Close();
                    }
                    return true;
                }

                else if (keyData.Equals(Keys.F4))
                {
                    fntxtFileFill();
                    return true;
                }

                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        #endregion 이벤트 연결_End
        private void txtFile1_DoubleClick(object sender, EventArgs e)
        {
            fnProcessOpen("");
        }

        private void txtFile2_DoubleClick(object sender, EventArgs e)
        {
            fnProcessOpen("");
        }

        private void txtFile3_DoubleClick(object sender, EventArgs e)
        {
            fnProcessOpen("");
        }

        private void txtFile4_DoubleClick(object sender, EventArgs e)
        {
            fnProcessOpen("");
        }



    }
}