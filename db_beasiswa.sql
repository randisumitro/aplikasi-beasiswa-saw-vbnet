-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 17 Nov 2025 pada 12.07
-- Versi server: 10.1.37-MariaDB
-- Versi PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_beasiswa`
--

DELIMITER $$
--
-- Prosedur
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_hitung_saw` ()  BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE v_id_siswa INT;
    DECLARE v_total_nilai DECIMAL(10,4);
    
    DECLARE cur_siswa CURSOR FOR 
        SELECT DISTINCT id_siswa FROM tbl_penilaian;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    -- Hapus hasil lama
    TRUNCATE TABLE tbl_hasil_saw;
    
    -- Loop untuk setiap siswa
    OPEN cur_siswa;
    
    read_loop: LOOP
        FETCH cur_siswa INTO v_id_siswa;
        IF done THEN
            LEAVE read_loop;
        END IF;
        
        -- Hitung nilai preferensi
        SELECT 
            SUM(
                CASE 
                    WHEN k.sifat = 'Benefit' THEN 
                        (p.nilai / (SELECT MAX(nilai) FROM tbl_penilaian WHERE id_kriteria = p.id_kriteria)) * k.bobot
                    WHEN k.sifat = 'Cost' THEN 
                        ((SELECT MIN(nilai) FROM tbl_penilaian WHERE id_kriteria = p.id_kriteria) / p.nilai) * k.bobot
                END
            ) INTO v_total_nilai
        FROM tbl_penilaian p
        INNER JOIN tbl_kriteria k ON p.id_kriteria = k.id_kriteria
        WHERE p.id_siswa = v_id_siswa;
        
        -- Insert hasil
        INSERT INTO tbl_hasil_saw (id_siswa, nilai_preferensi, ranking)
        VALUES (v_id_siswa, v_total_nilai, 0);
        
    END LOOP;
    
    CLOSE cur_siswa;
    
    -- Update ranking
    SET @rank = 0;
    UPDATE tbl_hasil_saw
    SET ranking = (@rank := @rank + 1)
    ORDER BY nilai_preferensi DESC;
    
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_hasil_saw`
--

CREATE TABLE `tbl_hasil_saw` (
  `id_hasil` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `nilai_preferensi` decimal(10,4) NOT NULL,
  `ranking` int(11) NOT NULL,
  `tanggal_proses` datetime DEFAULT CURRENT_TIMESTAMP,
  `keterangan` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_hasil_saw`
--

INSERT INTO `tbl_hasil_saw` (`id_hasil`, `id_siswa`, `nilai_preferensi`, `ranking`, `tanggal_proses`, `keterangan`) VALUES
(1, 1, '0.5985', 0, '2025-11-13 08:54:23', NULL),
(2, 2, '0.5815', 0, '2025-11-13 08:54:23', NULL),
(3, 3, '0.4672', 0, '2025-11-13 08:54:23', NULL),
(4, 4, '0.6557', 0, '2025-11-13 08:54:23', NULL),
(5, 5, '0.5183', 0, '2025-11-13 08:54:23', NULL),
(6, 6, '0.7316', 0, '2025-11-13 08:54:23', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_kriteria`
--

CREATE TABLE `tbl_kriteria` (
  `id_kriteria` int(11) NOT NULL,
  `kode_kriteria` varchar(10) NOT NULL,
  `nama_kriteria` varchar(100) NOT NULL,
  `bobot` decimal(3,2) NOT NULL,
  `sifat` enum('Benefit','Cost') NOT NULL,
  `keterangan` text,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_kriteria`
--

INSERT INTO `tbl_kriteria` (`id_kriteria`, `kode_kriteria`, `nama_kriteria`, `bobot`, `sifat`, `keterangan`, `created_at`, `updated_at`) VALUES
(1, 'C1', 'Nilai Rata-rata Rapor', '0.30', 'Benefit', 'Nilai rata-rata rapor semester terakhir (0-100)', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(2, 'C2', 'Penghasilan Orang Tua', '0.25', 'Cost', 'Penghasilan orang tua per bulan (dalam juta rupiah)', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(3, 'C3', 'Jumlah Tanggungan', '0.20', 'Benefit', 'Jumlah saudara kandung yang masih sekolah', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(4, 'C4', 'Prestasi', '0.15', 'Benefit', 'Jumlah prestasi akademik/non-akademik yang diraih', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(5, 'C5', 'Kehadiran', '0.10', 'Benefit', 'Persentase kehadiran siswa (0-100)', '2025-11-11 06:09:01', '2025-11-11 06:09:01');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_penilaian`
--

CREATE TABLE `tbl_penilaian` (
  `id_penilaian` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `id_kriteria` int(11) NOT NULL,
  `nilai` decimal(10,2) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_penilaian`
--

INSERT INTO `tbl_penilaian` (`id_penilaian`, `id_siswa`, `id_kriteria`, `nilai`, `created_at`, `updated_at`) VALUES
(1, 1, 1, '85.50', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(2, 1, 2, '2.50', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(3, 1, 3, '3.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(4, 1, 4, '2.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(5, 1, 5, '95.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(6, 2, 1, '90.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(7, 2, 2, '3.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(8, 2, 3, '2.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(9, 2, 4, '3.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(10, 2, 5, '98.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(11, 3, 1, '78.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(12, 3, 2, '4.50', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(13, 3, 3, '1.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(14, 3, 4, '1.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(15, 3, 5, '88.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(16, 4, 1, '88.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(17, 4, 2, '2.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(18, 4, 3, '4.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(19, 4, 4, '2.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(20, 4, 5, '90.00', '2025-11-11 06:09:01', '2025-11-12 12:05:38'),
(21, 5, 1, '82.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(22, 5, 2, '3.50', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(23, 5, 3, '2.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(24, 5, 4, '1.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(25, 5, 5, '90.00', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(26, 6, 1, '88.00', '2025-11-12 11:58:29', '2025-11-12 11:58:29'),
(27, 6, 2, '75.00', '2025-11-12 11:58:29', '2025-11-12 11:58:29'),
(28, 6, 3, '50.00', '2025-11-12 11:58:29', '2025-11-12 11:58:29'),
(29, 6, 4, '66.00', '2025-11-12 11:58:29', '2025-11-12 11:58:29'),
(30, 6, 5, '80.00', '2025-11-12 11:58:29', '2025-11-12 11:58:29');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_siswa`
--

CREATE TABLE `tbl_siswa` (
  `id_siswa` int(11) NOT NULL,
  `nis` varchar(20) NOT NULL,
  `nama_siswa` varchar(100) NOT NULL,
  `kelas` varchar(20) NOT NULL,
  `jenis_kelamin` enum('L','P') NOT NULL,
  `alamat` text,
  `telepon` varchar(15) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_siswa`
--

INSERT INTO `tbl_siswa` (`id_siswa`, `nis`, `nama_siswa`, `kelas`, `jenis_kelamin`, `alamat`, `telepon`, `created_at`, `updated_at`) VALUES
(1, '2024001', 'Ahmad Rizki', 'XII IPA 1', 'L', 'Jl. Merdeka No. 10', '081234567890', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(2, '2024002', 'Siti Nurhaliza', 'XII IPA 1', 'P', 'Jl. Sudirman No. 25', '081234567891', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(3, '2024003', 'Budi Santoso', 'XII IPA 2', 'L', 'Jl. Ahmad Yani No. 5', '081234567892', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(4, '2024004', 'Dewi Lestari', 'XII IPS 1', 'P', 'Jl. Gatot Subroto No. 15', '081234567893', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(5, '2024005', 'Eko Prasetyo', 'XII IPS 2', 'L', 'Jl. Diponegoro No. 30', '081234567894', '2025-11-11 06:09:01', '2025-11-11 06:09:01'),
(6, '2024006', 'nasya', 'X IPA 1', 'P', 'jl.jawa pematangsiantar', '088789902341', '2025-11-12 11:57:28', '2025-11-12 12:06:26');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_user`
--

CREATE TABLE `tbl_user` (
  `id_user` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nama_lengkap` varchar(100) NOT NULL,
  `level` enum('Admin','User') NOT NULL DEFAULT 'User',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_user`
--

INSERT INTO `tbl_user` (`id_user`, `username`, `password`, `nama_lengkap`, `level`, `created_at`) VALUES
(1, 'admin', '0192023a7bbd73250516f069df18b500', 'Administrator', 'Admin', '2025-11-11 06:09:01'),
(2, 'user', '6ad14ba9986e3615423dfca256d04e3f', 'User Biasa', 'User', '2025-11-11 06:09:01');

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `view_hasil_ranking`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `view_hasil_ranking` (
`ranking` int(11)
,`nis` varchar(20)
,`nama_siswa` varchar(100)
,`kelas` varchar(20)
,`nilai_preferensi` decimal(10,4)
,`tanggal_proses` datetime
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `view_penilaian_lengkap`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `view_penilaian_lengkap` (
`id_penilaian` int(11)
,`id_siswa` int(11)
,`nis` varchar(20)
,`nama_siswa` varchar(100)
,`kelas` varchar(20)
,`id_kriteria` int(11)
,`kode_kriteria` varchar(10)
,`nama_kriteria` varchar(100)
,`bobot` decimal(3,2)
,`sifat` enum('Benefit','Cost')
,`nilai` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Struktur untuk view `view_hasil_ranking`
--
DROP TABLE IF EXISTS `view_hasil_ranking`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_hasil_ranking`  AS  select `h`.`ranking` AS `ranking`,`s`.`nis` AS `nis`,`s`.`nama_siswa` AS `nama_siswa`,`s`.`kelas` AS `kelas`,`h`.`nilai_preferensi` AS `nilai_preferensi`,`h`.`tanggal_proses` AS `tanggal_proses` from (`tbl_hasil_saw` `h` join `tbl_siswa` `s` on((`h`.`id_siswa` = `s`.`id_siswa`))) order by `h`.`ranking` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `view_penilaian_lengkap`
--
DROP TABLE IF EXISTS `view_penilaian_lengkap`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_penilaian_lengkap`  AS  select `p`.`id_penilaian` AS `id_penilaian`,`p`.`id_siswa` AS `id_siswa`,`s`.`nis` AS `nis`,`s`.`nama_siswa` AS `nama_siswa`,`s`.`kelas` AS `kelas`,`p`.`id_kriteria` AS `id_kriteria`,`k`.`kode_kriteria` AS `kode_kriteria`,`k`.`nama_kriteria` AS `nama_kriteria`,`k`.`bobot` AS `bobot`,`k`.`sifat` AS `sifat`,`p`.`nilai` AS `nilai` from ((`tbl_penilaian` `p` join `tbl_siswa` `s` on((`p`.`id_siswa` = `s`.`id_siswa`))) join `tbl_kriteria` `k` on((`p`.`id_kriteria` = `k`.`id_kriteria`))) ;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tbl_hasil_saw`
--
ALTER TABLE `tbl_hasil_saw`
  ADD PRIMARY KEY (`id_hasil`),
  ADD KEY `id_siswa` (`id_siswa`);

--
-- Indeks untuk tabel `tbl_kriteria`
--
ALTER TABLE `tbl_kriteria`
  ADD PRIMARY KEY (`id_kriteria`),
  ADD UNIQUE KEY `kode_kriteria` (`kode_kriteria`);

--
-- Indeks untuk tabel `tbl_penilaian`
--
ALTER TABLE `tbl_penilaian`
  ADD PRIMARY KEY (`id_penilaian`),
  ADD UNIQUE KEY `unique_penilaian` (`id_siswa`,`id_kriteria`),
  ADD KEY `id_kriteria` (`id_kriteria`);

--
-- Indeks untuk tabel `tbl_siswa`
--
ALTER TABLE `tbl_siswa`
  ADD PRIMARY KEY (`id_siswa`),
  ADD UNIQUE KEY `nis` (`nis`);

--
-- Indeks untuk tabel `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`id_user`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tbl_hasil_saw`
--
ALTER TABLE `tbl_hasil_saw`
  MODIFY `id_hasil` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT untuk tabel `tbl_kriteria`
--
ALTER TABLE `tbl_kriteria`
  MODIFY `id_kriteria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `tbl_penilaian`
--
ALTER TABLE `tbl_penilaian`
  MODIFY `id_penilaian` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT untuk tabel `tbl_siswa`
--
ALTER TABLE `tbl_siswa`
  MODIFY `id_siswa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT untuk tabel `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tbl_hasil_saw`
--
ALTER TABLE `tbl_hasil_saw`
  ADD CONSTRAINT `tbl_hasil_saw_ibfk_1` FOREIGN KEY (`id_siswa`) REFERENCES `tbl_siswa` (`id_siswa`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `tbl_penilaian`
--
ALTER TABLE `tbl_penilaian`
  ADD CONSTRAINT `tbl_penilaian_ibfk_1` FOREIGN KEY (`id_siswa`) REFERENCES `tbl_siswa` (`id_siswa`) ON DELETE CASCADE,
  ADD CONSTRAINT `tbl_penilaian_ibfk_2` FOREIGN KEY (`id_kriteria`) REFERENCES `tbl_kriteria` (`id_kriteria`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
