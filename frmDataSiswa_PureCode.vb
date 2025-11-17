Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmDataSiswa_PureCode
    Inherits Form

    Private pnlTop As Panel
    Private lblTitle As Label
    Private pnlForm As Panel
    Private lblNIS As Label
    Private txtNIS As TextBox
    Private lblNama As Label
    Private txtNama As TextBox
    Private lblKelas As Label
    Private cboKelas As ComboBox
    Private lblJK As Label
    Private rbLaki As RadioButton
    Private rbPerempuan As RadioButton
    Private lblAlamat As Label
    Private txtAlamat As TextBox
    Private lblTelepon As Label
    Private txtTelepon As TextBox
    Private pnlButtons As Panel
    Private btnSimpan As Button
    Private btnEdit As Button
    Private btnHapus As Button
    Private btnBatal As Button
    Private btnTutup As Button
    Private grpData As GroupBox
    Private dgvSiswa As DataGridView
    Private idSiswaSelected As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblTitle = New Label()
        Me.pnlForm = New Panel()
        Me.lblNIS = New Label()
        Me.txtNIS = New TextBox()
        Me.lblNama = New Label()
        Me.txtNama = New TextBox()
        Me.lblKelas = New Label()
        Me.cboKelas = New ComboBox()
        Me.lblJK = New Label()
        Me.rbLaki = New RadioButton()
        Me.rbPerempuan = New RadioButton()
        Me.lblAlamat = New Label()
        Me.txtAlamat = New TextBox()
        Me.lblTelepon = New Label()
        Me.txtTelepon = New TextBox()
        Me.pnlButtons = New Panel()
        Me.btnSimpan = New Button()
        Me.btnEdit = New Button()
        Me.btnHapus = New Button()
        Me.btnBatal = New Button()
        Me.btnTutup = New Button()
        Me.grpData = New GroupBox()
        Me.dgvSiswa = New DataGridView()

        ' pnlTop
        Me.pnlTop.BackColor = Color.FromArgb(76, 175, 80)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Location = New Point(330, 0)
        Me.pnlTop.Size = New Size(981, 60)

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(20, 15)
        Me.lblTitle.Text = "DATA SISWA"

        ' pnlForm
        Me.pnlForm.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlForm.Controls.Add(Me.lblNIS)
        Me.pnlForm.Controls.Add(Me.txtNIS)
        Me.pnlForm.Controls.Add(Me.lblNama)
        Me.pnlForm.Controls.Add(Me.txtNama)
        Me.pnlForm.Controls.Add(Me.lblKelas)
        Me.pnlForm.Controls.Add(Me.cboKelas)
        Me.pnlForm.Controls.Add(Me.lblJK)
        Me.pnlForm.Controls.Add(Me.rbLaki)
        Me.pnlForm.Controls.Add(Me.rbPerempuan)
        Me.pnlForm.Controls.Add(Me.lblAlamat)
        Me.pnlForm.Controls.Add(Me.txtAlamat)
        Me.pnlForm.Controls.Add(Me.lblTelepon)
        Me.pnlForm.Controls.Add(Me.txtTelepon)
        Me.pnlForm.Dock = DockStyle.Left
        Me.pnlForm.Location = New Point(0, 0)
        Me.pnlForm.Padding = New Padding(20)
        Me.pnlForm.Size = New Size(330, 583)

        ' lblNIS
        Me.lblNIS.AutoSize = True
        Me.lblNIS.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblNIS.Location = New Point(20, 20)
        Me.lblNIS.Text = "NIS:"

        ' txtNIS
        Me.txtNIS.Font = New Font("Segoe UI", 10.0)
        Me.txtNIS.Location = New Point(20, 45)
        Me.txtNIS.MaxLength = 20
        Me.txtNIS.Size = New Size(290, 30)

        ' lblNama
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblNama.Location = New Point(20, 85)
        Me.lblNama.Text = "Nama Siswa:"

        ' txtNama
        Me.txtNama.Font = New Font("Segoe UI", 10.0)
        Me.txtNama.Location = New Point(20, 110)
        Me.txtNama.MaxLength = 100
        Me.txtNama.Size = New Size(290, 30)

        ' lblKelas
        Me.lblKelas.AutoSize = True
        Me.lblKelas.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblKelas.Location = New Point(20, 150)
        Me.lblKelas.Text = "Kelas:"

        ' cboKelas
        Me.cboKelas.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboKelas.Font = New Font("Segoe UI", 10.0)
        Me.cboKelas.Items.AddRange(New Object() {"X IPA 1", "X IPA 2", "X IPS 1", "X IPS 2", "XI IPA 1", "XI IPA 2", "XI IPS 1", "XI IPS 2", "XII IPA 1", "XII IPA 2", "XII IPS 1", "XII IPS 2"})
        Me.cboKelas.Location = New Point(20, 175)
        Me.cboKelas.Size = New Size(290, 31)

        ' lblJK
        Me.lblJK.AutoSize = True
        Me.lblJK.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblJK.Location = New Point(20, 215)
        Me.lblJK.Text = "Jenis Kelamin:"

        ' rbLaki
        Me.rbLaki.AutoSize = True
        Me.rbLaki.Checked = True
        Me.rbLaki.Font = New Font("Segoe UI", 9.0)
        Me.rbLaki.Location = New Point(20, 240)
        Me.rbLaki.Text = "Laki-laki"

        ' rbPerempuan
        Me.rbPerempuan.AutoSize = True
        Me.rbPerempuan.Font = New Font("Segoe UI", 9.0)
        Me.rbPerempuan.Location = New Point(120, 240)
        Me.rbPerempuan.Text = "Perempuan"

        ' lblAlamat
        Me.lblAlamat.AutoSize = True
        Me.lblAlamat.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblAlamat.Location = New Point(20, 275)
        Me.lblAlamat.Text = "Alamat:"

        ' txtAlamat
        Me.txtAlamat.Font = New Font("Segoe UI", 10.0)
        Me.txtAlamat.Location = New Point(20, 300)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.ScrollBars = ScrollBars.Vertical
        Me.txtAlamat.Size = New Size(290, 60)

        ' lblTelepon
        Me.lblTelepon.AutoSize = True
        Me.lblTelepon.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblTelepon.Location = New Point(20, 370)
        Me.lblTelepon.Text = "Telepon:"

        ' txtTelepon
        Me.txtTelepon.Font = New Font("Segoe UI", 10.0)
        Me.txtTelepon.Location = New Point(20, 395)
        Me.txtTelepon.MaxLength = 15
        Me.txtTelepon.Size = New Size(290, 30)

        ' pnlButtons
        Me.pnlButtons.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlButtons.Controls.Add(Me.btnSimpan)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnHapus)
        Me.pnlButtons.Controls.Add(Me.btnBatal)
        Me.pnlButtons.Controls.Add(Me.btnTutup)
        Me.pnlButtons.Dock = DockStyle.Bottom
        Me.pnlButtons.Location = New Point(0, 583)
        Me.pnlButtons.Padding = New Padding(20, 15, 20, 15)
        Me.pnlButtons.Size = New Size(1311, 70)

        ' btnSimpan
        Me.btnSimpan.BackColor = Color.FromArgb(76, 175, 80)
        Me.btnSimpan.Cursor = Cursors.Hand
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatStyle = FlatStyle.Flat
        Me.btnSimpan.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnSimpan.ForeColor = Color.White
        Me.btnSimpan.Location = New Point(20, 15)
        Me.btnSimpan.Size = New Size(100, 40)
        Me.btnSimpan.Text = "SIMPAN"

        ' btnEdit
        Me.btnEdit.BackColor = Color.FromArgb(33, 150, 243)
        Me.btnEdit.Cursor = Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = FlatStyle.Flat
        Me.btnEdit.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnEdit.ForeColor = Color.White
        Me.btnEdit.Location = New Point(135, 15)
        Me.btnEdit.Size = New Size(100, 40)
        Me.btnEdit.Text = "EDIT"

        ' btnHapus
        Me.btnHapus.BackColor = Color.FromArgb(244, 67, 54)
        Me.btnHapus.Cursor = Cursors.Hand
        Me.btnHapus.FlatAppearance.BorderSize = 0
        Me.btnHapus.FlatStyle = FlatStyle.Flat
        Me.btnHapus.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnHapus.ForeColor = Color.White
        Me.btnHapus.Location = New Point(250, 15)
        Me.btnHapus.Size = New Size(100, 40)
        Me.btnHapus.Text = "HAPUS"

        ' btnBatal
        Me.btnBatal.BackColor = Color.FromArgb(158, 158, 158)
        Me.btnBatal.Cursor = Cursors.Hand
        Me.btnBatal.FlatAppearance.BorderSize = 0
        Me.btnBatal.FlatStyle = FlatStyle.Flat
        Me.btnBatal.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnBatal.ForeColor = Color.White
        Me.btnBatal.Location = New Point(365, 15)
        Me.btnBatal.Size = New Size(100, 40)
        Me.btnBatal.Text = "BATAL"

        ' btnTutup
        Me.btnTutup.BackColor = Color.FromArgb(96, 125, 139)
        Me.btnTutup.Cursor = Cursors.Hand
        Me.btnTutup.FlatAppearance.BorderSize = 0
        Me.btnTutup.FlatStyle = FlatStyle.Flat
        Me.btnTutup.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnTutup.ForeColor = Color.White
        Me.btnTutup.Location = New Point(480, 15)
        Me.btnTutup.Size = New Size(100, 40)
        Me.btnTutup.Text = "TUTUP"

        ' grpData
        Me.grpData.Controls.Add(Me.dgvSiswa)
        Me.grpData.Dock = DockStyle.Fill
        Me.grpData.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.grpData.Location = New Point(0, 0)
        Me.grpData.Padding = New Padding(10)
        Me.grpData.Size = New Size(1311, 653)
        Me.grpData.Text = "  DAFTAR SISWA  "

        ' dgvSiswa
        Me.dgvSiswa.AllowUserToAddRows = False
        Me.dgvSiswa.AllowUserToDeleteRows = False
        Me.dgvSiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSiswa.BackgroundColor = Color.White
        Me.dgvSiswa.BorderStyle = BorderStyle.None
        Me.dgvSiswa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80)
        Me.dgvSiswa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0)
        Me.dgvSiswa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvSiswa.ColumnHeadersHeight = 35
        Me.dgvSiswa.Dock = DockStyle.Fill
        Me.dgvSiswa.EnableHeadersVisualStyles = False
        Me.dgvSiswa.Font = New Font("Segoe UI", 9.0)
        Me.dgvSiswa.Location = New Point(10, 35)
        Me.dgvSiswa.Name = "dgvSiswa"
        Me.dgvSiswa.ReadOnly = True
        Me.dgvSiswa.RowHeadersVisible = False
        Me.dgvSiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvSiswa.Size = New Size(1291, 608)

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(1311, 653)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.grpData)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Data Siswa - Sistem Beasiswa SAW"

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmDataSiswa_Load
        AddHandler btnSimpan.Click, AddressOf btnSimpan_Click
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
        AddHandler btnHapus.Click, AddressOf btnHapus_Click
        AddHandler btnBatal.Click, AddressOf btnBatal_Click
        AddHandler btnTutup.Click, AddressOf btnTutup_Click
        AddHandler dgvSiswa.CellClick, AddressOf dgvSiswa_CellClick
    End Sub

    Private Sub frmDataSiswa_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadData()
        SetButtonState("Input")
    End Sub

    Private Sub LoadData()
        Try
            Dim query As String = "SELECT id_siswa AS ID, nis AS NIS, nama_siswa AS 'Nama Siswa', " &
                                 "kelas AS Kelas, jenis_kelamin AS JK, alamat AS Alamat, " &
                                 "telepon AS Telepon FROM tbl_siswa ORDER BY nama_siswa"

            Dim dt As DataTable = ExecuteQuery(query)
            dgvSiswa.DataSource = dt

            If dgvSiswa.Columns.Count > 0 Then
                dgvSiswa.Columns("ID").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error load data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetButtonState(ByVal state As String)
        If state = "Input" Then
            btnSimpan.Enabled = True
            btnEdit.Enabled = False
            btnHapus.Enabled = False
        ElseIf state = "Selected" Then
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
        End If
    End Sub

    Private Sub ClearForm()
        txtNIS.Clear()
        txtNama.Clear()
        cboKelas.SelectedIndex = -1
        rbLaki.Checked = True
        txtAlamat.Clear()
        txtTelepon.Clear()
        idSiswaSelected = 0
        SetButtonState("Input")
        txtNIS.Focus()
    End Sub

    Private Function ValidasiInput() As Boolean
        If String.IsNullOrWhiteSpace(txtNIS.Text) Then
            MessageBox.Show("NIS tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIS.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama siswa tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return False
        End If

        If cboKelas.SelectedIndex = -1 Then
            MessageBox.Show("Pilih kelas!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboKelas.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSimpan_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not ValidasiInput() Then Return

        Try
            Dim jk As String = If(rbLaki.Checked, "L", "P")

            Dim query As String = "INSERT INTO tbl_siswa (nis, nama_siswa, kelas, jenis_kelamin, alamat, telepon) " &
                                 "VALUES ('" & EscapeSQL(txtNIS.Text.Trim()) & "', '" & EscapeSQL(txtNama.Text.Trim()) & "', " &
                                 "'" & EscapeSQL(cboKelas.Text) & "', '" & jk & "', " &
                                 "'" & EscapeSQL(txtAlamat.Text.Trim()) & "', '" & EscapeSQL(txtTelepon.Text.Trim()) & "')"

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Data siswa berhasil disimpan!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
            End If

        Catch ex As Exception
            MessageBox.Show("Error simpan: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If idSiswaSelected = 0 Then
            MessageBox.Show("Pilih data yang akan diedit!", "Peringatan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidasiInput() Then Return

        Try
            Dim jk As String = If(rbLaki.Checked, "L", "P")

            Dim query As String = "UPDATE tbl_siswa SET " &
                                 "nis='" & EscapeSQL(txtNIS.Text.Trim()) & "', " &
                                 "nama_siswa='" & EscapeSQL(txtNama.Text.Trim()) & "', " &
                                 "kelas='" & EscapeSQL(cboKelas.Text) & "', " &
                                 "jenis_kelamin='" & jk & "', " &
                                 "alamat='" & EscapeSQL(txtAlamat.Text.Trim()) & "', " &
                                 "telepon='" & EscapeSQL(txtTelepon.Text.Trim()) & "' " &
                                 "WHERE id_siswa=" & idSiswaSelected

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Data siswa berhasil diupdate!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
            End If

        Catch ex As Exception
            MessageBox.Show("Error update: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapus_Click(ByVal sender As Object, ByVal e As EventArgs)
        If idSiswaSelected = 0 Then
            MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Yakin ingin menghapus data siswa ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                ' Hapus penilaian terkait dulu
                Dim queryDeletePenilaian As String = "DELETE FROM tbl_penilaian WHERE id_siswa=" & idSiswaSelected
                ExecuteNonQuery(queryDeletePenilaian)

                ' Hapus hasil SAW terkait
                Dim queryDeleteHasil As String = "DELETE FROM tbl_hasil_saw WHERE id_siswa=" & idSiswaSelected
                ExecuteNonQuery(queryDeleteHasil)

                ' Hapus siswa
                Dim query As String = "DELETE FROM tbl_siswa WHERE id_siswa=" & idSiswaSelected

                If ExecuteNonQuery(query) Then
                    MessageBox.Show("Data siswa berhasil dihapus!", "Sukses",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                    ClearForm()
                End If

            Catch ex As Exception
                MessageBox.Show("Error hapus: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnBatal_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearForm()
    End Sub

    Private Sub btnTutup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub dgvSiswa_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvSiswa.Rows(e.RowIndex)

                idSiswaSelected = Convert.ToInt32(row.Cells("ID").Value)
                txtNIS.Text = row.Cells("NIS").Value.ToString()
                txtNama.Text = row.Cells("Nama Siswa").Value.ToString()
                cboKelas.Text = row.Cells("Kelas").Value.ToString()

                Dim jk As String = row.Cells("JK").Value.ToString()
                If jk = "L" Then
                    rbLaki.Checked = True
                Else
                    rbPerempuan.Checked = True
                End If

                txtAlamat.Text = row.Cells("Alamat").Value.ToString()
                txtTelepon.Text = row.Cells("Telepon").Value.ToString()

                SetButtonState("Selected")

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function EscapeSQL(ByVal input As String) As String
        Return input.Replace("'", "''")
    End Function
End Class