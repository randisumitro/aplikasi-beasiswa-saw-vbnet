Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class frmLaporan_PureCode
    Inherits Form

    Private pnlTop As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private lblTanggal As Label
    Private pnlKeterangan As Panel
    Private lblKetTitle As Label
    Private lblKetMetode As Label
    Private lblKetTotal As Label
    Private pnlButtons As Panel
    Private btnRefresh As Button
    Private btnPrint As Button
    Private btnTutup As Button
    Private grpRanking As GroupBox
    Private dgvRanking As DataGridView

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblTitle = New Label()
        Me.lblSubtitle = New Label()
        Me.lblTanggal = New Label()
        Me.pnlKeterangan = New Panel()
        Me.lblKetTitle = New Label()
        Me.lblKetMetode = New Label()
        Me.lblKetTotal = New Label()
        Me.pnlButtons = New Panel()
        Me.btnRefresh = New Button()
        Me.btnPrint = New Button()
        Me.btnTutup = New Button()
        Me.grpRanking = New GroupBox()
        Me.dgvRanking = New DataGridView()

        ' pnlTop
        Me.pnlTop.BackColor = Color.FromArgb(33, 150, 243)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.lblSubtitle)
        Me.pnlTop.Controls.Add(Me.lblTanggal)
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Location = New Point(0, 0)
        Me.pnlTop.Size = New Size(1100, 100)

        ' lblTitle
        Me.lblTitle.Font = New Font("Segoe UI", 18.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(0, 15)
        Me.lblTitle.Size = New Size(1100, 40)
        Me.lblTitle.Text = "LAPORAN HASIL SELEKSI BEASISWA"
        Me.lblTitle.TextAlign = ContentAlignment.MiddleCenter

        ' lblSubtitle
        Me.lblSubtitle.Font = New Font("Segoe UI", 11.0)
        Me.lblSubtitle.ForeColor = Color.White
        Me.lblSubtitle.Location = New Point(0, 55)
        Me.lblSubtitle.Size = New Size(1100, 25)
        Me.lblSubtitle.Text = "Metode SAW (Simple Additive Weighting)"
        Me.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter

        ' lblTanggal
        Me.lblTanggal.Font = New Font("Segoe UI", 9.0)
        Me.lblTanggal.ForeColor = Color.White
        Me.lblTanggal.Location = New Point(0, 75)
        Me.lblTanggal.Size = New Size(1100, 20)
        Me.lblTanggal.Text = "Tanggal: " & DateTime.Now.ToString("dddd, dd MMMM yyyy")
        Me.lblTanggal.TextAlign = ContentAlignment.MiddleCenter

        ' pnlKeterangan
        Me.pnlKeterangan.BackColor = Color.FromArgb(227, 242, 253)
        Me.pnlKeterangan.BorderStyle = BorderStyle.FixedSingle
        Me.pnlKeterangan.Controls.Add(Me.lblKetTitle)
        Me.pnlKeterangan.Controls.Add(Me.lblKetMetode)
        Me.pnlKeterangan.Controls.Add(Me.lblKetTotal)
        Me.pnlKeterangan.Dock = DockStyle.Top
        Me.pnlKeterangan.Location = New Point(0, 100)
        Me.pnlKeterangan.Padding = New Padding(20, 15, 20, 15)
        Me.pnlKeterangan.Size = New Size(1100, 100)

        ' lblKetTitle
        Me.lblKetTitle.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.lblKetTitle.Location = New Point(20, 15)
        Me.lblKetTitle.Size = New Size(200, 25)
        Me.lblKetTitle.Text = "INFORMASI:"

        ' lblKetMetode
        Me.lblKetMetode.Font = New Font("Segoe UI", 9.5)
        Me.lblKetMetode.Location = New Point(20, 45)
        Me.lblKetMetode.Size = New Size(1050, 20)
        Me.lblKetMetode.Text = "Metode SAW menghitung nilai preferensi berdasarkan normalisasi matriks keputusan dan bobot kriteria"

        ' lblKetTotal
        Me.lblKetTotal.Font = New Font("Segoe UI", 9.5, FontStyle.Bold)
        Me.lblKetTotal.Location = New Point(20, 70)
        Me.lblKetTotal.Size = New Size(500, 20)
        Me.lblKetTotal.Text = "Total Siswa yang Diranking: 0 siswa"

        ' pnlButtons
        Me.pnlButtons.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.btnPrint)
        Me.pnlButtons.Controls.Add(Me.btnTutup)
        Me.pnlButtons.Dock = DockStyle.Bottom
        Me.pnlButtons.Location = New Point(0, 580)
        Me.pnlButtons.Padding = New Padding(20, 15, 20, 15)
        Me.pnlButtons.Size = New Size(1100, 70)

        ' btnRefresh
        Me.btnRefresh.BackColor = Color.FromArgb(76, 175, 80)
        Me.btnRefresh.Cursor = Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = FlatStyle.Flat
        Me.btnRefresh.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnRefresh.ForeColor = Color.White
        Me.btnRefresh.Location = New Point(20, 15)
        Me.btnRefresh.Size = New Size(150, 40)
        Me.btnRefresh.Text = "REFRESH"

        ' btnPrint
        Me.btnPrint.BackColor = Color.FromArgb(255, 152, 0)
        Me.btnPrint.Cursor = Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = FlatStyle.Flat
        Me.btnPrint.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnPrint.ForeColor = Color.White
        Me.btnPrint.Location = New Point(185, 15)
        Me.btnPrint.Size = New Size(150, 40)
        Me.btnPrint.Text = "PRINT"

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

        ' grpRanking
        Me.grpRanking.Controls.Add(Me.dgvRanking)
        Me.grpRanking.Dock = DockStyle.Fill
        Me.grpRanking.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.grpRanking.Location = New Point(0, 200)
        Me.grpRanking.Padding = New Padding(15)
        Me.grpRanking.Size = New Size(1100, 380)
        Me.grpRanking.Text = "  DAFTAR PENERIMA BEASISWA (URUT BERDASARKAN RANKING)  "

        ' dgvRanking
        Me.dgvRanking.AllowUserToAddRows = False
        Me.dgvRanking.AllowUserToDeleteRows = False
        Me.dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRanking.BackgroundColor = Color.White
        Me.dgvRanking.BorderStyle = BorderStyle.None
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80)
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvRanking.ColumnHeadersHeight = 40
        Me.dgvRanking.Dock = DockStyle.Fill
        Me.dgvRanking.EnableHeadersVisualStyles = False
        Me.dgvRanking.Font = New Font("Segoe UI", 10.0)
        Me.dgvRanking.Location = New Point(15, 40)
        Me.dgvRanking.Name = "dgvRanking"
        Me.dgvRanking.ReadOnly = True
        Me.dgvRanking.RowHeadersVisible = False
        Me.dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvRanking.Size = New Size(1070, 325)

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(1100, 650)
        Me.Controls.Add(Me.grpRanking)
        Me.Controls.Add(Me.pnlKeterangan)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlButtons)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Laporan Hasil Ranking - Sistem Beasiswa SAW"

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmLaporan_Load
        AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
        AddHandler btnPrint.Click, AddressOf btnPrint_Click
        AddHandler btnTutup.Click, AddressOf btnTutup_Click
        AddHandler dgvRanking.CellFormatting, AddressOf dgvRanking_CellFormatting
    End Sub

    Private Sub frmLaporan_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadLaporanRanking()
    End Sub

    Private Sub LoadLaporanRanking()
        Try
            Dim query As String = "SELECT " &
                                 "h.ranking AS 'Ranking', " &
                                 "s.nis AS 'NIS', " &
                                 "s.nama_siswa AS 'Nama Siswa', " &
                                 "s.kelas AS 'Kelas', " &
                                 "s.jenis_kelamin AS 'JK', " &
                                 "h.nilai_preferensi AS 'Nilai Preferensi', " &
                                 "CASE " &
                                 "  WHEN h.ranking <= 3 THEN 'LOLOS' " &
                                 "  ELSE 'TIDAK LOLOS' " &
                                 "END AS 'Status' " &
                                 "FROM tbl_hasil_saw h " &
                                 "INNER JOIN tbl_siswa s ON h.id_siswa = s.id_siswa " &
                                 "ORDER BY h.ranking ASC"

            Dim dt As DataTable = ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                dgvRanking.DataSource = dt

                ' Format kolom
                With dgvRanking
                    .Columns("Ranking").Width = 80
                    .Columns("Ranking").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Ranking").DefaultCellStyle.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)

                    .Columns("NIS").Width = 100
                    .Columns("JK").Width = 50
                    .Columns("JK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("Nilai Preferensi").Width = 150
                    .Columns("Nilai Preferensi").DefaultCellStyle.Format = "0.0000"
                    .Columns("Nilai Preferensi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("Status").Width = 120
                    .Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Status").DefaultCellStyle.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
                End With

                ' Update info
                lblKetTotal.Text = "Total Siswa yang Diranking: " & dt.Rows.Count & " siswa"

            Else
                MessageBox.Show("Belum ada hasil ranking!" & vbCrLf &
                              "Silakan proses SAW terlebih dahulu.",
                              "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error load laporan: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRanking_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
        Try
            If dgvRanking.Columns(e.ColumnIndex).Name = "Status" Then
                If e.Value IsNot Nothing Then
                    Dim status As String = e.Value.ToString()

                    If status = "LOLOS" Then
                        e.CellStyle.BackColor = Color.LightGreen
                        e.CellStyle.ForeColor = Color.DarkGreen
                    ElseIf status = "TIDAK LOLOS" Then
                        e.CellStyle.BackColor = Color.LightCoral
                        e.CellStyle.ForeColor = Color.DarkRed
                    End If
                End If
            End If

            ' Highlight ranking 1-3
            If dgvRanking.Columns(e.ColumnIndex).Name = "Ranking" Then
                If e.Value IsNot Nothing Then
                    Dim ranking As Integer = Convert.ToInt32(e.Value)

                    If ranking = 1 Then
                        e.CellStyle.BackColor = Color.Gold
                        e.CellStyle.ForeColor = Color.DarkGoldenrod
                    ElseIf ranking = 2 Then
                        e.CellStyle.BackColor = Color.Silver
                        e.CellStyle.ForeColor = Color.DimGray
                    ElseIf ranking = 3 Then
                        e.CellStyle.BackColor = Color.SandyBrown
                        e.CellStyle.ForeColor = Color.SaddleBrown
                    End If
                End If
            End If

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
        LoadLaporanRanking()
        MessageBox.Show("Data laporan berhasil diperbarui!", "Info",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim printDocument As New PrintDocument()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage

            Dim printDialog As New PrintDialog()
            printDialog.Document = printDocument

            If printDialog.ShowDialog() = DialogResult.OK Then
                printDocument.Print()
                MessageBox.Show("Laporan berhasil dikirim ke printer!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error print: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Try
            Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
            Dim fontHeader As New Font("Arial", 12, FontStyle.Bold)
            Dim fontNormal As New Font("Arial", 10)
            Dim brush As New SolidBrush(Color.Black)

            ' Judul
            e.Graphics.DrawString("LAPORAN HASIL SELEKSI BEASISWA", fontTitle, brush, 100, 50)
            e.Graphics.DrawString("Metode SAW (Simple Additive Weighting)", fontNormal, brush, 100, 80)
            e.Graphics.DrawString("Tanggal: " & DateTime.Now.ToString("dd/MM/yyyy"), fontNormal, brush, 100, 100)

            ' Header tabel
            Dim yPos As Integer = 150
            e.Graphics.DrawString("Ranking", fontHeader, brush, 100, yPos)
            e.Graphics.DrawString("NIS", fontHeader, brush, 180, yPos)
            e.Graphics.DrawString("Nama Siswa", fontHeader, brush, 280, yPos)
            e.Graphics.DrawString("Kelas", fontHeader, brush, 480, yPos)
            e.Graphics.DrawString("Nilai", fontHeader, brush, 580, yPos)
            e.Graphics.DrawString("Status", fontHeader, brush, 680, yPos)

            yPos += 30

            ' Data
            For Each row As DataGridViewRow In dgvRanking.Rows
                If yPos > 700 Then
                    e.HasMorePages = True
                    Return
                End If

                e.Graphics.DrawString(row.Cells("Ranking").Value.ToString(), fontNormal, brush, 100, yPos)
                e.Graphics.DrawString(row.Cells("NIS").Value.ToString(), fontNormal, brush, 180, yPos)
                e.Graphics.DrawString(row.Cells("Nama Siswa").Value.ToString(), fontNormal, brush, 280, yPos)
                e.Graphics.DrawString(row.Cells("Kelas").Value.ToString(), fontNormal, brush, 480, yPos)
                e.Graphics.DrawString(row.Cells("Nilai Preferensi").Value.ToString(), fontNormal, brush, 580, yPos)
                e.Graphics.DrawString(row.Cells("Status").Value.ToString(), fontNormal, brush, 680, yPos)

                yPos += 20
            Next

        Catch ex As Exception
            MessageBox.Show("Error mencetak: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTutup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class