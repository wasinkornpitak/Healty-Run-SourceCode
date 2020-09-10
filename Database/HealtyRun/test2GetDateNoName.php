
<?php

include("Connect.php");

	//testTwo
	$data_testTwo = array();
	$all_data_testTwo = array();


if($_POST['start'] != "" && $_POST['end'] != ""){

	$start = $_POST['start'];
	$end = $_POST['end'];

	$sql_testTwo=" SELECT DATE_FORMAT(score.Date_score, '%d/%m/%Y') AS datePlay, date(score.Date_score) AS dates, day(Date_score) as dayPlay, player.UserName AS UserName, MAX(score.Value_score) AS score

	   FROM score INNER JOIN player ON score.UserName = player.UserName

	   WHERE (date(score.Date_score) BETWEEN '$start' AND '$end')

	   GROUP BY dates, UserName

	   ORDER BY dates DESC, score DESC";

}else{

	$sql_testTwo=" SELECT DATE_FORMAT(score.Date_score, '%d/%m/%Y') AS datePlay, date(score.Date_score) AS dates, day(Date_score) as dayPlay, player.UserName AS UserName, MAX(score.Value_score) AS score

	   FROM score INNER JOIN player ON score.UserName = player.UserName

	   GROUP BY dates, UserName

	   ORDER BY dates DESC, score DESC";
}

	$res_testTwo = mysql_query($sql_testTwo);
	while ($row_testTwo = mysql_fetch_assoc($res_testTwo)) {
		$data_testTwo = array($row_testTwo);
		$all_data_testTwo = array_merge($all_data_testTwo, $data_testTwo);
	}

	$retrun["TestTwo"] = $all_data_testTwo;

	echo json_encode($retrun);


?>