Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmDataKriteria_PureCode
    Inherits Form

    Private pnlTop As Panel
    Private lblTitle As Label
    Private pnlForm As Panel
    Private lblKode As Label
    Private txtKode As TextBox
    Private lblNama As Label
    Private txtNama As TextBox
    Private lblBobot As Label
    Private txtBobot As TextBox
    Private lblSifat As Label
    Private cboSifat As ComboBox
    Private lblKeterangan As Label
    Private txtKeterangan As TextBox
    Private lblInfo As Label
    Private pnlButtons As Panel
    Private btnSimpan As Button
    Private btnEdit As Button
    Private btnHapus As Button
    Private btnBatal As Button
    Private btnTutup As Button
    Private grpData As GroupBox
    Private dgvKriteria As DataGridView
    Private idKriteriaSelected As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblTitle = New Label()
        Me.pnlForm = New Panel()
        Me.lblKode = New Label()
        Me.txtKode = New TextBox()
        Me.lblNama = New Label()
        Me.txtNama = New TextBox()
        Me.lblBobot = New Label()
        Me.txtBobot = New TextBox()
        Me.lblSifat = New Label()
        Me.cboSifat = New ComboBox()
        Me.lblKeterangan = New Label()
        Me.txtKeterangan = New TextBox()
        Me.lblInfo = New Label()
        Me.pnlButtons = New Panel()
        Me.btnSimpan = New Button()
        Me.btnEdit = New Button()
        Me.btnHapus = New Button()
        Me.btnBatal = New Button()
        Me.btnTutup = New Button()
        Me.grpData = New GroupBox()
        Me.dgvKriteria = New DataGridView()

        ' pnlTop
        Me.pnlTop.BackColor = Color.FromArgb(255, 152, 0)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Location = New Point(330, 0)
        Me.pnlTop.Size = New Size(981, 60)

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(20, 15)
        Me.lblTitle.Text = "DATA KRITERIA"

        ' pnlForm
        Me.pnlForm.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlForm.Controls.Add(Me.lblKode)
        Me.pnlForm.Controls.Add(Me.txtKode)
        Me.pnlForm.Controls.Add(Me.lblNama)
        Me.pnlForm.Controls.Add(Me.txtNama)
        Me.pnlForm.Controls.Add(Me.lblBobot)
        Me.pnlForm.Controls.Add(Me.txtBobot)
        Me.pnlForm.Controls.Add(Me.lblSifat)
        Me.pnlForm.Controls.Add(Me.cboSifat)
        Me.pnlForm.Controls.Add(Me.lblKeterangan)
        Me.pnlForm.Controls.Add(Me.txtKeterangan)
        Me.pnlForm.Controls.Add(Me.lblInfo)
        Me.pnlForm.Dock = DockStyle.Left
        Me.pnlForm.Location = New Point(0, 0)
        Me.pnlForm.Padding = New Padding(20)
        Me.pnlForm.Size = New Size(330, 583)

        ' lblKode
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblKode.Location = New Point(20, 20)
        Me.lblKode.Text = "Kode Kriteria:"

        ' txtKode
        Me.txtKode.Font = New Font("Segoe UI", 10.0)
        Me.txtKode.Location = New Point(20, 45)
        Me.txtKode.MaxLength = 10
        Me.txtKode.Size = New Size(290, 30)

        ' lblNama
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblNama.Location = New Point(20, 85)
        Me.lblNama.Text = "Nama Kriteria:"

        ' txtNama
        Me.txtNama.Font = New Font("Segoe UI", 10.0)
        Me.txtNama.Location = New Point(20, 110)
        Me.txtNama.MaxLength = 100
        Me.txtNama.Size = New Size(290, 30)

        ' lblBobot
        Me.lblBobot.AutoSize = True
        Me.lblBobot.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblBobot.Location = New Point(20, 150)
        Me.lblBobot.Text = "Bobot (0.0-1.0):"

        ' txtBobot
        Me.txtBobot.Font = New Font("Segoe UI", 10.0)
        Me.txtBobot.Location = New Point(20, 175)
        Me.txtBobot.MaxLength = 10
        Me.txtBobot.Size = New Size(290, 30)

        ' lblSifat
        Me.lblSifat.AutoSize = True
        Me.lblSifat.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblSifat.Location = New Point(20, 215)
        Me.lblSifat.Text = "Sifat Kriteria:"

        ' cboSifat
        Me.cboSifat.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboSifat.Font = New Font("Segoe UI", 10.0)
        Me.cboSifat.Items.AddRange(New Object() {"Benefit", "Cost"})
        Me.cboSifat.Location = New Point(20, 240)
        Me.cboSifat.Size = New Size(290, 31)

        ' lblKeterangan
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.lblKeterangan.Location = New Point(20, 280)
        Me.lblKeterangan.Text = "Keterangan:"

        ' txtKeterangan
        Me.txtKeterangan.Font = New Font("Segoe UI", 10.0)
        Me.txtKeterangan.Location = New Point(20, 305)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.ScrollBars = ScrollBars.Vertical
        Me.txtKeterangan.Size = New Size(290, 80)

        ' lblInfo
        Me.lblInfo.BackColor = Color.FromArgb(255, 243, 224)
        Me.lblInfo.BorderStyle = BorderStyle.FixedSingle
        Me.lblInfo.Font = New Font("Segoe UI", 8.0)
        Me.lblInfo.ForeColor = Color.FromArgb(230, 81, 0)
        Me.lblInfo.Location = New Point(20, 400)
        Me.lblInfo.Padding = New Padding(10)
        Me.lblInfo.Size = New Size(290, 120)
        Me.lblInfo.Text = "INFO KRITERIA:" & vbCrLf & "• Kode: C1, C2, C3, dst" & vbCrLf & "• Bobot: Total harus = 1.0" & vbCrLf & "• Benefit: Semakin tinggi nilai semakin baik" & vbCrLf & "• Cost: Semakin rendah nilai semakin baik"

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
        Me.btnSimpan.BackColor = Color.FromArgb(255, 152, 0)
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
        Me.grpData.Controls.Add(Me.dgvKriteria)
        Me.grpData.Dock = DockStyle.Fill
        Me.grpData.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.grpData.Location = New Point(0, 0)
        Me.grpData.Padding = New Padding(10)
        Me.grpData.Size = New Size(1311, 653)
        Me.grpData.Text = "  DAFTAR KRITERIA PENILAIAN  "

        ' dgvKriteria
        Me.dgvKriteria.AllowUserToAddRows = False
        Me.dgvKriteria.AllowUserToDeleteRows = False
        Me.dgvKriteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvKriteria.BackgroundColor = Color.White
        Me.dgvKriteria.BorderStyle = BorderStyle.None
        Me.dgvKriteria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0)
        Me.dgvKriteria.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0)
        Me.dgvKriteria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvKriteria.ColumnHeadersHeight = 35
        Me.dgvKriteria.Dock = DockStyle.Fill
        Me.dgvKriteria.EnableHeadersVisualStyles = False
        Me.dgvKriteria.Font = New Font("Segoe UI", 9.0)
        Me.dgvKriteria.Location = New Point(10, 35)
        Me.dgvKriteria.Name = "dgvKriteria"
        Me.dgvKriteria.ReadOnly = True
        Me.dgvKriteria.RowHeadersVisible = False
        Me.dgvKriteria.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvKriteria.Size = New Size(1291, 608)

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(1311, 653)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.grpData)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Data Kriteria - Sistem Beasiswa SAW"

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmDataKriteria_Load
        AddHandler btnSimpan.Click, AddressOf btnSimpan_Click
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
        AddHandler btnHapus.Click, AddressOf btnHapus_Click
        AddHandler btnBatal.Click, AddressOf btnBatal_Click
        AddHandler btnTutup.Click, AddressOf btnTutup_Click
        AddHandler dgvKriteria.CellClick, AddressOf dgvKriteria_CellClick
    End Sub

    Private Sub frmDataKriteria_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadData()
        SetButtonState("Input")
        HitungTotalBobot()
    End Sub

    Private Sub LoadData()
        Try
            Dim query As String = "SELECT id_kriteria AS ID, kode_kriteria AS 'Kode', " &
                                 "nama_kriteria AS 'Nama Kriteria', bobot AS 'Bobot', " &
                                 "sifat AS 'Sifat', keterangan AS 'Keterangan' " &
                                 "FROM tbl_kriteria ORDER BY kode_kriteria"

            Dim dt As DataTable = ExecuteQuery(query)
            dgvKriteria.DataSource = dt

            If dgvKriteria.Columns.Count > 0 Then
                dgvKriteria.Columns("ID").Visible = False
            End If

            If dgvKriteria.Columns.Contains("Bobot") Then
                dgvKriteria.Columns("Bobot").DefaultCellStyle.Format = "0.00"
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
        txtKode.Clear()
        txtNama.Clear()
        txtBobot.Clear()
        cboSifat.SelectedIndex = -1
        txtKeterangan.Clear()
        idKriteriaSelected = 0
        SetButtonState("Input")
        txtKode.Focus()
    End Sub

    Private Sub HitungTotalBobot()
        Try
            Dim query As String = "SELECT IFNULL(SUM(bobot), 0) AS total FROM tbl_kriteria"
            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim totalBobot As Double = Convert.ToDouble(dt.Rows(0)("total"))
                Me.Text = "Data Kriteria - Total Bobot: " & totalBobot.ToString("0.00") & " / 1.00"
            End If

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Function ValidasiInput() As Boolean
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode kriteria tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKode.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama kriteria tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtBobot.Text) Then
            MessageBox.Show("Bobot tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBobot.Focus()
            Return False
        End If

        Dim bobot As Double
        If Not Double.TryParse(txtBobot.Text, bobot) Then
            MessageBox.Show("Bobot harus berupa angka!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBobot.Focus()
            Return False
        End If

        If bobot <= 0 OrElse bobot > 1 Then
            MessageBox.Show("Bobot harus antara 0.0 - 1.0!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBobot.Focus()
            Return False
        End If

        If cboSifat.SelectedIndex = -1 Then
            MessageBox.Show("Pilih sifat kriteria!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSifat.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSimpan_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not ValidasiInput() Then Return

        Try
            Dim bobotBaru As Double = Convert.ToDouble(txtBobot.Text)

            ' Cek total bobot
            Dim queryTotal As String = "SELECT IFNULL(SUM(bobot), 0) AS total FROM tbl_kriteria"
            Dim dtTotal As DataTable = ExecuteQuery(queryTotal)
            Dim totalBobotSekarang As Double = Convert.ToDouble(dtTotal.Rows(0)("total"))
            Dim totalBobotAkan As Double = totalBobotSekarang + bobotBaru

            If totalBobotAkan > 1 Then
                MessageBox.Show("Total bobot akan melebihi 1.0!" & vbCrLf & vbCrLf &
                              "Total bobot sekarang: " & totalBobotSekarang.ToString("0.00") & vbCrLf &
                              "Bobot yang akan ditambah: " & bobotBaru.ToString("0.00") & vbCrLf &
                              "Total bobot akan menjadi: " & totalBobotAkan.ToString("0.00") & vbCrLf & vbCrLf &
                              "Silakan kurangi bobot atau edit kriteria yang sudah ada.",
                              "Peringatan Bobot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Insert data
            Dim query As String = "INSERT INTO tbl_kriteria (kode_kriteria, nama_kriteria, bobot, sifat, keterangan) " &
                                 "VALUES ('" & EscapeSQL(txtKode.Text.Trim()) & "', '" & EscapeSQL(txtNama.Text.Trim()) & "', " &
                                 bobotBaru.ToString("0.00").Replace(",", ".") & ", '" & cboSifat.Text & "', " &
                                 "'" & EscapeSQL(txtKeterangan.Text.Trim()) & "')"

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Data kriteria berhasil disimpan!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
                HitungTotalBobot()
            End If

        Catch ex As Exception
            MessageBox.Show("Error simpan: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If idKriteriaSelected = 0 Then
            MessageBox.Show("Pilih data yang akan diedit!", "Peringatan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidasiInput() Then Return

        Try
            Dim bobotBaru As Double = Convert.ToDouble(txtBobot.Text)

            ' Cek total bobot (exclude kriteria yang sedang diedit)
            Dim queryTotal As String = "SELECT IFNULL(SUM(bobot), 0) AS total FROM tbl_kriteria " &
                                      "WHERE id_kriteria <> " & idKriteriaSelected
            Dim dtTotal As DataTable = ExecuteQuery(queryTotal)
            Dim totalBobotLain As Double = Convert.ToDouble(dtTotal.Rows(0)("total"))
            Dim totalBobotAkan As Double = totalBobotLain + bobotBaru

            If totalBobotAkan > 1 Then
                MessageBox.Show("Total bobot akan melebihi 1.0!" & vbCrLf & vbCrLf &
                              "Total bobot kriteria lain: " & totalBobotLain.ToString("0.00") & vbCrLf &
                              "Bobot baru: " & bobotBaru.ToString("0.00") & vbCrLf &
                              "Total akan menjadi: " & totalBobotAkan.ToString("0.00"),
                              "Peringatan Bobot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update data
            Dim query As String = "UPDATE tbl_kriteria SET " &
                                 "kode_kriteria='" & EscapeSQL(txtKode.Text.Trim()) & "', " &
                                 "nama_kriteria='" & EscapeSQL(txtNama.Text.Trim()) & "', " &
                                 "bobot=" & bobotBaru.ToString("0.00").Replace(",", ".") & ", " &
                                 "sifat='" & cboSifat.Text & "', " &
                                 "keterangan='" & EscapeSQL(txtKeterangan.Text.Trim()) & "' " &
                                 "WHERE id_kriteria=" & idKriteriaSelected

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Data kriteria berhasil diupdate!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearForm()
                HitungTotalBobot()
            End If

        Catch ex As Exception
            MessageBox.Show("Error update: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapus_Click(ByVal sender As Object, ByVal e As EventArgs)
        If idKriteriaSelected = 0 Then
            MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Yakin ingin menghapus kriteria ini?" & vbCrLf & vbCrLf &
            "PERHATIAN: Menghapus kriteria akan menghapus semua penilaian yang terkait!",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                ' Hapus penilaian terkait dulu
                Dim queryDeletePenilaian As String = "DELETE FROM tbl_penilaian WHERE id_kriteria=" & idKriteriaSelected
                ExecuteNonQuery(queryDeletePenilaian)

                ' Hapus kriteria
                Dim query As String = "DELETE FROM tbl_kriteria WHERE id_kriteria=" & idKriteriaSelected

                If ExecuteNonQuery(query) Then
                    MessageBox.Show("Data kriteria berhasil dihapus!", "Sukses",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                    ClearForm()
                    HitungTotalBobot()
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

    Private Sub dgvKriteria_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvKriteria.Rows(e.RowIndex)

                idKriteriaSelected = Convert.ToInt32(row.Cells("ID").Value)
                txtKode.Text = row.Cells("Kode").Value.ToString()
                txtNama.Text = row.Cells("Nama Kriteria").Value.ToString()
                txtBobot.Text = Convert.ToDouble(row.Cells("Bobot").Value).ToString("0.00")
                cboSifat.Text = row.Cells("Sifat").Value.ToString()
                txtKeterangan.Text = row.Cells("Keterangan").Value.ToString()

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