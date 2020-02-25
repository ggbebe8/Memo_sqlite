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
        #region ��������

        public string rMainCombText = "";

        public string rSmallCombText = "";

        int mSeq;   //������ �� Seq��ȣ

        string mDate;   //���� ���� ��¥ -- ��¥ ���� �� ������ �ű�� ����

        bool mIsNew = false; //�ű� ���� ���� 

        List<string> mFilePathList = new List<string>();

        List<string> mOldFileList = new List<string>();

        DataTable dtCombo;


        #endregion ��������_End

        #region ������
        /// <summary>
        /// �ű�
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

            cboColor.SelectedItem = "���";

            fnInitOpt();

        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_Main"></param>
        /// <param name="p_Small"></param>
        /// <param name="p_dicSelected"></param>
        public EnrollForm(DataTable p_dtCombo, Dictionary<string,string> p_dicSelected)
        {
            InitializeComponent();

            //seq�� ���������� ����
            mSeq = Convert.ToInt32(p_dicSelected["Seq"]);

            //���� ��¥ ����
            mDate = p_dicSelected["��¥"];

            //�޺��ڽ� ������ �޾ƿ���
            dtCombo = p_dtCombo;

            //�̵�,���� üũ����
            fnInitOpt();

            //�ű� ���� ���� 
            mIsNew = false;

            //������ ������ ���    //mOldFileList �� ������ ÷�����ϵ��� ����
            fnDividerFileName(p_dicSelected["FileDetail"]);

            //�޺����ε�
            fnComboInit();

            //������Ʈ�� �ʱ�ȭ
            fnFileInit();

            //�� �ۿ� ��Ʈ�� ���ε�
            fnSelectedInit(p_dicSelected);
        }
        #endregion ������_End




        #region �Լ�

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
        /// �� ���丮 ����
        /// </summary>
        /// <param name="p_Path"></param>
        private void fnEmptyDirDel(string p_Path)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(p_Path);
            if (DirInfo.GetFiles().Length < 1)
                DirInfo.Delete();
        }

        /// <summary>
        /// ������ ���� ���ϸ���Ʈ�� ���������� ����(mOldFileList)
        /// </summary>
        /// <param name="p_LongName"></param>
        private void fnDividerFileName(string p_LongName)
        {
            string[] Temp;
            mOldFileList.Clear();

            if (p_LongName != "")
            {
                Temp = p_LongName.Split('��');

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
        /// ���� ��, ��Ʈ�� �ʱ�ȭ
        /// </summary>
        /// <param name="p_dicSelected"></param>
        private void fnSelectedInit(Dictionary<string, string> p_dicSelected)
        {
            dte.Value = Convert.ToDateTime(p_dicSelected["��¥"].Substring(0, 4) + "." + p_dicSelected["��¥"].Substring(4, 2) + "." + p_dicSelected["��¥"].Substring(6, 2));
            cboMain.SelectedIndex = cboMain.FindStringExact(p_dicSelected["��з�"]);
            cboSmall.SelectedIndex = cboSmall.FindStringExact(p_dicSelected["�Һз�"]);
            cboColor.SelectedIndex = cboColor.FindStringExact(p_dicSelected["Color"] == "" ? "���" : p_dicSelected["Color"]);
            txtTitle.Text = p_dicSelected["����"].Replace("��", "'");
            //rtxtContents.Text = p_dicSelected["����"].Replace("��", "'");
            if (p_dicSelected["Contents_Rtf"] != "")
            {
                rtxtContents.Rtf = p_dicSelected["Contents_Rtf"].Replace("��", "'");
            }
            else
            {
                rtxtContents.Text = p_dicSelected["����"].Replace("��", "'");
            }
        }

        /// <summary>
        /// ���� ��Ʈ�� �ʱ�ȭ
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
                MessageBox.Show("���� ���� ����");
            }
            else
            {
                btnDirOpen.Visible = false;
            }
        }


        /// <summary>
        /// �޺� �ʱ�ȭ
        /// </summary>
        /// <param name="p_Main"></param>
        /// <param name="p_Small"></param>
        private void fnComboInit()
        {
            cboMain.Items.Clear();
            cboSmall.Items.Clear();

            cboMain.Items.Add("<��ü>");

            cboColor.Items.Add("���");
            cboColor.Items.Add("ȸ��");
            cboColor.Items.Add("�ϴ�");
            cboColor.Items.Add("���");
            cboColor.Items.Add("����");

            //�޺��ڽ� ���ε�
            foreach (DataRow dr in dtCombo.Rows)
            {

                if (!cboMain.Items.Contains(dr["��з�"].ToString()))
                {
                    cboMain.Items.Add(dr["��з�"].ToString());
                }

            }


        }


        /// <summary>
        /// ��� ����  
        /// </summary>
        /// <param name="p_Seq"></param>
        /// <returns></returns>
        private bool fnSave(int p_Seq)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("���� ������ �����ϴ�.");
                return false;
            }

            if (txtFile.Text != "")
            {
                if (MessageBox.Show("������ ������� �ʾҴµ�, �״�� �����Ͻðڽ��ϱ�?", "�˸�", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }


            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\Contents.db");
            SQLiteCommand sqlcmd;
            string strSQL = "";
            string strFileQuery = "";
            string strCboMain = cboMain.Text.Equals("<��ü>") ? "" : cboMain.Text;

            if (strCboMain.Replace(" ","").Equals(""))
            {
                MessageBox.Show("��з��� ������ �����ϴ�.");
                return false;
            }

            conn.Open();

            //��¥�� �ٲ��� ��� ���� ��ε� �ٽ� ������

            if (mOldFileList.Count > 0)
            {

                foreach (string oldFile in mOldFileList)
                {
                    if (!File.Exists(@".\FileList\" + mDate + @"\" + oldFile))
                    {
                        MessageBox.Show("��ο� ����( '" + oldFile + "' )�� ����.");
                    }


                    else if (!File.Exists(@".\FileList\" + dte.Value.ToString("yyyyMMdd") + @"\" + Path.GetFileName(oldFile)))
                    {
                        if (fnFileCopyMove(@".\FileList\" + mDate + @"\" + oldFile, false))
                        {
                            strFileQuery += oldFile + "��";
                        }
                        fnEmptyDirDel(@".\FileList\" + mDate);
                    }

                    else
                    {
                        strFileQuery += oldFile + "��";
                    }
                }
            }


            //�߰��� ���� �̵�
            if (mFilePathList.Count > 0)
            {
                for (int i = 0; i < mFilePathList.Count; i++)
                {

                    if (fnFileCopyMove(mFilePathList[i], rdoCopy.Checked))
                    {
                        strFileQuery += Path.GetFileName(mFilePathList[i]) + "��";
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
                                    ,'" + txtTitle.Text.Replace("'","��") + @"'
                                    ,'" + rtxtContents.Text.Replace("'", "��") + @"'
                                    ,'" + strFileQuery + @"'
                                    ,'" + rtxtContents.Rtf.Replace("'", "��") + @"'
                                    ,'" + (cboColor.Text == "���" ? "" : cboColor.Text) + "')";
            }
            else
            {
                strSQL = @"UPDATE ASList 
                              SET Date = '" + dte.Value.ToString("yyyyMMdd") + @"', 
                                  MainCate = '" + strCboMain + @"',
                                  SmallCate = '" + cboSmall.Text + @"',
                                  Title = '" + txtTitle.Text.Replace("'", "��") + @"',
                                  Contents = '" + rtxtContents.Text.Replace("'", "��") + @"',
                                  File = '" + strFileQuery + @"',
                                  Contents_Rtf = '" + rtxtContents.Rtf.Replace("'", "��") + @"',
                                  Color = '" + (cboColor.Text == "���" ? "" : cboColor.Text) + @"'
                            WHERE Seq = " + mSeq;
            }

            sqlcmd = new SQLiteCommand(strSQL, conn);
            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();
                conn.Dispose();
                mFilePathList.Clear();

                //����ȸ
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
        /// ���� �����ϱ�
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
        /// ���� �����ϱ�
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
                    //�����ֱ�
                    DirectorySecurity dSecurity = Directory.GetAccessControl(strSourcePath);
                    dSecurity.AddAccessRule(new FileSystemAccessRule(System.Environment.UserDomainName + "\\" + System.Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                    Directory.SetAccessControl(strSourcePath, dSecurity);

                    File.Delete(strTargetDirPath + @"\" + strFileName);
                    File.Move(strSourcePath, strTargetDirPath + @"\" + strFileName);
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("���� �̵� ������ ���� ������ �����ϴ�.");
                    mOldFileList.Remove(strFileName + "��");
                    return false;
                }
            }

        }

        private void fntxtFileFill()
        {

            string strTargetDirPath = @".\FileList\" + dte.Value.ToString("yyyyMMdd");
            string strSourcePath = txtFile.Text;
            string strFileName = Path.GetFileName(txtFile.Text);
            string strMessage = string.Format("{0} ������ �̹� ����Ǿ� �ֽ��ϴ�. �ٲٽðڽ��ϱ�?", strFileName);

            if(!File.Exists(strSourcePath))
            {
                MessageBox.Show("������ ã�� �� �����ϴ�.");
                return;
            }

            if (File.Exists(strTargetDirPath + @"\" + strFileName))
            {
                if (MessageBox.Show(strMessage, "�˸�", MessageBoxButtons.YesNo) == DialogResult.No)
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
                MessageBox.Show("4�� �̻��� ÷�ε��� �ʽ��ϴ�.");
                return;
            }

            mFilePathList.Add(strSourcePath);
            txtFile.Text = "";
        }

        /// <summary>
        /// ���� ����� ��ư
        /// </summary>
        /// <param name="p_TextBox"></param>
        /// <param name="p_Label"></param>
        /// <param name="p_Button"></param>
        private void fnDelButton(TextBox p_TextBox, Label p_Label, Button p_Button)
        {
            if (MessageBox.Show("���� ���� �Ͻðڽ��ϱ�?", "���", MessageBoxButtons.YesNo) == DialogResult.No)
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
                    //�����ֱ�
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
                MessageBox.Show("���� �̸��̳� ��ΰ� �����ʽ��ϴ�.");
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
                
                //���⺯��
                if(p_boldOpt)
                    rtxtContents.SelectionFont = new Font(rtxtContents.SelectionFont.FontFamily, rtxtContents.SelectionFont.Size, rtxtContents.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold);

                else
                    rtxtContents.SelectionFont = new Font(rtxtContents.SelectionFont.FontFamily, rtxtContents.SelectionFont.Size + p_size, rtxtContents.SelectionFont.Bold ? FontStyle.Bold : FontStyle.Regular);
            }

            rtxtContents.Select(intSelectStart, intSelectLength);
        }

        /// <summary>
        /// ���ϰ�ο���.
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
                MessageBox.Show("�ش� ������ ������ �����ϴ��� Ȯ�ιٶ��ϴ�.");
            }
        }

        #endregion �Լ�_End

        #region �̺�Ʈ ����
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fnSave(mSeq))
            {
                MessageBox.Show("����Ǿ����ϴ�.");
                mDate = dte.Value.ToString("yyyyMMdd");
                mIsNew = false;
            }



        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (fnSave(mSeq))
            {
                MessageBox.Show("����Ǿ����ϴ�.");
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
            
            if (cboMain.Text.Equals("<��ü>"))
            {
                foreach (DataRow dr in dtCombo.Rows)
                {
                    if (!cboSmall.Items.Contains(dr["�Һз�"].ToString()))
                    {
                        cboSmall.Items.Add(dr["�Һз�"].ToString());
                    }
                }
            }


            foreach (DataRow dr in dtCombo.Rows)
            {
                if (dr["��з�"].ToString().Equals(cboMain.Text) && !cboSmall.Items.Contains(dr["�Һз�"].ToString()))
                {
                    cboSmall.Items.Add(dr["�Һз�"].ToString());
                }
            }
        }


        private void cboMain_Leave(object sender, EventArgs e)
        {
            cboSmall.Items.Clear();

            if (cboMain.Text.Equals("<��ü>"))
            {
                foreach (DataRow dr in dtCombo.Rows)
                {
                    if (!cboSmall.Items.Contains(dr["�Һз�"].ToString()))
                    {
                        cboSmall.Items.Add(dr["�Һз�"].ToString());
                    }
                }
            }


            foreach (DataRow dr in dtCombo.Rows)
            {
                if (dr["��з�"].ToString().Equals(cboMain.Text) && !cboSmall.Items.Contains(dr["�Һз�"].ToString()))
                {
                    cboSmall.Items.Add(dr["�Һз�"].ToString());
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData)) // ������ ó�� ��������
            {
                // ���⿡ ó���ڵ带 �ִ´�.
                if (keyData.Equals(Keys.F5))
                {
                    if (fnSave(mSeq))
                    {
                        MessageBox.Show("����Ǿ����ϴ�.");
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

        #endregion �̺�Ʈ ����_End
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