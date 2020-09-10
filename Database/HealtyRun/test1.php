
<?php

include("Connect.php");

	//testOne
	$data_testOne = array();
	$all_data_testOne = array();


if($_POST['start'] != "" && $_POST['end'] != ""){

	$start = $_POST['start'];
	$end = $_POST['end'];

	$sql_testOne=" SELECT DATE_FORMAT(score.Date_score, '%d/%m/%Y') AS datePlay, date(score.Date_score) AS dates, day(Date_score) as dayPlay, player.UserName AS UserName,
				  SUM(Value_score) as sumScore, SUM(Count_hp) as sumHP, SUM(Count_Milk) as sumMilk, SUM(Count_miniItem) as sumMiniItem, 
	             SUM(Count_bigItem) as sumBigItem, SUM(Count_hpEnemy) as sumHpEnemy, SUM(Count_scoreEnemy) as sumScoreEnemy

	   FROM score INNER JOIN player ON score.UserName = player.UserName

	   WHERE (date(score.Date_score) BETWEEN '$start' AND '$end')

	   GROUP BY dates, UserName

	   ORDER BY dates DESC";

}else{

	$sql_testOne=" SELECT DATE_FORMAT(score.Date_score, '%d/%m/%Y') AS datePlay, date(score.Date_score) AS dates, day(Date_score) as dayPlay, player.UserName AS UserName,
				  SUM(Value_score) as sumScore, SUM(Count_hp) as sumHP, SUM(Count_Milk) as sumMilk, SUM(Count_miniItem) as sumMiniItem, 
	             SUM(Count_bigItem) as sumBigItem, SUM(Count_hpEnemy) as sumHpEnemy, SUM(Count_scoreEnemy) as sumScoreEnemy
				 
	   FROM score INNER JOIN player ON score.UserName = player.UserName

	   GROUP BY dates, UserName

	   ORDER BY dates DESC";
}

	$res_testOne = mysql_query($sql_testOne);
	while ($row_testOne = mysql_fetch_assoc($res_testOne)) {
		$data_testOne = array($row_testOne);
		$all_data_testOne = array_merge($all_data_testOne, $data_testOne);
	}

	$retrun["TestOne"] = $all_data_testOne;

	echo json_encode($retrun);


?>