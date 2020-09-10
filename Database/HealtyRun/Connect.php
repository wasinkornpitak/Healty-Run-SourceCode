<?php
//CONNECT DATABASE
	$host = "localhost";//name host
	$user = "root"; //user
	$passwd = "123456";//password
	$dbname = "Healty Run";
	mysql_connect("$host","$user","$passwd")or die("ติดต่อ Host ไม่ได้");
	mysql_query("SET NAMES utf8"); // set กำหนดมาตราฐาน
	mysql_select_db("$dbname")or die("ติดต่อฐานข้อมูลไม่ได้"); 
?>