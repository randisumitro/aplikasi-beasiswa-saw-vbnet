Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmMenuUtama_PureCode
    Inherits Form

    Private menuStrip As MenuStrip
    Private mnuMaster As ToolStripMenuItem
    Private mnuDataSiswa As ToolStripMenuItem
    Private mnuDataKriteria As ToolStripMenuItem
    Private mnuPenilaian As ToolStripMenuItem
    Private mnuProses As ToolStripMenuItem
    Private mnuLaporan As ToolStripMenuItem
    Private mnuKeluar As ToolStripMenuItem

    Private pnlHeader As Panel
    Private lblWelcome As Label
    Private lblLevel As Label

    Private pnlCards As Panel
    Private pnlCardSiswa As Panel
    Private lblCardSiswa As Label
    Private lblTotalSiswa As Label

    Private pnlCardKriteria As Panel
    Private lblCardKriteria As Label
    Private lblTotalKriteria As Label

    Private pnlCardPenilaian As Panel
    Private lblCardPenilaian As Label
    Private lblTotalPenilaian As Label

    Private grpSiswa As GroupBox
    Private dgvSiswa As DataGridView

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Menu Utama - Sistem Beasiswa SAW"
        Me.Size = New Size(1000, 650)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.FromArgb(245, 245, 245)

        ' Menu Strip
        menuStrip = New MenuStrip()
        menuStrip.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        menuStrip.BackColor = Color.White

        ' Menu Master
        mnuMaster = New ToolStripMenuItem("&Master")
        mnuDataSiswa = New ToolStripMenuItem("Data Siswa")
        mnuDataKriteria = New ToolStripMenuItem("Data Kriteria")
        mnuMaster.DropDownItems.Add(mnuDataSiswa)
        mnuMaster.DropDownItems.Add(mnuDataKriteria)

        ' Menu Penilaian
        mnuPenilaian = New ToolStripMenuItem("&Penilaian")

        ' Menu Proses
        mnuProses = New ToolStripMenuItem("P&roses SAW")

        ' Menu Laporan
        mnuLaporan = New ToolStripMenuItem("&Laporan")

        ' Menu Keluar
        mnuKeluar = New ToolStripMenuItem("&Keluar")

        menuStrip.Items.Add(mnuMaster)
        menuStrip.Items.Add(mnuPenilaian)
        menuStrip.Items.Add(mnuProses)
        menuStrip.Items.Add(mnuLaporan)
        menuStrip.Items.Add(mnuKeluar)

        Me.Controls.Add(menuStrip)
        Me.MainMenuStrip = menuStrip

        ' Panel Header
        pnlHeader = New Panel()
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 60
        pnlHeader.BackColor = Color.FromArgb(33, 150, 243)
        pnlHeader.Padding = New Padding(20, 10, 20, 10)

        lblWelcome = New Label()
        lblWelcome.Text = "Selamat Datang, " & SessionUserName
        lblWelcome.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblWelcome.ForeColor = Color.White
        lblWelcome.AutoSize = True
        lblWelcome.Location = New Point(20, 10)
        pnlHeader.Controls.Add(lblWelcome)

        lblLevel = New Label()
        lblLevel.Text = "Level: " & SessionUserLevel
        lblLevel.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblLevel.ForeColor = Color.White
        lblLevel.AutoSize = True
        lblLevel.Location = New Point(20, 35)
        pnlHeader.Controls.Add(lblLevel)

        Me.Controls.Add(pnlHeader)

        ' Panel Cards
        pnlCards = New Panel()
        pnlCards.Dock = DockStyle.Top
        pnlCards.Height = 150
        pnlCards.BackColor = Color.White
        pnlCards.Padding = New Padding(20, 20, 20, 20)

        ' Card Siswa
        pnlCardSiswa = New Panel()
        pnlCardSiswa.Size = New Size(250, 110)
        pnlCardSiswa.Location = New Point(30, 20)
        pnlCardSiswa.BackColor = Color.FromArgb(76, 175, 80)
        pnlCardSiswa.Cursor = Cursors.Hand

        lblCardSiswa = New Label()
        lblCardSiswa.Text = "DATA SISWA"
        lblCardSiswa.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblCardSiswa.ForeColor = Color.White
        lblCardSiswa.Size = New Size(250, 30)
        lblCardSiswa.Location = New Point(0, 10)
        lblCardSiswa.TextAlign = ContentAlignment.MiddleCenter
        lblCardSiswa.Cursor = Cursors.Hand
        pnlCardSiswa.Controls.Add(lblCardSiswa)

        lblTotalSiswa = New Label()
        lblTotalSiswa.Text = "0"
        lblTotalSiswa.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblTotalSiswa.ForeColor = Color.White
        lblTotalSiswa.Size = New Size(250, 70)
        lblTotalSiswa.Location = New Point(0, 40)
        lblTotalSiswa.TextAlign = ContentAlignment.MiddleCenter
        lblTotalSiswa.Cursor = Cursors.Hand
        pnlCardSiswa.Controls.Add(lblTotalSiswa)

        pnlCards.Controls.Add(pnlCardSiswa)

        ' Card Kriteria
        pnlCardKriteria = New Panel()
        pnlCardKriteria.Size = New Size(250, 110)
        pnlCardKriteria.Location = New Point(300, 20)
        pnlCardKriteria.BackColor = Color.FromArgb(255, 152, 0)
        pnlCardKriteria.Cursor = Cursors.Hand

        lblCardKriteria = New Label()
        lblCardKriteria.Text = "DATA KRITERIA"
        lblCardKriteria.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblCardKriteria.ForeColor = Color.White
        lblCardKriteria.Size = New Size(250, 30)
        lblCardKriteria.Location = New Point(0, 10)
        lblCardKriteria.TextAlign = ContentAlignment.MiddleCenter
        lblCardKriteria.Cursor = Cursors.Hand
        pnlCardKriteria.Controls.Add(lblCardKriteria)

        lblTotalKriteria = New Label()
        lblTotalKriteria.Text = "0"
        lblTotalKriteria.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblTotalKriteria.ForeColor = Color.White
        lblTotalKriteria.Size = New Size(250, 70)
        lblTotalKriteria.Location = New Point(0, 40)
        lblTotalKriteria.TextAlign = ContentAlignment.MiddleCenter
        lblTotalKriteria.Cursor = Cursors.Hand
        pnlCardKriteria.Controls.Add(lblTotalKriteria)

        pnlCards.Controls.Add(pnlCardKriteria)

        ' Card Penilaian
        pnlCardPenilaian = New Panel()
        pnlCardPenilaian.Size = New Size(250, 110)
        pnlCardPenilaian.Location = New Point(570, 20)
        pnlCardPenilaian.BackColor = Color.FromArgb(156, 39, 176)
        pnlCardPenilaian.Cursor = Cursors.Hand

        lblCardPenilaian = New Label()
        lblCardPenilaian.Text = "PENILAIAN"
        lblCardPenilaian.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblCardPenilaian.ForeColor = Color.White
        lblCardPenilaian.Size = New Size(250, 30)
        lblCardPenilaian.Location = New Point(0, 10)
        lblCardPenilaian.TextAlign = ContentAlignment.MiddleCenter
        lblCardPenilaian.Cursor = Cursors.Hand
        pnlCardPenilaian.Controls.Add(lblCardPenilaian)

        lblTotalPenilaian = New Label()
        lblTotalPenilaian.Text = "0"
        lblTotalPenilaian.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblTotalPenilaian.ForeColor = Color.White
        lblTotalPenilaian.Size = New Size(250, 70)
        lblTotalPenilaian.Location = New Point(0, 40)
        lblTotalPenilaian.TextAlign = ContentAlignment.MiddleCenter
        lblTotalPenilaian.Cursor = Cursors.Hand
        pnlCardPenilaian.Controls.Add(lblTotalPenilaian)

        pnlCards.Controls.Add(pnlCardPenilaian)

        Me.Controls.Add(pnlCards)

        ' GroupBox Data Siswa
        grpSiswa = New GroupBox()
        grpSiswa.Text = "  DAFTAR SISWA  "
        grpSiswa.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        grpSiswa.Dock = DockStyle.Fill
        grpSiswa.Padding = New Padding(10)

        ' DataGridView
        dgvSiswa = New DataGridView()
        dgvSiswa.Dock = DockStyle.Fill
        dgvSiswa.BackgroundColor = Color.White
        dgvSiswa.BorderStyle = BorderStyle.None
        dgvSiswa.AllowUserToAddRows = False
        dgvSiswa.AllowUserToDeleteRows = False
        dgvSiswa.ReadOnly = True
        dgvSiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSiswa.RowHeadersVisible = False
        dgvSiswa.Font = New Font("Segoe UI", 9, FontStyle.Regular)

        ' Header style
        dgvSiswa.EnableHeadersVisualStyles = False
        dgvSiswa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243)
        dgvSiswa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvSiswa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvSiswa.ColumnHeadersHeight = 35

        ' Alternating row
        dgvSiswa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)

        grpSiswa.Controls.Add(dgvSiswa)
        Me.Controls.Add(grpSiswa)

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmMenuUtama_Load
        AddHandler mnuDataSiswa.Click, AddressOf mnuDataSiswa_Click
        AddHandler mnuDataKriteria.Click, AddressOf mnuDataKriteria_Click
        AddHandler mnuPenilaian.Click, AddressOf mnuPenilaian_Click
        AddHandler mnuProses.Click, AddressOf mnuProses_Click
        AddHandler mnuLaporan.Click, AddressOf mnuLaporan_Click
        AddHandler mnuKeluar.Click, AddressOf mnuKeluar_Click
        AddHandler pnlCardSiswa.Click, AddressOf pnlCardSiswa_Click
        AddHandler lblCardSiswa.Click, AddressOf pnlCardSiswa_Click
        AddHandler lblTotalSiswa.Click, AddressOf pnlCardSiswa_Click
        AddHandler pnlCardKriteria.Click, AddressOf pnlCardKriteria_Click
        AddHandler lblCardKriteria.Click, AddressOf pnlCardKriteria_Click
        AddHandler lblTotalKriteria.Click, AddressOf pnlCardKriteria_Click
        AddHandler pnlCardPenilaian.Click, AddressOf pnlCardPenilaian_Click
        AddHandler lblCardPenilaian.Click, AddressOf pnlCardPenilaian_Click
        AddHandler lblTotalPenilaian.Click, AddressOf pnlCardPenilaian_Click
    End Sub

    Private Sub frmMenuUtama_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadStatistik()
        LoadDataSiswa()
    End Sub

    Private Sub LoadStatistik()
        Try
            ' Total siswa
            Dim dtSiswa As DataTable = ExecuteQuery("SELECT COUNT(*) as total FROM tbl_siswa")
            lblTotalSiswa.Text = dtSiswa.Rows(0)("total").ToString()

            ' Total kriteria
            Dim dtKriteria As DataTable = ExecuteQuery("SELECT COUNT(*) as total FROM tbl_kriteria")
            lblTotalKriteria.Text = dtKriteria.Rows(0)("total").ToString()

            ' Total penilaian
            Dim dtPenilaian As DataTable = ExecuteQuery("SELECT COUNT(DISTINCT id_siswa) as total FROM tbl_penilaian")
            If dtPenilaian.Rows.Count > 0 Then
                lblTotalPenilaian.Text = dtPenilaian.Rows(0)("total").ToString()
            Else
                lblTotalPenilaian.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error load statistik: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDataSiswa()
        Try
            Dim query As String = "SELECT nis AS NIS, nama_siswa AS 'Nama Siswa', " &
                                 "kelas AS Kelas, jenis_kelamin AS JK " &
                                 "FROM tbl_siswa ORDER BY nama_siswa"

            Dim dt As DataTable = ExecuteQuery(query)
            dgvSiswa.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error load data siswa: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuDataSiswa_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmDataSiswa_PureCode()
        frm.ShowDialog()
        LoadStatistik()
        LoadDataSiswa()
    End Sub

    Private Sub mnuDataKriteria_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmDataKriteria_PureCode()
        frm.ShowDialog()
        LoadStatistik()
    End Sub

    Private Sub mnuPenilaian_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmPenilaian_PureCode()
        frm.ShowDialog()
        LoadStatistik()
    End Sub

    Private Sub mnuProses_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmProsesSAW_PureCode()
        frm.ShowDialog()
    End Sub

    Private Sub mnuLaporan_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim count As Integer = GetTableCount("tbl_hasil_saw")
        If count = 0 Then
            MessageBox.Show("Belum ada hasil perhitungan!" & vbCrLf &
                          "Silakan proses SAW terlebih dahulu di menu Proses SAW.",
                          "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim frm As New frmLaporan_PureCode()
        frm.ShowDialog()
    End Sub

    Private Sub mnuKeluar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim result As DialogResult = MessageBox.Show(
            "Yakin ingin logout?",
            "Konfirmasi Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim frmLog As New frmLogin_PureCode()
            frmLog.Show()
            Me.Close()
        End If
    End Sub

    Private Sub pnlCardSiswa_Click(ByVal sender As Object, ByVal e As EventArgs)
        mnuDataSiswa.PerformClick()
    End Sub

    Private Sub pnlCardKriteria_Click(ByVal sender As Object, ByVal e As EventArgs)
        mnuDataKriteria.PerformClick()
    End Sub

    Private Sub pnlCardPenilaian_Click(ByVal sender As Object, ByVal e As EventArgs)
        mnuPenilaian.PerformClick()
    End Sub
End Class