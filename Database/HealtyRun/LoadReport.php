<?php

include("Connect.php");
	
	//History
	$data_history = array();
	$all_data_history = array();
	$UserName = $_POST['Id'];
	$sql_history="SELECT Value_score, Count_hp, Count_milk, Count_miniItem, Count_bigItem, Count_time, Count_hpEnemy, Count_scoreEnemy, 
				 DATE_FORMAT(score.Date_score, '%d/%m/%Y %H:%i:%s' ) AS Date_score
		  FROM score 
		  WHERE UserName = '$UserName' 
		  ORDER BY Value_score DESC";
	$res_history = mysql_query($sql_history);
	while ($row_history = mysql_fetch_assoc($res_history)) {
		$data_history = array($row_history);
		$all_data_history = array_merge($all_data_history, $data_history);
	}

	//Top5
	$data_topfive = array();
	$all_data_topfive = array();
	$sql_topfive=" SELECT MAX(score.Value_score) as MaxScore, score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY score.UserName
	      ORDER BY MaxScore DESC
	      LIMIT 5";
	$res_topfive = mysql_query($sql_topfive);
	while ($row_topfive = mysql_fetch_assoc($res_topfive)) {
		$data_topfive = array($row_topfive);
		$all_data_topfive = array_merge($all_data_topfive, $data_topfive);
	}

	//TotalHistory
	$data_totalHistory = array();
	$all_data_totalHistory = array();
	$UserName = $_POST['Id'];
	$sql_totalHistory="SELECT COUNT(Value_score) as countScore, SUM(Value_score) as sumScore, SUM(Count_hp) as sumHP, SUM(Count_Milk) as sumMilk, SUM(Count_miniItem) as sumMiniItem, 
	             SUM(Count_bigItem) as sumBigItem, SUM(Count_time) as sumTime, SUM(Distance) as sumDistance, SUM(Count_hpEnemy) as sumHpEnemy, SUM(Count_scoreEnemy) as sumScoreEnemy
	         
		  FROM score 
		  WHERE UserName = '$UserName' 
		  ORDER BY ID_score DESC";
	$res_totalHistory = mysql_query($sql_totalHistory);
	while ($row_totalHistory = mysql_fetch_assoc($res_totalHistory)) {
		$data_totalHistory = array($row_totalHistory);
		$all_data_totalHistory = array_merge($all_data_totalHistory, $data_totalHistory);
	}

	//PlayMost
	$data_playMost = array();
	$all_data_playMost = array();
	
	$sql_playMost=" SELECT COUNT(score.Value_score) as CountScore, DATE_FORMAT(score.Date_score, '%d/%m/%Y') as DatePlay,
		       day(score.Date_score) as DayPlay, date(score.Date_score) as DateScore, 
			   score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY DateScore, score.UserName
	      ORDER BY DateScore DESC, CountScore DESC";
	$res_playMost = mysql_query($sql_playMost);
	while ($row_playMost = mysql_fetch_assoc($res_playMost)) {
		$data_playMost = array($row_playMost);
		$all_data_playMost = array_merge($all_data_playMost, $data_playMost);
	}

	//Hiscore
	$data_hiscore = array();
	$all_data_hiscore = array();
	
	$sql_hiscore=" SELECT MAX(score.Value_score) as MaxScore, DATE_FORMAT(score.Date_score, '%d/%m/%Y') as DatePlay,
		       day(score.Date_score) as DayPlay, date(score.Date_score) as DateScore, 
			   score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY DateScore, score.UserName
	      ORDER BY DateScore DESC, MaxScore DESC";
	$res_hiscore = mysql_query($sql_hiscore);
	while ($row_hiscore = mysql_fetch_assoc($res_hiscore)) {
		$data_hiscore = array($row_hiscore);
		$all_data_hiscore = array_merge($all_data_hiscore, $data_hiscore);
	}

	//AllPlayer
	$data_allPlayer = array();
	$all_data_allPlayer = array();
	$sql_allPlayer=" SELECT MAX(score.Value_score) as MaxScore, score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY score.UserName";
	$res_allPlayer = mysql_query($sql_allPlayer);
	while ($row_allPlayer = mysql_fetch_assoc($res_allPlayer)) {
		$data_allPlayer = array($row_allPlayer);
		$all_data_allPlayer = array_merge($all_data_allPlayer, $data_allPlayer);
	}

	//Distance
	$data_topfiveDistance = array();
	$all_data_topfiveDistance = array();
	$sql_topfiveDistance=" SELECT Sum(score.Distance) as sumDistance, score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY score.UserName
	      ORDER BY sumDistance DESC
	      LIMIT 5";
	$res_topfiveDistance = mysql_query($sql_topfiveDistance);
	while ($row_topfiveDistance = mysql_fetch_assoc($res_topfiveDistance)) {
		$data_topfiveDistance = array($row_topfiveDistance);
		$all_data_topfiveDistance = array_merge($all_data_topfiveDistance, $data_topfiveDistance);
	}

	$retrun["History"] = $all_data_history;
	$retrun["TopFive"] = $all_data_topfive;
	$retrun["TotalHistory"] = $all_data_totalHistory;
	$retrun["PlayMost"] = $all_data_playMost;
	$retrun["HiScore"] = $all_data_hiscore;
	$retrun["AllPlayer"] = $all_data_allPlayer;
	$retrun["TopFiveDistance"] = $all_data_topfiveDistance;
	// $retrun["TestOne"] = $all_data_testOne;

	echo json_encode($retrun);

?>