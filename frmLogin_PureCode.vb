Imports System.Windows.Forms
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class frmLogin_PureCode
    Inherits Form

    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private lblUsername As Label
    Private txtUsername As TextBox
    Private lblPassword As Label
    Private txtPassword As TextBox
    Private btnLogin As Button
    Private btnKeluar As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.pnlHeader = New Panel()
        Me.lblTitle = New Label()
        Me.lblSubtitle = New Label()
        Me.lblUsername = New Label()
        Me.txtUsername = New TextBox()
        Me.lblPassword = New Label()
        Me.txtPassword = New TextBox()
        Me.btnLogin = New Button()
        Me.btnKeluar = New Button()

        ' pnlHeader
        Me.pnlHeader.BackColor = Color.FromArgb(33, 150, 243)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Location = New Point(0, 0)
        Me.pnlHeader.Size = New Size(450, 80)

        ' lblTitle
        Me.lblTitle.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.White
        Me.lblTitle.Location = New Point(0, 15)
        Me.lblTitle.Size = New Size(450, 30)
        Me.lblTitle.Text = "SISTEM BEASISWA"
        Me.lblTitle.TextAlign = ContentAlignment.MiddleCenter

        ' lblSubtitle
        Me.lblSubtitle.Font = New Font("Segoe UI", 9.0)
        Me.lblSubtitle.ForeColor = Color.White
        Me.lblSubtitle.Location = New Point(0, 50)
        Me.lblSubtitle.Size = New Size(450, 20)
        Me.lblSubtitle.Text = "Metode SAW (Simple Additive Weighting)"
        Me.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter

        ' lblUsername
        Me.lblUsername.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.lblUsername.Location = New Point(30, 100)
        Me.lblUsername.Size = New Size(380, 20)
        Me.lblUsername.Text = "Username:"

        ' txtUsername
        Me.txtUsername.Font = New Font("Segoe UI", 10.0)
        Me.txtUsername.Location = New Point(30, 125)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Size = New Size(380, 30)

        ' lblPassword
        Me.lblPassword.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.lblPassword.Location = New Point(30, 160)
        Me.lblPassword.Size = New Size(380, 20)
        Me.lblPassword.Text = "Password:"

        ' txtPassword
        Me.txtPassword.Font = New Font("Segoe UI", 10.0)
        Me.txtPassword.Location = New Point(30, 185)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.PasswordChar = "*"c
        Me.txtPassword.Size = New Size(380, 30)

        ' btnLogin
        Me.btnLogin.BackColor = Color.FromArgb(33, 150, 243)
        Me.btnLogin.Cursor = Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = FlatStyle.Flat
        Me.btnLogin.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnLogin.ForeColor = Color.White
        Me.btnLogin.Location = New Point(30, 240)
        Me.btnLogin.Size = New Size(180, 40)
        Me.btnLogin.Text = "LOGIN"

        ' btnKeluar
        Me.btnKeluar.BackColor = Color.FromArgb(244, 67, 54)
        Me.btnKeluar.Cursor = Cursors.Hand
        Me.btnKeluar.FlatAppearance.BorderSize = 0
        Me.btnKeluar.FlatStyle = FlatStyle.Flat
        Me.btnKeluar.Font = New Font("Segoe UI", 10.0, FontStyle.Bold)
        Me.btnKeluar.ForeColor = Color.White
        Me.btnKeluar.Location = New Point(230, 240)
        Me.btnKeluar.Size = New Size(180, 40)
        Me.btnKeluar.Text = "KELUAR"

        ' Form
        Me.BackColor = Color.White
        Me.ClientSize = New Size(450, 310)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnKeluar)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Login - Sistem Beasiswa SAW"

        ' Event Handlers
        AddHandler Me.Load, AddressOf frmLogin_Load
        AddHandler btnLogin.Click, AddressOf btnLogin_Click
        AddHandler btnKeluar.Click, AddressOf btnKeluar_Click
        AddHandler txtPassword.KeyPress, AddressOf txtPassword_KeyPress
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not CheckDatabaseExists() Then
            MessageBox.Show("Database 'db_beasiswa' tidak ditemukan!" & vbCrLf & vbCrLf &
                          "Pastikan:" & vbCrLf &
                          "1. XAMPP MySQL sudah running" & vbCrLf &
                          "2. Database sudah dibuat di phpMyAdmin",
                          "Peringatan Database", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        Try
            Dim query As String = "SELECT * FROM tbl_user WHERE username=@username AND password=MD5(@password)"
            OpenConnection()
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                SessionUserID = Convert.ToInt32(dr("id_user"))
                SessionUserName = dr("nama_lengkap").ToString()
                SessionUserLevel = dr("level").ToString()
                dr.Close()
                CloseConnection()

                MessageBox.Show("Login Berhasil!" & vbCrLf & vbCrLf &
                              "Selamat datang, " & SessionUserName & vbCrLf &
                              "Level: " & SessionUserLevel,
                              "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim frmMenu As New frmMenuUtama_PureCode()
                frmMenu.Show()
                Me.Hide()
            Else
                dr.Close()
                CloseConnection()
                MessageBox.Show("Login Gagal!" & vbCrLf & vbCrLf &
                              "Username atau Password salah.",
                              "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()
                txtUsername.Focus()
            End If

        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
            CloseConnection()
            MessageBox.Show("Error: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim result As DialogResult = MessageBox.Show(
            "Yakin ingin keluar dari aplikasi?",
            "Konfirmasi Keluar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub
End Class