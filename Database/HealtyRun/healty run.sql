-- phpMyAdmin SQL Dump
-- version 2.10.3
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Jul 10, 2018 at 10:08 PM
-- Server version: 5.0.51
-- PHP Version: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

-- 
-- Database: `healty run`
-- 

-- --------------------------------------------------------

-- 
-- Table structure for table `enemy`
-- 

CREATE TABLE `enemy` (
  `Id_enemy` varchar(10) NOT NULL,
  `Name_enemy` varchar(10) NOT NULL,
  `Dmg_enemy` int(10) NOT NULL,
  `Detail_enemy` varchar(20) NOT NULL,
  PRIMARY KEY  (`Id_enemy`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `enemy`
-- 

INSERT INTO `enemy` VALUES ('EN001', 'HpEnemy', 1, 'Hp -1');
INSERT INTO `enemy` VALUES ('EN002', 'ScoreEnemy', 1, 'score -1');

-- --------------------------------------------------------

-- 
-- Table structure for table `item`
-- 

CREATE TABLE `item` (
  `Id_item` varchar(10) NOT NULL,
  `Name_item` varchar(10) NOT NULL,
  `Unit_item` int(10) NOT NULL,
  `Detail_item` varchar(20) NOT NULL,
  PRIMARY KEY  (`Id_item`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `item`
-- 

INSERT INTO `item` VALUES ('IT001', 'Hp', 1, 'Hp +1');
INSERT INTO `item` VALUES ('IT002', 'Milk', 0, 'Protection');
INSERT INTO `item` VALUES ('IT003', 'MiniItem', 1, 'Score +1');
INSERT INTO `item` VALUES ('IT004', 'BigItem', 2, 'Score +2');
INSERT INTO `item` VALUES ('IT005', 'Time', 10, 'Time + 10');

-- --------------------------------------------------------

-- 
-- Table structure for table `level`
-- 

CREATE TABLE `level` (
  `Id_level` varchar(10) NOT NULL,
  `Speed_level` float NOT NULL,
  `Distance_level` int(10) NOT NULL,
  `Detail_level` varchar(10) NOT NULL,
  PRIMARY KEY  (`Id_level`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `level`
-- 

INSERT INTO `level` VALUES ('LV001', 1, 100, 'Level 1');
INSERT INTO `level` VALUES ('LV002', 2, 200, 'Level 2');
INSERT INTO `level` VALUES ('LV003', 3, 300, 'Level 3');
INSERT INTO `level` VALUES ('LV004', 4, 400, 'Level 4');
INSERT INTO `level` VALUES ('LV005', 5, 500, 'Level 5');

-- --------------------------------------------------------

-- 
-- Table structure for table `player`
-- 

CREATE TABLE `player` (
  `UserName` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  PRIMARY KEY  (`UserName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `player`
-- 

INSERT INTO `player` VALUES ('test01', 'test01');
INSERT INTO `player` VALUES ('fieldqq', 'fieldkiku41');
INSERT INTO `player` VALUES ('fieldqqqq', 'field');
INSERT INTO `player` VALUES ('fieldqqq', 'field');
INSERT INTO `player` VALUES ('test02', 'test01');
INSERT INTO `player` VALUES ('aaaaa', 'aaaaa');
INSERT INTO `player` VALUES ('aaaaaa', 'aaaaa');
INSERT INTO `player` VALUES ('aaaaaaa', 'aaaaa');
INSERT INTO `player` VALUES ('test03', 'test03');
INSERT INTO `player` VALUES ('safff', 'qqqqq');
INSERT INTO `player` VALUES ('aaawww', 'aaawww');
INSERT INTO `player` VALUES ('asfasf', 'aaaaa');
INSERT INTO `player` VALUES ('sadfasf', 'aaaaa');
INSERT INTO `player` VALUES ('qqqqq', 'qqqqq');
INSERT INTO `player` VALUES ('fieldza', 'fieldza');
INSERT INTO `player` VALUES ('zzzzz', 'zzzzz');
INSERT INTO `player` VALUES ('xxxxx', 'xxxxx');
INSERT INTO `player` VALUES ('ccccc', 'ccccc');
INSERT INTO `player` VALUES ('aasaa', 'aaaaa');
INSERT INTO `player` VALUES ('test08', 'test08');
INSERT INTO `player` VALUES ('wwwww', 'wwwww');
INSERT INTO `player` VALUES ('vvvvv', 'vvvvv');

-- --------------------------------------------------------

-- 
-- Table structure for table `score`
-- 

CREATE TABLE `score` (
  `Id_score` int(10) NOT NULL auto_increment,
  `Value_score` int(10) NOT NULL,
  `Count_hp` int(10) NOT NULL,
  `Count_milk` int(10) NOT NULL,
  `Count_miniItem` int(10) NOT NULL,
  `Count_bigItem` int(10) NOT NULL,
  `Count_time` int(10) NOT NULL,
  `Count_hpEnemy` int(10) NOT NULL,
  `Count_scoreEnemy` int(10) NOT NULL,
  `Distance` float NOT NULL,
  `Date_score` datetime NOT NULL,
  `UserName` varchar(20) NOT NULL,
  PRIMARY KEY  (`Id_score`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=547 ;

-- 
-- Dumping data for table `score`
-- 

INSERT INTO `score` VALUES (45, 5, 0, 0, 3, 1, 5, 3, 0, 50, '2018-04-08 06:10:23', 'aaaaa');
INSERT INTO `score` VALUES (44, 1, 0, 0, 1, 0, 5, 3, 0, 25.6, '2018-04-07 20:55:57', 'ccccc');
INSERT INTO `score` VALUES (43, 6, 0, 0, 4, 2, 9, 3, 2, 32.4569, '2018-04-07 20:54:14', 'aaaaa');
INSERT INTO `score` VALUES (4, 13, 0, 0, 8, 3, 3, 3, 1, 100.659, '2018-03-12 21:14:00', 'aaaaa');
INSERT INTO `score` VALUES (5, 16, 0, 0, 9, 5, 4, 3, 3, 141.257, '2018-03-12 23:06:47', 'test01');
INSERT INTO `score` VALUES (7, 2, 0, 0, 2, 0, 4, 3, 0, 12.3659, '2018-03-13 00:59:49', 'aaaaa');
INSERT INTO `score` VALUES (8, 5, 0, 0, 2, 2, 0, 3, 1, 1.235, '2018-03-13 01:47:08', 'aaaaa');
INSERT INTO `score` VALUES (9, 3, 0, 0, 0, 2, 2, 3, 1, 5, '2018-03-13 03:48:32', 'aaaaa');
INSERT INTO `score` VALUES (10, 2, 0, 0, 2, 0, 1, 3, 0, 13.265, '2018-03-13 03:48:56', 'aaaaa');
INSERT INTO `score` VALUES (11, 44, 0, 2, 16, 15, 1, 6, 5, 136.265, '2018-03-13 03:51:29', 'test01');
INSERT INTO `score` VALUES (12, 59, 3, 1, 24, 19, 0, 7, 5, 63.3654, '2018-03-14 05:50:04', 'aaaaa');
INSERT INTO `score` VALUES (13, 4, 0, 0, 0, 3, 2, 3, 2, 520.12, '2018-03-14 05:55:31', 'qqqqq');
INSERT INTO `score` VALUES (14, 4, 0, 0, 1, 2, 2, 3, 1, 10.236, '2018-03-14 05:55:59', 'qqqqq');
INSERT INTO `score` VALUES (15, 4, 0, 0, 2, 1, 0, 3, 0, 50.326, '2018-03-14 05:56:40', 'qqqqq');
INSERT INTO `score` VALUES (16, 6, 0, 0, 2, 2, 0, 3, 0, 52.364, '2018-03-14 07:40:11', 'qqqqq');
INSERT INTO `score` VALUES (17, 52, 4, 1, 25, 17, 5, 9, 8, 102.351, '2018-03-14 07:46:41', 'fieldqq');
INSERT INTO `score` VALUES (18, 49, 3, 0, 21, 16, 0, 6, 4, 20.3545, '2018-03-20 10:56:48', 'aaaaa');
INSERT INTO `score` VALUES (19, 27, 0, 0, 14, 9, 0, 3, 5, 250.364, '2018-03-20 21:15:33', 'aaaaa');
INSERT INTO `score` VALUES (20, 47, 3, 0, 25, 14, 2, 6, 6, 250.351, '2018-03-20 21:29:43', 'aaaaa');
INSERT INTO `score` VALUES (21, 16, 1, 0, 5, 6, 0, 4, 1, 159.524, '2018-03-20 21:31:05', 'aaaaa');
INSERT INTO `score` VALUES (22, 20, 1, 0, 14, 4, 1, 4, 2, 14.256, '2018-03-21 08:12:09', 'aaaaa');
INSERT INTO `score` VALUES (23, 21, 0, 0, 12, 6, 0, 3, 3, 123.651, '2018-03-27 03:25:06', 'aaaaa');
INSERT INTO `score` VALUES (25, 500, 2, 6, 4, 5, 5, 2, 0, 45.651, '2018-03-28 03:10:31', 'fieldza');
INSERT INTO `score` VALUES (26, 19, 0, 0, 9, 6, 1, 3, 2, 128.514, '2018-04-03 14:48:00', 'aaaaa');
INSERT INTO `score` VALUES (27, 14, 0, 0, 5, 5, 0, 3, 1, 75.41, '2018-04-03 15:10:47', 'aaaaa');
INSERT INTO `score` VALUES (28, 24, 0, 1, 15, 5, 7, 5, 2, 123.524, '2018-04-03 15:33:41', 'aaaaa');
INSERT INTO `score` VALUES (29, 9, 0, 0, 3, 4, 0, 3, 2, 41.72, '2018-04-03 17:19:11', 'aaaaa');
INSERT INTO `score` VALUES (30, 6, 0, 0, 1, 3, 0, 3, 1, 568, '2018-04-03 20:27:04', 'aaaaa');
INSERT INTO `score` VALUES (31, 31, 0, 1, 9, 12, 2, 4, 4, 42.256, '2018-04-03 20:49:01', 'aaaaa');
INSERT INTO `score` VALUES (32, 2, 0, 0, 1, 1, 0, 3, 1, 102.258, '2018-04-03 21:01:25', 'aaaaa');
INSERT INTO `score` VALUES (33, 11, 0, 0, 3, 5, 0, 3, 2, 52.852, '2018-04-03 21:04:57', 'aaaaa');
INSERT INTO `score` VALUES (34, 7, 0, 0, 2, 3, 0, 3, 1, 126.369, '2018-04-04 03:45:18', 'aaaaa');
INSERT INTO `score` VALUES (40, 13, 0, 0, 5, 4, 0, 3, 0, 14.9921, '2018-04-07 20:52:02', 'zzzzz');
INSERT INTO `score` VALUES (41, 3, 0, 0, 1, 1, 3, 3, 2, 456.52, '2018-04-07 20:52:46', 'aaaaa');
INSERT INTO `score` VALUES (42, 4, 0, 0, 2, 2, 0, 3, 2, 300.526, '2018-04-07 20:53:23', 'aaaaa');
INSERT INTO `score` VALUES (46, 7, 2, 2, 2, 2, 0, 8, 3, 125.8, '2018-04-08 19:20:21', 'aaaaa');
INSERT INTO `score` VALUES (47, 3, 0, 0, 2, 1, 2, 3, 1, 125.66, '2018-04-08 19:22:24', 'aaaaa');
INSERT INTO `score` VALUES (48, 3, 0, 0, 1, 1, 0, 3, 0, 127.64, '2018-04-08 19:22:56', 'zzzzz');
INSERT INTO `score` VALUES (49, 5, 0, 0, 3, 1, 2, 3, 0, 253.45, '2018-04-08 21:23:17', 'aaaaa');
INSERT INTO `score` VALUES (50, 5, 0, 0, 3, 2, 0, 3, 2, 30.586, '2018-04-08 21:24:16', 'aaaaa');
INSERT INTO `score` VALUES (51, 8, 0, 0, 4, 3, 0, 3, 2, 120.527, '2018-04-08 21:39:43', 'aaaaa');
INSERT INTO `score` VALUES (52, 5, 0, 0, 1, 2, 0, 3, 0, 221.825, '2018-04-08 21:56:07', 'aaaaa');
INSERT INTO `score` VALUES (53, 5, 0, 0, 3, 1, 0, 3, 0, 22.5874, '2018-04-08 21:56:33', 'aaaaa');
INSERT INTO `score` VALUES (54, 2, 0, 0, 1, 1, 0, 3, 1, 248.369, '2018-04-08 22:26:52', 'aaaaa');
INSERT INTO `score` VALUES (55, 1, 0, 0, 2, 0, 1, 3, 1, 13.3509, '2018-04-08 22:31:16', 'aaaaa');
INSERT INTO `score` VALUES (56, 3, 0, 0, 2, 1, 0, 3, 1, 17.7094, '2018-04-08 22:40:31', 'zzzzz');
INSERT INTO `score` VALUES (57, 2, 0, 0, 2, 0, 0, 3, 0, 11.2166, '2018-04-08 22:41:15', 'zzzzz');
INSERT INTO `score` VALUES (58, 9, 0, 0, 7, 2, 0, 3, 2, 42.5929, '2018-04-09 05:45:05', 'aaaaa');
INSERT INTO `score` VALUES (59, 8, 0, 0, 3, 3, 8, 3, 1, 28.8039, '2018-04-09 05:47:26', 'aaaaa');
INSERT INTO `score` VALUES (60, 8, 1, 0, 5, 5, 0, 3, 8, 49.783, '2018-04-09 05:48:18', 'aaaaa');
INSERT INTO `score` VALUES (61, 10, 0, 0, 5, 4, 5, 3, 3, 40.3727, '2018-04-09 05:52:02', 'test01');
INSERT INTO `score` VALUES (62, 35, 2, 1, 16, 14, 2, 6, 11, 128.866, '2018-04-09 06:07:45', 'aaaaa');
INSERT INTO `score` VALUES (63, 1, 0, 0, 2, 0, 0, 3, 1, 10.5943, '2018-04-09 06:08:12', 'aaaaa');
INSERT INTO `score` VALUES (64, 1, 0, 0, 1, 0, 8, 3, 0, 10.4458, '2018-04-09 06:08:30', 'aaaaa');
INSERT INTO `score` VALUES (65, 7, 0, 0, 5, 1, 0, 3, 0, 18.6658, '2018-04-09 06:09:03', 'aaaaa');
INSERT INTO `score` VALUES (66, 13, 0, 1, 9, 5, 0, 5, 7, 76.8616, '2018-04-09 06:10:21', 'aaaaa');
INSERT INTO `score` VALUES (67, 1, 0, 0, 2, 0, 1, 3, 1, 10.9746, '2018-04-09 06:53:13', 'aaaaa');
INSERT INTO `score` VALUES (68, 10, 0, 0, 5, 3, 0, 3, 1, 41.9288, '2018-04-09 06:53:58', 'aaaaa');
INSERT INTO `score` VALUES (69, 2, 0, 0, 3, 0, 1, 3, 1, 16.4666, '2018-04-09 06:55:04', 'test08');
INSERT INTO `score` VALUES (70, 2, 0, 0, 3, 0, 0, 3, 1, 14.3429, '2018-04-09 21:07:14', 'qqqqq');
INSERT INTO `score` VALUES (100, 50, 2, 6, 7, 8, 2, 8, 5, 5, '2018-03-09 21:12:46', 'test01');
INSERT INTO `score` VALUES (101, 5, 0, 0, 4, 1, 2, 3, 1, 20.0294, '2018-04-09 21:27:56', 'zzzzz');
INSERT INTO `score` VALUES (102, 2, 0, 0, 2, 0, 4, 1, 0, 12.0804, '2018-04-10 02:04:54', 'test01');
INSERT INTO `score` VALUES (103, 2, 0, 0, 0, 1, 0, 0, 0, 10.2249, '2018-04-10 02:05:45', 'test01');
INSERT INTO `score` VALUES (104, 2, 0, 0, 2, 0, 0, 1, 0, 10.227, '2018-04-10 02:09:35', 'test01');
INSERT INTO `score` VALUES (105, 1, 0, 0, 1, 0, 6, 0, 0, 10.2237, '2018-04-10 02:09:47', 'test01');
INSERT INTO `score` VALUES (106, 2, 0, 0, 0, 1, 1, 0, 0, 10.2243, '2018-04-10 02:12:19', 'test01');
INSERT INTO `score` VALUES (107, 1, 0, 0, 1, 0, 0, 0, 0, 10.2262, '2018-04-10 02:35:59', 'test01');
INSERT INTO `score` VALUES (108, 0, 0, 0, 0, 0, 1, 3, 2, 32.3372, '2018-04-10 02:37:34', 'test01');
INSERT INTO `score` VALUES (110, 19, 0, 1, 4, 9, 0, 4, 3, 80.2233, '2018-04-10 02:58:28', 'test01');
INSERT INTO `score` VALUES (111, 21, 1, 0, 6, 7, 0, 0, 1, 60.2273, '2018-04-10 03:06:59', 'test01');
INSERT INTO `score` VALUES (112, 27, 1, 1, 12, 8, 0, 0, 5, 90.2219, '2018-04-10 03:11:32', 'test01');
INSERT INTO `score` VALUES (114, 20, 0, 1, 7, 7, 0, 4, 3, 77.0492, '2018-04-10 03:16:11', 'test01');
INSERT INTO `score` VALUES (115, 3, 0, 0, 4, 0, 0, 3, 1, 23.257, '2018-04-10 03:23:54', 'test01');
INSERT INTO `score` VALUES (149, 2, 0, 0, 2, 0, 5, 3, 0, 10.0114, '2018-04-10 03:40:21', 'test01');
INSERT INTO `score` VALUES (546, 3, 0, 0, 2, 1, 0, 3, 1, 15.2888, '2018-04-10 05:03:23', 'vvvvv');
INSERT INTO `score` VALUES (545, 18, 0, 1, 8, 6, 1, 3, 4, 70.2261, '2018-04-10 05:00:43', 'test01');
INSERT INTO `score` VALUES (544, 4, 0, 0, 2, 1, 0, 3, 0, 22.0374, '2018-04-10 04:59:30', 'test01');
INSERT INTO `score` VALUES (543, 4, 0, 0, 3, 1, 1, 3, 1, 21.5556, '2018-04-10 04:59:03', 'test01');
INSERT INTO `score` VALUES (542, 0, 0, 0, 0, 0, 0, 1, 0, 5.22008, '2018-04-10 04:57:06', 'fieldqq');
INSERT INTO `score` VALUES (541, 0, 0, 0, 0, 0, 0, 1, 0, 5.20832, '2018-04-10 04:56:41', 'test01');
INSERT INTO `score` VALUES (540, 0, 0, 0, 1, 0, 0, 3, 1, 13.9384, '2018-04-10 04:55:46', 'test01');
INSERT INTO `score` VALUES (539, 0, 0, 0, 1, 0, 0, 3, 1, 13.9384, '2018-04-10 04:55:46', 'test01');
INSERT INTO `score` VALUES (538, 13, 1, 0, 9, 5, 2, 3, 6, 81.1498, '2018-04-10 04:52:09', 'test01');
INSERT INTO `score` VALUES (537, 3, 0, 0, 1, 1, 0, 3, 0, 10.5539, '2018-04-10 04:45:17', 'fieldqq');
INSERT INTO `score` VALUES (536, 3, 0, 0, 1, 1, 0, 3, 0, 10.5539, '2018-04-10 04:45:17', 'fieldqq');
INSERT INTO `score` VALUES (535, 18, 1, 0, 6, 6, 3, 3, 2, 62.5115, '2018-04-10 04:29:05', 'test01');
INSERT INTO `score` VALUES (534, 18, 1, 0, 6, 6, 3, 3, 2, 62.5115, '2018-04-10 04:29:05', 'test01');
