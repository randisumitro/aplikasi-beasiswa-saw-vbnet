Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmPenilaian_PureCode
    Inherits Form

    Private pnlTop As Panel
    Private lblTitle As Label
    Private pnlLeft As Panel
    Private lblSiswa As Label
    Private cboSiswa As ComboBox
    Private btnPilihSiswa As Button
    Private grpInfoSiswa As GroupBox
    Private lblInfoNIS As Label
    Private lblInfoNama As Label
    Private lblInfoKelas As Label
    Private pnlButtons As Panel
    Private btnSimpan As Button
    Private btnBatal As Button
    Private btnTutup As Button
    Private grpPenilaian As GroupBox
    Private flpKriteria As FlowLayoutPanel
    Private dictTextBoxNilai As New Dictionary(Of Integer, TextBox)
    Private selectedSiswaID As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblTitle = New Label()
        Me.pnlLeft = New Panel()
        Me.lblSiswa = New Label()
        Me.cboSiswa = New ComboBox()
        Me.btnPilihSiswa = New Button()
        Me.grpInfoSiswa = New GroupBox()
        Me.lblInfoNIS = New Label()
        Me.lblInfoNama = New Label()
        Me.lblInfoKelas = New Label()
        Me.pnlButtons = New Panel()
        Me.btnSimpan = New Button()
        Me.btnBatal = New Button()
        Me.btnTutup = New Button()
        Me.grpPenilaian = New GroupBox()
        Me.flpKriteria = New FlowLayoutPanel()

        ' pnlTop
        Me.pnlTop.BackColor = Color.FromArgb(156, 39, 176)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Location = New Point(330, 0)
        Me.pnlTop.Size = New Size(970, 60)

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(20, 15)
        Me.lblTitle.Text = "PENILAIAN SISWA"

        ' pnlLeft
        Me.pnlLeft.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlLeft.Controls.Add(Me.lblSiswa)
        Me.pnlLeft.Controls.Add(Me.cboSiswa)
        Me.pnlLeft.Controls.Add(Me.btnPilihSiswa)
        Me.pnlLeft.Controls.Add(Me.grpInfoSiswa)
        Me.pnlLeft.Dock = DockStyle.Left
        Me.pnlLeft.Location = New Point(0, 0)
        Me.pnlLeft.Padding = New Padding(20)
        Me.pnlLeft.Size = New Size(330, 583)

        ' lblSiswa
        Me.lblSiswa.AutoSize = True
        Me.lblSiswa.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.lblSiswa.Location = New Point(20, 20)
        Me.lblSiswa.Text = "Pilih Siswa:"

        ' cboSiswa
        Me.cboSiswa.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboSiswa.Font = New Font("Segoe UI", 10.0)
        Me.cboSiswa.Location = New Point(20, 50)
        Me.cboSiswa.Size = New Size(290, 31)

        ' btnPilihSiswa
        Me.btnPilihSiswa.BackColor = Color.FromArgb(156, 39, 176)
        Me.btnPilihSiswa.Cursor = Cursors.Hand
        Me.btnPilihSiswa.FlatAppearance.BorderSize = 0
        Me.btnPilihSiswa.FlatStyle = FlatStyle.Flat
        Me.btnPilihSiswa.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        Me.btnPilihSiswa.ForeColor = Color.White
        Me.btnPilihSiswa.Location = New Point(20, 95)
        Me.btnPilihSiswa.Size = New Size(290, 40)
        Me.btnPilihSiswa.Text = "TAMPILKAN FORM PENILAIAN"

        ' grpInfoSiswa
        Me.grpInfoSiswa.Controls.Add(Me.lblInfoNIS)
        Me.grpInfoSiswa.Controls.Add(Me.lblInfoNama)
        Me.grpInfoSiswa.Controls.Add(Me.lblInfoKelas)
        Me.grpInfoSiswa.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.grpInfoSiswa.Location = New Point(20, 150)
        Me.grpInfoSiswa.Padding = New Padding(15)
        Me.grpInfoSiswa.Size = New Size(290, 150)
        Me.grpInfoSiswa.Text = "  Info Siswa  "

        ' lblInfoNIS
        Me.lblInfoNIS.Font = New Font("Segoe UI", 9.0)
        Me.lblInfoNIS.Location = New Point(15, 35)
        Me.lblInfoNIS.Size = New Size(260, 25)
        Me.lblInfoNIS.Text = "NIS: -"

        ' lblInfoNama
        Me.lblInfoNama.Font = New Font("Segoe UI", 9.0)
        Me.lblInfoNama.Location = New Point(15, 65)
        Me.lblInfoNama.Size = New Size(260, 25)
        Me.lblInfoNama.Text = "Nama: -"

        ' lblInfoKelas
        Me.lblInfoKelas.Font = New Font("Segoe UI", 9.0)
        Me.lblInfoKelas.Location = New Point(15, 95)
        Me.lblInfoKelas.Size = New Size(260, 25)
        Me.lblInfoKelas.Text = "Kelas: -"

        ' pnlButtons
        Me.pnlButtons.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlButtons.Controls.Add(Me.btnSimpan)
        Me.pnlButtons.Controls.Add(Me.btnBatal)
        Me.pnlButtons.Controls.Add(Me.btnTutup)
        Me.pnlButtons.Dock = DockStyle.Bottom
        Me.pnlButtons.Location = New Point(0, 583)
        Me.pnlButtons.Padding = New Padding(20, 15, 20, 15)
        Me.pnlButtons.Size = New Size(1300, 70)

        ' btnSimpan
        Me.btnSimpan.BackColor = Color.FromArgb(76, 175, 80)
        Me.btnSimpan.Cursor = Cursors.Hand
        Me.btnSimpan.Enabled = False
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatStyle = FlatStyle.Flat
        Me.btnSimpan.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnSimpan.ForeColor = Color.White
        Me.btnSimpan.Location = New Point(20, 15)
        Me.btnSimpan.Size = New Size(150, 40)
        Me.btnSimpan.Text = "SIMPAN"

        ' btnBatal
        Me.btnBatal.BackColor = Color.FromArgb(158, 158, 158)
        Me.btnBatal.Cursor = Cursors.Hand
        Me.btnBatal.FlatAppearance.BorderSize = 0
        Me.btnBatal.FlatStyle = FlatStyle.Flat
        Me.btnBatal.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnBatal.ForeColor = Color.White
        Me.btnBatal.Location = New Point(185, 15)
        Me.btnBatal.Size = New Size(150, 40)
        Me.btnBatal.Text = "BATAL"

        ' btnTutup
        Me.btnTutup.BackColor = Color.FromArgb(96, 125, 139)
        Me.btnTutup.Cursor = Cursors.Hand
        Me.btnTutup.FlatAppearance.BorderSize = 0
        Me.btnTutup.FlatStyle = FlatStyle.Flat
        Me.btnTutup.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnTutup.ForeColor = Color.White
        Me.btnTutup.Location = New Point(350, 15)
        Me.btnTutup.Size = New Size(150, 40)
        Me.btnTutup.Text = "TUTUP"

        ' grpPenilaian
        Me.grpPenilaian.Controls.Add(Me.flpKriteria)
        Me.grpPenilaian.Dock = DockStyle.Fill
        Me.grpPenilaian.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.grpPenilaian.Location = New Point(0, 0)
        Me.grpPenilaian.Padding = New Padding(20)
        Me.grpPenilaian.Size = New Size(1300, 653)
        Me.grpPenilaian.Text = "  FORM PENILAIAN KRITERIA  "

        ' flpKriteria
        Me.flpKriteria.AutoScroll = True
        Me.flpKriteria.BackColor = Color.White
        Me.flpKriteria.Dock = DockStyle.Fill
        Me.flpKriteria.FlowDirection = FlowDirection.TopDown
        Me.flpKriteria.Location = New Point(20, 45)
        Me.flpKriteria.Padding = New Padding(10)
        Me.flpKriteria.Size = New Size(1260, 588)
        Me.flpKriteria.WrapContents = False

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(1300, 653)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.grpPenilaian)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Penilaian Siswa - Sistem Beasiswa SAW"

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmPenilaian_Load
        AddHandler btnPilihSiswa.Click, AddressOf btnPilihSiswa_Click
        AddHandler btnSimpan.Click, AddressOf btnSimpan_Click
        AddHandler btnBatal.Click, AddressOf btnBatal_Click
        AddHandler btnTutup.Click, AddressOf btnTutup_Click
    End Sub

    Private Sub frmPenilaian_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadComboSiswa()
    End Sub

    Private Sub LoadComboSiswa()
        Try
            Dim query As String = "SELECT id_siswa, CONCAT(nis, ' - ', nama_siswa) AS display " &
                                 "FROM tbl_siswa ORDER BY nama_siswa"

            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cboSiswa.DataSource = dt
                cboSiswa.DisplayMember = "display"
                cboSiswa.ValueMember = "id_siswa"
                cboSiswa.SelectedIndex = -1
            Else
                MessageBox.Show("Belum ada data siswa!" & vbCrLf &
                              "Silakan tambahkan data siswa terlebih dahulu.",
                              "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error load siswa: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPilihSiswa_Click(ByVal sender As Object, ByVal e As EventArgs)
        If cboSiswa.SelectedIndex = -1 Then
            MessageBox.Show("Pilih siswa terlebih dahulu!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        selectedSiswaID = Convert.ToInt32(cboSiswa.SelectedValue)
        LoadInfoSiswa()
        LoadFormKriteria()
        btnSimpan.Enabled = True
    End Sub

    Private Sub LoadInfoSiswa()
        Try
            Dim query As String = "SELECT nis, nama_siswa, kelas FROM tbl_siswa WHERE id_siswa=" & selectedSiswaID
            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                lblInfoNIS.Text = "NIS: " & row("nis").ToString()
                lblInfoNama.Text = "Nama: " & row("nama_siswa").ToString()
                lblInfoKelas.Text = "Kelas: " & row("kelas").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error load info siswa: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadFormKriteria()
        Try
            flpKriteria.Controls.Clear()
            dictTextBoxNilai.Clear()

            Dim query As String = "SELECT id_kriteria, kode_kriteria, nama_kriteria, sifat, keterangan " &
                                 "FROM tbl_kriteria ORDER BY kode_kriteria"

            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim idKriteria As Integer = Convert.ToInt32(row("id_kriteria"))
                    Dim kodeKriteria As String = row("kode_kriteria").ToString()
                    Dim namaKriteria As String = row("nama_kriteria").ToString()
                    Dim sifat As String = row("sifat").ToString()
                    Dim keterangan As String = row("keterangan").ToString()

                    ' Create panel untuk setiap kriteria
                    Dim pnlKriteria As New Panel()
                    pnlKriteria.Size = New Size(1220, 120)
                    pnlKriteria.BorderStyle = BorderStyle.FixedSingle
                    pnlKriteria.BackColor = Color.FromArgb(250, 250, 250)
                    pnlKriteria.Margin = New Padding(10)

                    ' Label kode + nama
                    Dim lblNama As New Label()
                    lblNama.Text = kodeKriteria & " - " & namaKriteria
                    lblNama.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
                    lblNama.Location = New Point(15, 10)
                    lblNama.Size = New Size(600, 25)
                    pnlKriteria.Controls.Add(lblNama)

                    ' Label sifat
                    Dim lblSifat As New Label()
                    lblSifat.Text = "Sifat: " & sifat
                    lblSifat.Font = New Font("Segoe UI", 9.0, FontStyle.Italic)
                    lblSifat.ForeColor = If(sifat = "Benefit", Color.Green, Color.Red)
                    lblSifat.Location = New Point(15, 40)
                    lblSifat.Size = New Size(200, 20)
                    pnlKriteria.Controls.Add(lblSifat)

                    ' Label keterangan
                    Dim lblKet As New Label()
                    lblKet.Text = keterangan
                    lblKet.Font = New Font("Segoe UI", 8.5)
                    lblKet.ForeColor = Color.Gray
                    lblKet.Location = New Point(15, 65)
                    lblKet.Size = New Size(900, 40)
                    pnlKriteria.Controls.Add(lblKet)

                    ' Label "Nilai:"
                    Dim lblNilai As New Label()
                    lblNilai.Text = "Nilai:"
                    lblNilai.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
                    lblNilai.Location = New Point(950, 15)
                    lblNilai.Size = New Size(50, 25)
                    pnlKriteria.Controls.Add(lblNilai)

                    ' TextBox nilai
                    Dim txtNilai As New TextBox()
                    txtNilai.Font = New Font("Segoe UI", 12.0)
                    txtNilai.Location = New Point(1010, 10)
                    txtNilai.Size = New Size(180, 35)
                    txtNilai.MaxLength = 10
                    txtNilai.TextAlign = HorizontalAlignment.Center
                    pnlKriteria.Controls.Add(txtNilai)

                    ' Simpan ke dictionary
                    dictTextBoxNilai.Add(idKriteria, txtNilai)

                    ' Load nilai jika sudah ada
                    LoadNilaiExisting(idKriteria, txtNilai)

                    flpKriteria.Controls.Add(pnlKriteria)
                Next
            Else
                MessageBox.Show("Belum ada data kriteria!" & vbCrLf &
                              "Silakan tambahkan kriteria terlebih dahulu.",
                              "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error load form kriteria: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadNilaiExisting(ByVal idKriteria As Integer, ByVal txtNilai As TextBox)
        Try
            Dim query As String = "SELECT nilai FROM tbl_penilaian " &
                                 "WHERE id_siswa=" & selectedSiswaID & " AND id_kriteria=" & idKriteria

            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                txtNilai.Text = dt.Rows(0)("nilai").ToString()
            End If

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As Object, ByVal e As EventArgs)
        If selectedSiswaID = 0 Then
            MessageBox.Show("Pilih siswa terlebih dahulu!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validasi semua input
        For Each kvp In dictTextBoxNilai
            If String.IsNullOrWhiteSpace(kvp.Value.Text) Then
                MessageBox.Show("Semua nilai harus diisi!", "Validasi",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kvp.Value.Focus()
                Return
            End If

            Dim nilai As Double
            If Not Double.TryParse(kvp.Value.Text, nilai) Then
                MessageBox.Show("Nilai harus berupa angka!", "Validasi",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kvp.Value.Focus()
                Return
            End If

            If nilai < 0 Then
                MessageBox.Show("Nilai tidak boleh negatif!", "Validasi",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kvp.Value.Focus()
                Return
            End If
        Next

        ' Simpan ke database
        Try
            OpenConnection()

            For Each kvp In dictTextBoxNilai
                Dim idKriteria As Integer = kvp.Key
                Dim nilai As String = kvp.Value.Text.Trim().Replace(",", ".")

                ' Check if exists
                Dim queryCheck As String = "SELECT COUNT(*) FROM tbl_penilaian " &
                                          "WHERE id_siswa=" & selectedSiswaID & " AND id_kriteria=" & idKriteria

                cmd = New MySqlCommand(queryCheck, conn)
                Dim exists As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If exists > 0 Then
                    ' Update
                    Dim queryUpdate As String = "UPDATE tbl_penilaian SET nilai=" & nilai & " " &
                                               "WHERE id_siswa=" & selectedSiswaID & " AND id_kriteria=" & idKriteria
                    cmd = New MySqlCommand(queryUpdate, conn)
                    cmd.ExecuteNonQuery()
                Else
                    ' Insert
                    Dim queryInsert As String = "INSERT INTO tbl_penilaian (id_siswa, id_kriteria, nilai) " &
                                               "VALUES (" & selectedSiswaID & ", " & idKriteria & ", " & nilai & ")"
                    cmd = New MySqlCommand(queryInsert, conn)
                    cmd.ExecuteNonQuery()
                End If
            Next

            CloseConnection()

            MessageBox.Show("Penilaian berhasil disimpan!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            CloseConnection()
            MessageBox.Show("Error simpan: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(ByVal sender As Object, ByVal e As EventArgs)
        flpKriteria.Controls.Clear()
        dictTextBoxNilai.Clear()
        lblInfoNIS.Text = "NIS: -"
        lblInfoNama.Text = "Nama: -"
        lblInfoKelas.Text = "Kelas: -"
        cboSiswa.SelectedIndex = -1
        selectedSiswaID = 0
        btnSimpan.Enabled = False
    End Sub

    Private Sub btnTutup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class