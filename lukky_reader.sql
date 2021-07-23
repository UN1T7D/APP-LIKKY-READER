-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-07-2021 a las 22:12:56
-- Versión del servidor: 10.4.20-MariaDB
-- Versión de PHP: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `lukky_reader`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `escaneos`
--

CREATE TABLE `escaneos` (
  `id` int(11) NOT NULL,
  `url` varchar(250) COLLATE utf8_spanish_ci DEFAULT NULL,
  `ip` varchar(100) COLLATE utf8_spanish_ci DEFAULT NULL,
  `updated_at` varchar(60) COLLATE utf8_spanish_ci NOT NULL,
  `created_at` varchar(60) COLLATE utf8_spanish_ci NOT NULL,
  `id_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `escaneos`
--

INSERT INTO `escaneos` (`id`, `url`, `ip`, `updated_at`, `created_at`, `id_usuario`) VALUES
(30, 'https://wp.gxnas.com/2157.html', '192.168.0.166', '2021-07-21 10:26:39', '2021-07-21 10:26:39', 20),
(31, 'https://esalvador.com', '255.255.0.0', '2021-07-21 11:07:10', '2021-07-21 11:07:10', 5),
(32, 'http://www.fengshuimanhattan.com', '192.168.0.166', '2021-07-21 14:07:06', '2021-07-21 14:07:06', 22),
(33, 'http://www.fengshuimanhattan.com', '192.168.0.166', '2021-07-21 14:07:44', '2021-07-21 14:07:44', 22),
(43, 'https://www.agoria.be/nl/download-brochure-5G', '192.168.0.166', '2021-07-22 08:48:41', '2021-07-22 08:48:41', 23),
(44, 'http://www.pkulaw.com/environmentallaw/36873221949095941.html', '192.168.0.166', '2021-07-22 08:49:27', '2021-07-22 08:49:27', 24),
(45, 'https://www.asahiinryo.co.jp/newsrelease/topics/', '192.168.0.166', '2021-07-22 08:49:58', '2021-07-22 08:49:58', 24);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `failed_jobs`
--

CREATE TABLE `failed_jobs` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `uuid` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `connection` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `queue` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `payload` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `exception` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Volcado de datos para la tabla `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_users_table', 1),
(2, '2014_10_12_100000_create_password_resets_table', 1),
(3, '2019_08_19_000000_create_failed_jobs_table', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `password_resets`
--

CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `name`, `email`, `password`, `remember_token`, `created_at`, `updated_at`) VALUES
(5, 'cfbcbcvb', 'cfdfgfdgdfg@gmail.com', 'fdfsdfsdfdsf', NULL, NULL, NULL),
(10, 'kenejgjgf', 'jajaja@hotmail.com', '45465', NULL, '2021-07-19 17:12:27', '2021-07-19 17:12:27'),
(12, 'kenejgjgf', 'jajaja@hotmail.comsds', '45465', NULL, '2021-07-20 18:01:14', '2021-07-20 18:01:14'),
(14, 'jdjdjd', 'hdhdhdhs@gmail.com', 'hdhdhdhs@gmail.com', NULL, '2021-07-20 21:05:49', '2021-07-20 21:05:49'),
(20, 'prueba usuario', 'pruebausuario@gmail.com', '655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b', NULL, '2021-07-20 21:46:47', '2021-07-20 21:46:47'),
(21, 'kevin.aquino', 'kevin@gmail.com', '61be55a8e2f6b4e172338bddf184d6dbee29c98853e0a0485ecee7f27b9af0b4', NULL, '2021-07-21 00:16:44', '2021-07-21 00:16:44'),
(22, 'prueba', 'prueba@gmail.com', '655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b', NULL, '2021-07-21 14:52:54', '2021-07-21 14:52:54'),
(23, 'prueba1', 'prueba1@gmail.com', 'ef994e7262a78b97c039adf58214ee7df1076824a7e47538948ba61ae02b05c7', NULL, '2021-07-21 22:35:18', '2021-07-21 22:35:18'),
(24, 'prueba2', 'prueba2@gmail.com', '92573009c9ed328bd9d47d7187e01eb0abe4b995fb6abe0724b4f53bed590264', NULL, '2021-07-22 02:10:21', '2021-07-22 02:10:21');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `escaneos`
--
ALTER TABLE `escaneos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- Indices de la tabla `failed_jobs`
--
ALTER TABLE `failed_jobs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`);

--
-- Indices de la tabla `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `password_resets`
--
ALTER TABLE `password_resets`
  ADD KEY `password_resets_email_index` (`email`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_email_unique` (`email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `escaneos`
--
ALTER TABLE `escaneos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT de la tabla `failed_jobs`
--
ALTER TABLE `failed_jobs`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `escaneos`
--
ALTER TABLE `escaneos`
  ADD CONSTRAINT `escaneos_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
