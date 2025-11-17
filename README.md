# Sistem Pendukung Keputusan (SPK) Seleksi Beasiswa - Metode SAW

Aplikasi desktop ini adalah Sistem Pendukung Keputusan (SPK) yang dirancang untuk membantu proses seleksi penerima beasiswa secara objektif, cepat, dan akurat menggunakan metode **Simple Additive Weighting (SAW)**.

Dibangun menggunakan **Visual Basic .NET (VB 2010)** dan database **MySQL**.

## 📋 Fitur Utama

* **Manajemen Data Siswa:** Input, Edit, dan Hapus data kandidat penerima beasiswa.
* **Manajemen Kriteria Dinamis:** Pengaturan bobot dan sifat kriteria (Benefit/Cost).
* **Penilaian Siswa:** Input nilai untuk setiap siswa berdasarkan kriteria yang ditentukan.
* **Proses Hitung Otomatis:** Melakukan normalisasi matriks dan perhitungan preferensi sesuai rumus SAW.
* **Laporan & Perankingan:** Menampilkan hasil akhir berupa ranking siswa yang layak menerima beasiswa.

## 🛠️ Teknologi yang Digunakan

* **Bahasa Pemrograman:** Visual Basic .NET (Visual Studio 2010 Express)
* **Database:** MySQL
* **Reporting:** Crystal Reports (atau fitur print bawaan VB)

## 🧮 Kriteria Penilaian

Sistem ini menggunakan contoh kriteria sebagai berikut (dapat disesuaikan di aplikasi):
1.  **Nilai Rata-rata Rapor** (Benefit) - Bobot: 0.30
2.  **Penghasilan Orang Tua** (Cost) - Bobot: 0.25
3.  **Jumlah Tanggungan** (Benefit) - Bobot: 0.20
4.  **Prestasi** (Benefit) - Bobot: 0.15
5.  **Kehadiran** (Benefit) - Bobot: 0.10

## 📷 Screenshots Aplikasi

Berikut adalah tampilan antarmuka dari sistem:

### 1. Login & Coding Environment
Halaman login untuk administrator dan tampilan *backend code* koneksi database.
![Login Screen](aset/image_483c02.png)

### 2. Dashboard Utama
Menu utama yang menampilkan ringkasan jumlah data (Siswa, Kriteria, dan Penilaian).
![Menu Utama](aset/image_483c3e.png)

### 3. Data Siswa
Form untuk mengelola data biodata siswa yang akan diseleksi.
![Data Siswa](aset/image_483c61.png)

### 4. Data Kriteria & Bobot
Pengaturan kriteria penilaian beserta bobot dan sifatnya (Cost/Benefit).
![Data Kriteria](aset/image_483f29.png)

### 5. Input Penilaian
Form untuk memasukkan nilai mentah siswa berdasarkan kriteria yang ada.
![Input Penilaian](aset/image_483f88.png)

### 6. Proses Perhitungan SAW
Tampilan matriks keputusan dan hasil normalisasi sebelum perankingan.
![Proses Hitung](aset/image_483fc0.png)

### 7. Laporan Hasil Seleksi
Hasil akhir perankingan yang menentukan status kelolosan siswa.
![Laporan Akhir](aset/image_483fe5.png)

## 🚀 Cara Menjalankan Aplikasi

1.  Pastikan **XAMPP** (atau server MySQL lainnya) sudah berjalan.
2.  Import file database (`database.sql`) ke dalam MySQL/phpMyAdmin.
3.  Buka project menggunakan **Visual Studio 2010** (atau versi yang lebih baru).
4.  Sesuaikan konfigurasi koneksi database di module koneksi jika diperlukan.
5.  Jalankan aplikasi (Start/F5).

## 📄 Lisensi

Project ini dibuat untuk tujuan pendidikan/pembelajaran. Silakan dikembangkan lebih lanjut.
