Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmProsesSAW_PureCode
    Inherits Form

    Private pnlTop As Panel
    Private lblTitle As Label
    Private pnlInfo As Panel
    Private lblInfoTitle As Label
    Private lblInfoSiswa As Label
    Private lblInfoKriteria As Label
    Private lblInfoPenilaian As Label
    Private pnlButtons As Panel
    Private btnProses As Button
    Private btnReset As Button
    Private btnLaporan As Button
    Private btnTutup As Button
    Private tabControl As TabControl
    Private tabMatriks As TabPage
    Private tabNormalisasi As TabPage
    Private tabRanking As TabPage
    Private dgvMatriks As DataGridView
    Private dgvNormalisasi As DataGridView
    Private dgvRanking As DataGridView

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblTitle = New Label()
        Me.pnlInfo = New Panel()
        Me.lblInfoTitle = New Label()
        Me.lblInfoSiswa = New Label()
        Me.lblInfoKriteria = New Label()
        Me.lblInfoPenilaian = New Label()
        Me.pnlButtons = New Panel()
        Me.btnProses = New Button()
        Me.btnReset = New Button()
        Me.btnLaporan = New Button()
        Me.btnTutup = New Button()
        Me.tabControl = New TabControl()
        Me.tabMatriks = New TabPage()
        Me.tabNormalisasi = New TabPage()
        Me.tabRanking = New TabPage()
        Me.dgvMatriks = New DataGridView()
        Me.dgvNormalisasi = New DataGridView()
        Me.dgvRanking = New DataGridView()

        ' pnlTop
        Me.pnlTop.BackColor = Color.FromArgb(3, 169, 244)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Location = New Point(0, 0)
        Me.pnlTop.Size = New Size(1300, 60)
        Me.pnlTop.TabIndex = 0

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New Size(450, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "PROSES PERHITUNGAN SAW"

        ' pnlInfo
        Me.pnlInfo.BackColor = Color.FromArgb(232, 245, 253)
        Me.pnlInfo.BorderStyle = BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.lblInfoTitle)
        Me.pnlInfo.Controls.Add(Me.lblInfoSiswa)
        Me.pnlInfo.Controls.Add(Me.lblInfoKriteria)
        Me.pnlInfo.Controls.Add(Me.lblInfoPenilaian)
        Me.pnlInfo.Dock = DockStyle.Top
        Me.pnlInfo.Location = New Point(0, 60)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Padding = New Padding(20, 15, 20, 15)
        Me.pnlInfo.Size = New Size(1300, 100)
        Me.pnlInfo.TabIndex = 1

        ' lblInfoTitle
        Me.lblInfoTitle.Font = New Font("Segoe UI", 11.0, FontStyle.Bold)
        Me.lblInfoTitle.Location = New Point(20, 15)
        Me.lblInfoTitle.Name = "lblInfoTitle"
        Me.lblInfoTitle.Size = New Size(200, 25)
        Me.lblInfoTitle.TabIndex = 0
        Me.lblInfoTitle.Text = "INFO DATA:"

        ' lblInfoSiswa
        Me.lblInfoSiswa.Font = New Font("Segoe UI", 10.0)
        Me.lblInfoSiswa.Location = New Point(20, 45)
        Me.lblInfoSiswa.Name = "lblInfoSiswa"
        Me.lblInfoSiswa.Size = New Size(300, 25)
        Me.lblInfoSiswa.TabIndex = 1
        Me.lblInfoSiswa.Text = "Total Siswa: 0"

        ' lblInfoKriteria
        Me.lblInfoKriteria.Font = New Font("Segoe UI", 10.0)
        Me.lblInfoKriteria.Location = New Point(350, 45)
        Me.lblInfoKriteria.Name = "lblInfoKriteria"
        Me.lblInfoKriteria.Size = New Size(300, 25)
        Me.lblInfoKriteria.TabIndex = 2
        Me.lblInfoKriteria.Text = "Total Kriteria: 0"

        ' lblInfoPenilaian
        Me.lblInfoPenilaian.Font = New Font("Segoe UI", 10.0)
        Me.lblInfoPenilaian.Location = New Point(680, 45)
        Me.lblInfoPenilaian.Name = "lblInfoPenilaian"
        Me.lblInfoPenilaian.Size = New Size(400, 25)
        Me.lblInfoPenilaian.TabIndex = 3
        Me.lblInfoPenilaian.Text = "Siswa yang Sudah Dinilai: 0"

        ' pnlButtons
        Me.pnlButtons.BackColor = Color.FromArgb(250, 250, 250)
        Me.pnlButtons.Controls.Add(Me.btnProses)
        Me.pnlButtons.Controls.Add(Me.btnReset)
        Me.pnlButtons.Controls.Add(Me.btnLaporan)
        Me.pnlButtons.Controls.Add(Me.btnTutup)
        Me.pnlButtons.Dock = DockStyle.Bottom
        Me.pnlButtons.Location = New Point(0, 603)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Padding = New Padding(20, 15, 20, 15)
        Me.pnlButtons.Size = New Size(1300, 70)
        Me.pnlButtons.TabIndex = 2

        ' btnProses
        Me.btnProses.BackColor = Color.FromArgb(76, 175, 80)
        Me.btnProses.Cursor = Cursors.Hand
        Me.btnProses.FlatAppearance.BorderSize = 0
        Me.btnProses.FlatStyle = FlatStyle.Flat
        Me.btnProses.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnProses.ForeColor = Color.White
        Me.btnProses.Location = New Point(20, 15)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New Size(180, 40)
        Me.btnProses.TabIndex = 0
        Me.btnProses.Text = "PROSES SAW"
        Me.btnProses.UseVisualStyleBackColor = False

        ' btnReset
        Me.btnReset.BackColor = Color.FromArgb(255, 152, 0)
        Me.btnReset.Cursor = Cursors.Hand
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = FlatStyle.Flat
        Me.btnReset.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnReset.ForeColor = Color.White
        Me.btnReset.Location = New Point(215, 15)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New Size(180, 40)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "RESET HASIL"
        Me.btnReset.UseVisualStyleBackColor = False

        ' btnLaporan
        Me.btnLaporan.BackColor = Color.FromArgb(33, 150, 243)
        Me.btnLaporan.Cursor = Cursors.Hand
        Me.btnLaporan.FlatAppearance.BorderSize = 0
        Me.btnLaporan.FlatStyle = FlatStyle.Flat
        Me.btnLaporan.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnLaporan.ForeColor = Color.White
        Me.btnLaporan.Location = New Point(410, 15)
        Me.btnLaporan.Name = "btnLaporan"
        Me.btnLaporan.Size = New Size(180, 40)
        Me.btnLaporan.TabIndex = 2
        Me.btnLaporan.Text = "LIHAT LAPORAN"
        Me.btnLaporan.UseVisualStyleBackColor = False

        ' btnTutup
        Me.btnTutup.BackColor = Color.FromArgb(96, 125, 139)
        Me.btnTutup.Cursor = Cursors.Hand
        Me.btnTutup.FlatAppearance.BorderSize = 0
        Me.btnTutup.FlatStyle = FlatStyle.Flat
        Me.btnTutup.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnTutup.ForeColor = Color.White
        Me.btnTutup.Location = New Point(605, 15)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New Size(150, 40)
        Me.btnTutup.TabIndex = 3
        Me.btnTutup.Text = "TUTUP"
        Me.btnTutup.UseVisualStyleBackColor = False

        ' tabControl
        Me.tabControl.Controls.Add(Me.tabMatriks)
        Me.tabControl.Controls.Add(Me.tabNormalisasi)
        Me.tabControl.Controls.Add(Me.tabRanking)
        Me.tabControl.Dock = DockStyle.Fill
        Me.tabControl.Font = New Font("Segoe UI", 10.0)
        Me.tabControl.Location = New Point(0, 160)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New Size(1300, 443)
        Me.tabControl.TabIndex = 3

        ' tabMatriks
        Me.tabMatriks.Controls.Add(Me.dgvMatriks)
        Me.tabMatriks.Location = New Point(4, 32)
        Me.tabMatriks.Name = "tabMatriks"
        Me.tabMatriks.Padding = New Padding(10)
        Me.tabMatriks.Size = New Size(1292, 407)
        Me.tabMatriks.TabIndex = 0
        Me.tabMatriks.Text = "Matriks Keputusan"
        Me.tabMatriks.UseVisualStyleBackColor = True

        ' dgvMatriks
        Me.dgvMatriks.AllowUserToAddRows = False
        Me.dgvMatriks.AllowUserToDeleteRows = False
        Me.dgvMatriks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMatriks.BackgroundColor = Color.White
        Me.dgvMatriks.BorderStyle = BorderStyle.None
        Me.dgvMatriks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(3, 169, 244)
        Me.dgvMatriks.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.dgvMatriks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvMatriks.ColumnHeadersHeight = 35
        Me.dgvMatriks.Dock = DockStyle.Fill
        Me.dgvMatriks.EnableHeadersVisualStyles = False
        Me.dgvMatriks.Location = New Point(10, 10)
        Me.dgvMatriks.Name = "dgvMatriks"
        Me.dgvMatriks.ReadOnly = True
        Me.dgvMatriks.RowHeadersVisible = False
        Me.dgvMatriks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvMatriks.Size = New Size(1272, 387)
        Me.dgvMatriks.TabIndex = 0

        ' tabNormalisasi
        Me.tabNormalisasi.Controls.Add(Me.dgvNormalisasi)
        Me.tabNormalisasi.Location = New Point(4, 32)
        Me.tabNormalisasi.Name = "tabNormalisasi"
        Me.tabNormalisasi.Padding = New Padding(10)
        Me.tabNormalisasi.Size = New Size(1292, 407)
        Me.tabNormalisasi.TabIndex = 1
        Me.tabNormalisasi.Text = "Matriks Normalisasi"
        Me.tabNormalisasi.UseVisualStyleBackColor = True

        ' dgvNormalisasi
        Me.dgvNormalisasi.AllowUserToAddRows = False
        Me.dgvNormalisasi.AllowUserToDeleteRows = False
        Me.dgvNormalisasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvNormalisasi.BackgroundColor = Color.White
        Me.dgvNormalisasi.BorderStyle = BorderStyle.None
        Me.dgvNormalisasi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0)
        Me.dgvNormalisasi.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.dgvNormalisasi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvNormalisasi.ColumnHeadersHeight = 35
        Me.dgvNormalisasi.Dock = DockStyle.Fill
        Me.dgvNormalisasi.EnableHeadersVisualStyles = False
        Me.dgvNormalisasi.Location = New Point(10, 10)
        Me.dgvNormalisasi.Name = "dgvNormalisasi"
        Me.dgvNormalisasi.ReadOnly = True
        Me.dgvNormalisasi.RowHeadersVisible = False
        Me.dgvNormalisasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvNormalisasi.Size = New Size(1272, 387)
        Me.dgvNormalisasi.TabIndex = 0

        ' tabRanking
        Me.tabRanking.Controls.Add(Me.dgvRanking)
        Me.tabRanking.Location = New Point(4, 32)
        Me.tabRanking.Name = "tabRanking"
        Me.tabRanking.Padding = New Padding(10)
        Me.tabRanking.Size = New Size(1292, 407)
        Me.tabRanking.TabIndex = 2
        Me.tabRanking.Text = "Hasil Ranking"
        Me.tabRanking.UseVisualStyleBackColor = True

        ' dgvRanking
        Me.dgvRanking.AllowUserToAddRows = False
        Me.dgvRanking.AllowUserToDeleteRows = False
        Me.dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRanking.BackgroundColor = Color.White
        Me.dgvRanking.BorderStyle = BorderStyle.None
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80)
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.dgvRanking.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvRanking.ColumnHeadersHeight = 35
        Me.dgvRanking.Dock = DockStyle.Fill
        Me.dgvRanking.EnableHeadersVisualStyles = False
        Me.dgvRanking.Location = New Point(10, 10)
        Me.dgvRanking.Name = "dgvRanking"
        Me.dgvRanking.ReadOnly = True
        Me.dgvRanking.RowHeadersVisible = False
        Me.dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvRanking.Size = New Size(1272, 387)
        Me.dgvRanking.TabIndex = 0

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(1300, 673)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlButtons)
        Me.Name = "frmProsesSAW_PureCode"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Proses SAW - Sistem Beasiswa"
        Me.WindowState = FormWindowState.Maximized

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmProsesSAW_Load
        AddHandler btnProses.Click, AddressOf btnProses_Click
        AddHandler btnReset.Click, AddressOf btnReset_Click
        AddHandler btnLaporan.Click, AddressOf btnLaporan_Click
        AddHandler btnTutup.Click, AddressOf btnTutup_Click
    End Sub

    Private Sub frmProsesSAW_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadInfo()
        LoadMatriksKeputusan()
    End Sub

    Private Sub LoadInfo()
        Try
            ' Total siswa
            Dim totalSiswa As Integer = GetTableCount("tbl_siswa")
            lblInfoSiswa.Text = "Total Siswa: " & totalSiswa

            ' Total kriteria
            Dim totalKriteria As Integer = GetTableCount("tbl_kriteria")
            lblInfoKriteria.Text = "Total Kriteria: " & totalKriteria

            ' Siswa yang sudah dinilai
            Dim query As String = "SELECT COUNT(DISTINCT id_siswa) AS total FROM tbl_penilaian"
            Dim dt As DataTable = ExecuteQuery(query)
            Dim siswaTerinput As Integer = If(dt IsNot Nothing AndAlso dt.Rows.Count > 0, Convert.ToInt32(dt.Rows(0)("total")), 0)

            lblInfoPenilaian.Text = "Siswa yang Sudah Dinilai: " & siswaTerinput & " dari " & totalSiswa

        Catch ex As Exception
            MessageBox.Show("Error load info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMatriksKeputusan()
        Try
            ' Get kriteria
            Dim queryKriteria As String = "SELECT kode_kriteria FROM tbl_kriteria ORDER BY kode_kriteria"
            Dim dtKriteria As DataTable = ExecuteQuery(queryKriteria)

            If dtKriteria Is Nothing OrElse dtKriteria.Rows.Count = 0 Then
                MessageBox.Show("Belum ada data kriteria!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Create DataTable untuk matriks
            Dim dtMatriks As New DataTable()
            dtMatriks.Columns.Add("NIS", GetType(String))
            dtMatriks.Columns.Add("Nama Siswa", GetType(String))

            For Each rowK As DataRow In dtKriteria.Rows
                dtMatriks.Columns.Add(rowK("kode_kriteria").ToString(), GetType(Double))
            Next

            ' Get siswa yang sudah dinilai
            Dim querySiswa As String = "SELECT DISTINCT s.nis, s.nama_siswa, s.id_siswa FROM tbl_siswa s INNER JOIN tbl_penilaian p ON s.id_siswa = p.id_siswa ORDER BY s.nama_siswa"
            Dim dtSiswa As DataTable = ExecuteQuery(querySiswa)

            If dtSiswa IsNot Nothing AndAlso dtSiswa.Rows.Count > 0 Then
                For Each rowS As DataRow In dtSiswa.Rows
                    Dim newRow As DataRow = dtMatriks.NewRow()
                    newRow("NIS") = rowS("nis").ToString()
                    newRow("Nama Siswa") = rowS("nama_siswa").ToString()

                    Dim idSiswa As Integer = Convert.ToInt32(rowS("id_siswa"))

                    ' Fill nilai untuk setiap kriteria
                    For Each rowK As DataRow In dtKriteria.Rows
                        Dim kodeKriteria As String = rowK("kode_kriteria").ToString()

                        Dim queryNilai As String = "SELECT p.nilai FROM tbl_penilaian p INNER JOIN tbl_kriteria k ON p.id_kriteria = k.id_kriteria WHERE p.id_siswa=" & idSiswa & " AND k.kode_kriteria='" & kodeKriteria & "'"
                        Dim dtNilai As DataTable = ExecuteQuery(queryNilai)

                        If dtNilai IsNot Nothing AndAlso dtNilai.Rows.Count > 0 Then
                            newRow(kodeKriteria) = Convert.ToDouble(dtNilai.Rows(0)("nilai"))
                        Else
                            newRow(kodeKriteria) = 0
                        End If
                    Next

                    dtMatriks.Rows.Add(newRow)
                Next
            End If

            dgvMatriks.DataSource = dtMatriks

            ' Format decimal
            For Each col As DataGridViewColumn In dgvMatriks.Columns
                If col.Index > 1 Then ' Skip NIS dan Nama
                    col.DefaultCellStyle.Format = "0.00"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error load matriks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProses_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            ' Validasi data
            Dim totalSiswa As Integer = GetTableCount("tbl_siswa")
            Dim totalKriteria As Integer = GetTableCount("tbl_kriteria")

            If totalSiswa = 0 Then
                MessageBox.Show("Belum ada data siswa!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If totalKriteria = 0 Then
                MessageBox.Show("Belum ada data kriteria!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check penilaian
            Dim queryCheck As String = "SELECT COUNT(DISTINCT id_siswa) AS total FROM tbl_penilaian"
            Dim dtCheck As DataTable = ExecuteQuery(queryCheck)

            If dtCheck Is Nothing OrElse Convert.ToInt32(dtCheck.Rows(0)("total")) = 0 Then
                MessageBox.Show("Belum ada data penilaian!" & vbCrLf & "Silakan input penilaian siswa terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Proses perhitungan
            Me.Cursor = Cursors.WaitCursor
            btnProses.Enabled = False

            ' Step 1: Hitung normalisasi dan ranking
            HitungRanking()

            ' Step 2: Tampilkan hasil
            TampilkanHasilNormalisasi()
            TampilkanHasilRanking()

            Me.Cursor = Cursors.Default
            btnProses.Enabled = True

            MessageBox.Show("Proses perhitungan SAW selesai!" & vbCrLf & "Lihat hasil pada tab Normalisasi dan Ranking.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            tabControl.SelectedIndex = 2 ' Pindah ke tab Ranking

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            btnProses.Enabled = True
            MessageBox.Show("Error proses SAW: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HitungRanking()
        Try
            OpenConnection()

            ' Truncate table hasil
            Dim queryTruncate As String = "TRUNCATE TABLE tbl_hasil_saw"
            cmd = New MySqlCommand(queryTruncate, conn)
            cmd.ExecuteNonQuery()

            ' Get semua siswa yang sudah dinilai
            Dim querySiswa As String = "SELECT DISTINCT id_siswa FROM tbl_penilaian"
            cmd = New MySqlCommand(querySiswa, conn)
            dr = cmd.ExecuteReader()

            Dim listSiswa As New List(Of Integer)()
            While dr.Read()
                listSiswa.Add(Convert.ToInt32(dr("id_siswa")))
            End While
            dr.Close()

            ' Hitung preferensi untuk setiap siswa
            For Each idSiswa In listSiswa
                Dim totalPreferensi As Double = 0

                ' Get semua kriteria
                Dim queryKriteria As String = "SELECT id_kriteria, bobot, sifat FROM tbl_kriteria"
                cmd = New MySqlCommand(queryKriteria, conn)
                Dim drK As MySqlDataReader = cmd.ExecuteReader()

                Dim listKriteria As New List(Of Tuple(Of Integer, Double, String))()
                While drK.Read()
                    listKriteria.Add(New Tuple(Of Integer, Double, String)(Convert.ToInt32(drK("id_kriteria")), Convert.ToDouble(drK("bobot")), drK("sifat").ToString()))
                End While
                drK.Close()

                ' Hitung untuk setiap kriteria
                For Each kriteria In listKriteria
                    Dim idKriteria As Integer = kriteria.Item1
                    Dim bobot As Double = kriteria.Item2
                    Dim sifat As String = kriteria.Item3

                    ' Get nilai siswa
                    Dim queryNilai As String = "SELECT nilai FROM tbl_penilaian WHERE id_siswa=" & idSiswa & " AND id_kriteria=" & idKriteria
                    cmd = New MySqlCommand(queryNilai, conn)
                    Dim nilai As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    ' Hitung normalisasi
                    Dim nilaiNormalisasi As Double = 0

                    If sifat = "Benefit" Then
                        ' Max
                        Dim queryMax As String = "SELECT MAX(nilai) FROM tbl_penilaian WHERE id_kriteria=" & idKriteria
                        cmd = New MySqlCommand(queryMax, conn)
                        Dim maxVal As Double = Convert.ToDouble(cmd.ExecuteScalar())
                        If maxVal > 0 Then
                            nilaiNormalisasi = nilai / maxVal
                        Else
                            nilaiNormalisasi = 0
                        End If
                    Else ' Cost
                        ' Min
                        Dim queryMin As String = "SELECT MIN(nilai) FROM tbl_penilaian WHERE id_kriteria=" & idKriteria
                        cmd = New MySqlCommand(queryMin, conn)
                        Dim minVal As Double = Convert.ToDouble(cmd.ExecuteScalar())
                        If nilai > 0 Then
                            nilaiNormalisasi = minVal / nilai
                        Else
                            nilaiNormalisasi = 0
                        End If
                    End If

                    totalPreferensi += (nilaiNormalisasi * bobot)
                Next

                ' Insert hasil
                Dim queryInsert As String = "INSERT INTO tbl_hasil_saw (id_siswa, nilai_preferensi, ranking) VALUES (" & idSiswa & ", " & totalPreferensi.ToString("0.0000").Replace(",", ".") & ", 0)"
                cmd = New MySqlCommand(queryInsert, conn)
                cmd.ExecuteNonQuery()
            Next

            ' Update ranking
            Dim queryUpdateRank As String = "UPDATE tbl_hasil_saw SET ranking = 0"
            cmd = New MySqlCommand(queryUpdateRank, conn)
            cmd.ExecuteNonQuery()

            queryUpdateRank = "SET @rank = 0; UPDATE tbl_hasil_saw SET ranking = (@rank := @rank + 1) ORDER BY nilai_preferensi DESC"
            cmd = New MySqlCommand(queryUpdateRank, conn)
            cmd.ExecuteNonQuery()

            CloseConnection()

        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
            CloseConnection()
            Throw ex
        End Try
    End Sub

    Private Sub TampilkanHasilNormalisasi()
        Try
            Dim dtNorm As New DataTable()
            dtNorm.Columns.Add("Keterangan", GetType(String))

            Dim row1 As DataRow = dtNorm.NewRow()
            row1("Keterangan") = "Matriks Normalisasi dihitung dengan rumus:"
            dtNorm.Rows.Add(row1)

            Dim row2 As DataRow = dtNorm.NewRow()
            row2("Keterangan") = "• Benefit: Rij = Xij / Max(Xij)"
            dtNorm.Rows.Add(row2)

            Dim row3 As DataRow = dtNorm.NewRow()
            row3("Keterangan") = "• Cost: Rij = Min(Xij) / Xij"
            dtNorm.Rows.Add(row3)

            Dim row4 As DataRow = dtNorm.NewRow()
            row4("Keterangan") = "Nilai Preferensi = Σ(Rij * Wj) dimana Wj adalah bobot kriteria"
            dtNorm.Rows.Add(row4)

            dgvNormalisasi.DataSource = dtNorm

        Catch ex As Exception
            MessageBox.Show("Error tampilkan normalisasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TampilkanHasilRanking()
        Try
            Dim query As String = "SELECT h.ranking AS Ranking, s.nis AS NIS, s.nama_siswa AS 'Nama Siswa', s.kelas AS Kelas, h.nilai_preferensi AS 'Nilai Preferensi' FROM tbl_hasil_saw h INNER JOIN tbl_siswa s ON h.id_siswa = s.id_siswa ORDER BY h.ranking ASC"

            Dim dt As DataTable = ExecuteQuery(query)
            dgvRanking.DataSource = dt

            ' Format
            If dgvRanking.Columns.Contains("Nilai Preferensi") Then
                dgvRanking.Columns("Nilai Preferensi").DefaultCellStyle.Format = "0.0000"
                dgvRanking.Columns("Nilai Preferensi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If dgvRanking.Columns.Contains("Ranking") Then
                dgvRanking.Columns("Ranking").Width = 80
                dgvRanking.Columns("Ranking").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        Catch ex As Exception
            MessageBox.Show("Error tampilkan ranking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Yakin ingin menghapus semua hasil perhitungan SAW?" & vbCrLf & "Data penilaian tidak akan terhapus.", "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim query As String = "TRUNCATE TABLE tbl_hasil_saw"
                If ExecuteNonQuery(query) Then
                    MessageBox.Show("Hasil perhitungan berhasil direset!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dgvNormalisasi.DataSource = Nothing
                    dgvRanking.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show("Error reset: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnLaporan_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim count As Integer = GetTableCount("tbl_hasil_saw")
        If count = 0 Then
            MessageBox.Show("Belum ada hasil perhitungan!" & vbCrLf & "Silakan proses SAW terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim frmLap As New frmLaporan_PureCode()
        frmLap.ShowDialog()
    End Sub

    Private Sub btnTutup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class